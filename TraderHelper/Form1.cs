﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TraderHelper
{
    public partial class Form1 : Form
    {
        int buttonType = 0; // 0.添加到自选股 1.从自选股移除
        int GCTimeFlow; // GC计时变量(s), 计时依赖于timer
        const int GCTime = 3;  // GC时间间隔(s), 计时依赖于timer
        const string DefaultCode = "000001";
        const string Formtitle = "Trader Helper";
        const string httpHeader = "http://hq.sinajs.cn/list=";
        const string httpImageHeader = "http://image.sinajs.cn/newchart/min/n/";
        const string stockListFilePath = @"stockList.ini";
        static readonly string[] buttonTypeText = { "添加到自选股", "从自选股移除" };        
        Timer timer = new Timer();
        
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += textBox1_KeyPress;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string code = null;
            listView1.Click += ListView1_Click;
            listView1.DoubleClick += ListView1_Click;
            listView1.HideSelection = false;

            // Get Stock List and display the first stock
            string firstStock = Get2DisplayStockList();
            if (firstStock != null)
            {
                code = firstStock;
                listView1.Items[0].Selected = true;
                listView1.Select();
            }
            else code = DefaultCode;
            textBox1.Text = code;
            Get2DisplayShareInfomation(code, true);

            GCTimeFlow = GCTime;
            // Set timer to update stock data automatically
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void ListView1_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            ListView lv = sender as ListView;
            string code =lv.SelectedItems[0].Text;
            textBox1.Text = code;
        }

        private string Get2DisplayStockList() // return first stock code
        {
            using (StreamReader streamReader = new StreamReader(stockListFilePath))
            {
                string line = streamReader.ReadLine();
                string first = line;
                Share share = null;
                while (line != null)
                {
                    share = GetShareByCode(line);
                    Add2StockList(share.shareInfo.shareUrlCode, share.shareData.shareName, "", share.shareData.currentPrice, "");
                    line = streamReader.ReadLine();
                }
                return first;
            }
        }

        private bool Get2DisplayShareInfomation(string code, bool getFully = false)
        {
            textBox2.Text = "";

            try
            {
                // Get Share Data
                Share share = GetShareByCode(code);
                string outputString = "股票名称: " + share.shareData.shareName + "\n现价:" + share.shareData.currentPrice + "\n买一: " + share.shareData.buyPrice[0] + "\n卖一:" + share.shareData.sellPrice[0] + "\n数据时间: " + share.shareData.dataTime;
                textBox2.Text = outputString.Replace("\n", Environment.NewLine + Environment.NewLine);

                // Trading-time judgement
                /// Get Hour-Minute
                System.Text.RegularExpressions.Match timePartMatch = Helper.Regexer_Ex(@"\d{2}", share.shareData.dataTime);
                /// Convert to minutes
                int currentTime = int.Parse(timePartMatch.ToString()) * 60 + int.Parse(timePartMatch.NextMatch().ToString());
                /// Reload Picture only in trading time (or in necessary cases)
                if (((currentTime >= 9*60 && currentTime<11*60+30) || (currentTime >= 13*60 && currentTime < 15*60)) || getFully)
                {
                    // Get Share real-time image
                    pictureBox1.Image = GetShareImgByCode(code);
                    System.Diagnostics.Debug.WriteLine("Picture!");
                }

                UpdateButtonType();
                button2.Enabled = true;

                return true;
            }
            catch (SystemException exception)
            {
                button2.Enabled = false;
                textBox1.ForeColor = Color.Red;
                textBox2.Text = exception.Message;
                return false;
            }
        }

        private string GetShareTypeByCode(string shareCode)
        {
            if (shareCode == DefaultCode)
                return "sh";
            return shareCode.First() == '0' ? "sz" : "sh";
        }

        private Share GetShareByCode(string shareCode)
        {
            // Get Share Data
            string shareType = GetShareTypeByCode(shareCode);
            return Share.CreateFromShareInfo(ShareInfo.Build(httpHeader, shareType, shareCode));
        }

        private Image GetShareImgByCode(string shareCode)
        {
            // Get Share real-time image 
            string shareType = GetShareTypeByCode(shareCode);
            return Helper.HttpRequestImage(httpImageHeader + shareType + shareCode + ".gif");
        }

        private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Only numbers and backspace can be entered
            if (e.KeyChar != '\b')
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))
                {
                    e.Handled = true;
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Get2DisplayShareInfomation(textBox1.Text))
                this.Text = Formtitle + " (Stock data has update: " + System.DateTime.Now.ToLongDateString() + " " + System.DateTime.Now.ToLongTimeString() + " )";
            else
                this.Text = Formtitle + " (Request Error!)";
            if(--GCTimeFlow<0)
            {
                GC.Collect();
                GCTimeFlow = GCTime;
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.TextLength == 6)
            {
                string code = textBox1.Text;
                UpdateButtonType();
                textBox1.ForeColor = Color.Black;
                Get2DisplayShareInfomation(code, true);
            }
            else
            {
                button2.Enabled = false;
                textBox1.ForeColor = Color.Red;
            }
        }

        private int UpdateButtonType()
        {
            string code = textBox1.Text;

            if (Helper.isStockCodeExistList(code, stockListFilePath))   buttonType = 1;
            else buttonType = 0;

            button2.Text = buttonTypeText[buttonType];

            return buttonType;
        }

        private void Add2StockList(string stockCode, string stockName, string stockPriceUp, string stockPriceCurrent, string stockPriceDown)
        {
            ListViewItem lvi_1 = new ListViewItem(stockCode);
            lvi_1.SubItems.Add(stockName);
            lvi_1.SubItems.Add(stockPriceUp);
            lvi_1.SubItems.Add(stockPriceCurrent);
            lvi_1.SubItems.Add(stockPriceDown);

            listView1.Items.AddRange(new ListViewItem[] { lvi_1 });
        }

        private void UpdateStockList(bool write = false)
        {
            if(write)
            {
                string output = "";
                foreach (ListViewItem item in listView1.Items) output += item.Text + Environment.NewLine;
                using (StreamWriter streamWriter = new StreamWriter(stockListFilePath, false))
                {
                    streamWriter.Write(output);
                }
                return;
            }
            listView1.Items.Clear();
            Get2DisplayStockList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tarCode = textBox1.Text;
            if(buttonType == 0) // Add to list
            {
                if (Helper.isStockCodeExistList(tarCode, stockListFilePath)) return;

                using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(stockListFilePath, true))
                {
                    streamWriter.WriteLine(textBox1.Text);
                }
                UpdateStockList();
                UpdateButtonType();
            }
            else if(buttonType == 1) // Remove from list
            {
                // Comfirm dialog
                DialogResult result =  MessageBox.Show("移除自选股后，该股票的预警设置也将被丢弃，是否确认删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.ToString() != "Yes") return;

                foreach (ListViewItem item in listView1.Items)
                {
                    if(item.Text == tarCode)
                    {
                        listView1.Items[item.Index].Remove();
                        UpdateStockList(true);
                        UpdateButtonType();
                        break;
                    }
                }
            }
        }
    }
}

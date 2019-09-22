using System;
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
        const string stockUpDownPriceDirectoryPath = @"stocksConfig";
        int currentIndex = -1;
        const int subitemIndex_UpPrice = 2;
        const int subitemIndex_CurrentPrice = 3;
        const int subitemIndex_DownPrice = 4;
        static readonly string[] buttonTypeText = { "添加到自选股", "从自选股移除" };        
        Timer timer = new Timer();
        
        public Form1()
        {
            // 固定边框, 禁用标题栏最大化按钮
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            InitializeComponent();
            textBox_StockCode.KeyPress += textBox1_KeyPress;
            textBox_PriceSettingUp.KeyPress += priceInput_KeyPress;
            textBox_PriceSettingDown.KeyPress += priceInput_KeyPress;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string code = null;

            // Infomation panal initialize
            // Get Stock List and display the first stock
            string firstStock = Get2DisplayStockList();
            if (firstStock != null)
            {
                code = firstStock;
                listView_StockList.Items[0].Selected = true;
                listView_StockList.Select();
            }
            else code = DefaultCode;
            textBox_StockCode.Text = code;

            // Listview initialize
            if (!Directory.Exists(stockUpDownPriceDirectoryPath))
                Directory.CreateDirectory(stockUpDownPriceDirectoryPath);
            listView_StockList.Click += ListView1_Click;
            listView_StockList.DoubleClick += ListView1_Click;
            listView_StockList.HideSelection = false;
            UpdatePriceSetting();

            // Display Data
            Get2DisplayShareInfomationByCode(code, true);

            // GC Time initialize
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
            textBox_StockCode.Text = code;
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

        private bool Get2DisplayShareInfomationByCode(string code, bool getFully = false)
        {
            textBox_StockInformation.Text = "";

            try
            {
                // Get Share Data
                Share share = GetShareByCode(code);

                // Update Information Panal Text
                string outputString = "股票名称: " + share.shareData.shareName + "\n现价:" + share.shareData.currentPrice + "\n买一: " + share.shareData.buyPrice[0] + "\n卖一:" + share.shareData.sellPrice[0] + "\n数据时间: " + share.shareData.dataTime;
                textBox_StockInformation.Text = outputString.Replace("\n", Environment.NewLine + Environment.NewLine);

                // Update Up/Down Price panal current price / down price / up price               
                ListViewItem lvi = listView_StockList.FindItemWithText(code);
                if (lvi != null)
                {
                    UpDownPriceConfigPanal.Enabled = true;
                    textBox_PriceSettingCurrent.Text = share.shareData.currentPrice;
                    if (getFully)
                    {
                        textBox_PriceSettingUp.Text = lvi.SubItems[subitemIndex_UpPrice].Text;
                        textBox_PriceSettingDown.Text = lvi.SubItems[subitemIndex_DownPrice].Text;
                    }
                    currentIndex = lvi.Index;
                }
                else UpDownPriceConfigPanal.Enabled = false;


                // Trading-time judgement
                /// Get Hour-Minute
                System.Text.RegularExpressions.Match timePartMatch = Helper.Regexer_Ex(@"\d{2}", share.shareData.dataTime);
                /// Convert to minutes
                int currentTime = int.Parse(timePartMatch.ToString()) * 60 + int.Parse(timePartMatch.NextMatch().ToString());
                /// Reload Picture only in trading time (or in necessary cases)
                if (((currentTime >= 9*60 && currentTime<11*60+30) || (currentTime >= 13*60 && currentTime < 15*60)) || getFully)
                {
                    // Get Share real-time image
                    pictureBox_StockImage.Image = GetShareImgByCode(code);
                    System.Diagnostics.Debug.WriteLine("Picture!");
                }

                UpdateButtonType();
                UpDownPriceConfigPanal.Enabled = true;
                button_StockListItemOperate.Enabled = true;

                return true;
            }
            catch (SystemException exception)
            {
                UpDownPriceConfigPanal.Enabled = false;
                button_StockListItemOperate.Enabled = false;
                textBox_StockCode.ForeColor = Color.Red;
                textBox_StockInformation.Text = exception.Message;
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

        private void priceInput_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Only numbers redix point and backspace can be entered (and redix point can only be entered once)
            TextBox textbox = sender as TextBox;
            if (e.KeyChar != '\b' && (e.KeyChar != '.' || textbox.Text.IndexOf(".") != -1))
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))
                {
                    e.Handled = true;
                }
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update stock list current price information
            Share share = null;
            foreach (ListViewItem lvi in listView_StockList.Items)
            {
                share = GetShareByCode(lvi.Text);
                lvi.SubItems[subitemIndex_CurrentPrice].Text = share.shareData.currentPrice;
            }
            
            // Update Infomation Panal
            if (Get2DisplayShareInfomationByCode(textBox_StockCode.Text))
                this.Text = Formtitle + " (Stock data has update: " + System.DateTime.Now.ToLongDateString() + " " + System.DateTime.Now.ToLongTimeString() + " )";
            else
            { 
                this.Text = Formtitle + " (Request Error!)";
                pictureBox_StockImage.Image = null;
            }
            if (--GCTimeFlow<0)
            {
                GC.Collect();
                GCTimeFlow = GCTime;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox_StockCode.TextLength == 6)
            {
                string code = textBox_StockCode.Text;
                UpdateButtonType();
                textBox_StockCode.ForeColor = Color.Black;
                UpDownPriceConfigPanal.Enabled = Get2DisplayShareInfomationByCode(code, true);
            }
            else
            {
                UpDownPriceConfigPanal.Enabled = false;
                button_StockListItemOperate.Enabled = false;
                textBox_StockCode.ForeColor = Color.Red;
            }
        }

        private int UpdateButtonType()
        {
            string code = textBox_StockCode.Text;

            if (Helper.isStockCodeExistList(code, stockListFilePath))   buttonType = 1;
            else buttonType = 0;

            button_StockListItemOperate.Text = buttonTypeText[buttonType];

            return buttonType;
        }

        private void Add2StockList(string stockCode, string stockName, string stockPriceUp, string stockPriceCurrent, string stockPriceDown)
        {
            ListViewItem lvi_1 = new ListViewItem(stockCode);
            lvi_1.SubItems.Add(stockName);
            lvi_1.SubItems.Add(stockPriceUp);
            lvi_1.SubItems.Add(stockPriceCurrent);
            lvi_1.SubItems.Add(stockPriceDown);

            listView_StockList.Items.AddRange(new ListViewItem[] { lvi_1 });
        }

        private void UpdateStockList(bool write = false)
        {
            if(write)
            {
                string output = "";
                foreach (ListViewItem item in listView_StockList.Items) output += item.Text + Environment.NewLine;
                using (StreamWriter streamWriter = new StreamWriter(stockListFilePath, false))
                {
                    streamWriter.Write(output);
                }
                return;
            }
            listView_StockList.Items.Clear();
            Get2DisplayStockList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string tarCode = textBox_StockCode.Text;
            if(buttonType == 0) // Add to list
            {
                if (Helper.isStockCodeExistList(tarCode, stockListFilePath)) return;

                using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(stockListFilePath, true))
                {
                    streamWriter.WriteLine(textBox_StockCode.Text);
                }
                UpdateStockList();
                UpdateButtonType();
            }
            else if(buttonType == 1) // Remove from list
            {
                // Comfirm dialog
                DialogResult result =  MessageBox.Show("移除自选股后，该股票的预警设置也将被丢弃，是否确认删除？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.ToString() != "Yes") return;

                foreach (ListViewItem item in listView_StockList.Items)
                {
                    if(item.Text == tarCode)
                    {
                        listView_StockList.Items[item.Index].Remove();
                        UpdateStockList(true);
                        UpdateButtonType();
                        break;
                    }
                }
            }
        }

        private void UpdatePriceSetting(bool write = false)
        {
            // throw new NotImplementedException();

            if(write)
            {
                string output = "";
                if (!Directory.Exists(stockUpDownPriceDirectoryPath))
                    Directory.CreateDirectory(stockUpDownPriceDirectoryPath);
                foreach (ListViewItem lvi in listView_StockList.Items)
                {
                    output = "";
                    output += lvi.SubItems[subitemIndex_UpPrice] + Environment.NewLine;
                    output += lvi.SubItems[subitemIndex_DownPrice] + Environment.NewLine;
                    string code = lvi.Text;
                    using (StreamWriter streamWriter = new StreamWriter(stockUpDownPriceDirectoryPath + @"\" + code))
                    {
                        streamWriter.Write(output);
                    }
                }
                return;
            }
            foreach(ListViewItem lvi in listView_StockList.Items)
            {
                string code = lvi.Text;
                string filePath = stockUpDownPriceDirectoryPath + @"\" + code;
                if (!File.Exists(filePath))
                    continue;
                using (StreamReader stremReader = new StreamReader(filePath))
                {
                    System.Text.RegularExpressions.Match result = Helper.Regexer_Ex("(?<={).+(?=})", stremReader.ReadToEnd());
                    string upPrice = result.Value.ToString();
                    string downPrice = result.NextMatch().ToString();
                    lvi.SubItems[subitemIndex_UpPrice].Text = upPrice;
                    lvi.SubItems[subitemIndex_DownPrice].Text = downPrice;
                }
            }
        }

        private void button_PriceSettingConfirm_Click(object sender, EventArgs e)
        {
            int index = currentIndex;
            string code = listView_StockList.Items[index].Text;
            Share share = GetShareByCode(code);
            string currentPrice = share.shareData.currentPrice;
            string upPrice = textBox_PriceSettingUp.Text;
            string downPrice = textBox_PriceSettingDown.Text;
            if (upPrice == "" || downPrice == "" || float.Parse(upPrice) <= float.Parse(currentPrice) || float.Parse(downPrice) >= float.Parse(currentPrice))
            {
                MessageBox.Show("上破价或下破价设置有误，请检查修改后再确认设置。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            listView_StockList.Items[index].SubItems[subitemIndex_UpPrice].Text = upPrice;
            listView_StockList.Items[index].SubItems[subitemIndex_DownPrice].Text = downPrice;

            // save to file (Implement later)
            UpdatePriceSetting(true);
        }

        private void textBox_PriceSetting_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = sender as TextBox;
            float currentPrice = float.Parse(textBox_PriceSettingCurrent.Text);
            float price = textbox.Text == "" ? 0f :float.Parse(textbox.Text);
            if (textbox.Tag.ToString() == "up")
            {
                if (price <= currentPrice)
                    textbox.ForeColor = Color.FromArgb(255, 0, 0);
                else
                    textbox.ForeColor = Color.Black;
            }
            else if (textbox.Tag.ToString() == "down")
            {
                if (price >= currentPrice)
                    textbox.ForeColor = Color.FromArgb(255, 0, 0);
                else
                    textbox.ForeColor = Color.Black;
            }
        }
    }
}

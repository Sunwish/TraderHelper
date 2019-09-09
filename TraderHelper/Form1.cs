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
        const string Formtitle = "Trader Helper";
        Timer timer = new Timer();
        
        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += textBox1_KeyPress;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Get2DisplayShareInfomation(textBox1.Text);

            // Set timer to update stock data automatically
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private bool Get2DisplayShareInfomation(string code)
        {
            textBox2.Text = "";
            pictureBox1.Image = null;

            try
            {
                // Get Share Data
                string httpHeader = "http://hq.sinajs.cn/list=";
                string shareCode = code;
                string shareType = shareCode.First() == '0' ? "sz" : "sh";

                Share share = Share.CreateFromShareInfo(ShareInfo.Build(httpHeader, shareType, shareCode));
                string outputString = "股票名称: " + share.shareData.shareName + "\n现价:" + share.shareData.currentPrice + "\n买一: " + share.shareData.buyPrice[0] + "\n卖一:" + share.shareData.sellPrice[0] + "\n数据时间: " + share.shareData.dataTime;
                textBox2.Text = outputString.Replace("\n", Environment.NewLine + Environment.NewLine);

                // Get Share real-time image
                string httpImageHeader = "http://image.sinajs.cn/newchart/min/n/";
                pictureBox1.Image = Helper.HttpRequestImage(httpImageHeader + shareType + shareCode + ".gif");

                return true;
            }
            catch (SystemException exception)
            {
                textBox1.ForeColor = Color.Red;
                textBox2.Text = exception.Message;
                return false;
            }
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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.TextLength == 6)
            {
                textBox1.ForeColor = Color.Black;
                Get2DisplayShareInfomation(textBox1.Text);
            }
            else
            {
                textBox1.ForeColor = Color.Red;
            }

        }
    }
}

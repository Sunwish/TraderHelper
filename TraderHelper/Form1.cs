using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace TraderHelper
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            textBox1.KeyPress += textBox1_KeyPress;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string httpHeader = "http://hq.sinajs.cn/list=";
            string shareCode = textBox1.Text;
            string shareType = shareCode.First() == '0' ? "sz" : "sh";

            try
            {
                Share share = Share.CreateFromShareInfo(ShareInfo.Build(httpHeader, shareType, shareCode));
                string outputString = "股票名称: " + share.shareData.shareName + "\n现价:" + share.shareData.currentPrice + "\n买一: " + share.shareData.buyPrice[0] + "\n卖一:" + share.shareData.sellPrice[0] + "\n数据时间: " + share.shareData.dataTime;
                textBox2.Text = outputString.Replace("\n", Environment.NewLine);             
            }
            catch(SystemException exception)
            {
                textBox2.Text = exception.Message;
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

    }
}

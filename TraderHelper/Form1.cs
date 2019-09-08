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

            // Get http response
            string requestURL = MakeShareResponseURL(httpHeader, shareType, shareCode);
            string httpResponse;
            httpResponse = HttpResponse(requestURL, "GB2312");

            // Gain infomation
            string reg1 = Regexer(@"(?<=.+=.).+(?=,)", httpResponse);
            string[] shareParams = reg1.Split(',');
            string paramList = String.Join("-", shareParams);

            if (paramList != "")
                textBox2.Text = paramList;
            else
                textBox2.Text = "信息获取错误";
        }

        private string MakeShareResponseURL(string urlHeader, string shareType, string shareCode)
        {
            return urlHeader + shareType + shareCode;
        }

        private string HttpResponse(string url, string encoding)
        {
            HttpWebRequest httpRequst = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse httpResponse = httpRequst.GetResponse() as HttpWebResponse;

            System.IO.Stream httpStream = httpResponse.GetResponseStream();
            System.IO.StreamReader streamReader = new System.IO.StreamReader(httpStream, Encoding.GetEncoding(encoding));

            return streamReader.ReadToEnd();
        }
        
        private string Regexer(string regex, string source)
        {
            Regex reg = new Regex(regex);
            Match match = reg.Match(source);
            return match.ToString();
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

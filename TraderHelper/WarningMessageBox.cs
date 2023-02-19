using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Collections;
using TraderHelper.common;
using System.CodeDom;

namespace TraderHelper
{
    partial class WarningMessageBox : Form
    {
        SecuritiesData bindSecuritiesObject;
        static ArrayList bindCode = new ArrayList();
        string warningPrice;
        int warningType;
        Form1 mainWindow;
        public WarningMessageBox(SecuritiesData securitiesObject, int warningType/* 0.UpWarning, 1.DownWarning, 2.Exception */, string warningPrice, Form1 mainWindow)
        {
            // Add share to bind list
            bindCode.Add(securitiesObject.code);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.TopMost = true;
            this.bindSecuritiesObject = securitiesObject;
            this.warningPrice = warningPrice;
            this.warningType = warningType;
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void WarningMessageBox_Load(object sender, EventArgs e)
        {
            label_WarningText.Text = "[" + bindSecuritiesObject.code + "] " + bindSecuritiesObject.name + " 触发" + (warningType == 0 ? "上" : "下") + "破价格 " + warningPrice + "，现价 " + bindSecuritiesObject.price;
            if (warningType == 0)
                label_WarningText.ForeColor = Color.Red;
            else if (warningType == 1)
                label_WarningText.ForeColor = Color.Green;
            else if (warningType == 2)
            {
                label_WarningText.ForeColor = Color.Red;
                this.Text = "程序异常";
                label_WarningText.Text = "数据获取失败";
            }
        }

        private void WarningMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Remove share from bind list
            bindCode.Remove(bindSecuritiesObject.code);
        }

        public static bool isSecuritiesObjectBind(SecuritiesData data)
        {
            return bindCode.IndexOf(data.code) != -1;
        }

        public static int getBindCount()
        {
            return bindCode.Count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainWindow.WakeUp();
        }
    }
}

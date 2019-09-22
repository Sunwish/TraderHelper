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

namespace TraderHelper
{
    partial class WarningMessageBox : Form
    {
        Share bindShare;
        static ArrayList bindCode = new ArrayList();
        string warningPrice;
        int warningType;
        Form1 mainWindow;
        public WarningMessageBox(Share bindShare, int warningType/* 0.UpWarning, 1.DownWarning */, string warningPrice, Form1 mainWindow)
        {
            // Add share to bind list
            bindCode.Add(bindShare.shareInfo.shareUrlCode);

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.TopMost = true;
            this.bindShare = bindShare;
            this.warningPrice = warningPrice;
            this.warningType = warningType;
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private void WarningMessageBox_Load(object sender, EventArgs e)
        {
            label_WarningText.Text = "[" + bindShare.shareInfo.shareUrlCode + "] " + bindShare.shareData.shareName + " 触发" + (warningType == 0 ? "上" : "下") + "破价格 " + warningPrice + "，现价 " + bindShare.shareData.currentPrice;
            if (warningType == 0)
                label_WarningText.ForeColor = Color.Red;
            else
                label_WarningText.ForeColor = Color.Green;
        }

        private void WarningMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Remove share from bind list
            bindCode.Remove(bindShare.shareInfo.shareUrlCode);
        }

        public static bool isShareBind(Share share)
        {
            return bindCode.IndexOf(share.shareInfo.shareUrlCode) != -1;
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

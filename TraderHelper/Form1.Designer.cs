namespace TraderHelper
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox_StockCode = new System.Windows.Forms.TextBox();
            this.textBox_StockInformation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_StockImage = new System.Windows.Forms.PictureBox();
            this.listView_StockList = new System.Windows.Forms.ListView();
            this.StockCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StockName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PriceUp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PriceCurrent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PriceDown = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_StockListItemOperate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_PriceSettingUp = new System.Windows.Forms.TextBox();
            this.textBox_PriceSettingDown = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_PriceSettingCurrent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_PriceSettingConfirm = new System.Windows.Forms.Button();
            this.DivideLine = new System.Windows.Forms.GroupBox();
            this.UpDownPriceConfigPanal = new System.Windows.Forms.Panel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.wechatNotify = new System.Windows.Forms.CheckBox();
            this.pushdeerNotify = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dataSourceComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_StockImage)).BeginInit();
            this.UpDownPriceConfigPanal.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_StockCode
            // 
            this.textBox_StockCode.Location = new System.Drawing.Point(966, 43);
            this.textBox_StockCode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_StockCode.Name = "textBox_StockCode";
            this.textBox_StockCode.Size = new System.Drawing.Size(188, 35);
            this.textBox_StockCode.TabIndex = 0;
            this.textBox_StockCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_StockCode.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_StockInformation
            // 
            this.textBox_StockInformation.BackColor = System.Drawing.Color.White;
            this.textBox_StockInformation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_StockInformation.Location = new System.Drawing.Point(860, 174);
            this.textBox_StockInformation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_StockInformation.Multiline = true;
            this.textBox_StockInformation.Name = "textBox_StockInformation";
            this.textBox_StockInformation.ReadOnly = true;
            this.textBox_StockInformation.Size = new System.Drawing.Size(398, 175);
            this.textBox_StockInformation.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(854, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "股票代码";
            // 
            // pictureBox_StockImage
            // 
            this.pictureBox_StockImage.BackColor = System.Drawing.Color.White;
            this.pictureBox_StockImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_StockImage.Location = new System.Drawing.Point(14, 40);
            this.pictureBox_StockImage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_StockImage.Name = "pictureBox_StockImage";
            this.pictureBox_StockImage.Size = new System.Drawing.Size(816, 486);
            this.pictureBox_StockImage.TabIndex = 4;
            this.pictureBox_StockImage.TabStop = false;
            // 
            // listView_StockList
            // 
            this.listView_StockList.AllowColumnReorder = true;
            this.listView_StockList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.StockCode,
            this.StockName,
            this.PriceUp,
            this.PriceCurrent,
            this.PriceDown});
            this.listView_StockList.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView_StockList.FullRowSelect = true;
            this.listView_StockList.HideSelection = false;
            this.listView_StockList.Location = new System.Drawing.Point(50, 536);
            this.listView_StockList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.listView_StockList.MultiSelect = false;
            this.listView_StockList.Name = "listView_StockList";
            this.listView_StockList.Size = new System.Drawing.Size(703, 257);
            this.listView_StockList.TabIndex = 5;
            this.listView_StockList.UseCompatibleStateImageBehavior = false;
            this.listView_StockList.View = System.Windows.Forms.View.Details;
            // 
            // StockCode
            // 
            this.StockCode.Text = " 代码";
            // 
            // StockName
            // 
            this.StockName.Text = "股票名称";
            this.StockName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.StockName.Width = 100;
            // 
            // PriceUp
            // 
            this.PriceUp.Text = "上破价";
            this.PriceUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PriceUp.Width = 94;
            // 
            // PriceCurrent
            // 
            this.PriceCurrent.Text = "现价";
            this.PriceCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PriceCurrent.Width = 94;
            // 
            // PriceDown
            // 
            this.PriceDown.Text = "下破价";
            this.PriceDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PriceDown.Width = 94;
            // 
            // button_StockListItemOperate
            // 
            this.button_StockListItemOperate.Location = new System.Drawing.Point(860, 402);
            this.button_StockListItemOperate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_StockListItemOperate.Name = "button_StockListItemOperate";
            this.button_StockListItemOperate.Size = new System.Drawing.Size(297, 67);
            this.button_StockListItemOperate.TabIndex = 7;
            this.button_StockListItemOperate.Text = "添加到自选股";
            this.button_StockListItemOperate.UseVisualStyleBackColor = true;
            this.button_StockListItemOperate.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(20, 94);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 31);
            this.label2.TabIndex = 8;
            this.label2.Text = "上破价";
            // 
            // textBox_PriceSettingUp
            // 
            this.textBox_PriceSettingUp.Location = new System.Drawing.Point(110, 88);
            this.textBox_PriceSettingUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_PriceSettingUp.Name = "textBox_PriceSettingUp";
            this.textBox_PriceSettingUp.Size = new System.Drawing.Size(254, 35);
            this.textBox_PriceSettingUp.TabIndex = 9;
            this.textBox_PriceSettingUp.Tag = "up";
            this.textBox_PriceSettingUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PriceSettingUp.TextChanged += new System.EventHandler(this.textBox_PriceSetting_TextChanged);
            // 
            // textBox_PriceSettingDown
            // 
            this.textBox_PriceSettingDown.Location = new System.Drawing.Point(110, 154);
            this.textBox_PriceSettingDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_PriceSettingDown.Name = "textBox_PriceSettingDown";
            this.textBox_PriceSettingDown.Size = new System.Drawing.Size(254, 35);
            this.textBox_PriceSettingDown.TabIndex = 11;
            this.textBox_PriceSettingDown.Tag = "down";
            this.textBox_PriceSettingDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_PriceSettingDown.TextChanged += new System.EventHandler(this.textBox_PriceSetting_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(20, 160);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 31);
            this.label3.TabIndex = 10;
            this.label3.Text = "下破价";
            // 
            // textBox_PriceSettingCurrent
            // 
            this.textBox_PriceSettingCurrent.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.textBox_PriceSettingCurrent.Enabled = false;
            this.textBox_PriceSettingCurrent.Location = new System.Drawing.Point(110, 24);
            this.textBox_PriceSettingCurrent.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox_PriceSettingCurrent.Name = "textBox_PriceSettingCurrent";
            this.textBox_PriceSettingCurrent.Size = new System.Drawing.Size(254, 35);
            this.textBox_PriceSettingCurrent.TabIndex = 13;
            this.textBox_PriceSettingCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(32, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 31);
            this.label4.TabIndex = 12;
            this.label4.Text = "现价";
            // 
            // button_PriceSettingConfirm
            // 
            this.button_PriceSettingConfirm.Location = new System.Drawing.Point(26, 216);
            this.button_PriceSettingConfirm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button_PriceSettingConfirm.Name = "button_PriceSettingConfirm";
            this.button_PriceSettingConfirm.Size = new System.Drawing.Size(340, 67);
            this.button_PriceSettingConfirm.TabIndex = 14;
            this.button_PriceSettingConfirm.Text = "确认设置";
            this.button_PriceSettingConfirm.UseVisualStyleBackColor = true;
            this.button_PriceSettingConfirm.Click += new System.EventHandler(this.button_PriceSettingConfirm_Click);
            // 
            // DivideLine
            // 
            this.DivideLine.Location = new System.Drawing.Point(790, 482);
            this.DivideLine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DivideLine.Name = "DivideLine";
            this.DivideLine.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DivideLine.Size = new System.Drawing.Size(366, 16);
            this.DivideLine.TabIndex = 15;
            this.DivideLine.TabStop = false;
            // 
            // UpDownPriceConfigPanal
            // 
            this.UpDownPriceConfigPanal.Controls.Add(this.label4);
            this.UpDownPriceConfigPanal.Controls.Add(this.button_PriceSettingConfirm);
            this.UpDownPriceConfigPanal.Controls.Add(this.label2);
            this.UpDownPriceConfigPanal.Controls.Add(this.textBox_PriceSettingCurrent);
            this.UpDownPriceConfigPanal.Controls.Add(this.textBox_PriceSettingUp);
            this.UpDownPriceConfigPanal.Controls.Add(this.label3);
            this.UpDownPriceConfigPanal.Controls.Add(this.textBox_PriceSettingDown);
            this.UpDownPriceConfigPanal.Location = new System.Drawing.Point(790, 510);
            this.UpDownPriceConfigPanal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UpDownPriceConfigPanal.Name = "UpDownPriceConfigPanal";
            this.UpDownPriceConfigPanal.Size = new System.Drawing.Size(410, 302);
            this.UpDownPriceConfigPanal.TabIndex = 16;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "当前无预警触发";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // wechatNotify
            // 
            this.wechatNotify.AutoSize = true;
            this.wechatNotify.Location = new System.Drawing.Point(860, 355);
            this.wechatNotify.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wechatNotify.Name = "wechatNotify";
            this.wechatNotify.Size = new System.Drawing.Size(138, 28);
            this.wechatNotify.TabIndex = 17;
            this.wechatNotify.Text = "微信提醒";
            this.wechatNotify.UseVisualStyleBackColor = true;
            this.wechatNotify.Click += new System.EventHandler(this.wechatNotify_Click);
            // 
            // pushdeerNotify
            // 
            this.pushdeerNotify.AutoSize = true;
            this.pushdeerNotify.Location = new System.Drawing.Point(1004, 355);
            this.pushdeerNotify.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pushdeerNotify.Name = "pushdeerNotify";
            this.pushdeerNotify.Size = new System.Drawing.Size(138, 28);
            this.pushdeerNotify.TabIndex = 18;
            this.pushdeerNotify.Text = "PushDeer";
            this.pushdeerNotify.UseVisualStyleBackColor = true;
            this.pushdeerNotify.CheckedChanged += new System.EventHandler(this.pushdeerNotify_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(854, 106);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 31);
            this.label5.TabIndex = 19;
            this.label5.Text = "数据来源";
            // 
            // dataSourceComboBox
            // 
            this.dataSourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataSourceComboBox.FormattingEnabled = true;
            this.dataSourceComboBox.Items.AddRange(new object[] {
            "腾讯财经",
            "新浪财经",
            "东方财经"});
            this.dataSourceComboBox.Location = new System.Drawing.Point(966, 106);
            this.dataSourceComboBox.Name = "dataSourceComboBox";
            this.dataSourceComboBox.Size = new System.Drawing.Size(188, 32);
            this.dataSourceComboBox.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1240, 832);
            this.Controls.Add(this.dataSourceComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pushdeerNotify);
            this.Controls.Add(this.wechatNotify);
            this.Controls.Add(this.DivideLine);
            this.Controls.Add(this.button_StockListItemOperate);
            this.Controls.Add(this.listView_StockList);
            this.Controls.Add(this.pictureBox_StockImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_StockInformation);
            this.Controls.Add(this.textBox_StockCode);
            this.Controls.Add(this.UpDownPriceConfigPanal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Trader Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_StockImage)).EndInit();
            this.UpDownPriceConfigPanal.ResumeLayout(false);
            this.UpDownPriceConfigPanal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_StockCode;
        private System.Windows.Forms.TextBox textBox_StockInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_StockImage;
        private System.Windows.Forms.ListView listView_StockList;
        private System.Windows.Forms.ColumnHeader StockName;
        private System.Windows.Forms.ColumnHeader PriceUp;
        private System.Windows.Forms.ColumnHeader PriceCurrent;
        private System.Windows.Forms.ColumnHeader StockCode;
        private System.Windows.Forms.ColumnHeader PriceDown;
        private System.Windows.Forms.Button button_StockListItemOperate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_PriceSettingUp;
        private System.Windows.Forms.TextBox textBox_PriceSettingDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_PriceSettingCurrent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_PriceSettingConfirm;
        private System.Windows.Forms.GroupBox DivideLine;
        private System.Windows.Forms.Panel UpDownPriceConfigPanal;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckBox wechatNotify;
        private System.Windows.Forms.CheckBox pushdeerNotify;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox dataSourceComboBox;
    }
}


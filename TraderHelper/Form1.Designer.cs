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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_StockImage)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_StockCode
            // 
            this.textBox_StockCode.Location = new System.Drawing.Point(644, 27);
            this.textBox_StockCode.Name = "textBox_StockCode";
            this.textBox_StockCode.Size = new System.Drawing.Size(114, 25);
            this.textBox_StockCode.TabIndex = 0;
            this.textBox_StockCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_StockCode.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_StockInformation
            // 
            this.textBox_StockInformation.BackColor = System.Drawing.Color.White;
            this.textBox_StockInformation.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_StockInformation.Location = new System.Drawing.Point(573, 70);
            this.textBox_StockInformation.Multiline = true;
            this.textBox_StockInformation.Name = "textBox_StockInformation";
            this.textBox_StockInformation.ReadOnly = true;
            this.textBox_StockInformation.Size = new System.Drawing.Size(180, 148);
            this.textBox_StockInformation.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(569, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "股票代码";
            // 
            // pictureBox_StockImage
            // 
            this.pictureBox_StockImage.BackColor = System.Drawing.Color.White;
            this.pictureBox_StockImage.Location = new System.Drawing.Point(9, 25);
            this.pictureBox_StockImage.Name = "pictureBox_StockImage";
            this.pictureBox_StockImage.Size = new System.Drawing.Size(544, 304);
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
            this.listView_StockList.Location = new System.Drawing.Point(33, 335);
            this.listView_StockList.MultiSelect = false;
            this.listView_StockList.Name = "listView_StockList";
            this.listView_StockList.Size = new System.Drawing.Size(470, 162);
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
            this.button_StockListItemOperate.Location = new System.Drawing.Point(545, 224);
            this.button_StockListItemOperate.Name = "button_StockListItemOperate";
            this.button_StockListItemOperate.Size = new System.Drawing.Size(208, 42);
            this.button_StockListItemOperate.TabIndex = 7;
            this.button_StockListItemOperate.Text = "添加到自选股";
            this.button_StockListItemOperate.UseVisualStyleBackColor = true;
            this.button_StockListItemOperate.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(541, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 8;
            this.label2.Text = "上破价";
            // 
            // textBox_PriceSettingUp
            // 
            this.textBox_PriceSettingUp.Location = new System.Drawing.Point(601, 375);
            this.textBox_PriceSettingUp.Name = "textBox_PriceSettingUp";
            this.textBox_PriceSettingUp.Size = new System.Drawing.Size(152, 25);
            this.textBox_PriceSettingUp.TabIndex = 9;
            this.textBox_PriceSettingUp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_PriceSettingDown
            // 
            this.textBox_PriceSettingDown.Location = new System.Drawing.Point(601, 416);
            this.textBox_PriceSettingDown.Name = "textBox_PriceSettingDown";
            this.textBox_PriceSettingDown.Size = new System.Drawing.Size(152, 25);
            this.textBox_PriceSettingDown.TabIndex = 11;
            this.textBox_PriceSettingDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(541, 420);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 19);
            this.label3.TabIndex = 10;
            this.label3.Text = "下破价";
            // 
            // textBox_PriceSettingCurrent
            // 
            this.textBox_PriceSettingCurrent.AccessibleRole = System.Windows.Forms.AccessibleRole.PageTabList;
            this.textBox_PriceSettingCurrent.Enabled = false;
            this.textBox_PriceSettingCurrent.Location = new System.Drawing.Point(601, 335);
            this.textBox_PriceSettingCurrent.Name = "textBox_PriceSettingCurrent";
            this.textBox_PriceSettingCurrent.Size = new System.Drawing.Size(152, 25);
            this.textBox_PriceSettingCurrent.TabIndex = 13;
            this.textBox_PriceSettingCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(549, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "现价";
            // 
            // button_PriceSettingConfirm
            // 
            this.button_PriceSettingConfirm.Location = new System.Drawing.Point(545, 455);
            this.button_PriceSettingConfirm.Name = "button_PriceSettingConfirm";
            this.button_PriceSettingConfirm.Size = new System.Drawing.Size(208, 42);
            this.button_PriceSettingConfirm.TabIndex = 14;
            this.button_PriceSettingConfirm.Text = "确认设置";
            this.button_PriceSettingConfirm.UseVisualStyleBackColor = true;
            this.button_PriceSettingConfirm.Click += new System.EventHandler(this.button_PriceSettingConfirm_Click);
            // 
            // DivideLine
            // 
            this.DivideLine.Location = new System.Drawing.Point(527, 295);
            this.DivideLine.Name = "DivideLine";
            this.DivideLine.Size = new System.Drawing.Size(244, 10);
            this.DivideLine.TabIndex = 15;
            this.DivideLine.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(786, 520);
            this.Controls.Add(this.DivideLine);
            this.Controls.Add(this.button_PriceSettingConfirm);
            this.Controls.Add(this.textBox_PriceSettingCurrent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_PriceSettingDown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_PriceSettingUp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_StockListItemOperate);
            this.Controls.Add(this.listView_StockList);
            this.Controls.Add(this.pictureBox_StockImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_StockInformation);
            this.Controls.Add(this.textBox_StockCode);
            this.Name = "Form1";
            this.Text = "Trader Helper";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_StockImage)).EndInit();
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
    }
}


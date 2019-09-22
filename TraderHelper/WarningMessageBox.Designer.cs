namespace TraderHelper
{
    partial class WarningMessageBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_WarningText = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_WarningText
            // 
            this.label_WarningText.AutoSize = true;
            this.label_WarningText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.label_WarningText.Location = new System.Drawing.Point(12, 45);
            this.label_WarningText.Name = "label_WarningText";
            this.label_WarningText.Size = new System.Drawing.Size(0, 20);
            this.label_WarningText.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(418, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "打开主界面";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(-12, 101);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(587, 69);
            this.panel1.TabIndex = 3;
            // 
            // WarningMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(563, 160);
            this.Controls.Add(this.label_WarningText);
            this.Controls.Add(this.panel1);
            this.Name = "WarningMessageBox";
            this.Text = "触发预警！";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WarningMessageBox_FormClosing);
            this.Load += new System.EventHandler(this.WarningMessageBox_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_WarningText;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}
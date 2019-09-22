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
            // WarningMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(563, 108);
            this.Controls.Add(this.label_WarningText);
            this.Name = "WarningMessageBox";
            this.Text = "触发预警！";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WarningMessageBox_FormClosing);
            this.Load += new System.EventHandler(this.WarningMessageBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_WarningText;
    }
}
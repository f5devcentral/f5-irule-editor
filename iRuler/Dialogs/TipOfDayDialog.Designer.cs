namespace iRuler.Dialogs
{
    partial class TipOfDayDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TipOfDayDialog));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox_Tip = new System.Windows.Forms.RichTextBox();
            this.button_NextTip = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_PrevTip = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox_Tip);
            this.groupBox1.Location = new System.Drawing.Point(13, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 147);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // richTextBox_Tip
            // 
            this.richTextBox_Tip.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_Tip.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_Tip.Location = new System.Drawing.Point(15, 20);
            this.richTextBox_Tip.Name = "richTextBox_Tip";
            this.richTextBox_Tip.ReadOnly = true;
            this.richTextBox_Tip.Size = new System.Drawing.Size(317, 113);
            this.richTextBox_Tip.TabIndex = 1;
            this.richTextBox_Tip.Text = "No tips found, please check for updates...";
            // 
            // button_NextTip
            // 
            this.button_NextTip.Location = new System.Drawing.Point(203, 184);
            this.button_NextTip.Name = "button_NextTip";
            this.button_NextTip.Size = new System.Drawing.Size(75, 23);
            this.button_NextTip.TabIndex = 1;
            this.button_NextTip.Text = "Next Tip";
            this.button_NextTip.UseVisualStyleBackColor = true;
            this.button_NextTip.Click += new System.EventHandler(this.button_NextTip_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(287, 184);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Did you know...";
            // 
            // button_PrevTip
            // 
            this.button_PrevTip.Location = new System.Drawing.Point(122, 184);
            this.button_PrevTip.Name = "button_PrevTip";
            this.button_PrevTip.Size = new System.Drawing.Size(75, 23);
            this.button_PrevTip.TabIndex = 3;
            this.button_PrevTip.Text = "Prev Tip";
            this.button_PrevTip.UseVisualStyleBackColor = true;
            this.button_PrevTip.Click += new System.EventHandler(this.button_PrevTip_Click);
            // 
            // TipOfDayDialog
            // 
            this.AcceptButton = this.button_NextTip;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(374, 214);
            this.Controls.Add(this.button_PrevTip);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_NextTip);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TipOfDayDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tip of the Day!";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.TipOfDayDialog_HelpButtonClicked);
            this.Load += new System.EventHandler(this.TipOfDayDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_NextTip;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox_Tip;
        private System.Windows.Forms.Button button_PrevTip;
    }
}
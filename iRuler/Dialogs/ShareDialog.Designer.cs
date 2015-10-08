namespace iRuler.Dialogs
{
    partial class ShareDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShareDialog));
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_RuleName = new System.Windows.Forms.TextBox();
            this.textBox_AuthorName = new System.Windows.Forms.TextBox();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_iRule = new System.Windows.Forms.RichTextBox();
            this.checkBox_Accept = new System.Windows.Forms.CheckBox();
            this.richTextBox_Acknowledgement = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(399, 576);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 12;
            this.button_OK.Text = "Share";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(480, 576);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 13;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "iRule Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Author Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_RuleName
            // 
            this.textBox_RuleName.Location = new System.Drawing.Point(100, 15);
            this.textBox_RuleName.Name = "textBox_RuleName";
            this.textBox_RuleName.Size = new System.Drawing.Size(248, 21);
            this.textBox_RuleName.TabIndex = 1;
            // 
            // textBox_AuthorName
            // 
            this.textBox_AuthorName.Location = new System.Drawing.Point(100, 42);
            this.textBox_AuthorName.Name = "textBox_AuthorName";
            this.textBox_AuthorName.Size = new System.Drawing.Size(248, 21);
            this.textBox_AuthorName.TabIndex = 3;
            // 
            // textBox_Description
            // 
            this.textBox_Description.Location = new System.Drawing.Point(99, 97);
            this.textBox_Description.Multiline = true;
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.Size = new System.Drawing.Size(455, 68);
            this.textBox_Description.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Description:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(56, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "iRule:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_iRule
            // 
            this.textBox_iRule.Location = new System.Drawing.Point(101, 171);
            this.textBox_iRule.Name = "textBox_iRule";
            this.textBox_iRule.ReadOnly = true;
            this.textBox_iRule.Size = new System.Drawing.Size(454, 296);
            this.textBox_iRule.TabIndex = 9;
            this.textBox_iRule.Text = "";
            // 
            // checkBox_Accept
            // 
            this.checkBox_Accept.AutoSize = true;
            this.checkBox_Accept.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Accept.Location = new System.Drawing.Point(83, 473);
            this.checkBox_Accept.Name = "checkBox_Accept";
            this.checkBox_Accept.Size = new System.Drawing.Size(220, 17);
            this.checkBox_Accept.TabIndex = 10;
            this.checkBox_Accept.Text = "I Accept the Terms and Conditions";
            this.checkBox_Accept.UseVisualStyleBackColor = true;
            // 
            // richTextBox_Acknowledgement
            // 
            this.richTextBox_Acknowledgement.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_Acknowledgement.Location = new System.Drawing.Point(100, 496);
            this.richTextBox_Acknowledgement.Name = "richTextBox_Acknowledgement";
            this.richTextBox_Acknowledgement.ReadOnly = true;
            this.richTextBox_Acknowledgement.Size = new System.Drawing.Size(454, 74);
            this.richTextBox_Acknowledgement.TabIndex = 11;
            this.richTextBox_Acknowledgement.Text = "Terms and conditions goes here...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Author eMail:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_Email
            // 
            this.textBox_Email.Location = new System.Drawing.Point(99, 70);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(248, 21);
            this.textBox_Email.TabIndex = 5;
            // 
            // ShareDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(575, 611);
            this.Controls.Add(this.textBox_Email);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBox_Acknowledgement);
            this.Controls.Add(this.checkBox_Accept);
            this.Controls.Add(this.textBox_iRule);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Description);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_AuthorName);
            this.Controls.Add(this.textBox_RuleName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShareDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Share your iRule with the DevCentral Community";
            this.Load += new System.EventHandler(this.ShareDialog_Load);
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.ShareDialog_HelpButtonClicked);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_RuleName;
        private System.Windows.Forms.TextBox textBox_AuthorName;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox textBox_iRule;
        private System.Windows.Forms.CheckBox checkBox_Accept;
        private System.Windows.Forms.RichTextBox richTextBox_Acknowledgement;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Email;
    }
}
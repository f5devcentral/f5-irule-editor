namespace iRuler.Dialogs
{
    partial class AboutBox
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutBox));
            this.button_OK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_AppName3 = new System.Windows.Forms.TextBox();
            this.textBox_AppName2 = new System.Windows.Forms.TextBox();
            this.richTextBox_Credits = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Copyright = new System.Windows.Forms.RichTextBox();
            this.textBox_Version = new System.Windows.Forms.TextBox();
            this.textBox_AppName = new System.Windows.Forms.TextBox();
			this.timer_AutoClose = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_OK.Location = new System.Drawing.Point(265, 465);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.textBox_AppName3);
            this.panel1.Controls.Add(this.textBox_AppName2);
            this.panel1.Controls.Add(this.richTextBox_Credits);
            this.panel1.Controls.Add(this.richTextBox_Copyright);
            this.panel1.Controls.Add(this.textBox_Version);
            this.panel1.Controls.Add(this.textBox_AppName);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 397);
            this.panel1.TabIndex = 2;
            this.panel1.Click += new System.EventHandler(this.button_OK_Click);
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // textBox_AppName3
            // 
            this.textBox_AppName3.BackColor = System.Drawing.Color.White;
            this.textBox_AppName3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_AppName3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_AppName3.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_AppName3.ForeColor = System.Drawing.Color.Firebrick;
            this.textBox_AppName3.Location = new System.Drawing.Point(12, 147);
            this.textBox_AppName3.Name = "textBox_AppName3";
            this.textBox_AppName3.ReadOnly = true;
            this.textBox_AppName3.Size = new System.Drawing.Size(118, 45);
            this.textBox_AppName3.TabIndex = 7;
            this.textBox_AppName3.Text = "Editor";
            this.textBox_AppName3.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // textBox_AppName2
            // 
            this.textBox_AppName2.BackColor = System.Drawing.Color.White;
            this.textBox_AppName2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_AppName2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_AppName2.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_AppName2.ForeColor = System.Drawing.Color.Firebrick;
            this.textBox_AppName2.Location = new System.Drawing.Point(12, 107);
            this.textBox_AppName2.Name = "textBox_AppName2";
            this.textBox_AppName2.ReadOnly = true;
            this.textBox_AppName2.Size = new System.Drawing.Size(106, 45);
            this.textBox_AppName2.TabIndex = 6;
            this.textBox_AppName2.Text = "iRule";
            this.textBox_AppName2.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // richTextBox_Credits
            // 
            this.richTextBox_Credits.BackColor = System.Drawing.Color.White;
            this.richTextBox_Credits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_Credits.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBox_Credits.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_Credits.ForeColor = System.Drawing.Color.Black;
            this.richTextBox_Credits.Location = new System.Drawing.Point(12, 335);
            this.richTextBox_Credits.Name = "richTextBox_Credits";
            this.richTextBox_Credits.ReadOnly = true;
            this.richTextBox_Credits.Size = new System.Drawing.Size(311, 59);
            this.richTextBox_Credits.TabIndex = 4;
            this.richTextBox_Credits.Text = "Portions of this code use...";
            this.richTextBox_Credits.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // richTextBox_Copyright
            // 
            this.richTextBox_Copyright.BackColor = System.Drawing.Color.White;
            this.richTextBox_Copyright.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox_Copyright.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richTextBox_Copyright.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox_Copyright.ForeColor = System.Drawing.Color.Black;
            this.richTextBox_Copyright.Location = new System.Drawing.Point(12, 221);
            this.richTextBox_Copyright.Name = "richTextBox_Copyright";
            this.richTextBox_Copyright.ReadOnly = true;
            this.richTextBox_Copyright.Size = new System.Drawing.Size(311, 116);
            this.richTextBox_Copyright.TabIndex = 5;
            this.richTextBox_Copyright.Text = "Portions of this code use...";
            this.richTextBox_Copyright.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // textBox_Version
            // 
            this.textBox_Version.BackColor = System.Drawing.Color.White;
            this.textBox_Version.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Version.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_Version.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Version.ForeColor = System.Drawing.Color.Gray;
            this.textBox_Version.Location = new System.Drawing.Point(13, 193);
            this.textBox_Version.Name = "textBox_Version";
            this.textBox_Version.ReadOnly = true;
            this.textBox_Version.Size = new System.Drawing.Size(118, 14);
            this.textBox_Version.TabIndex = 2;
            this.textBox_Version.Text = "version x.x.x.x";
            this.textBox_Version.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // textBox_AppName
            // 
            this.textBox_AppName.BackColor = System.Drawing.Color.White;
            this.textBox_AppName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_AppName.Font = new System.Drawing.Font("Tahoma", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_AppName.ForeColor = System.Drawing.Color.Firebrick;
            this.textBox_AppName.Location = new System.Drawing.Point(12, 68);
            this.textBox_AppName.Name = "textBox_AppName";
            this.textBox_AppName.ReadOnly = true;
            this.textBox_AppName.Size = new System.Drawing.Size(60, 45);
            this.textBox_AppName.TabIndex = 1;
            // 
			// timer_AutoClose
			// 
			this.timer_AutoClose.Tick += new System.EventHandler(this.timer_AutoClose_Tick);
			// 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(124, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(252, 319);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // AboutBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(345, 406);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button_OK);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About F5 iRule Editor";
            this.TopMost = true;
			this.Click += new System.EventHandler(this.button_OK_Click);
            this.Load += new System.EventHandler(this.AboutBox_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

		private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_AppName;
        private System.Windows.Forms.TextBox textBox_Version;
        private System.Windows.Forms.RichTextBox richTextBox_Credits;
        private System.Windows.Forms.RichTextBox richTextBox_Copyright;
        private System.Windows.Forms.TextBox textBox_AppName3;
        private System.Windows.Forms.TextBox textBox_AppName2;
        private System.Windows.Forms.Timer timer_AutoClose;
		private System.Windows.Forms.PictureBox pictureBox1;
    }
}
namespace iRuler.Dialogs
{
    partial class LogViewerDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogViewerDialog));
            this.comboBox_LogFile = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_Lines = new System.Windows.Forms.NumericUpDown();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.listView_Log = new System.Windows.Forms.ListView();
            this.columnHeader_Line = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Date = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Event = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Host = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Service = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_Status = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Lines)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_LogFile
            // 
            this.comboBox_LogFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_LogFile.FormattingEnabled = true;
            this.comboBox_LogFile.Items.AddRange(new object[] {
            "/var/log/ltm",
            "/var/log/messages"});
            this.comboBox_LogFile.Location = new System.Drawing.Point(60, 12);
            this.comboBox_LogFile.Name = "comboBox_LogFile";
            this.comboBox_LogFile.Size = new System.Drawing.Size(135, 21);
            this.comboBox_LogFile.TabIndex = 0;
            this.comboBox_LogFile.Text = "/var/log/ltm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Log File:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lines:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numericUpDown_Lines
            // 
            this.numericUpDown_Lines.Location = new System.Drawing.Point(243, 12);
            this.numericUpDown_Lines.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDown_Lines.Name = "numericUpDown_Lines";
            this.numericUpDown_Lines.Size = new System.Drawing.Size(90, 21);
            this.numericUpDown_Lines.TabIndex = 3;
            this.numericUpDown_Lines.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(13, 10);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(75, 23);
            this.button_Refresh.TabIndex = 4;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(94, 10);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 5;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // listView_Log
            // 
            this.listView_Log.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Line,
            this.columnHeader_Date,
            this.columnHeader_Host,
            this.columnHeader_Service,
            this.columnHeader_Status,
            this.columnHeader_Event});
            this.listView_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_Log.FullRowSelect = true;
            this.listView_Log.Location = new System.Drawing.Point(0, 0);
            this.listView_Log.Name = "listView_Log";
            this.listView_Log.Size = new System.Drawing.Size(659, 401);
            this.listView_Log.TabIndex = 0;
            this.listView_Log.UseCompatibleStateImageBehavior = false;
            this.listView_Log.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_Line
            // 
            this.columnHeader_Line.Text = "Line";
            this.columnHeader_Line.Width = 46;
            // 
            // columnHeader_Date
            // 
            this.columnHeader_Date.Text = "Timestamp";
            this.columnHeader_Date.Width = 97;
            // 
            // columnHeader_Event
            // 
            this.columnHeader_Event.Text = "Event";
            this.columnHeader_Event.Width = 472;
            // 
            // columnHeader_Host
            // 
            this.columnHeader_Host.Text = "Host";
            this.columnHeader_Host.Width = 63;
            // 
            // columnHeader_Service
            // 
            this.columnHeader_Service.Text = "Service";
            // 
            // columnHeader_Status
            // 
            this.columnHeader_Status.Text = "Status";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 401);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 45);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_Cancel);
            this.panel2.Controls.Add(this.button_Refresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(480, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(179, 45);
            this.panel2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.comboBox_LogFile);
            this.panel3.Controls.Add(this.numericUpDown_Lines);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(480, 45);
            this.panel3.TabIndex = 7;
            // 
            // LogViewerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 446);
            this.Controls.Add(this.listView_Log);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(550, 200);
            this.Name = "LogViewerDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BIG-IP Log Viewer";
            this.Load += new System.EventHandler(this.LogViewerDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Lines)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_LogFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_Lines;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.ListView listView_Log;
        private System.Windows.Forms.ColumnHeader columnHeader_Line;
        private System.Windows.Forms.ColumnHeader columnHeader_Event;
        private System.Windows.Forms.ColumnHeader columnHeader_Date;
        private System.Windows.Forms.ColumnHeader columnHeader_Host;
        private System.Windows.Forms.ColumnHeader columnHeader_Service;
        private System.Windows.Forms.ColumnHeader columnHeader_Status;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
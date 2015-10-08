namespace iRuler.Dialogs
{
    partial class iRuleInfoDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iRuleInfoDialog));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Membership_LTM = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox_Pools = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_RemoveVirtual = new System.Windows.Forms.Button();
            this.button_AddVirtual = new System.Windows.Forms.Button();
            this.listBox_VirtualServersUsing = new System.Windows.Forms.ListBox();
            this.listBox_VirtualServersNotUsing = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_RefreshMembership = new System.Windows.Forms.Button();
            this.tabPage_Statistics = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.linkLabel_Guess = new System.Windows.Forms.LinkLabel();
            this.comboBox_Metric = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_CPUSpeed = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.button_ResetStats = new System.Windows.Forms.Button();
            this.listView_Statistics = new System.Windows.Forms.ListView();
            this.columnHeader_Event = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Priority = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_TotalExecutions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Failures = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_Aborts = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_MinimumCycles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_AverageCycles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader_MaximumCycles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.label_Chars = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label_Lines = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Name = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label_Description = new System.Windows.Forms.Label();
            this.textBox_Description = new System.Windows.Forms.TextBox();
            this.button_ApplyDescription = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage_Membership_LTM.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage_Statistics.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Membership_LTM);
            this.tabControl1.Controls.Add(this.tabPage_Statistics);
            this.tabControl1.Location = new System.Drawing.Point(8, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 376);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage_Membership_LTM
            // 
            this.tabPage_Membership_LTM.Controls.Add(this.button_ApplyDescription);
            this.tabPage_Membership_LTM.Controls.Add(this.textBox_Description);
            this.tabPage_Membership_LTM.Controls.Add(this.label_Description);
            this.tabPage_Membership_LTM.Controls.Add(this.groupBox2);
            this.tabPage_Membership_LTM.Controls.Add(this.groupBox1);
            this.tabPage_Membership_LTM.Controls.Add(this.button_RefreshMembership);
            this.tabPage_Membership_LTM.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Membership_LTM.Name = "tabPage_Membership_LTM";
            this.tabPage_Membership_LTM.Size = new System.Drawing.Size(632, 350);
            this.tabPage_Membership_LTM.TabIndex = 1;
            this.tabPage_Membership_LTM.Text = "Membership";
            this.tabPage_Membership_LTM.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.listBox_Pools);
            this.groupBox2.Location = new System.Drawing.Point(441, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 283);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pools";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(163, 23);
            this.label7.TabIndex = 3;
            this.label7.Text = "Referencing this iRule";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listBox_Pools
            // 
            this.listBox_Pools.FormattingEnabled = true;
            this.listBox_Pools.HorizontalScrollbar = true;
            this.listBox_Pools.Location = new System.Drawing.Point(25, 47);
            this.listBox_Pools.Name = "listBox_Pools";
            this.listBox_Pools.Size = new System.Drawing.Size(124, 212);
            this.listBox_Pools.Sorted = true;
            this.listBox_Pools.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_RemoveVirtual);
            this.groupBox1.Controls.Add(this.button_AddVirtual);
            this.groupBox1.Controls.Add(this.listBox_VirtualServersUsing);
            this.groupBox1.Controls.Add(this.listBox_VirtualServersNotUsing);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(16, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 283);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Virtual Servers";
            // 
            // button_RemoveVirtual
            // 
            this.button_RemoveVirtual.Location = new System.Drawing.Point(181, 156);
            this.button_RemoveVirtual.Name = "button_RemoveVirtual";
            this.button_RemoveVirtual.Size = new System.Drawing.Size(40, 23);
            this.button_RemoveVirtual.TabIndex = 4;
            this.button_RemoveVirtual.Text = "<<";
            this.button_RemoveVirtual.UseVisualStyleBackColor = true;
            this.button_RemoveVirtual.Click += new System.EventHandler(this.button_RemoveVirtual_Click);
            // 
            // button_AddVirtual
            // 
            this.button_AddVirtual.Location = new System.Drawing.Point(181, 122);
            this.button_AddVirtual.Name = "button_AddVirtual";
            this.button_AddVirtual.Size = new System.Drawing.Size(40, 23);
            this.button_AddVirtual.TabIndex = 3;
            this.button_AddVirtual.Text = ">>";
            this.button_AddVirtual.UseVisualStyleBackColor = true;
            this.button_AddVirtual.Click += new System.EventHandler(this.button_AddVirtual_Click);
            // 
            // listBox_VirtualServersUsing
            // 
            this.listBox_VirtualServersUsing.FormattingEnabled = true;
            this.listBox_VirtualServersUsing.HorizontalScrollbar = true;
            this.listBox_VirtualServersUsing.Location = new System.Drawing.Point(227, 47);
            this.listBox_VirtualServersUsing.Name = "listBox_VirtualServersUsing";
            this.listBox_VirtualServersUsing.Size = new System.Drawing.Size(147, 212);
            this.listBox_VirtualServersUsing.Sorted = true;
            this.listBox_VirtualServersUsing.TabIndex = 1;
            this.listBox_VirtualServersUsing.SelectedIndexChanged += new System.EventHandler(this.listBox_VirtualServersUsing_SelectedIndexChanged);
            // 
            // listBox_VirtualServersNotUsing
            // 
            this.listBox_VirtualServersNotUsing.FormattingEnabled = true;
            this.listBox_VirtualServersNotUsing.HorizontalScrollbar = true;
            this.listBox_VirtualServersNotUsing.Location = new System.Drawing.Point(23, 47);
            this.listBox_VirtualServersNotUsing.Name = "listBox_VirtualServersNotUsing";
            this.listBox_VirtualServersNotUsing.Size = new System.Drawing.Size(152, 212);
            this.listBox_VirtualServersNotUsing.Sorted = true;
            this.listBox_VirtualServersNotUsing.TabIndex = 0;
            this.listBox_VirtualServersNotUsing.SelectedIndexChanged += new System.EventHandler(this.listBox_VirtualServersNotUsing_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Not using this iRule";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(227, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "Using this iRule";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_RefreshMembership
            // 
            this.button_RefreshMembership.Location = new System.Drawing.Point(528, 321);
            this.button_RefreshMembership.Name = "button_RefreshMembership";
            this.button_RefreshMembership.Size = new System.Drawing.Size(88, 23);
            this.button_RefreshMembership.TabIndex = 9;
            this.button_RefreshMembership.Text = "Refresh";
            this.button_RefreshMembership.Click += new System.EventHandler(this.button_RefreshMembership_Click);
            // 
            // tabPage_Statistics
            // 
            this.tabPage_Statistics.Controls.Add(this.label10);
            this.tabPage_Statistics.Controls.Add(this.linkLabel_Guess);
            this.tabPage_Statistics.Controls.Add(this.comboBox_Metric);
            this.tabPage_Statistics.Controls.Add(this.label9);
            this.tabPage_Statistics.Controls.Add(this.textBox_CPUSpeed);
            this.tabPage_Statistics.Controls.Add(this.label8);
            this.tabPage_Statistics.Controls.Add(this.button_Refresh);
            this.tabPage_Statistics.Controls.Add(this.button_ResetStats);
            this.tabPage_Statistics.Controls.Add(this.listView_Statistics);
            this.tabPage_Statistics.Controls.Add(this.label4);
            this.tabPage_Statistics.Controls.Add(this.label_Chars);
            this.tabPage_Statistics.Controls.Add(this.label5);
            this.tabPage_Statistics.Controls.Add(this.label_Lines);
            this.tabPage_Statistics.Controls.Add(this.label3);
            this.tabPage_Statistics.Controls.Add(this.label_Name);
            this.tabPage_Statistics.Controls.Add(this.label1);
            this.tabPage_Statistics.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Statistics.Name = "tabPage_Statistics";
            this.tabPage_Statistics.Size = new System.Drawing.Size(632, 350);
            this.tabPage_Statistics.TabIndex = 0;
            this.tabPage_Statistics.Text = "Statistics";
            this.tabPage_Statistics.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(322, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 24);
            this.label10.TabIndex = 15;
            this.label10.Text = "MHz";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabel_Guess
            // 
            this.linkLabel_Guess.AutoSize = true;
            this.linkLabel_Guess.Location = new System.Drawing.Point(195, 54);
            this.linkLabel_Guess.Name = "linkLabel_Guess";
            this.linkLabel_Guess.Size = new System.Drawing.Size(44, 13);
            this.linkLabel_Guess.TabIndex = 8;
            this.linkLabel_Guess.TabStop = true;
            this.linkLabel_Guess.Text = "(Guess)";
            this.linkLabel_Guess.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_Guess_LinkClicked);
            // 
            // comboBox_Metric
            // 
            this.comboBox_Metric.FormattingEnabled = true;
            this.comboBox_Metric.Items.AddRange(new object[] {
            "CPU Cycles/Request",
            "Run Time (ms)/Request",
            "Percent CPU Usage/Request",
            "Max Concurrent Requests"});
            this.comboBox_Metric.Location = new System.Drawing.Point(434, 50);
            this.comboBox_Metric.Name = "comboBox_Metric";
            this.comboBox_Metric.Size = new System.Drawing.Size(182, 21);
            this.comboBox_Metric.TabIndex = 11;
            this.comboBox_Metric.SelectedIndexChanged += new System.EventHandler(this.comboBox_Metric_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(380, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 24);
            this.label9.TabIndex = 10;
            this.label9.Text = "Metric:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox_CPUSpeed
            // 
            this.textBox_CPUSpeed.Location = new System.Drawing.Point(246, 52);
            this.textBox_CPUSpeed.Name = "textBox_CPUSpeed";
            this.textBox_CPUSpeed.Size = new System.Drawing.Size(74, 21);
            this.textBox_CPUSpeed.TabIndex = 9;
            this.textBox_CPUSpeed.Text = "1600.000";
            this.textBox_CPUSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(116, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 24);
            this.label8.TabIndex = 7;
            this.label8.Text = "CPU  Speed:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(408, 320);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(88, 23);
            this.button_Refresh.TabIndex = 13;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // button_ResetStats
            // 
            this.button_ResetStats.Location = new System.Drawing.Point(512, 320);
            this.button_ResetStats.Name = "button_ResetStats";
            this.button_ResetStats.Size = new System.Drawing.Size(96, 23);
            this.button_ResetStats.TabIndex = 14;
            this.button_ResetStats.Text = "Reset Statistics";
            this.button_ResetStats.Click += new System.EventHandler(this.button_ResetStats_Click);
            // 
            // listView_Statistics
            // 
            this.listView_Statistics.AllowColumnReorder = true;
            this.listView_Statistics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Event,
            this.columnHeader_Priority,
            this.columnHeader_TotalExecutions,
            this.columnHeader_Failures,
            this.columnHeader_Aborts,
            this.columnHeader_MinimumCycles,
            this.columnHeader_AverageCycles,
            this.columnHeader_MaximumCycles});
            this.listView_Statistics.Location = new System.Drawing.Point(24, 80);
            this.listView_Statistics.Name = "listView_Statistics";
            this.listView_Statistics.Size = new System.Drawing.Size(592, 232);
            this.listView_Statistics.TabIndex = 12;
            this.listView_Statistics.UseCompatibleStateImageBehavior = false;
            this.listView_Statistics.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader_Event
            // 
            this.columnHeader_Event.Text = "Event";
            this.columnHeader_Event.Width = 118;
            // 
            // columnHeader_Priority
            // 
            this.columnHeader_Priority.Text = "Priority";
            this.columnHeader_Priority.Width = 47;
            // 
            // columnHeader_TotalExecutions
            // 
            this.columnHeader_TotalExecutions.Text = "Executions";
            this.columnHeader_TotalExecutions.Width = 64;
            // 
            // columnHeader_Failures
            // 
            this.columnHeader_Failures.Text = "Failures";
            this.columnHeader_Failures.Width = 52;
            // 
            // columnHeader_Aborts
            // 
            this.columnHeader_Aborts.Text = "Aborts";
            this.columnHeader_Aborts.Width = 49;
            // 
            // columnHeader_MinimumCycles
            // 
            this.columnHeader_MinimumCycles.Text = "Minimum";
            this.columnHeader_MinimumCycles.Width = 75;
            // 
            // columnHeader_AverageCycles
            // 
            this.columnHeader_AverageCycles.Text = "Average";
            this.columnHeader_AverageCycles.Width = 82;
            // 
            // columnHeader_MaximumCycles
            // 
            this.columnHeader_MaximumCycles.Text = "Maximum";
            this.columnHeader_MaximumCycles.Width = 96;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Statistics";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Chars
            // 
            this.label_Chars.Location = new System.Drawing.Point(416, 16);
            this.label_Chars.Name = "label_Chars";
            this.label_Chars.Size = new System.Drawing.Size(48, 24);
            this.label_Chars.TabIndex = 5;
            this.label_Chars.Text = "yyy";
            this.label_Chars.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(352, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Chars: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Lines
            // 
            this.label_Lines.Location = new System.Drawing.Point(328, 16);
            this.label_Lines.Name = "label_Lines";
            this.label_Lines.Size = new System.Drawing.Size(32, 24);
            this.label_Lines.TabIndex = 3;
            this.label_Lines.Text = "xxx";
            this.label_Lines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(264, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Lines: ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Name
            // 
            this.label_Name.Location = new System.Drawing.Point(80, 16);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(194, 24);
            this.label_Name.TabIndex = 1;
            this.label_Name.Text = "Name Goes Here";
            this.label_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(488, 408);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 1;
            this.button_OK.Text = "&OK";
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(568, 408);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 2;
            this.button_Cancel.Text = "&Cancel";
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // label_Description
            // 
            this.label_Description.AutoSize = true;
            this.label_Description.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Description.Location = new System.Drawing.Point(14, 305);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(71, 13);
            this.label_Description.TabIndex = 12;
            this.label_Description.Text = "Description";
            // 
            // textBox_Description
            // 
            this.textBox_Description.Location = new System.Drawing.Point(91, 313);
            this.textBox_Description.Multiline = true;
            this.textBox_Description.Name = "textBox_Description";
            this.textBox_Description.Size = new System.Drawing.Size(323, 31);
            this.textBox_Description.TabIndex = 13;
            this.textBox_Description.TextChanged += new System.EventHandler(this.textBox_Description_TextChanged);
            // 
            // button_ApplyDescription
            // 
            this.button_ApplyDescription.Enabled = false;
            this.button_ApplyDescription.Location = new System.Drawing.Point(17, 321);
            this.button_ApplyDescription.Name = "button_ApplyDescription";
            this.button_ApplyDescription.Size = new System.Drawing.Size(68, 23);
            this.button_ApplyDescription.TabIndex = 14;
            this.button_ApplyDescription.Text = "Apply";
            this.button_ApplyDescription.Click += new System.EventHandler(this.button_ApplyDescription_Click);
            // 
            // iRuleInfoDialog
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(654, 444);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "iRuleInfoDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "iRule Information";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.iRuleInfoDialog_HelpButtonClicked);
            this.Load += new System.EventHandler(this.iRuleInfoDialog_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Membership_LTM.ResumeLayout(false);
            this.tabPage_Membership_LTM.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage_Statistics.ResumeLayout(false);
            this.tabPage_Statistics.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.TabPage tabPage_Statistics;
        private System.Windows.Forms.TabPage tabPage_Membership_LTM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_Lines;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listView_Statistics;
        private System.Windows.Forms.ColumnHeader columnHeader_Event;
        private System.Windows.Forms.ColumnHeader columnHeader_Priority;
        private System.Windows.Forms.ColumnHeader columnHeader_Failures;
        private System.Windows.Forms.ColumnHeader columnHeader_Aborts;
        private System.Windows.Forms.ColumnHeader columnHeader_TotalExecutions;
        private System.Windows.Forms.ColumnHeader columnHeader_AverageCycles;
        private System.Windows.Forms.ColumnHeader columnHeader_MaximumCycles;
        private System.Windows.Forms.ColumnHeader columnHeader_MinimumCycles;
        private System.Windows.Forms.Button button_ResetStats;
        private System.Windows.Forms.Label label_Chars;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_RefreshMembership;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox_Pools;
        private System.Windows.Forms.ListBox listBox_VirtualServersUsing;
        private System.Windows.Forms.ListBox listBox_VirtualServersNotUsing;
        private System.Windows.Forms.Button button_RemoveVirtual;
        private System.Windows.Forms.Button button_AddVirtual;
		private System.Windows.Forms.TextBox textBox_CPUSpeed;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox comboBox_Metric;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.LinkLabel linkLabel_Guess;
		private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button_ApplyDescription;
        private System.Windows.Forms.TextBox textBox_Description;
        private System.Windows.Forms.Label label_Description;
    }
}
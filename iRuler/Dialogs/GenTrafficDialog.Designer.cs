namespace iRuler.Dialogs
{
    partial class GenTrafficDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenTrafficDialog));
			this.comboBox_VirtualServer = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabControl_Protocols = new System.Windows.Forms.TabControl();
			this.tabPage_HTTP = new System.Windows.Forms.TabPage();
			this.label11 = new System.Windows.Forms.Label();
			this.button_HTTPHeaderRemove = new System.Windows.Forms.Button();
			this.button_HTTPHeaderAdd = new System.Windows.Forms.Button();
			this.textBox_HTTPHeaderValue = new System.Windows.Forms.TextBox();
			this.textBox_HTTPHeaderName = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.listView_HTTPHeaders = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.checkBox_SSL = new System.Windows.Forms.CheckBox();
			this.progressBar_Status = new System.Windows.Forms.ProgressBar();
			this.label10 = new System.Windows.Forms.Label();
			this.richTextBox_Status = new System.Windows.Forms.RichTextBox();
			this.label_Error = new System.Windows.Forms.Label();
			this.textBox_URI = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox_HTTPPassword = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.textBox_HTTPUsername = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.button_HTTPParamRemove = new System.Windows.Forms.Button();
			this.button_HTTPParamAdd = new System.Windows.Forms.Button();
			this.textBox_HTTPParamValue = new System.Windows.Forms.TextBox();
			this.textBox_HTTPParamName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBox_HTTPMethod = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.listView_HTTPParameters = new System.Windows.Forms.ListView();
			this.columnHeader_Name = new System.Windows.Forms.ColumnHeader();
			this.columnHeader_Value = new System.Windows.Forms.ColumnHeader();
			this.numericUpDown_Interval = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.button_StartStop = new System.Windows.Forms.Button();
			this.button_Cancel = new System.Windows.Forms.Button();
			this.backgroundWorker_traffic = new System.ComponentModel.BackgroundWorker();
			this.timer_GenTraffic = new System.Windows.Forms.Timer(this.components);
			this.UseProxyCheckBox = new System.Windows.Forms.CheckBox();
			this.ProxyServerTextBox = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.ProxyPortTextBox = new System.Windows.Forms.TextBox();
			this.tabControl_Protocols.SuspendLayout();
			this.tabPage_HTTP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Interval)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBox_VirtualServer
			// 
			this.comboBox_VirtualServer.FormattingEnabled = true;
			this.comboBox_VirtualServer.Location = new System.Drawing.Point(109, 16);
			this.comboBox_VirtualServer.Name = "comboBox_VirtualServer";
			this.comboBox_VirtualServer.Size = new System.Drawing.Size(258, 21);
			this.comboBox_VirtualServer.TabIndex = 1;
			this.comboBox_VirtualServer.Leave += new System.EventHandler(this.comboBox_VirtualServer_Leave);
			this.comboBox_VirtualServer.SelectedIndexChanged += new System.EventHandler(this.comboBox_VirtualServer_SelectedIndexChanged);
			this.comboBox_VirtualServer.TextChanged += new System.EventHandler(this.comboBox_VirtualServer_TextChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(13, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Virtual Server";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tabControl_Protocols
			// 
			this.tabControl_Protocols.Controls.Add(this.tabPage_HTTP);
			this.tabControl_Protocols.Location = new System.Drawing.Point(16, 49);
			this.tabControl_Protocols.Name = "tabControl_Protocols";
			this.tabControl_Protocols.SelectedIndex = 0;
			this.tabControl_Protocols.Size = new System.Drawing.Size(579, 523);
			this.tabControl_Protocols.TabIndex = 4;
			// 
			// tabPage_HTTP
			// 
			this.tabPage_HTTP.Controls.Add(this.ProxyPortTextBox);
			this.tabPage_HTTP.Controls.Add(this.label14);
			this.tabPage_HTTP.Controls.Add(this.ProxyServerTextBox);
			this.tabPage_HTTP.Controls.Add(this.UseProxyCheckBox);
			this.tabPage_HTTP.Controls.Add(this.label11);
			this.tabPage_HTTP.Controls.Add(this.button_HTTPHeaderRemove);
			this.tabPage_HTTP.Controls.Add(this.button_HTTPHeaderAdd);
			this.tabPage_HTTP.Controls.Add(this.textBox_HTTPHeaderValue);
			this.tabPage_HTTP.Controls.Add(this.textBox_HTTPHeaderName);
			this.tabPage_HTTP.Controls.Add(this.label12);
			this.tabPage_HTTP.Controls.Add(this.label13);
			this.tabPage_HTTP.Controls.Add(this.listView_HTTPHeaders);
			this.tabPage_HTTP.Controls.Add(this.checkBox_SSL);
			this.tabPage_HTTP.Controls.Add(this.progressBar_Status);
			this.tabPage_HTTP.Controls.Add(this.label10);
			this.tabPage_HTTP.Controls.Add(this.richTextBox_Status);
			this.tabPage_HTTP.Controls.Add(this.label_Error);
			this.tabPage_HTTP.Controls.Add(this.textBox_URI);
			this.tabPage_HTTP.Controls.Add(this.label9);
			this.tabPage_HTTP.Controls.Add(this.textBox_HTTPPassword);
			this.tabPage_HTTP.Controls.Add(this.label8);
			this.tabPage_HTTP.Controls.Add(this.textBox_HTTPUsername);
			this.tabPage_HTTP.Controls.Add(this.label7);
			this.tabPage_HTTP.Controls.Add(this.label6);
			this.tabPage_HTTP.Controls.Add(this.button_HTTPParamRemove);
			this.tabPage_HTTP.Controls.Add(this.button_HTTPParamAdd);
			this.tabPage_HTTP.Controls.Add(this.textBox_HTTPParamValue);
			this.tabPage_HTTP.Controls.Add(this.textBox_HTTPParamName);
			this.tabPage_HTTP.Controls.Add(this.label5);
			this.tabPage_HTTP.Controls.Add(this.label4);
			this.tabPage_HTTP.Controls.Add(this.comboBox_HTTPMethod);
			this.tabPage_HTTP.Controls.Add(this.label3);
			this.tabPage_HTTP.Controls.Add(this.listView_HTTPParameters);
			this.tabPage_HTTP.Location = new System.Drawing.Point(4, 22);
			this.tabPage_HTTP.Name = "tabPage_HTTP";
			this.tabPage_HTTP.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage_HTTP.Size = new System.Drawing.Size(571, 497);
			this.tabPage_HTTP.TabIndex = 0;
			this.tabPage_HTTP.Text = "HTTP";
			this.tabPage_HTTP.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label11.Location = new System.Drawing.Point(23, 84);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(54, 13);
			this.label11.TabIndex = 21;
			this.label11.Text = "Headers";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// button_HTTPHeaderRemove
			// 
			this.button_HTTPHeaderRemove.Enabled = false;
			this.button_HTTPHeaderRemove.Location = new System.Drawing.Point(250, 131);
			this.button_HTTPHeaderRemove.Name = "button_HTTPHeaderRemove";
			this.button_HTTPHeaderRemove.Size = new System.Drawing.Size(38, 23);
			this.button_HTTPHeaderRemove.TabIndex = 27;
			this.button_HTTPHeaderRemove.Text = "<<";
			this.button_HTTPHeaderRemove.UseVisualStyleBackColor = true;
			this.button_HTTPHeaderRemove.Click += new System.EventHandler(this.button_HTTPHeaderRemove_Click);
			// 
			// button_HTTPHeaderAdd
			// 
			this.button_HTTPHeaderAdd.Enabled = false;
			this.button_HTTPHeaderAdd.Location = new System.Drawing.Point(250, 102);
			this.button_HTTPHeaderAdd.Name = "button_HTTPHeaderAdd";
			this.button_HTTPHeaderAdd.Size = new System.Drawing.Size(38, 23);
			this.button_HTTPHeaderAdd.TabIndex = 26;
			this.button_HTTPHeaderAdd.Text = ">>";
			this.button_HTTPHeaderAdd.UseVisualStyleBackColor = true;
			this.button_HTTPHeaderAdd.Click += new System.EventHandler(this.button_HTTPHeaderAdd_Click);
			// 
			// textBox_HTTPHeaderValue
			// 
			this.textBox_HTTPHeaderValue.Location = new System.Drawing.Point(89, 130);
			this.textBox_HTTPHeaderValue.Name = "textBox_HTTPHeaderValue";
			this.textBox_HTTPHeaderValue.Size = new System.Drawing.Size(141, 21);
			this.textBox_HTTPHeaderValue.TabIndex = 25;
			// 
			// textBox_HTTPHeaderName
			// 
			this.textBox_HTTPHeaderName.Location = new System.Drawing.Point(89, 102);
			this.textBox_HTTPHeaderName.Name = "textBox_HTTPHeaderName";
			this.textBox_HTTPHeaderName.Size = new System.Drawing.Size(141, 21);
			this.textBox_HTTPHeaderName.TabIndex = 23;
			this.textBox_HTTPHeaderName.TextChanged += new System.EventHandler(this.textBox_HTTPHeaderName_TextChanged);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label12.Location = new System.Drawing.Point(43, 133);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(38, 13);
			this.label12.TabIndex = 24;
			this.label12.Text = "Value";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label13.Location = new System.Drawing.Point(43, 107);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(39, 13);
			this.label13.TabIndex = 22;
			this.label13.Text = "Name";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// listView_HTTPHeaders
			// 
			this.listView_HTTPHeaders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listView_HTTPHeaders.FullRowSelect = true;
			this.listView_HTTPHeaders.Location = new System.Drawing.Point(307, 84);
			this.listView_HTTPHeaders.Name = "listView_HTTPHeaders";
			this.listView_HTTPHeaders.Size = new System.Drawing.Size(241, 90);
			this.listView_HTTPHeaders.TabIndex = 28;
			this.listView_HTTPHeaders.UseCompatibleStateImageBehavior = false;
			this.listView_HTTPHeaders.View = System.Windows.Forms.View.Details;
			this.listView_HTTPHeaders.SelectedIndexChanged += new System.EventHandler(this.listView_HTTPHeaders_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 109;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Value";
			this.columnHeader2.Width = 128;
			// 
			// checkBox_SSL
			// 
			this.checkBox_SSL.AutoSize = true;
			this.checkBox_SSL.Location = new System.Drawing.Point(332, 22);
			this.checkBox_SSL.Name = "checkBox_SSL";
			this.checkBox_SSL.Size = new System.Drawing.Size(43, 17);
			this.checkBox_SSL.TabIndex = 20;
			this.checkBox_SSL.Text = "SSL";
			this.checkBox_SSL.UseVisualStyleBackColor = true;
			// 
			// progressBar_Status
			// 
			this.progressBar_Status.Location = new System.Drawing.Point(73, 295);
			this.progressBar_Status.Name = "progressBar_Status";
			this.progressBar_Status.Size = new System.Drawing.Size(228, 18);
			this.progressBar_Status.TabIndex = 18;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label10.Location = new System.Drawing.Point(23, 295);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(44, 13);
			this.label10.TabIndex = 17;
			this.label10.Text = "Status";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// richTextBox_Status
			// 
			this.richTextBox_Status.Location = new System.Drawing.Point(26, 319);
			this.richTextBox_Status.Name = "richTextBox_Status";
			this.richTextBox_Status.ReadOnly = true;
			this.richTextBox_Status.Size = new System.Drawing.Size(522, 109);
			this.richTextBox_Status.TabIndex = 16;
			this.richTextBox_Status.Text = "";
			// 
			// label_Error
			// 
			this.label_Error.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Error.ForeColor = System.Drawing.Color.Red;
			this.label_Error.Location = new System.Drawing.Point(26, 431);
			this.label_Error.Name = "label_Error";
			this.label_Error.Size = new System.Drawing.Size(522, 27);
			this.label_Error.TabIndex = 7;
			// 
			// textBox_URI
			// 
			this.textBox_URI.Location = new System.Drawing.Point(89, 19);
			this.textBox_URI.Name = "textBox_URI";
			this.textBox_URI.Size = new System.Drawing.Size(227, 21);
			this.textBox_URI.TabIndex = 1;
			this.textBox_URI.Text = "/";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label9.Location = new System.Drawing.Point(23, 22);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(28, 13);
			this.label9.TabIndex = 0;
			this.label9.Text = "URI";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox_HTTPPassword
			// 
			this.textBox_HTTPPassword.Location = new System.Drawing.Point(307, 46);
			this.textBox_HTTPPassword.Name = "textBox_HTTPPassword";
			this.textBox_HTTPPassword.PasswordChar = '*';
			this.textBox_HTTPPassword.Size = new System.Drawing.Size(141, 21);
			this.textBox_HTTPPassword.TabIndex = 5;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label8.Location = new System.Drawing.Point(240, 49);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(61, 13);
			this.label8.TabIndex = 4;
			this.label8.Text = "Password";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox_HTTPUsername
			// 
			this.textBox_HTTPUsername.Location = new System.Drawing.Point(89, 46);
			this.textBox_HTTPUsername.Name = "textBox_HTTPUsername";
			this.textBox_HTTPUsername.Size = new System.Drawing.Size(141, 21);
			this.textBox_HTTPUsername.TabIndex = 3;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label7.Location = new System.Drawing.Point(23, 49);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(65, 13);
			this.label7.TabIndex = 2;
			this.label7.Text = "Username";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.Location = new System.Drawing.Point(23, 189);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(74, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Parameters";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// button_HTTPParamRemove
			// 
			this.button_HTTPParamRemove.Enabled = false;
			this.button_HTTPParamRemove.Location = new System.Drawing.Point(250, 236);
			this.button_HTTPParamRemove.Name = "button_HTTPParamRemove";
			this.button_HTTPParamRemove.Size = new System.Drawing.Size(38, 23);
			this.button_HTTPParamRemove.TabIndex = 14;
			this.button_HTTPParamRemove.Text = "<<";
			this.button_HTTPParamRemove.UseVisualStyleBackColor = true;
			this.button_HTTPParamRemove.Click += new System.EventHandler(this.button_HTTPParamRemove_Click);
			// 
			// button_HTTPParamAdd
			// 
			this.button_HTTPParamAdd.Enabled = false;
			this.button_HTTPParamAdd.Location = new System.Drawing.Point(250, 207);
			this.button_HTTPParamAdd.Name = "button_HTTPParamAdd";
			this.button_HTTPParamAdd.Size = new System.Drawing.Size(38, 23);
			this.button_HTTPParamAdd.TabIndex = 13;
			this.button_HTTPParamAdd.Text = ">>";
			this.button_HTTPParamAdd.UseVisualStyleBackColor = true;
			this.button_HTTPParamAdd.Click += new System.EventHandler(this.button_HTTPParamAdd_Click);
			// 
			// textBox_HTTPParamValue
			// 
			this.textBox_HTTPParamValue.Location = new System.Drawing.Point(89, 235);
			this.textBox_HTTPParamValue.Name = "textBox_HTTPParamValue";
			this.textBox_HTTPParamValue.Size = new System.Drawing.Size(141, 21);
			this.textBox_HTTPParamValue.TabIndex = 12;
			this.textBox_HTTPParamValue.TextChanged += new System.EventHandler(this.textBox_HTTPParamValue_TextChanged);
			// 
			// textBox_HTTPParamName
			// 
			this.textBox_HTTPParamName.Location = new System.Drawing.Point(89, 207);
			this.textBox_HTTPParamName.Name = "textBox_HTTPParamName";
			this.textBox_HTTPParamName.Size = new System.Drawing.Size(141, 21);
			this.textBox_HTTPParamName.TabIndex = 10;
			this.textBox_HTTPParamName.TextChanged += new System.EventHandler(this.textBox_HTTPParamName_TextChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.Location = new System.Drawing.Point(43, 238);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(38, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Value";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(43, 212);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Name";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// comboBox_HTTPMethod
			// 
			this.comboBox_HTTPMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox_HTTPMethod.FormattingEnabled = true;
			this.comboBox_HTTPMethod.Items.AddRange(new object[] {
            "GET",
            "POST"});
			this.comboBox_HTTPMethod.Location = new System.Drawing.Point(437, 18);
			this.comboBox_HTTPMethod.Name = "comboBox_HTTPMethod";
			this.comboBox_HTTPMethod.Size = new System.Drawing.Size(111, 21);
			this.comboBox_HTTPMethod.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(381, 23);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Method";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// listView_HTTPParameters
			// 
			this.listView_HTTPParameters.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Name,
            this.columnHeader_Value});
			this.listView_HTTPParameters.FullRowSelect = true;
			this.listView_HTTPParameters.Location = new System.Drawing.Point(307, 189);
			this.listView_HTTPParameters.Name = "listView_HTTPParameters";
			this.listView_HTTPParameters.Size = new System.Drawing.Size(241, 90);
			this.listView_HTTPParameters.TabIndex = 15;
			this.listView_HTTPParameters.UseCompatibleStateImageBehavior = false;
			this.listView_HTTPParameters.View = System.Windows.Forms.View.Details;
			this.listView_HTTPParameters.SelectedIndexChanged += new System.EventHandler(this.listView_HTTPParameters_SelectedIndexChanged);
			// 
			// columnHeader_Name
			// 
			this.columnHeader_Name.Text = "Name";
			this.columnHeader_Name.Width = 109;
			// 
			// columnHeader_Value
			// 
			this.columnHeader_Value.Text = "Value";
			this.columnHeader_Value.Width = 128;
			// 
			// numericUpDown_Interval
			// 
			this.numericUpDown_Interval.Location = new System.Drawing.Point(435, 16);
			this.numericUpDown_Interval.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
			this.numericUpDown_Interval.Name = "numericUpDown_Interval";
			this.numericUpDown_Interval.Size = new System.Drawing.Size(69, 21);
			this.numericUpDown_Interval.TabIndex = 3;
			this.numericUpDown_Interval.ValueChanged += new System.EventHandler(this.numericUpDown_Interval_ValueChanged);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(360, 19);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Interval";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// button_StartStop
			// 
			this.button_StartStop.Location = new System.Drawing.Point(435, 578);
			this.button_StartStop.Name = "button_StartStop";
			this.button_StartStop.Size = new System.Drawing.Size(75, 23);
			this.button_StartStop.TabIndex = 5;
			this.button_StartStop.Text = "Start";
			this.button_StartStop.UseVisualStyleBackColor = true;
			this.button_StartStop.Click += new System.EventHandler(this.button_StartStop_Click);
			// 
			// button_Cancel
			// 
			this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button_Cancel.Location = new System.Drawing.Point(516, 578);
			this.button_Cancel.Name = "button_Cancel";
			this.button_Cancel.Size = new System.Drawing.Size(75, 23);
			this.button_Cancel.TabIndex = 6;
			this.button_Cancel.Text = "Cancel";
			this.button_Cancel.UseVisualStyleBackColor = true;
			this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
			// 
			// backgroundWorker_traffic
			// 
			this.backgroundWorker_traffic.WorkerReportsProgress = true;
			this.backgroundWorker_traffic.WorkerSupportsCancellation = true;
			this.backgroundWorker_traffic.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_traffic_DoWork);
			this.backgroundWorker_traffic.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_traffic_RunWorkerCompleted);
			this.backgroundWorker_traffic.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_traffic_ProgressChanged);
			// 
			// timer_GenTraffic
			// 
			this.timer_GenTraffic.Tick += new System.EventHandler(this.timer_GenTraffic_Tick);
			// 
			// UseProxyCheckBox
			// 
			this.UseProxyCheckBox.AutoSize = true;
			this.UseProxyCheckBox.Location = new System.Drawing.Point(300, 474);
			this.UseProxyCheckBox.Name = "UseProxyCheckBox";
			this.UseProxyCheckBox.Size = new System.Drawing.Size(89, 17);
			this.UseProxyCheckBox.TabIndex = 29;
			this.UseProxyCheckBox.Text = "Proxy Server";
			this.UseProxyCheckBox.UseVisualStyleBackColor = true;
			this.UseProxyCheckBox.CheckedChanged += new System.EventHandler(this.UseProxyCheckBox_CheckedChanged);
			// 
			// ProxyServerTextBox
			// 
			this.ProxyServerTextBox.Enabled = false;
			this.ProxyServerTextBox.Location = new System.Drawing.Point(395, 470);
			this.ProxyServerTextBox.Name = "ProxyServerTextBox";
			this.ProxyServerTextBox.Size = new System.Drawing.Size(115, 21);
			this.ProxyServerTextBox.TabIndex = 30;
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(513, 474);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(11, 13);
			this.label14.TabIndex = 31;
			this.label14.Text = ":";
			// 
			// ProxyPortTextBox
			// 
			this.ProxyPortTextBox.Enabled = false;
			this.ProxyPortTextBox.Location = new System.Drawing.Point(523, 470);
			this.ProxyPortTextBox.Name = "ProxyPortTextBox";
			this.ProxyPortTextBox.Size = new System.Drawing.Size(33, 21);
			this.ProxyPortTextBox.TabIndex = 32;
			this.ProxyPortTextBox.Text = "8080";
			// 
			// GenTrafficDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.button_Cancel;
			this.ClientSize = new System.Drawing.Size(614, 614);
			this.Controls.Add(this.button_Cancel);
			this.Controls.Add(this.button_StartStop);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.numericUpDown_Interval);
			this.Controls.Add(this.tabControl_Protocols);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBox_VirtualServer);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "GenTrafficDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Virtual Server Traffic Generation";
			this.Load += new System.EventHandler(this.GenTrafficDialog_Load);
			this.tabControl_Protocols.ResumeLayout(false);
			this.tabPage_HTTP.ResumeLayout(false);
			this.tabPage_HTTP.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Interval)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_VirtualServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl_Protocols;
        private System.Windows.Forms.TabPage tabPage_HTTP;
        private System.Windows.Forms.NumericUpDown numericUpDown_Interval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_StartStop;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label_Error;
        private System.Windows.Forms.ComboBox comboBox_HTTPMethod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView_HTTPParameters;
        private System.Windows.Forms.Button button_HTTPParamRemove;
        private System.Windows.Forms.Button button_HTTPParamAdd;
        private System.Windows.Forms.TextBox textBox_HTTPParamValue;
        private System.Windows.Forms.TextBox textBox_HTTPParamName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_HTTPPassword;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_HTTPUsername;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader columnHeader_Name;
        private System.Windows.Forms.ColumnHeader columnHeader_Value;
        private System.ComponentModel.BackgroundWorker backgroundWorker_traffic;
        private System.Windows.Forms.Timer timer_GenTraffic;
        private System.Windows.Forms.TextBox textBox_URI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richTextBox_Status;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ProgressBar progressBar_Status;
        private System.Windows.Forms.CheckBox checkBox_SSL;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button_HTTPHeaderRemove;
        private System.Windows.Forms.Button button_HTTPHeaderAdd;
        private System.Windows.Forms.TextBox textBox_HTTPHeaderValue;
        private System.Windows.Forms.TextBox textBox_HTTPHeaderName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListView listView_HTTPHeaders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.TextBox ProxyPortTextBox;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox ProxyServerTextBox;
		private System.Windows.Forms.CheckBox UseProxyCheckBox;
    }
}
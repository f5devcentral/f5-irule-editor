namespace iRuler.Dialogs
{
    partial class DataGroupsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataGroupsDialog));
            this.listBox_Address = new System.Windows.Forms.ListBox();
            this.listBox_Integer = new System.Windows.Forms.ListBox();
            this.listBox_String = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_AddAddress = new System.Windows.Forms.Button();
            this.button_EditAddress = new System.Windows.Forms.Button();
            this.button_DeleteAddress = new System.Windows.Forms.Button();
            this.button_DeleteInteger = new System.Windows.Forms.Button();
            this.button_EditInteger = new System.Windows.Forms.Button();
            this.button_AddInteger = new System.Windows.Forms.Button();
            this.button_DeleteString = new System.Windows.Forms.Button();
            this.button_EditString = new System.Windows.Forms.Button();
            this.button_AddString = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_Address
            // 
            this.listBox_Address.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Address.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Address.FormattingEnabled = true;
            this.listBox_Address.HorizontalScrollbar = true;
            this.listBox_Address.Location = new System.Drawing.Point(8, 26);
            this.listBox_Address.Name = "listBox_Address";
            this.listBox_Address.Size = new System.Drawing.Size(162, 291);
            this.listBox_Address.Sorted = true;
            this.listBox_Address.TabIndex = 1;
            this.listBox_Address.Tag = "1";
            this.listBox_Address.SelectedIndexChanged += new System.EventHandler(this.listBox_Address_SelectedIndexChanged);
            this.listBox_Address.DoubleClick += new System.EventHandler(this.button_EditAddress_Click);
            // 
            // listBox_Integer
            // 
            this.listBox_Integer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Integer.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_Integer.FormattingEnabled = true;
            this.listBox_Integer.HorizontalScrollbar = true;
            this.listBox_Integer.Location = new System.Drawing.Point(176, 26);
            this.listBox_Integer.Name = "listBox_Integer";
            this.listBox_Integer.Size = new System.Drawing.Size(162, 291);
            this.listBox_Integer.Sorted = true;
            this.listBox_Integer.TabIndex = 6;
            this.listBox_Integer.Tag = "2";
            this.listBox_Integer.SelectedIndexChanged += new System.EventHandler(this.listBox_Integer_SelectedIndexChanged);
            this.listBox_Integer.DoubleClick += new System.EventHandler(this.button_EditInteger_Click);
            // 
            // listBox_String
            // 
            this.listBox_String.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_String.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox_String.FormattingEnabled = true;
            this.listBox_String.HorizontalScrollbar = true;
            this.listBox_String.Location = new System.Drawing.Point(344, 26);
            this.listBox_String.Name = "listBox_String";
            this.listBox_String.Size = new System.Drawing.Size(162, 291);
            this.listBox_String.Sorted = true;
            this.listBox_String.TabIndex = 11;
            this.listBox_String.Tag = "3";
            this.listBox_String.SelectedIndexChanged += new System.EventHandler(this.listBox_String_SelectedIndexChanged);
            this.listBox_String.DoubleClick += new System.EventHandler(this.button_EditString_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Address";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(232, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Integer";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(404, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "String";
            // 
            // button_AddAddress
            // 
            this.button_AddAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_AddAddress.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AddAddress.Location = new System.Drawing.Point(51, 323);
            this.button_AddAddress.Name = "button_AddAddress";
            this.button_AddAddress.Size = new System.Drawing.Size(75, 23);
            this.button_AddAddress.TabIndex = 2;
            this.button_AddAddress.Text = "Add";
            this.button_AddAddress.UseVisualStyleBackColor = true;
            this.button_AddAddress.Click += new System.EventHandler(this.button_AddAddress_Click);
            // 
            // button_EditAddress
            // 
            this.button_EditAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_EditAddress.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_EditAddress.Location = new System.Drawing.Point(51, 353);
            this.button_EditAddress.Name = "button_EditAddress";
            this.button_EditAddress.Size = new System.Drawing.Size(75, 23);
            this.button_EditAddress.TabIndex = 3;
            this.button_EditAddress.Text = "Edit";
            this.button_EditAddress.UseVisualStyleBackColor = true;
            this.button_EditAddress.Click += new System.EventHandler(this.button_EditAddress_Click);
            // 
            // button_DeleteAddress
            // 
            this.button_DeleteAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_DeleteAddress.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DeleteAddress.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_DeleteAddress.Location = new System.Drawing.Point(51, 383);
            this.button_DeleteAddress.Name = "button_DeleteAddress";
            this.button_DeleteAddress.Size = new System.Drawing.Size(75, 23);
            this.button_DeleteAddress.TabIndex = 4;
            this.button_DeleteAddress.Text = "Delete";
            this.button_DeleteAddress.UseVisualStyleBackColor = true;
            this.button_DeleteAddress.Click += new System.EventHandler(this.button_DeleteAddress_Click);
            // 
            // button_DeleteInteger
            // 
            this.button_DeleteInteger.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_DeleteInteger.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DeleteInteger.Location = new System.Drawing.Point(219, 383);
            this.button_DeleteInteger.Name = "button_DeleteInteger";
            this.button_DeleteInteger.Size = new System.Drawing.Size(75, 23);
            this.button_DeleteInteger.TabIndex = 9;
            this.button_DeleteInteger.Text = "Delete";
            this.button_DeleteInteger.UseVisualStyleBackColor = true;
            this.button_DeleteInteger.Click += new System.EventHandler(this.button_DeleteInteger_Click);
            // 
            // button_EditInteger
            // 
            this.button_EditInteger.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_EditInteger.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_EditInteger.Location = new System.Drawing.Point(219, 353);
            this.button_EditInteger.Name = "button_EditInteger";
            this.button_EditInteger.Size = new System.Drawing.Size(75, 23);
            this.button_EditInteger.TabIndex = 8;
            this.button_EditInteger.Text = "Edit";
            this.button_EditInteger.UseVisualStyleBackColor = true;
            this.button_EditInteger.Click += new System.EventHandler(this.button_EditInteger_Click);
            // 
            // button_AddInteger
            // 
            this.button_AddInteger.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_AddInteger.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AddInteger.Location = new System.Drawing.Point(219, 323);
            this.button_AddInteger.Name = "button_AddInteger";
            this.button_AddInteger.Size = new System.Drawing.Size(75, 23);
            this.button_AddInteger.TabIndex = 7;
            this.button_AddInteger.Text = "Add";
            this.button_AddInteger.UseVisualStyleBackColor = true;
            this.button_AddInteger.Click += new System.EventHandler(this.button_AddInteger_Click);
            // 
            // button_DeleteString
            // 
            this.button_DeleteString.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_DeleteString.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_DeleteString.Location = new System.Drawing.Point(387, 383);
            this.button_DeleteString.Name = "button_DeleteString";
            this.button_DeleteString.Size = new System.Drawing.Size(75, 23);
            this.button_DeleteString.TabIndex = 14;
            this.button_DeleteString.Text = "Delete";
            this.button_DeleteString.UseVisualStyleBackColor = true;
            this.button_DeleteString.Click += new System.EventHandler(this.button_DeleteString_Click);
            // 
            // button_EditString
            // 
            this.button_EditString.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_EditString.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_EditString.Location = new System.Drawing.Point(387, 353);
            this.button_EditString.Name = "button_EditString";
            this.button_EditString.Size = new System.Drawing.Size(75, 23);
            this.button_EditString.TabIndex = 13;
            this.button_EditString.Text = "Edit";
            this.button_EditString.UseVisualStyleBackColor = true;
            this.button_EditString.Click += new System.EventHandler(this.button_EditString_Click);
            // 
            // button_AddString
            // 
            this.button_AddString.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_AddString.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AddString.Location = new System.Drawing.Point(387, 323);
            this.button_AddString.Name = "button_AddString";
            this.button_AddString.Size = new System.Drawing.Size(75, 23);
            this.button_AddString.TabIndex = 12;
            this.button_AddString.Text = "Add";
            this.button_AddString.UseVisualStyleBackColor = true;
            this.button_AddString.Click += new System.EventHandler(this.button_AddString_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 468);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button_DeleteString, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.button_OK, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.button_Refresh, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_DeleteInteger, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.button_EditString, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.button_DeleteAddress, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.listBox_Integer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_AddString, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button_EditInteger, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.listBox_String, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_EditAddress, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_AddInteger, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.listBox_Address, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_AddAddress, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(514, 449);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // button_OK
            // 
            this.button_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_OK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_OK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.Location = new System.Drawing.Point(431, 418);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 2;
            this.button_OK.Text = "OK";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Refresh
            // 
            this.button_Refresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_Refresh.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Refresh.Location = new System.Drawing.Point(8, 418);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(75, 23);
            this.button_Refresh.TabIndex = 1;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // DataGroupsDialog
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_OK;
            this.ClientSize = new System.Drawing.Size(520, 468);
            this.Controls.Add(this.groupBox1);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataGroupsDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data Groups";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.DataGroupsDialog_HelpButtonClicked);
            this.Load += new System.EventHandler(this.DataGroupsDialog_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DataGroupsDialog_Paint);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Address;
        private System.Windows.Forms.ListBox listBox_Integer;
        private System.Windows.Forms.ListBox listBox_String;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_AddAddress;
        private System.Windows.Forms.Button button_EditAddress;
        private System.Windows.Forms.Button button_DeleteAddress;
        private System.Windows.Forms.Button button_DeleteInteger;
        private System.Windows.Forms.Button button_EditInteger;
        private System.Windows.Forms.Button button_AddInteger;
        private System.Windows.Forms.Button button_DeleteString;
        private System.Windows.Forms.Button button_EditString;
        private System.Windows.Forms.Button button_AddString;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
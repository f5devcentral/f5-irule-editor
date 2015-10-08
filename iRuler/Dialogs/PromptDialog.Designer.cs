namespace iRuler.Dialogs
{
    partial class PromptDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PromptDialog));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.textBox_Name = new System.Windows.Forms.TextBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl_Options = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.treeView_Templates = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox_Events = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.RuleTypeComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl_Options.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 452);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // textBox_Name
            // 
            this.textBox_Name.Location = new System.Drawing.Point(72, 16);
            this.textBox_Name.Name = "textBox_Name";
            this.textBox_Name.Size = new System.Drawing.Size(216, 21);
            this.textBox_Name.TabIndex = 2;
            this.textBox_Name.TextChanged += new System.EventHandler(this.textBox_Name_TextChanged);
            // 
            // button_OK
            // 
            this.button_OK.Location = new System.Drawing.Point(131, 411);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(75, 23);
            this.button_OK.TabIndex = 6;
            this.button_OK.Text = "&OK";
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(219, 411);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 7;
            this.button_Cancel.Text = "&Cancel";
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl_Options
            // 
            this.tabControl_Options.Controls.Add(this.tabPage1);
            this.tabControl_Options.Controls.Add(this.tabPage2);
            this.tabControl_Options.Location = new System.Drawing.Point(19, 67);
            this.tabControl_Options.Name = "tabControl_Options";
            this.tabControl_Options.SelectedIndex = 0;
            this.tabControl_Options.Size = new System.Drawing.Size(280, 320);
            this.tabControl_Options.TabIndex = 5;
            this.tabControl_Options.TabIndexChanged += new System.EventHandler(this.tabControl_Options_TabIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeView_Templates);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(272, 294);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Templates";
            // 
            // treeView_Templates
            // 
            this.treeView_Templates.Location = new System.Drawing.Point(19, 35);
            this.treeView_Templates.Name = "treeView_Templates";
            this.treeView_Templates.Size = new System.Drawing.Size(236, 245);
            this.treeView_Templates.TabIndex = 1;
            this.treeView_Templates.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_Templates_AfterSelect);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Available Templates";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listBox_Events);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(272, 294);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Custom";
            // 
            // listBox_Events
            // 
            this.listBox_Events.Location = new System.Drawing.Point(16, 40);
            this.listBox_Events.Name = "listBox_Events";
            this.listBox_Events.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox_Events.Size = new System.Drawing.Size(240, 238);
            this.listBox_Events.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 23);
            this.label3.TabIndex = 3;
            this.label3.Text = "Available Events";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(17, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Type:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RuleTypeComboBox
            // 
            this.RuleTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RuleTypeComboBox.FormattingEnabled = true;
            this.RuleTypeComboBox.Location = new System.Drawing.Point(72, 40);
            this.RuleTypeComboBox.Name = "RuleTypeComboBox";
            this.RuleTypeComboBox.Size = new System.Drawing.Size(216, 21);
            this.RuleTypeComboBox.TabIndex = 4;
            this.RuleTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.RuleTypeComboBox_SelectedIndexChanged);
            // 
            // PromptDialog
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(314, 452);
            this.Controls.Add(this.RuleTypeComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tabControl_Options);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.textBox_Name);
            this.Controls.Add(this.splitter1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PromptDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create a new iRule";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.PromptDialog_HelpButtonClicked);
            this.Load += new System.EventHandler(this.PromptDialog_Load);
            this.tabControl_Options.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox textBox_Name;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl_Options;
        private System.Windows.Forms.ListBox listBox_Events;
        private System.Windows.Forms.TreeView treeView_Templates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox RuleTypeComboBox;
    }
}
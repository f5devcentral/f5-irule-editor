using System.Windows.Forms;

namespace iRuler
{
    partial class iRulerMain
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
            saveConfiguration();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(iRulerMain));
            this.panel_TreeViewToolbar = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_New = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Share = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_CheckSyntax = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_RefreshList = new System.Windows.Forms.ToolStripButton();
            this.treeView_iRules = new System.Windows.Forms.TreeView();
            this.contextMenuStrip_TreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_CheckSyntax = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Share = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Reset = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Reload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_CopyOffline = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Properties = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList_TreeView = new System.Windows.Forms.ImageList(this.components);
            this.panel_TreeView = new System.Windows.Forms.Panel();
            this.m_textEditor = new scintilla.ScintillaControl();
            this.textBox_Status = new System.Windows.Forms.RichTextBox();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FileConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FilePartition = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FileSaveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FileDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_FileArchive = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FileArchiveExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FileArchiveImport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FileArchiveOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_FileArchiveSetLocation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_EditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_EditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Search = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SearchFind = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SearchFindNext = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SearchFindPrevious = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_View = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ViewLineNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ViewIndentionGuides = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ViewMargin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ViewFoldMargin = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ViewWordWrap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ViewWhiteSpace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ViewEndOfLine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ViewBookmarks = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ViewChangeIndentionSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_ViewAutoComplete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ViewHotspots = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_ViewStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Tools = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ToolsDataGroupEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ToolsLogViewer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ToolsShare = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ToolsGenerateTraffic = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_ToolsCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ToolsConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ToolsReloadConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ToolsResetConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ToolsEditConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ToolsBIGIPConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ToolsBIGIPConfigSaveConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_ToolsBIGIPConfigAutoSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_HelpiRuler = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_HelpDevCentral = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_HelpForums = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_HelpiRulesReference = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_HelpTCLReference = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_HelpTipOfTheDay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_HelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Connect = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_DataGroups = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_GenerateTraffic = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_DevCentral = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_DevCentralForums = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Wiki = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_TCL = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panelx = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusStripLabel_Connection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Line = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Column = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_Character = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_Middle = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ToolStripMenuItem_FileFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_TreeViewToolbar.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.contextMenuStrip_TreeView.SuspendLayout();
            this.panel_TreeView.SuspendLayout();
            this.panel_Top.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.panelx.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panel_Middle.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_TreeViewToolbar
            // 
            this.panel_TreeViewToolbar.Controls.Add(this.toolStrip2);
            this.panel_TreeViewToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_TreeViewToolbar.Location = new System.Drawing.Point(0, 0);
            this.panel_TreeViewToolbar.Name = "panel_TreeViewToolbar";
            this.panel_TreeViewToolbar.Size = new System.Drawing.Size(140, 29);
            this.panel_TreeViewToolbar.TabIndex = 5;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_New,
            this.toolStripButton_Save,
            this.toolStripButton_Delete,
            this.toolStripButton_Share,
            this.toolStripButton_CheckSyntax,
            this.toolStripButton_RefreshList});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(140, 29);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton_New
            // 
            this.toolStripButton_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_New.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_New.Image")));
            this.toolStripButton_New.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_New.Name = "toolStripButton_New";
            this.toolStripButton_New.Size = new System.Drawing.Size(23, 26);
            this.toolStripButton_New.Text = "Create a new iRule";
            this.toolStripButton_New.Click += new System.EventHandler(this.toolStripButton_New_Click);
            // 
            // toolStripButton_Save
            // 
            this.toolStripButton_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Save.Image = global::iRuler.Properties.Resources.ToolbarSave;
            this.toolStripButton_Save.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Save.Name = "toolStripButton_Save";
            this.toolStripButton_Save.Size = new System.Drawing.Size(23, 26);
            this.toolStripButton_Save.Text = "Save the current iRule";
            this.toolStripButton_Save.Click += new System.EventHandler(this.toolStripButton_Save_Click);
            // 
            // toolStripButton_Delete
            // 
            this.toolStripButton_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Delete.Image = global::iRuler.Properties.Resources.ToolbarDelete;
            this.toolStripButton_Delete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Delete.Name = "toolStripButton_Delete";
            this.toolStripButton_Delete.Size = new System.Drawing.Size(23, 26);
            this.toolStripButton_Delete.Text = "Delete the current iRule";
            this.toolStripButton_Delete.Click += new System.EventHandler(this.toolStripButton_Delete_Click);
            // 
            // toolStripButton_Share
            // 
            this.toolStripButton_Share.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Share.Image = global::iRuler.Properties.Resources.ToolbarShare;
            this.toolStripButton_Share.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Share.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Share.Name = "toolStripButton_Share";
            this.toolStripButton_Share.Size = new System.Drawing.Size(23, 26);
            this.toolStripButton_Share.Text = "Share your iRule with the DevCentral Community!";
            this.toolStripButton_Share.Click += new System.EventHandler(this.toolStripButton_Share_Click);
            // 
            // toolStripButton_CheckSyntax
            // 
            this.toolStripButton_CheckSyntax.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_CheckSyntax.Image = global::iRuler.Properties.Resources.ToolbarCheckSyntax;
            this.toolStripButton_CheckSyntax.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_CheckSyntax.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_CheckSyntax.Name = "toolStripButton_CheckSyntax";
            this.toolStripButton_CheckSyntax.Size = new System.Drawing.Size(23, 26);
            this.toolStripButton_CheckSyntax.Text = "Check the syntax of the current iRule";
            this.toolStripButton_CheckSyntax.Click += new System.EventHandler(this.toolStripButton_CheckSyntax_Click);
            // 
            // toolStripButton_RefreshList
            // 
            this.toolStripButton_RefreshList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_RefreshList.Image = global::iRuler.Properties.Resources.ToolbarRefresh;
            this.toolStripButton_RefreshList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_RefreshList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_RefreshList.Name = "toolStripButton_RefreshList";
            this.toolStripButton_RefreshList.Size = new System.Drawing.Size(23, 26);
            this.toolStripButton_RefreshList.Text = "Refresh the list of iRules";
            this.toolStripButton_RefreshList.Click += new System.EventHandler(this.toolStripButton_RefreshList_Click);
            // 
            // treeView_iRules
            // 
            this.treeView_iRules.AllowDrop = true;
            this.treeView_iRules.ContextMenuStrip = this.contextMenuStrip_TreeView;
            this.treeView_iRules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_iRules.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView_iRules.FullRowSelect = true;
            this.treeView_iRules.ImageIndex = 0;
            this.treeView_iRules.ImageList = this.imageList_TreeView;
            this.treeView_iRules.Location = new System.Drawing.Point(0, 0);
            this.treeView_iRules.Name = "treeView_iRules";
            this.treeView_iRules.SelectedImageIndex = 0;
            this.treeView_iRules.ShowNodeToolTips = true;
            this.treeView_iRules.Size = new System.Drawing.Size(140, 522);
            this.treeView_iRules.TabIndex = 3;
            this.treeView_iRules.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeView_iRules_ItemDrag);
            this.treeView_iRules.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_iRules_AfterSelect);
            this.treeView_iRules.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_iRules_NodeMouseClick);
            this.treeView_iRules.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_iRules_NodeMouseDoubleClick);
            this.treeView_iRules.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView_iRules_DragDrop);
            this.treeView_iRules.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeView_iRules_DragEnter);
            this.treeView_iRules.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView_iRules_DragOver);
            this.treeView_iRules.DragLeave += new System.EventHandler(this.treeView_iRules_DragLeave);
            // 
            // contextMenuStrip_TreeView
            // 
            this.contextMenuStrip_TreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Save,
            this.toolStripMenuItem_Delete,
            this.toolStripMenuItem_CheckSyntax,
            this.toolStripMenuItem_Share,
            this.toolStripMenuItem_Reset,
            this.toolStripMenuItem_Reload,
            this.toolStripMenuItem_CopyOffline,
            this.toolStripSeparator2,
            this.toolStripMenuItem_Properties});
            this.contextMenuStrip_TreeView.Name = "contextMenuStrip_TreeView";
            this.contextMenuStrip_TreeView.Size = new System.Drawing.Size(145, 186);
            this.contextMenuStrip_TreeView.Opened += new System.EventHandler(this.contextMenuStrip_TreeView_Opened);
            // 
            // toolStripMenuItem_Save
            // 
            this.toolStripMenuItem_Save.Image = global::iRuler.Properties.Resources.ToolbarSave;
            this.toolStripMenuItem_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_Save.Name = "toolStripMenuItem_Save";
            this.toolStripMenuItem_Save.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_Save.Text = "&Save";
            this.toolStripMenuItem_Save.Click += new System.EventHandler(this.toolStripMenuItem_Save_Click);
            // 
            // toolStripMenuItem_Delete
            // 
            this.toolStripMenuItem_Delete.Image = global::iRuler.Properties.Resources.ToolbarDelete;
            this.toolStripMenuItem_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_Delete.Name = "toolStripMenuItem_Delete";
            this.toolStripMenuItem_Delete.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_Delete.Text = "&Delete";
            this.toolStripMenuItem_Delete.Click += new System.EventHandler(this.toolStripMenuItem_Delete_Click);
            // 
            // toolStripMenuItem_CheckSyntax
            // 
            this.toolStripMenuItem_CheckSyntax.Image = global::iRuler.Properties.Resources.ToolbarCheckSyntax;
            this.toolStripMenuItem_CheckSyntax.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_CheckSyntax.Name = "toolStripMenuItem_CheckSyntax";
            this.toolStripMenuItem_CheckSyntax.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_CheckSyntax.Text = "&Check Syntax";
            this.toolStripMenuItem_CheckSyntax.Click += new System.EventHandler(this.toolStripMenuItem_CheckSyntax_Click);
            // 
            // toolStripMenuItem_Share
            // 
            this.toolStripMenuItem_Share.Image = global::iRuler.Properties.Resources.ToolbarShare;
            this.toolStripMenuItem_Share.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_Share.Name = "toolStripMenuItem_Share";
            this.toolStripMenuItem_Share.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_Share.Text = "S&hare";
            this.toolStripMenuItem_Share.Click += new System.EventHandler(this.toolStripMenuItem_Share_Click);
            // 
            // toolStripMenuItem_Reset
            // 
            this.toolStripMenuItem_Reset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_Reset.Name = "toolStripMenuItem_Reset";
            this.toolStripMenuItem_Reset.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_Reset.Text = "&Reset";
            this.toolStripMenuItem_Reset.Click += new System.EventHandler(this.toolStripMenuItem_Reset_Click);
            // 
            // toolStripMenuItem_Reload
            // 
            this.toolStripMenuItem_Reload.Name = "toolStripMenuItem_Reload";
            this.toolStripMenuItem_Reload.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_Reload.Text = "Re&load";
            this.toolStripMenuItem_Reload.Click += new System.EventHandler(this.toolStripMenuItem_Reload_Click);
            // 
            // toolStripMenuItem_CopyOffline
            // 
            this.toolStripMenuItem_CopyOffline.Image = global::iRuler.Properties.Resources.ToolbarConnect;
            this.toolStripMenuItem_CopyOffline.Name = "toolStripMenuItem_CopyOffline";
            this.toolStripMenuItem_CopyOffline.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_CopyOffline.Text = "Copy &Offline";
            this.toolStripMenuItem_CopyOffline.Click += new System.EventHandler(this.toolStripMenuItem_CopyOffline_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(141, 6);
            // 
            // toolStripMenuItem_Properties
            // 
            this.toolStripMenuItem_Properties.Image = global::iRuler.Properties.Resources.ToolbarProperties;
            this.toolStripMenuItem_Properties.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_Properties.Name = "toolStripMenuItem_Properties";
            this.toolStripMenuItem_Properties.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem_Properties.Text = "&Properties";
            this.toolStripMenuItem_Properties.Click += new System.EventHandler(this.toolStripMenuItem_Properties_Click);
            // 
            // imageList_TreeView
            // 
            this.imageList_TreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_TreeView.ImageStream")));
            this.imageList_TreeView.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList_TreeView.Images.SetKeyName(0, "Toolbar-iRule.bmp");
            this.imageList_TreeView.Images.SetKeyName(1, "Toolbar-LocalLB.bmp");
            this.imageList_TreeView.Images.SetKeyName(2, "Toolbar-GlobalLB.bmp");
            this.imageList_TreeView.Images.SetKeyName(3, "Toolbar-Document.bmp");
            this.imageList_TreeView.Images.SetKeyName(4, "Toolbar-Config.bmp");
            this.imageList_TreeView.Images.SetKeyName(5, "Toolbar-Connect.bmp");
            // 
            // panel_TreeView
            // 
            this.panel_TreeView.Controls.Add(this.treeView_iRules);
            this.panel_TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_TreeView.Location = new System.Drawing.Point(0, 29);
            this.panel_TreeView.Name = "panel_TreeView";
            this.panel_TreeView.Size = new System.Drawing.Size(140, 522);
            this.panel_TreeView.TabIndex = 4;
            // 
            // m_textEditor
            // 
            this.m_textEditor.AnchorPosition = 0;
            this.m_textEditor.BackSpaceUnIndents = false;
            this.m_textEditor.BufferedDraw = true;
            this.m_textEditor.CaretForeground = 0;
            this.m_textEditor.CaretLineBackground = 65535;
            this.m_textEditor.CaretLineVisible = false;
            this.m_textEditor.CaretPeriod = 500;
            this.m_textEditor.CaretWidth = 1;
            this.m_textEditor.CodePage = 0;
            this.m_textEditor.Configuration = null;
            this.m_textEditor.ConfigurationLanguage = "";
            this.m_textEditor.ControlCharSymbol = 0;
            this.m_textEditor.CurrentPos = 0;
            this.m_textEditor.CursorType = -1;
            this.m_textEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_textEditor.EdgeColour = 12632256;
            this.m_textEditor.EdgeColumn = 0;
            this.m_textEditor.EdgeMode = 0;
            this.m_textEditor.EndAtLastLine = true;
            this.m_textEditor.EOLCharactersVisible = false;
            this.m_textEditor.EOLMode = 0;
            this.m_textEditor.focus = false;
            this.m_textEditor.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_textEditor.HighlightGuide = 0;
            this.m_textEditor.HorizontalScrollBarVisible = true;
            this.m_textEditor.Indent = 0;
            this.m_textEditor.IndentationGuidesVisible = false;
            this.m_textEditor.LayoutCache = 1;
            this.m_textEditor.Lexer = scintilla.Lexer.container;
            this.m_textEditor.LexerLanguage = null;
            this.m_textEditor.Location = new System.Drawing.Point(0, 0);
            this.m_textEditor.MarginLeft = 0;
            this.m_textEditor.MarginRight = 0;
            this.m_textEditor.ModEventMask = 3959;
            this.m_textEditor.MouseDownCaptures = true;
            this.m_textEditor.MouseDwellTime = 10000000;
            this.m_textEditor.Name = "m_textEditor";
            this.m_textEditor.Overtype = false;
            this.m_textEditor.PrintColourMode = 0;
            this.m_textEditor.PrintMagnification = 0;
            this.m_textEditor.PrintWrapMode = 1;
            this.m_textEditor.ReadOnly = false;
            this.m_textEditor.ScrollWidth = 2000;
            this.m_textEditor.SearchFlags = 0;
            this.m_textEditor.SelectionEnd = 0;
            this.m_textEditor.SelectionStart = 0;
            this.m_textEditor.Size = new System.Drawing.Size(516, 506);
            this.m_textEditor.Status = 0;
            this.m_textEditor.StyleBits = 5;
            this.m_textEditor.TabIndents = true;
            this.m_textEditor.TabIndex = 0;
            this.m_textEditor.TabWidth = 4;
            this.m_textEditor.TargetEnd = 0;
            this.m_textEditor.TargetStart = 0;
            this.m_textEditor.UsePalette = false;
            this.m_textEditor.UseTabs = true;
            this.m_textEditor.VerticalScrollBarVisible = true;
            this.m_textEditor.WhitespaceVisibleState = 0;
            this.m_textEditor.WrapMode = 0;
            this.m_textEditor.XOffset = 0;
            this.m_textEditor.ZoomLevel = 0;
            this.m_textEditor.HotSpotClick += new scintilla.HotSpotClickHandler(this.m_textEditor_HotSpotClick);
            this.m_textEditor.DwellStart += new scintilla.DwellStartHandler(this.m_textEditor_DwellStart);
            this.m_textEditor.MarginClick += new scintilla.MarginClickHandler(this.m_textEditor_MarginClick);
            this.m_textEditor.Modified += new scintilla.ModifiedHandler(this.m_textEditor_Modified);
            this.m_textEditor.UpdateUI += new scintilla.UpdateUIHandler(this.m_textEditor_UpdateUI);
            this.m_textEditor.CharAdded += new scintilla.CharAddedHandler(this.m_textEditor_CharAdded);
            // 
            // textBox_Status
            // 
            this.textBox_Status.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Status.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.textBox_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Status.Location = new System.Drawing.Point(0, 0);
            this.textBox_Status.Name = "textBox_Status";
            this.textBox_Status.ReadOnly = true;
            this.textBox_Status.Size = new System.Drawing.Size(516, 41);
            this.textBox_Status.TabIndex = 0;
            this.textBox_Status.Text = "Disconnected";
            this.textBox_Status.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox_Status_MouseClick);
            // 
            // panel_Top
            // 
            this.panel_Top.BackColor = System.Drawing.SystemColors.Control;
            this.panel_Top.Controls.Add(this.menuStrip1);
            this.panel_Top.Controls.Add(this.toolStrip1);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(660, 51);
            this.panel_Top.TabIndex = 8;
            this.panel_Top.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Top_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_File,
            this.toolStripMenuItem_Edit,
            this.toolStripMenuItem_Search,
            this.toolStripMenuItem_View,
            this.toolStripMenuItem_Tools,
            this.toolStripMenuItem_Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(660, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem_File
            // 
            this.toolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_FileConnect,
            this.toolStripMenuItem_FilePartition,
            this.ToolStripMenuItem_FileFolder,
            this.toolStripMenuItem_FileNew,
            this.toolStripMenuItem_FileSave,
            this.toolStripMenuItem_FileSaveAll,
            this.toolStripMenuItem_FileDelete,
            this.toolStripSeparator4,
            this.toolStripMenuItem_FileArchive,
            this.toolStripSeparator5,
            this.toolStripMenuItem_Exit});
            this.toolStripMenuItem_File.Name = "toolStripMenuItem_File";
            this.toolStripMenuItem_File.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.toolStripMenuItem_File.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem_File.Text = "&File";
            // 
            // toolStripMenuItem_FileConnect
            // 
            this.toolStripMenuItem_FileConnect.Image = global::iRuler.Properties.Resources.ToolbarConnect;
            this.toolStripMenuItem_FileConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_FileConnect.Name = "toolStripMenuItem_FileConnect";
            this.toolStripMenuItem_FileConnect.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.toolStripMenuItem_FileConnect.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_FileConnect.Text = "&Connect";
            this.toolStripMenuItem_FileConnect.Click += new System.EventHandler(this.toolStripMenuItem_FileConnect_Click);
            // 
            // toolStripMenuItem_FilePartition
            // 
            this.toolStripMenuItem_FilePartition.Enabled = false;
            this.toolStripMenuItem_FilePartition.Name = "toolStripMenuItem_FilePartition";
            this.toolStripMenuItem_FilePartition.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_FilePartition.Text = "&Partition";
            // 
            // toolStripMenuItem_FileNew
            // 
            this.toolStripMenuItem_FileNew.Image = global::iRuler.Properties.Resources.ToolbarNew;
            this.toolStripMenuItem_FileNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_FileNew.Name = "toolStripMenuItem_FileNew";
            this.toolStripMenuItem_FileNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.toolStripMenuItem_FileNew.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_FileNew.Text = "&New";
            this.toolStripMenuItem_FileNew.Click += new System.EventHandler(this.toolStripMenuItem_FileNew_Click);
            // 
            // toolStripMenuItem_FileSave
            // 
            this.toolStripMenuItem_FileSave.Image = global::iRuler.Properties.Resources.ToolbarSave;
            this.toolStripMenuItem_FileSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_FileSave.Name = "toolStripMenuItem_FileSave";
            this.toolStripMenuItem_FileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem_FileSave.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_FileSave.Text = "&Save";
            this.toolStripMenuItem_FileSave.Click += new System.EventHandler(this.toolStripMenuItem_FileSave_Click);
            // 
            // toolStripMenuItem_FileSaveAll
            // 
            this.toolStripMenuItem_FileSaveAll.Image = global::iRuler.Properties.Resources.ToolbarSaveAll;
            this.toolStripMenuItem_FileSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_FileSaveAll.Name = "toolStripMenuItem_FileSaveAll";
            this.toolStripMenuItem_FileSaveAll.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_FileSaveAll.Text = "Save &All";
            this.toolStripMenuItem_FileSaveAll.Click += new System.EventHandler(this.toolStripMenuItem_FileSaveAll_Click);
            // 
            // toolStripMenuItem_FileDelete
            // 
            this.toolStripMenuItem_FileDelete.Image = global::iRuler.Properties.Resources.ToolbarDelete;
            this.toolStripMenuItem_FileDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_FileDelete.Name = "toolStripMenuItem_FileDelete";
            this.toolStripMenuItem_FileDelete.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_FileDelete.Text = "&Delete";
            this.toolStripMenuItem_FileDelete.Click += new System.EventHandler(this.toolStripMenuItem_FileDelete_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem_FileArchive
            // 
            this.toolStripMenuItem_FileArchive.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_FileArchiveExport,
            this.toolStripMenuItem_FileArchiveImport,
            this.toolStripMenuItem_FileArchiveOpen,
            this.toolStripMenuItem_FileArchiveSetLocation});
            this.toolStripMenuItem_FileArchive.Image = global::iRuler.Properties.Resources.ToolbarArchive;
            this.toolStripMenuItem_FileArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_FileArchive.Name = "toolStripMenuItem_FileArchive";
            this.toolStripMenuItem_FileArchive.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_FileArchive.Text = "A&rchive";
            // 
            // toolStripMenuItem_FileArchiveExport
            // 
            this.toolStripMenuItem_FileArchiveExport.Name = "toolStripMenuItem_FileArchiveExport";
            this.toolStripMenuItem_FileArchiveExport.Size = new System.Drawing.Size(227, 22);
            this.toolStripMenuItem_FileArchiveExport.Text = "&Export";
            this.toolStripMenuItem_FileArchiveExport.Click += new System.EventHandler(this.toolStripMenuItem_FileArchiveExport_Click);
            // 
            // toolStripMenuItem_FileArchiveImport
            // 
            this.toolStripMenuItem_FileArchiveImport.Name = "toolStripMenuItem_FileArchiveImport";
            this.toolStripMenuItem_FileArchiveImport.Size = new System.Drawing.Size(227, 22);
            this.toolStripMenuItem_FileArchiveImport.Text = "&Import";
            this.toolStripMenuItem_FileArchiveImport.Click += new System.EventHandler(this.toolStripMenuItem_FileArchiveImport_Click);
            // 
            // toolStripMenuItem_FileArchiveOpen
            // 
            this.toolStripMenuItem_FileArchiveOpen.Image = global::iRuler.Properties.Resources.ToolbarFolder;
            this.toolStripMenuItem_FileArchiveOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_FileArchiveOpen.Name = "toolStripMenuItem_FileArchiveOpen";
            this.toolStripMenuItem_FileArchiveOpen.Size = new System.Drawing.Size(227, 22);
            this.toolStripMenuItem_FileArchiveOpen.Text = "&Open Archive Folder";
            this.toolStripMenuItem_FileArchiveOpen.Click += new System.EventHandler(this.toolStripMenuItem_FileArchiveOpen_Click);
            // 
            // toolStripMenuItem_FileArchiveSetLocation
            // 
            this.toolStripMenuItem_FileArchiveSetLocation.Name = "toolStripMenuItem_FileArchiveSetLocation";
            this.toolStripMenuItem_FileArchiveSetLocation.Size = new System.Drawing.Size(227, 22);
            this.toolStripMenuItem_FileArchiveSetLocation.Text = "&Set Archive Folder Location...";
            this.toolStripMenuItem_FileArchiveSetLocation.Click += new System.EventHandler(this.toolStripMenuItem_FileArchiveSetLocation_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(149, 6);
            // 
            // toolStripMenuItem_Exit
            // 
            this.toolStripMenuItem_Exit.Name = "toolStripMenuItem_Exit";
            this.toolStripMenuItem_Exit.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem_Exit.Text = "E&xit";
            this.toolStripMenuItem_Exit.Click += new System.EventHandler(this.toolStripMenuItem_Exit_Click);
            // 
            // toolStripMenuItem_Edit
            // 
            this.toolStripMenuItem_Edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_EditUndo,
            this.toolStripMenuItem_EditRedo,
            this.toolStripSeparator6,
            this.toolStripMenuItem_EditCut,
            this.toolStripMenuItem_EditCopy,
            this.toolStripMenuItem_EditPaste,
            this.toolStripMenuItem_EditDelete,
            this.toolStripSeparator7,
            this.toolStripMenuItem_EditSelectAll});
            this.toolStripMenuItem_Edit.Name = "toolStripMenuItem_Edit";
            this.toolStripMenuItem_Edit.Size = new System.Drawing.Size(39, 20);
            this.toolStripMenuItem_Edit.Text = "&Edit";
            // 
            // toolStripMenuItem_EditUndo
            // 
            this.toolStripMenuItem_EditUndo.Image = global::iRuler.Properties.Resources.ToolbarUndo;
            this.toolStripMenuItem_EditUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_EditUndo.Name = "toolStripMenuItem_EditUndo";
            this.toolStripMenuItem_EditUndo.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_EditUndo.Text = "&Undo";
            this.toolStripMenuItem_EditUndo.Click += new System.EventHandler(this.toolStripMenuItem_EditUndo_Click);
            // 
            // toolStripMenuItem_EditRedo
            // 
            this.toolStripMenuItem_EditRedo.Image = global::iRuler.Properties.Resources.ToolbarRedo;
            this.toolStripMenuItem_EditRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_EditRedo.Name = "toolStripMenuItem_EditRedo";
            this.toolStripMenuItem_EditRedo.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_EditRedo.Text = "&Redo";
            this.toolStripMenuItem_EditRedo.Click += new System.EventHandler(this.toolStripMenuItem_EditRedo_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(119, 6);
            // 
            // toolStripMenuItem_EditCut
            // 
            this.toolStripMenuItem_EditCut.Image = global::iRuler.Properties.Resources.ToolbarCut;
            this.toolStripMenuItem_EditCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_EditCut.Name = "toolStripMenuItem_EditCut";
            this.toolStripMenuItem_EditCut.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_EditCut.Text = "&Cut";
            this.toolStripMenuItem_EditCut.Click += new System.EventHandler(this.toolStripMenuItem_EditCut_Click);
            // 
            // toolStripMenuItem_EditCopy
            // 
            this.toolStripMenuItem_EditCopy.Image = global::iRuler.Properties.Resources.ToolbarCopy;
            this.toolStripMenuItem_EditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_EditCopy.Name = "toolStripMenuItem_EditCopy";
            this.toolStripMenuItem_EditCopy.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_EditCopy.Text = "&Copy";
            this.toolStripMenuItem_EditCopy.Click += new System.EventHandler(this.toolStripMenuItem_EditCopy_Click);
            // 
            // toolStripMenuItem_EditPaste
            // 
            this.toolStripMenuItem_EditPaste.Image = global::iRuler.Properties.Resources.ToolbarPaste;
            this.toolStripMenuItem_EditPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_EditPaste.Name = "toolStripMenuItem_EditPaste";
            this.toolStripMenuItem_EditPaste.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_EditPaste.Text = "&Paste";
            this.toolStripMenuItem_EditPaste.Click += new System.EventHandler(this.toolStripMenuItem_EditPaste_Click);
            // 
            // toolStripMenuItem_EditDelete
            // 
            this.toolStripMenuItem_EditDelete.Image = global::iRuler.Properties.Resources.ToolbarDelete;
            this.toolStripMenuItem_EditDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_EditDelete.Name = "toolStripMenuItem_EditDelete";
            this.toolStripMenuItem_EditDelete.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_EditDelete.Text = "&Delete";
            this.toolStripMenuItem_EditDelete.Click += new System.EventHandler(this.toolStripMenuItem_EditDelete_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(119, 6);
            // 
            // toolStripMenuItem_EditSelectAll
            // 
            this.toolStripMenuItem_EditSelectAll.Name = "toolStripMenuItem_EditSelectAll";
            this.toolStripMenuItem_EditSelectAll.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_EditSelectAll.Text = "Select &All";
            this.toolStripMenuItem_EditSelectAll.Click += new System.EventHandler(this.toolStripMenuItem_EditSelectAll_Click);
            // 
            // toolStripMenuItem_Search
            // 
            this.toolStripMenuItem_Search.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_SearchFind,
            this.toolStripMenuItem_SearchFindNext,
            this.toolStripMenuItem_SearchFindPrevious});
            this.toolStripMenuItem_Search.Name = "toolStripMenuItem_Search";
            this.toolStripMenuItem_Search.Size = new System.Drawing.Size(54, 20);
            this.toolStripMenuItem_Search.Text = "&Search";
            // 
            // toolStripMenuItem_SearchFind
            // 
            this.toolStripMenuItem_SearchFind.Image = global::iRuler.Properties.Resources.ToolbarFind;
            this.toolStripMenuItem_SearchFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_SearchFind.Name = "toolStripMenuItem_SearchFind";
            this.toolStripMenuItem_SearchFind.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.toolStripMenuItem_SearchFind.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem_SearchFind.Text = "&Find...";
            this.toolStripMenuItem_SearchFind.Click += new System.EventHandler(this.toolStripMenuItem_SearchFind_Click);
            // 
            // toolStripMenuItem_SearchFindNext
            // 
            this.toolStripMenuItem_SearchFindNext.Name = "toolStripMenuItem_SearchFindNext";
            this.toolStripMenuItem_SearchFindNext.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.toolStripMenuItem_SearchFindNext.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem_SearchFindNext.Text = "Find &Next";
            this.toolStripMenuItem_SearchFindNext.Click += new System.EventHandler(this.toolStripMenuItem_SearchFindNext_Click);
            // 
            // toolStripMenuItem_SearchFindPrevious
            // 
            this.toolStripMenuItem_SearchFindPrevious.Name = "toolStripMenuItem_SearchFindPrevious";
            this.toolStripMenuItem_SearchFindPrevious.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F3)));
            this.toolStripMenuItem_SearchFindPrevious.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem_SearchFindPrevious.Text = "Find Previou&s";
            this.toolStripMenuItem_SearchFindPrevious.Click += new System.EventHandler(this.toolStripMenuItem_SearchFindPrevious_Click);
            // 
            // toolStripMenuItem_View
            // 
            this.toolStripMenuItem_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ViewLineNumbers,
            this.toolStripMenuItem_ViewIndentionGuides,
            this.toolStripMenuItem_ViewMargin,
            this.toolStripMenuItem_ViewFoldMargin,
            this.toolStripMenuItem_ViewWordWrap,
            this.toolStripMenuItem_ViewWhiteSpace,
            this.toolStripMenuItem_ViewEndOfLine,
            this.toolStripMenuItem_ViewBookmarks,
            this.ToolStripMenuItem_ViewChangeIndentionSettings,
            this.toolStripSeparator8,
            this.toolStripMenuItem_ViewAutoComplete,
            this.toolStripMenuItem_ViewHotspots,
            this.toolStripSeparator9,
            this.toolStripMenuItem_ViewStatus});
            this.toolStripMenuItem_View.Name = "toolStripMenuItem_View";
            this.toolStripMenuItem_View.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem_View.Text = "&View";
            // 
            // toolStripMenuItem_ViewLineNumbers
            // 
            this.toolStripMenuItem_ViewLineNumbers.Name = "toolStripMenuItem_ViewLineNumbers";
            this.toolStripMenuItem_ViewLineNumbers.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.toolStripMenuItem_ViewLineNumbers.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItem_ViewLineNumbers.Text = "&Line Numbers";
            this.toolStripMenuItem_ViewLineNumbers.Click += new System.EventHandler(this.toolStripMenuItem_ViewLineNumbers_Click);
            // 
            // toolStripMenuItem_ViewIndentionGuides
            // 
            this.toolStripMenuItem_ViewIndentionGuides.Name = "toolStripMenuItem_ViewIndentionGuides";
            this.toolStripMenuItem_ViewIndentionGuides.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.toolStripMenuItem_ViewIndentionGuides.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItem_ViewIndentionGuides.Text = "&Indention Guides";
            this.toolStripMenuItem_ViewIndentionGuides.Click += new System.EventHandler(this.toolStripMenuItem_ViewIndentionGuides_Click);
            // 
            // toolStripMenuItem_ViewMargin
            // 
            this.toolStripMenuItem_ViewMargin.Name = "toolStripMenuItem_ViewMargin";
            this.toolStripMenuItem_ViewMargin.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.toolStripMenuItem_ViewMargin.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItem_ViewMargin.Text = "&Margin";
            this.toolStripMenuItem_ViewMargin.Click += new System.EventHandler(this.toolStripMenuItem_ViewMargin_Click);
            // 
            // toolStripMenuItem_ViewFoldMargin
            // 
            this.toolStripMenuItem_ViewFoldMargin.Name = "toolStripMenuItem_ViewFoldMargin";
            this.toolStripMenuItem_ViewFoldMargin.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.toolStripMenuItem_ViewFoldMargin.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItem_ViewFoldMargin.Text = "&Fold Margin";
            this.toolStripMenuItem_ViewFoldMargin.Click += new System.EventHandler(this.toolStripMenuItem_ViewFoldMargin_Click);
            // 
            // toolStripMenuItem_ViewWordWrap
            // 
            this.toolStripMenuItem_ViewWordWrap.Name = "toolStripMenuItem_ViewWordWrap";
            this.toolStripMenuItem_ViewWordWrap.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.toolStripMenuItem_ViewWordWrap.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItem_ViewWordWrap.Text = "Word W&rap";
            this.toolStripMenuItem_ViewWordWrap.Click += new System.EventHandler(this.toolStripMenuItem_ViewWordWrap_Click);
            // 
            // toolStripMenuItem_ViewWhiteSpace
            // 
            this.toolStripMenuItem_ViewWhiteSpace.Name = "toolStripMenuItem_ViewWhiteSpace";
            this.toolStripMenuItem_ViewWhiteSpace.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItem_ViewWhiteSpace.Text = "&Whitespace";
            this.toolStripMenuItem_ViewWhiteSpace.Click += new System.EventHandler(this.toolStripMenuItem_ViewWhiteSpace_Click);
            // 
            // toolStripMenuItem_ViewEndOfLine
            // 
            this.toolStripMenuItem_ViewEndOfLine.Name = "toolStripMenuItem_ViewEndOfLine";
            this.toolStripMenuItem_ViewEndOfLine.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItem_ViewEndOfLine.Text = "&End of Line";
            this.toolStripMenuItem_ViewEndOfLine.Click += new System.EventHandler(this.toolStripMenuItem_ViewEndOfLine_Click);
            // 
            // toolStripMenuItem_ViewBookmarks
            // 
            this.toolStripMenuItem_ViewBookmarks.Name = "toolStripMenuItem_ViewBookmarks";
            this.toolStripMenuItem_ViewBookmarks.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItem_ViewBookmarks.Text = "&Bookmarks";
            this.toolStripMenuItem_ViewBookmarks.Click += new System.EventHandler(this.toolStripMenuItem_ViewBookmarks_Click);
            // 
            // ToolStripMenuItem_ViewChangeIndentionSettings
            // 
            this.ToolStripMenuItem_ViewChangeIndentionSettings.Name = "ToolStripMenuItem_ViewChangeIndentionSettings";
            this.ToolStripMenuItem_ViewChangeIndentionSettings.Size = new System.Drawing.Size(223, 22);
            this.ToolStripMenuItem_ViewChangeIndentionSettings.Text = "Change I&ndention Settings...";
            this.ToolStripMenuItem_ViewChangeIndentionSettings.Click += new System.EventHandler(this.ToolStripMenuItem_ViewChangeIndentionSettings_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(220, 6);
            // 
            // toolStripMenuItem_ViewAutoComplete
            // 
            this.toolStripMenuItem_ViewAutoComplete.Name = "toolStripMenuItem_ViewAutoComplete";
            this.toolStripMenuItem_ViewAutoComplete.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItem_ViewAutoComplete.Text = "&Auto Complete";
            this.toolStripMenuItem_ViewAutoComplete.Click += new System.EventHandler(this.toolStripMenuItem_ViewAutoComplete_Click);
            // 
            // toolStripMenuItem_ViewHotspots
            // 
            this.toolStripMenuItem_ViewHotspots.Name = "toolStripMenuItem_ViewHotspots";
            this.toolStripMenuItem_ViewHotspots.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.toolStripMenuItem_ViewHotspots.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItem_ViewHotspots.Text = "&Hotspots";
            this.toolStripMenuItem_ViewHotspots.Click += new System.EventHandler(this.toolStripMenuItem_ViewHotspots_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(220, 6);
            // 
            // toolStripMenuItem_ViewStatus
            // 
            this.toolStripMenuItem_ViewStatus.Name = "toolStripMenuItem_ViewStatus";
            this.toolStripMenuItem_ViewStatus.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.toolStripMenuItem_ViewStatus.Size = new System.Drawing.Size(223, 22);
            this.toolStripMenuItem_ViewStatus.Text = "&Status";
            this.toolStripMenuItem_ViewStatus.Click += new System.EventHandler(this.toolStripMenuItem_ViewStatus_Click);
            // 
            // toolStripMenuItem_Tools
            // 
            this.toolStripMenuItem_Tools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ToolsDataGroupEditor,
            this.toolStripMenuItem_ToolsLogViewer,
            this.toolStripMenuItem_ToolsShare,
            this.toolStripMenuItem_ToolsGenerateTraffic,
            this.toolStripSeparator10,
            this.toolStripMenuItem_ToolsCheckForUpdates,
            this.ToolStripMenuItem_ToolsConfig,
            this.ToolStripMenuItem_ToolsBIGIPConfig});
            this.toolStripMenuItem_Tools.Name = "toolStripMenuItem_Tools";
            this.toolStripMenuItem_Tools.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem_Tools.Text = "&Tools";
            // 
            // toolStripMenuItem_ToolsDataGroupEditor
            // 
            this.toolStripMenuItem_ToolsDataGroupEditor.Image = global::iRuler.Properties.Resources.ToolbarDataGroups;
            this.toolStripMenuItem_ToolsDataGroupEditor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_ToolsDataGroupEditor.Name = "toolStripMenuItem_ToolsDataGroupEditor";
            this.toolStripMenuItem_ToolsDataGroupEditor.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItem_ToolsDataGroupEditor.Text = "&Data Group Editor...";
            this.toolStripMenuItem_ToolsDataGroupEditor.Click += new System.EventHandler(this.toolStripMenuItem_ToolsDataGroupEditor_Click);
            // 
            // toolStripMenuItem_ToolsLogViewer
            // 
            this.toolStripMenuItem_ToolsLogViewer.Name = "toolStripMenuItem_ToolsLogViewer";
            this.toolStripMenuItem_ToolsLogViewer.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItem_ToolsLogViewer.Text = "&Log Viewer...";
            this.toolStripMenuItem_ToolsLogViewer.Visible = false;
            this.toolStripMenuItem_ToolsLogViewer.Click += new System.EventHandler(this.toolStripMenuItem_ToolsLogViewer_Click);
            // 
            // toolStripMenuItem_ToolsShare
            // 
            this.toolStripMenuItem_ToolsShare.Image = global::iRuler.Properties.Resources.ToolbarShare;
            this.toolStripMenuItem_ToolsShare.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_ToolsShare.Name = "toolStripMenuItem_ToolsShare";
            this.toolStripMenuItem_ToolsShare.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItem_ToolsShare.Text = "&Share your iRule...";
            this.toolStripMenuItem_ToolsShare.Click += new System.EventHandler(this.toolStripMenuItem_ToolsShare_Click);
            // 
            // toolStripMenuItem_ToolsGenerateTraffic
            // 
            this.toolStripMenuItem_ToolsGenerateTraffic.Image = global::iRuler.Properties.Resources.ToolbarTraffic;
            this.toolStripMenuItem_ToolsGenerateTraffic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_ToolsGenerateTraffic.Name = "toolStripMenuItem_ToolsGenerateTraffic";
            this.toolStripMenuItem_ToolsGenerateTraffic.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItem_ToolsGenerateTraffic.Text = "&Generate Traffic";
            this.toolStripMenuItem_ToolsGenerateTraffic.Click += new System.EventHandler(this.toolStripMenuItem_ToolsGenerateTraffic_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(174, 6);
            // 
            // toolStripMenuItem_ToolsCheckForUpdates
            // 
            this.toolStripMenuItem_ToolsCheckForUpdates.Name = "toolStripMenuItem_ToolsCheckForUpdates";
            this.toolStripMenuItem_ToolsCheckForUpdates.Size = new System.Drawing.Size(177, 22);
            this.toolStripMenuItem_ToolsCheckForUpdates.Text = "&Check for Updates";
            this.toolStripMenuItem_ToolsCheckForUpdates.Click += new System.EventHandler(this.toolStripMenuItem_ToolsCheckForUpdates_Click);
            // 
            // ToolStripMenuItem_ToolsConfig
            // 
            this.ToolStripMenuItem_ToolsConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_ToolsReloadConfig,
            this.toolStripMenuItem_ToolsResetConfig,
            this.ToolStripMenuItem_ToolsEditConfig});
            this.ToolStripMenuItem_ToolsConfig.Name = "ToolStripMenuItem_ToolsConfig";
            this.ToolStripMenuItem_ToolsConfig.Size = new System.Drawing.Size(177, 22);
            this.ToolStripMenuItem_ToolsConfig.Text = "Con&fig";
            // 
            // toolStripMenuItem_ToolsReloadConfig
            // 
            this.toolStripMenuItem_ToolsReloadConfig.Name = "toolStripMenuItem_ToolsReloadConfig";
            this.toolStripMenuItem_ToolsReloadConfig.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItem_ToolsReloadConfig.Text = "&Reload Config";
            this.toolStripMenuItem_ToolsReloadConfig.Click += new System.EventHandler(this.toolStripMenuItem_ToolsReloadConfig_Click);
            // 
            // toolStripMenuItem_ToolsResetConfig
            // 
            this.toolStripMenuItem_ToolsResetConfig.Name = "toolStripMenuItem_ToolsResetConfig";
            this.toolStripMenuItem_ToolsResetConfig.Size = new System.Drawing.Size(149, 22);
            this.toolStripMenuItem_ToolsResetConfig.Text = "Rese&t Config";
            this.toolStripMenuItem_ToolsResetConfig.Click += new System.EventHandler(this.toolStripMenuItem_ToolsResetConfig_Click);
            // 
            // ToolStripMenuItem_ToolsEditConfig
            // 
            this.ToolStripMenuItem_ToolsEditConfig.Name = "ToolStripMenuItem_ToolsEditConfig";
            this.ToolStripMenuItem_ToolsEditConfig.Size = new System.Drawing.Size(149, 22);
            this.ToolStripMenuItem_ToolsEditConfig.Text = "&Edit Config";
            this.ToolStripMenuItem_ToolsEditConfig.Click += new System.EventHandler(this.ToolStripMenuItem_ToolsEditConfig_Click);
            // 
            // ToolStripMenuItem_ToolsBIGIPConfig
            // 
            this.ToolStripMenuItem_ToolsBIGIPConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_ToolsBIGIPConfigSaveConfig,
            this.ToolStripMenuItem_ToolsBIGIPConfigAutoSave});
            this.ToolStripMenuItem_ToolsBIGIPConfig.Name = "ToolStripMenuItem_ToolsBIGIPConfig";
            this.ToolStripMenuItem_ToolsBIGIPConfig.Size = new System.Drawing.Size(177, 22);
            this.ToolStripMenuItem_ToolsBIGIPConfig.Text = "&BIG-IP Config";
            // 
            // ToolStripMenuItem_ToolsBIGIPConfigSaveConfig
            // 
            this.ToolStripMenuItem_ToolsBIGIPConfigSaveConfig.Image = global::iRuler.Properties.Resources.ToolbarSaveAll;
            this.ToolStripMenuItem_ToolsBIGIPConfigSaveConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripMenuItem_ToolsBIGIPConfigSaveConfig.Name = "ToolStripMenuItem_ToolsBIGIPConfigSaveConfig";
            this.ToolStripMenuItem_ToolsBIGIPConfigSaveConfig.Size = new System.Drawing.Size(175, 22);
            this.ToolStripMenuItem_ToolsBIGIPConfigSaveConfig.Text = "&Save Configuration";
            this.ToolStripMenuItem_ToolsBIGIPConfigSaveConfig.Click += new System.EventHandler(this.ToolStripMenuItem_ToolsBIGIPConfigSaveConfig_Click);
            // 
            // ToolStripMenuItem_ToolsBIGIPConfigAutoSave
            // 
            this.ToolStripMenuItem_ToolsBIGIPConfigAutoSave.Name = "ToolStripMenuItem_ToolsBIGIPConfigAutoSave";
            this.ToolStripMenuItem_ToolsBIGIPConfigAutoSave.Size = new System.Drawing.Size(175, 22);
            this.ToolStripMenuItem_ToolsBIGIPConfigAutoSave.Text = "&Auto Save";
            this.ToolStripMenuItem_ToolsBIGIPConfigAutoSave.Click += new System.EventHandler(this.ToolStripMenuItem_ToolsBIGIPConfigAutoSave_Click);
            // 
            // toolStripMenuItem_Help
            // 
            this.toolStripMenuItem_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator11,
            this.toolStripMenuItem_HelpiRuler,
            this.toolStripMenuItem_HelpDevCentral,
            this.toolStripMenuItem_HelpForums,
            this.toolStripMenuItem_HelpiRulesReference,
            this.toolStripMenuItem_HelpTCLReference,
            this.toolStripMenuItem_HelpTipOfTheDay,
            this.toolStripSeparator12,
            this.toolStripMenuItem_HelpAbout});
            this.toolStripMenuItem_Help.Name = "toolStripMenuItem_Help";
            this.toolStripMenuItem_Help.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem_Help.Text = "&Help";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(193, 6);
            // 
            // toolStripMenuItem_HelpiRuler
            // 
            this.toolStripMenuItem_HelpiRuler.Image = global::iRuler.Properties.Resources.ToolbarWebLink;
            this.toolStripMenuItem_HelpiRuler.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_HelpiRuler.Name = "toolStripMenuItem_HelpiRuler";
            this.toolStripMenuItem_HelpiRuler.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.toolStripMenuItem_HelpiRuler.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem_HelpiRuler.Text = "F5 iRule Editor Help";
            this.toolStripMenuItem_HelpiRuler.Click += new System.EventHandler(this.toolStripMenuItem_HelpiRuler_Click_1);
            // 
            // toolStripMenuItem_HelpDevCentral
            // 
            this.toolStripMenuItem_HelpDevCentral.Image = global::iRuler.Properties.Resources.ToolbarWebLink;
            this.toolStripMenuItem_HelpDevCentral.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_HelpDevCentral.Name = "toolStripMenuItem_HelpDevCentral";
            this.toolStripMenuItem_HelpDevCentral.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem_HelpDevCentral.Text = "&DevCentral.f5.com";
            this.toolStripMenuItem_HelpDevCentral.Click += new System.EventHandler(this.toolStripMenuItem_HelpDevCentral_Click);
            // 
            // toolStripMenuItem_HelpForums
            // 
            this.toolStripMenuItem_HelpForums.Image = global::iRuler.Properties.Resources.ToolbarWebLink;
            this.toolStripMenuItem_HelpForums.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_HelpForums.Name = "toolStripMenuItem_HelpForums";
            this.toolStripMenuItem_HelpForums.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem_HelpForums.Text = "DevCentral &Forums";
            this.toolStripMenuItem_HelpForums.Click += new System.EventHandler(this.toolStripMenuItem_HelpForums_Click);
            // 
            // toolStripMenuItem_HelpiRulesReference
            // 
            this.toolStripMenuItem_HelpiRulesReference.Image = global::iRuler.Properties.Resources.ToolbarWebLink;
            this.toolStripMenuItem_HelpiRulesReference.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_HelpiRulesReference.Name = "toolStripMenuItem_HelpiRulesReference";
            this.toolStripMenuItem_HelpiRulesReference.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem_HelpiRulesReference.Text = "iRules &Reference";
            this.toolStripMenuItem_HelpiRulesReference.Click += new System.EventHandler(this.toolStripMenuItem_HelpiRulesReference_Click);
            // 
            // toolStripMenuItem_HelpTCLReference
            // 
            this.toolStripMenuItem_HelpTCLReference.Image = global::iRuler.Properties.Resources.ToolbarWebLink;
            this.toolStripMenuItem_HelpTCLReference.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_HelpTCLReference.Name = "toolStripMenuItem_HelpTCLReference";
            this.toolStripMenuItem_HelpTCLReference.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem_HelpTCLReference.Text = "&TCL Reference";
            this.toolStripMenuItem_HelpTCLReference.Click += new System.EventHandler(this.toolStripMenuItem_HelpTCLReference_Click);
            // 
            // toolStripMenuItem_HelpTipOfTheDay
            // 
            this.toolStripMenuItem_HelpTipOfTheDay.Image = global::iRuler.Properties.Resources.ToolbarLightbulb;
            this.toolStripMenuItem_HelpTipOfTheDay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripMenuItem_HelpTipOfTheDay.Name = "toolStripMenuItem_HelpTipOfTheDay";
            this.toolStripMenuItem_HelpTipOfTheDay.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem_HelpTipOfTheDay.Text = "Tip of the Day";
            this.toolStripMenuItem_HelpTipOfTheDay.Click += new System.EventHandler(this.toolStripMenuItem_HelpTipOfTheDay_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(193, 6);
            // 
            // toolStripMenuItem_HelpAbout
            // 
            this.toolStripMenuItem_HelpAbout.Name = "toolStripMenuItem_HelpAbout";
            this.toolStripMenuItem_HelpAbout.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem_HelpAbout.Text = "&About F5 iRule Editor";
            this.toolStripMenuItem_HelpAbout.Click += new System.EventHandler(this.toolStripMenuItem_HelpAbout_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Connect,
            this.toolStripSeparator1,
            this.toolStripButton_DataGroups,
            this.toolStripButton_GenerateTraffic,
            this.toolStripSeparator3,
            this.toolStripButton_DevCentral,
            this.toolStripButton_DevCentralForums,
            this.toolStripButton_Wiki,
            this.toolStripButton_TCL});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(442, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripButton_Connect
            // 
            this.toolStripButton_Connect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Connect.Image = global::iRuler.Properties.Resources.ToolbarConnect;
            this.toolStripButton_Connect.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Connect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Connect.Name = "toolStripButton_Connect";
            this.toolStripButton_Connect.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Connect.Text = "Connect";
            this.toolStripButton_Connect.Click += new System.EventHandler(this.toolStripButton_Connect_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_DataGroups
            // 
            this.toolStripButton_DataGroups.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_DataGroups.Image = global::iRuler.Properties.Resources.ToolbarDataGroups;
            this.toolStripButton_DataGroups.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_DataGroups.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_DataGroups.Name = "toolStripButton_DataGroups";
            this.toolStripButton_DataGroups.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_DataGroups.Text = "Open the Data Group Editor";
            this.toolStripButton_DataGroups.Click += new System.EventHandler(this.toolStripButton_DataGroups_Click);
            // 
            // toolStripButton_GenerateTraffic
            // 
            this.toolStripButton_GenerateTraffic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_GenerateTraffic.Image = global::iRuler.Properties.Resources.ToolbarTraffic;
            this.toolStripButton_GenerateTraffic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_GenerateTraffic.Name = "toolStripButton_GenerateTraffic";
            this.toolStripButton_GenerateTraffic.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_GenerateTraffic.Text = "Open the Traffic Generation Dialog";
            this.toolStripButton_GenerateTraffic.Click += new System.EventHandler(this.toolStripButton_GenerateTraffic_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_DevCentral
            // 
            this.toolStripButton_DevCentral.Image = global::iRuler.Properties.Resources.ToolbarWebLink;
            this.toolStripButton_DevCentral.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_DevCentral.Name = "toolStripButton_DevCentral";
            this.toolStripButton_DevCentral.Size = new System.Drawing.Size(85, 22);
            this.toolStripButton_DevCentral.Text = "DevCentral";
            this.toolStripButton_DevCentral.Click += new System.EventHandler(this.toolStripButton_DevCentral_Click);
            // 
            // toolStripButton_DevCentralForums
            // 
            this.toolStripButton_DevCentralForums.Image = global::iRuler.Properties.Resources.ToolbarWebLink;
            this.toolStripButton_DevCentralForums.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_DevCentralForums.Name = "toolStripButton_DevCentralForums";
            this.toolStripButton_DevCentralForums.Size = new System.Drawing.Size(67, 22);
            this.toolStripButton_DevCentralForums.Text = "Forums";
            this.toolStripButton_DevCentralForums.Click += new System.EventHandler(this.toolStripButton_DevCentralForums_Click);
            // 
            // toolStripButton_Wiki
            // 
            this.toolStripButton_Wiki.Image = global::iRuler.Properties.Resources.ToolbarWebLink;
            this.toolStripButton_Wiki.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Wiki.Name = "toolStripButton_Wiki";
            this.toolStripButton_Wiki.Size = new System.Drawing.Size(113, 22);
            this.toolStripButton_Wiki.Text = "iRules Reference";
            this.toolStripButton_Wiki.Click += new System.EventHandler(this.toolStripButton_Wiki_Click);
            // 
            // toolStripButton_TCL
            // 
            this.toolStripButton_TCL.Image = global::iRuler.Properties.Resources.ToolbarWebLink;
            this.toolStripButton_TCL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_TCL.Name = "toolStripButton_TCL";
            this.toolStripButton_TCL.Size = new System.Drawing.Size(103, 22);
            this.toolStripButton_TCL.Text = "TCL Reference";
            this.toolStripButton_TCL.Click += new System.EventHandler(this.toolStripButton_TCL_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(150, 150);
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(150, 175);
            this.toolStripContainer1.TabIndex = 0;
            // 
            // panelx
            // 
            this.panelx.Controls.Add(this.statusStrip);
            this.panelx.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelx.Location = new System.Drawing.Point(0, 602);
            this.panelx.Name = "panelx";
            this.panelx.Size = new System.Drawing.Size(660, 20);
            this.panelx.TabIndex = 9;
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Top;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusStripLabel_Connection,
            this.toolStripStatusLabel_Line,
            this.toolStripStatusLabel_Column,
            this.toolStripStatusLabel_Character});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(660, 22);
            this.statusStrip.TabIndex = 9;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusStripLabel_Connection
            // 
            this.statusStripLabel_Connection.AutoSize = false;
            this.statusStripLabel_Connection.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.statusStripLabel_Connection.Name = "statusStripLabel_Connection";
            this.statusStripLabel_Connection.Size = new System.Drawing.Size(412, 17);
            this.statusStripLabel_Connection.Spring = true;
            this.statusStripLabel_Connection.Text = "Disconnected. Click the Connect button...";
            this.statusStripLabel_Connection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_Line
            // 
            this.toolStripStatusLabel_Line.AutoSize = false;
            this.toolStripStatusLabel_Line.Name = "toolStripStatusLabel_Line";
            this.toolStripStatusLabel_Line.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel_Line.Text = "Ln 0";
            this.toolStripStatusLabel_Line.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_Column
            // 
            this.toolStripStatusLabel_Column.AutoSize = false;
            this.toolStripStatusLabel_Column.Name = "toolStripStatusLabel_Column";
            this.toolStripStatusLabel_Column.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel_Column.Text = "Col 0";
            this.toolStripStatusLabel_Column.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_Character
            // 
            this.toolStripStatusLabel_Character.AutoSize = false;
            this.toolStripStatusLabel_Character.Name = "toolStripStatusLabel_Character";
            this.toolStripStatusLabel_Character.Size = new System.Drawing.Size(75, 17);
            this.toolStripStatusLabel_Character.Text = "Ch 0";
            this.toolStripStatusLabel_Character.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_Middle
            // 
            this.panel_Middle.Controls.Add(this.splitContainer1);
            this.panel_Middle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Middle.Location = new System.Drawing.Point(0, 51);
            this.panel_Middle.Name = "panel_Middle";
            this.panel_Middle.Size = new System.Drawing.Size(660, 551);
            this.panel_Middle.TabIndex = 10;
            this.panel_Middle.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Middle_Paint);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel_TreeView);
            this.splitContainer1.Panel1.Controls.Add(this.panel_TreeViewToolbar);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(660, 551);
            this.splitContainer1.SplitterDistance = 140;
            this.splitContainer1.TabIndex = 9;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.m_textEditor);
            this.splitContainer2.Panel1MinSize = 0;
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.textBox_Status);
            this.splitContainer2.Panel2MinSize = 0;
            this.splitContainer2.Size = new System.Drawing.Size(516, 551);
            this.splitContainer2.SplitterDistance = 506;
            this.splitContainer2.TabIndex = 0;
            // 
            // ToolStripMenuItem_FileFolder
            // 
            this.ToolStripMenuItem_FileFolder.Enabled = false;
            this.ToolStripMenuItem_FileFolder.Name = "ToolStripMenuItem_FileFolder";
            this.ToolStripMenuItem_FileFolder.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem_FileFolder.Text = "&Folder";
            this.ToolStripMenuItem_FileFolder.Visible = false;
            // 
            // iRulerMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(660, 622);
            this.Controls.Add(this.panel_Middle);
            this.Controls.Add(this.panelx);
            this.Controls.Add(this.panel_Top);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "iRulerMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F5 iRule Editor";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.iRulerMain_HelpButtonClicked);
            this.Activated += new System.EventHandler(this.iRulerMain_Activated);
            this.Load += new System.EventHandler(this.iRulerMain_Load);
            this.panel_TreeViewToolbar.ResumeLayout(false);
            this.panel_TreeViewToolbar.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.contextMenuStrip_TreeView.ResumeLayout(false);
            this.panel_TreeView.ResumeLayout(false);
            this.panel_Top.ResumeLayout(false);
            this.panel_Top.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.panelx.ResumeLayout(false);
            this.panelx.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel_Middle.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion


        private scintilla.ScintillaControl m_textEditor;
        private System.Windows.Forms.RichTextBox textBox_Status;
        private System.Windows.Forms.Panel panel_Top;
        private ToolStripContainer toolStripContainer1;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton_Connect;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton_DataGroups;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton toolStripButton_DevCentral;
        private ToolStripButton toolStripButton_DevCentralForums;
        private ToolStripButton toolStripButton_Wiki;
        private ToolStripButton toolStripButton_TCL;
        private TreeView treeView_iRules;
        private ContextMenuStrip contextMenuStrip_TreeView;
        private ToolStripMenuItem toolStripMenuItem_Properties;
        private ToolStripMenuItem toolStripMenuItem_Reset;
        private Panel panel_TreeView;
        private Panel panel_TreeViewToolbar;
        private ToolStrip toolStrip2;
        private ToolStripButton toolStripButton_New;
        private ToolStripButton toolStripButton_Save;
        private ToolStripButton toolStripButton_Delete;
        private ToolStripButton toolStripButton_Share;
        private ToolStripButton toolStripButton_CheckSyntax;
        private ToolStripButton toolStripButton_RefreshList;
        private ToolStripMenuItem toolStripMenuItem_Save;
        private ToolStripMenuItem toolStripMenuItem_Delete;
        private ToolStripMenuItem toolStripMenuItem_CheckSyntax;
        private ToolStripMenuItem toolStripMenuItem_Share;
        private ToolStripSeparator toolStripSeparator2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem_File;
        private ToolStripMenuItem toolStripMenuItem_FileConnect;
        private ToolStripMenuItem toolStripMenuItem_FileNew;
        private ToolStripMenuItem toolStripMenuItem_FileSave;
        private ToolStripMenuItem toolStripMenuItem_FileDelete;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem toolStripMenuItem_FileArchive;
        private ToolStripMenuItem toolStripMenuItem_FileArchiveExport;
        private ToolStripMenuItem toolStripMenuItem_FileArchiveImport;
        private ToolStripMenuItem toolStripMenuItem_FileArchiveOpen;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem toolStripMenuItem_Exit;
        private ToolStripMenuItem toolStripMenuItem_Edit;
        private ToolStripMenuItem toolStripMenuItem_EditUndo;
        private ToolStripMenuItem toolStripMenuItem_EditRedo;
        private ToolStripMenuItem toolStripMenuItem_EditCut;
        private ToolStripMenuItem toolStripMenuItem_EditCopy;
        private ToolStripMenuItem toolStripMenuItem_EditPaste;
        private ToolStripMenuItem toolStripMenuItem_EditDelete;
        private ToolStripMenuItem toolStripMenuItem_View;
        private ToolStripMenuItem toolStripMenuItem_Tools;
        private ToolStripMenuItem toolStripMenuItem_Help;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripMenuItem toolStripMenuItem_EditSelectAll;
        private ToolStripMenuItem toolStripMenuItem_ViewLineNumbers;
        private ToolStripMenuItem toolStripMenuItem_ViewIndentionGuides;
        private ToolStripMenuItem toolStripMenuItem_ViewMargin;
        private ToolStripMenuItem toolStripMenuItem_ViewFoldMargin;
        private ToolStripMenuItem toolStripMenuItem_ViewWordWrap;
        private ToolStripMenuItem toolStripMenuItem_ViewWhiteSpace;
        private ToolStripMenuItem toolStripMenuItem_ViewEndOfLine;
        private ToolStripMenuItem toolStripMenuItem_ViewBookmarks;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem toolStripMenuItem_ViewAutoComplete;
        private ToolStripMenuItem toolStripMenuItem_ViewHotspots;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem toolStripMenuItem_ViewStatus;
        private ToolStripMenuItem toolStripMenuItem_ToolsDataGroupEditor;
        private ToolStripMenuItem toolStripMenuItem_ToolsShare;
        private ToolStripSeparator toolStripSeparator10;
		private ToolStripMenuItem toolStripMenuItem_ToolsCheckForUpdates;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem toolStripMenuItem_HelpDevCentral;
        private ToolStripMenuItem toolStripMenuItem_HelpForums;
        private ToolStripMenuItem toolStripMenuItem_HelpiRulesReference;
        private ToolStripMenuItem toolStripMenuItem_HelpTCLReference;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem toolStripMenuItem_HelpAbout;
        private Panel panelx;
        private Panel panel_Middle;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private ImageList imageList_TreeView;
        private ToolStripMenuItem toolStripMenuItem_FileSaveAll;
        private ToolStripMenuItem toolStripMenuItem_HelpTipOfTheDay;
        private ToolStripMenuItem toolStripMenuItem_Search;
        private ToolStripMenuItem toolStripMenuItem_SearchFind;
        private ToolStripMenuItem toolStripMenuItem_SearchFindNext;
		private ToolStripMenuItem toolStripMenuItem_SearchFindPrevious;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusStripLabel_Connection;
        private ToolStripStatusLabel toolStripStatusLabel_Line;
        private ToolStripStatusLabel toolStripStatusLabel_Column;
        private ToolStripStatusLabel toolStripStatusLabel_Character;
        private ToolStripMenuItem toolStripMenuItem_HelpiRuler;
        private ToolStripMenuItem toolStripMenuItem_ToolsLogViewer;
        private ToolStripMenuItem toolStripMenuItem_ToolsGenerateTraffic;
        private ToolStripButton toolStripButton_GenerateTraffic;
		private ToolStripMenuItem toolStripMenuItem_FilePartition;
		private ToolStripMenuItem ToolStripMenuItem_ViewChangeIndentionSettings;
		private ToolStripMenuItem ToolStripMenuItem_ToolsConfig;
		private ToolStripMenuItem toolStripMenuItem_ToolsReloadConfig;
		private ToolStripMenuItem toolStripMenuItem_ToolsResetConfig;
		private ToolStripMenuItem ToolStripMenuItem_ToolsEditConfig;
		private ToolStripMenuItem ToolStripMenuItem_ToolsBIGIPConfig;
		private ToolStripMenuItem ToolStripMenuItem_ToolsBIGIPConfigSaveConfig;
		private ToolStripMenuItem ToolStripMenuItem_ToolsBIGIPConfigAutoSave;
        private ToolStripMenuItem toolStripMenuItem_CopyOffline;
        private ToolStripMenuItem toolStripMenuItem_Reload;
        private ToolStripMenuItem toolStripMenuItem_FileArchiveSetLocation;
        private ToolStripMenuItem ToolStripMenuItem_FileFolder;
    }
}
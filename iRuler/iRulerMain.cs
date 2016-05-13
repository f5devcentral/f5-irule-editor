//===========================================================================
//
// File         : iRulerMain.cs
//                   
//---------------------------------------------------------------------------
//
// The contents of this file are subject to the "END USER LICENSE AGREEMENT FOR F5
// Software Development Kit for iControl"; you may not use this file except in
// compliance with the License. The License is included in the iControl
// Software Development Kit.
//
// Software distributed under the License is distributed on an "AS IS"
// basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See
// the License for the specific language governing rights and limitations
// under the License.
//
// The Original Code is iControl Code and related documentation
// distributed by F5.
//
// The Initial Developer of the Original Code is F5 Networks, Inc.
// Seattle, WA, USA.
// Portions created by F5 are Copyright (C) 2006 F5 Networks, Inc.
// All Rights Reserved.
// iControl (TM) is a registered trademark of F5 Networks, Inc.
//
// Alternatively, the contents of this file may be used under the terms
// of the GNU General Public License (the "GPL"), in which case the
// provisions of GPL are applicable instead of those above.  If you wish
// to allow use of your version of this file only under the terms of the
// GPL and not to allow others to use your version of this file under the
// License, indicate your decision by deleting the provisions above and
// replace them with the notice and other provisions required by the GPL.
// If you do not delete the provisions above, a recipient may use your
// version of this file under either the License or the GPL.
//
//===========================================================================
using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using iControl;
using iRuler.Dialogs;
using iRuler.Utility;
using System.Runtime.InteropServices;

namespace iRuler
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public partial class iRulerMain : Form
    {
        // For Auto-DragScroll functionality
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        #region Member Variables

        private int MARKER_BOOKMARK = 1;
        private String APP_TITLE = "F5 iRule Editor";
		private String CONFIG_KEY = "Software\\F5 Networks\\iRuler";
		private String m_currentPartition = "";

		private scintilla.configuration.Scintilla m_textEditorConfig = null;

        private SearchInfo m_si = new SearchInfo();
		private iRuleInfo m_iri = null;
        private TreeNode m_lastTreeViewNode = null;
        private TreeNode m_treeNodeLocalLB = new TreeNode("Local Traffic");
        private TreeNode m_treeNodeGlobalLB = new TreeNode("Global Traffic");
		private TreeNode m_treeNodeConfiguration = new TreeNode("Configuration");
        private TreeNode m_treeNodeOffline = new TreeNode("Offline iRules");

        private String m_eventList = "";
        private String m_eventListGTM = "";
        private String [] m_keyWordList = null;
        private String [] m_keyWordListLTM = null;
        private String [] m_keyWordListGTM = null;

        private bool m_bAddedShortcutKeys = false;
		private bool m_showLineNumbers = true;
        private bool m_showWordWrap = false;
        private bool m_showWhiteSpace = false;
        private bool m_showEndOfLine = false;
        private bool m_showMargin = true;
        private bool m_showFoldMargin = true;
        private bool m_showAutoComplete = true;
        private bool m_showHotspots = true;
        private bool m_showIndentionGuides = true;
        private bool m_showStatus = false;
        private bool m_showSplashScreen = true;

		private bool m_autoIndent = true;
		private bool m_useTabs = true;
		private int m_tabSize = 4;
		private int m_indentSize = 4;

        private Int64 m_lastUpdate = 0;
        private int m_startLocationX = -1;
        private int m_startLocationY = -1;
        private int m_startWidth = -1;
        private int m_startHeight = -1;
        private bool m_doAutoIndent = true;

        private bool m_bPossibleBookmarks = false;

		private bool m_autoSaveConfig = true;
        private bool m_configurationEditing = true;
        private bool m_offlineEditing = true;
        private String m_archiveDirectory = Configuration.getConfigSubDir("Archive");

        // Command Line Arguments
        private string m_hostName = "";
        private string m_userName = "";
        private string m_password = ""; 

        #endregion

		public iRulerMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
            System.Net.ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCallback;
		}

        #region Certificate Validation Members

        public bool RemoteCertificateValidationCallback (
	        Object sender,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
	        System.Net.Security.SslPolicyErrors sslPolicyErrors
        )
        {
            return true;
        }


		#endregion

        #region Initialization Methods

        protected void loadCommandArgs()
        {
            string lastarg = "";
            foreach (string arg in Environment.GetCommandLineArgs())
            {
                switch (lastarg.ToLower())
                {
                    case "/h":
                    case "/host":
                    case "/hostname":
                    case "/server":
                        m_hostName = arg;
                        break;

                    case "/u":
                    case "/user":
                    case "/username":
                        m_userName = arg;
                        break;

                    case "/p":
                    case "/pass":
                    case "/password":
                        m_password = arg;
                        break;
                }
                lastarg = arg;
            }
        } 
        protected void loadConfiguration()
        {
            Microsoft.Win32.RegistryKey cu = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey f5Key = cu.OpenSubKey(CONFIG_KEY);
            if (null != f5Key)
            {
                Object obj = null;
                if (null != (obj = f5Key.GetValue("WordWrap")))
                {
                    m_showWordWrap = Convert.ToBoolean(obj);
                }
                if (null != (obj = f5Key.GetValue("LineNumbers")))
                {
                    m_showLineNumbers = Convert.ToBoolean(obj);
                }
                if (null != (obj = f5Key.GetValue("WhiteSpace")))
                {
                    m_showWhiteSpace = Convert.ToBoolean(obj);
                }
                if (null != (obj = f5Key.GetValue("Margin")))
                {
                    m_showMargin = Convert.ToBoolean(obj);
                }
                if (null != (obj = f5Key.GetValue("FoldMargin")))
                {
                    m_showFoldMargin = Convert.ToBoolean(obj);
                }
                if (null != (obj = f5Key.GetValue("AutoComplete")))
                {
                    m_showAutoComplete = Convert.ToBoolean(obj);
                }
                if (null != (obj = f5Key.GetValue("Hotspots")))
                {
                    m_showHotspots = Convert.ToBoolean(obj);
                }
                if (null != (obj = f5Key.GetValue("IndentionGuides")))
                {
                    m_showIndentionGuides = Convert.ToBoolean(obj);
                }
                if (null != (obj = f5Key.GetValue("Status")))
                {
                    m_showStatus = Convert.ToBoolean(obj);
                }
                if (null != (obj = f5Key.GetValue("ShowSplashScreen")))
                {
                    m_showSplashScreen = Convert.ToBoolean(obj);
                }
                if (null != (obj = f5Key.GetValue("LastUpdate")))
                {
                    m_lastUpdate = Convert.ToInt64(obj);
                }
                if (null != (obj = f5Key.GetValue("WindowPosition")))
                {
                    String sPosition = Convert.ToString(obj);
                    String [] sSplit = sPosition.Split(new char [] {','});
                    if ( sSplit.Length == 4 )
                    {
                        m_startLocationX = Convert.ToInt32(sSplit[0]);
                        if (m_startLocationX < 0) { m_startLocationX = 0; }
                        m_startLocationY = Convert.ToInt32(sSplit[1]);
                        if (m_startLocationY < 0) { m_startLocationY = 0; }
                        m_startWidth = Convert.ToInt32(sSplit[2]);
                        if (m_startWidth < 500) { m_startWidth = 500; }
                        m_startHeight = Convert.ToInt32(sSplit[3]);
                        if (m_startHeight < 500) { m_startHeight = 500; }
                    }
                }
				if (null != (obj = f5Key.GetValue("AutoIndent")))
				{
					m_autoIndent = Convert.ToBoolean(obj);
				}
				if (null != (obj = f5Key.GetValue("UseTabs")))
				{
					m_useTabs = Convert.ToBoolean(obj);
				}
				if (null != (obj = f5Key.GetValue("TabSize")))
				{
					m_tabSize = Convert.ToInt32(obj);
				}
				if (null != (obj = f5Key.GetValue("IndentSize")))
				{
					m_indentSize = Convert.ToInt32(obj);
				}
				if (null != (obj = f5Key.GetValue("AutoSaveConfig")))
				{
					m_autoSaveConfig = Convert.ToBoolean(obj);
				}
                //if (null != (obj = f5Key.GetValue("ConfigurationEditing")))
                //{
                //    m_configurationEditing = Convert.ToBoolean(obj);
                //}
                //if (null != (obj = f5Key.GetValue("OfflineEditing")))
                //{
                //    m_offlineEditing = Convert.ToBoolean(obj);
                //}
                if (null != (obj = f5Key.GetValue("ArchiveDirectory")))
                {
                    m_archiveDirectory = Convert.ToString(obj);
                }
                f5Key.Close();
            }
        }
        protected void saveConfiguration()
        {
            Microsoft.Win32.RegistryKey cu = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey f5Key = cu.CreateSubKey(CONFIG_KEY);
            if (null != f5Key)
            {
                f5Key.SetValue("WordWrap", m_showWordWrap);
                f5Key.SetValue("LineNumbers", m_showLineNumbers);
                f5Key.SetValue("WhiteSpace", m_showWhiteSpace);
                f5Key.SetValue("Margin", m_showMargin);
                f5Key.SetValue("FoldMargin", m_showFoldMargin);
                f5Key.SetValue("AutoComplete", m_showAutoComplete);
                f5Key.SetValue("HotSpots", m_showHotspots);
                f5Key.SetValue("IndentionGuides", m_showIndentionGuides);
                f5Key.SetValue("Status", m_showStatus);
                f5Key.SetValue("LastUpdate", m_lastUpdate.ToString());
                f5Key.SetValue("WindowPosition", string.Format("{0},{1},{2},{3}", Location.X, Location.Y, Width, Height));
				f5Key.SetValue("AutoIndent", m_autoIndent);
				f5Key.SetValue("UseTabs", m_useTabs);
				f5Key.SetValue("TabSize", m_tabSize);
				f5Key.SetValue("IndentSize", m_indentSize);
				f5Key.SetValue("AutoSaveConfig", m_autoSaveConfig);
                f5Key.SetValue("ShowSplashScreen", m_showSplashScreen);
                //f5Key.SetValue("ConfigurationEditing", m_configurationEditing);
                //f5Key.SetValue("OfflineEditing", m_offlineEditing);
                f5Key.SetValue("ArchiveDirectory", m_archiveDirectory);
            }
            f5Key.Close();
        }
        protected void updateAutoCompleteList()
        {
            String sConfigPath = Configuration.getConfigSubDir("Templates");
            String sEventsFile = sConfigPath + "_Events.txt";

            m_eventList = "";
            if (System.IO.File.Exists(sEventsFile))
            {
                System.IO.StreamReader sr = System.IO.File.OpenText(sEventsFile);
                String input;
                while ((input = sr.ReadLine()) != null)
                {
                    if (0 == m_eventList.Length)
                    {
                        m_eventList = input + " ";
                    }
                    else
                    {
                        m_eventList = m_eventList + ";" + input + " ";
                    }
                }
                sr.Close();
            }

            sEventsFile = sConfigPath + "_GTMEvents.txt";
            m_eventListGTM = "";
            if (System.IO.File.Exists(sEventsFile))
            {
                System.IO.StreamReader sr = System.IO.File.OpenText(sEventsFile);
                String input;
                while ((input = sr.ReadLine()) != null)
                {
                    if (0 == m_eventList.Length)
                    {
                        m_eventListGTM = input + " ";
                    }
                    else
                    {
                        m_eventListGTM = m_eventListGTM + ";" + input + " ";
                    }
                }
                sr.Close();
            }

        }
        protected void updateKeywordList()
        {
            // build a master list of all keywords
            String masterList = "";
            String LTMList = "";
            String GTMList = "";
            for (int i = 0; i < m_textEditorConfig.keywordclass.Length; i++)
            {
                if (!m_textEditorConfig.keywordclass[i].name.Equals("tcl-notsupported"))
                {
                    masterList = masterList + m_textEditorConfig.keywordclass[i].val;
                    if (m_textEditorConfig.keywordclass[i].name.Equals("iRule-LTM-tokens"))
                    {
                        LTMList = LTMList + m_textEditorConfig.keywordclass[i].val;
                    }
                    if (m_textEditorConfig.keywordclass[i].name.Equals("iRule-GTM-tokens"))
                    {
                        GTMList = GTMList + m_textEditorConfig.keywordclass[i].val;
                    }
                    if (m_textEditorConfig.keywordclass[i].name.Equals("tcl"))
                    {
                        LTMList = LTMList + m_textEditorConfig.keywordclass[i].val;
                        GTMList = GTMList + m_textEditorConfig.keywordclass[i].val;
                    }
                }
            }

            // build array of keywords and filter out noise
            int num_keywords_ltm = 0;
            char[] seps = new char[] { ' ', '\t', '\r', '\n', ';', ',' };

            String[] sSplit_LTM = LTMList.Split(seps);
            for (int j = 0; j < sSplit_LTM.Length; j++)
            {
                if (sSplit_LTM[j].Trim().Length > 0)
                {
                    num_keywords_ltm++;
                }
            }
            int num_keywords_gtm = 0;
            String[] sSplit_GTM = GTMList.Split(seps);
            for (int j = 0; j < sSplit_GTM.Length; j++)
            {
                if (sSplit_GTM[j].Trim().Length > 0)
                {
                    num_keywords_gtm++;
                }
            }

            // build master keyword list
            m_keyWordList = new String[num_keywords_ltm + num_keywords_gtm];

            m_keyWordListLTM = new String[num_keywords_ltm];
            int index_ltm = 0;
            for (int j = 0; j < sSplit_LTM.Length; j++)
            {
                if (sSplit_LTM[j].Trim().Length > 0)
                {
                    m_keyWordListLTM[index_ltm] = sSplit_LTM[j].Trim();
                    m_keyWordList[index_ltm] = sSplit_LTM[j].Trim();
                    index_ltm++;
                }
            }

            // build master keyword list
            m_keyWordListGTM = new String[num_keywords_gtm];
            int index_gtm = 0;
            for (int j = 0; j < sSplit_GTM.Length; j++)
            {
                if (sSplit_GTM[j].Trim().Length > 0)
                {
                    m_keyWordListGTM[index_gtm] = sSplit_GTM[j].Trim();
                    m_keyWordList[index_ltm + index_gtm] = sSplit_GTM[j].Trim();
                    index_gtm++;
                }
            }

        }

        protected void ensureLatestConfig()
        {
            long diskLen = 0;
            long memoryLen = 0;

            String sConfig = Configuration.getConfigFile("iRuler.xml");
            // Get size of config on disk
            if (System.IO.File.Exists(sConfig))
            {
                System.IO.FileInfo diskInfo = new System.IO.FileInfo(sConfig);
                diskLen = diskInfo.Length;
            }

            // Get size of config in memory
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            if (null != assembly)
            {
                System.IO.Stream stream = assembly.GetManifestResourceStream("iRuler.iRuler.xml");
                if (null != stream)
                {
                    memoryLen = stream.Length;
                    stream.Close();
                }
            }

            if ( (0 == diskLen) || (diskLen != memoryLen) )
            {
                exportConfig();
            }
        }

        protected bool exportConfig()
        {
            bool bExported = false;
            String sConfig = Configuration.getConfigFile("iRuler.xml");
            // try to load them from the internal resources
            try
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                if (null != assembly)
                {
                    System.IO.Stream stream = assembly.GetManifestResourceStream("iRuler.iRuler.xml");
                    if (null != stream)
                    {
                        System.IO.StreamReader sr = new System.IO.StreamReader(stream);
                        System.IO.FileStream configOut = System.IO.File.Create(sConfig);
                        System.IO.StreamWriter sw = new System.IO.StreamWriter(configOut);
                        sw.Write(sr.ReadToEnd());
                        sw.Close();
                        configOut.Close();
                        sr.Close();
                        bExported = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return bExported;
        }
		protected void editConfig()
		{
			String sConfig = Configuration.getConfigFile("iRuler.xml");
			Configuration.LaunchProcess("Notepad.exe", sConfig);
		}

        /// <summary>
        /// Same as the version below but defaults to 0 (black).
        /// </summary>
        /// <param name="c">The color value to convert.  Currently only decimal
        /// and hex (starting with "0x") values are supported.</param>
        /// <returns>The converted value or 0 (black) if the conversion failed.</returns>
        private int parseColorValue(String c)
        {
            return parseColorValue(c, 0);
        }
        /// <summary>
        /// Converts a string into a color for use with the scintilla. settings.
        /// It looks like scintilla. interprets ints as being in BGR format, not
        /// RGB but the configuration file uses RGB.  To accomodate this the
        /// string is converted to a number and then the first (blue) and third
        /// (red) bytes are swapped.
        /// 
        /// If a default value of -1 is provided then -1 will be returned on
        /// conversion failure.  Otherwise the default value will have its
        /// bytes swapped to convert from RGB to BGR format.
        /// </summary>
        /// <param name="c">The color value to convert.  Currently only decimal
        /// and hex (starting with "0x") values are supported.</param>
        /// <param name="defVal">The default color to use if conversion fails.
        /// Should be in the RGB format or -1.</param>
        /// <returns>The converted value or the provided default value if the conversion vailed.</returns>
        private int parseColorValue(String c, int defVal)
        {
            int converted = 0;
            try
            {
                if (c.StartsWith("0x"))
                {
                    c = c.Substring(2);
                    converted = int.Parse(c, System.Globalization.NumberStyles.HexNumber);
                }
                else
                {
                    converted = int.Parse(c);
                }
            }
            catch (Exception)
            {
                Console.Out.WriteLine("Exception converting color: " + c);
                converted = defVal;
            }

            /* scintilla. seems to be using BGR format for colors while the configuration uses RGB.
             * Need to swap the first and third bytes. */
            if (converted != -1)
            {
                int blue = converted & 0xFF;
                int red = (converted >> 16) & 0xFF;
                converted = (converted & 0x00FF00) |
                            ((blue << 16) & 0xFF0000) |
                            red;
            }

            Console.Out.WriteLine("Converted " + c + " to " + converted);

            return converted;
        }
        /// <summary>
        /// Converts a string to an integer.  If the conversion fails it default
        /// to the provided default value.
        /// </summary>
        /// <param name="i">The value to convert.</param>
        /// <param name="defVal">The value to use if conversion fails.</param>
        /// <returns>The converted value.</returns>
        private int parseInt(String i, int defVal)
        {
            int converted = 0;
            try
            {
                converted = int.Parse(i);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine("Exception converting integer: " + e);
                converted = defVal;
            }
            return converted;
        }
        protected bool initializeEditor()
        {
            bool bInitialized = false;
            // create the configuration utility.
            // you need to pass a type that exists int the assembly where the class that you use as
            // a base node for configuration.
            scintilla.configuration.ConfigurationUtility cu = new scintilla.configuration.ConfigurationUtility(GetType().Module.Assembly);

            // Make sure configuration is latest
            ensureLatestConfig();

            // set the configuration to scintilla.
            String sConfig = Configuration.getConfigFile("iRuler.xml");

            m_textEditorConfig = (scintilla.configuration.Scintilla)cu.LoadConfiguration(typeof(scintilla.configuration.Scintilla), sConfig);

            if (null == m_textEditorConfig)
            {
                if (exportConfig())
                {
                    m_textEditorConfig = (scintilla.configuration.Scintilla)cu.LoadConfiguration(typeof(scintilla.configuration.Scintilla), sConfig);
                }
            }

            if (null != m_textEditorConfig)
            {
                m_textEditor.Configuration = m_textEditorConfig;
                m_textEditor.ConfigurationLanguage = "iRule";
                m_textEditor.CodePage = 65001;
                m_textEditor.WrapMode = 1;
				m_textEditor.Lexer = scintilla.Lexer.tcl;
                m_textEditor.AutoCSetTypeSeparator = ';';
                m_textEditor.Colourise(0, -1);


                m_textEditor.set_Property("fold", "1");
                m_textEditor.ModEventMask = 0xF77; // SC_MOD_EVENTMASKALL
                m_textEditor.set_MarginTypeN(2, 0 /* SC_MARGIN_SYMBOL */ );
                m_textEditor.set_MarginMaskN(2, -33554432);
                m_textEditor.set_MarginSensitiveN(2, true);
                m_textEditor.SetFoldFlags(16);

                // HACK
                this.m_textEditor.AutoCSetSeparator(';');
                this.m_textEditor.AutoCSetTypeSeparator = 63;
                this.m_textEditor.EndAtLastLine = true;
                this.m_textEditor.EOLMode = 0; /* SC_EOL_CRLF */
                this.m_textEditor.AutoCSetAutoHide(true);
                this.m_textEditor.AutoCSetCancelAtStart(true);
                this.m_textEditor.AutoCSetChooseSingle(false);
                this.m_textEditor.AutoCSetDropRestOfWord(false);
                this.m_textEditor.AutoCSetIgnoreCase(false);
                this.m_textEditor.BackSpaceUnIndents = false;
                this.m_textEditor.BufferedDraw = true;
                this.m_textEditor.CaretLineVisible = false;
                this.m_textEditor.focus = true;
                this.m_textEditor.HorizontalScrollBarVisible = true;
                this.m_textEditor.IndentationGuidesVisible = false;
                this.m_textEditor.MouseDownCaptures = true;
                this.m_textEditor.Overtype = false;
                this.m_textEditor.ReadOnly = false;
                this.m_textEditor.TabIndents = true;
                this.m_textEditor.SetTwoPhaseDraw(true);
                this.m_textEditor.UndoCollection = true;
                this.m_textEditor.UsePalette = false;
                this.m_textEditor.UseTabs = true;
                this.m_textEditor.EOLCharactersVisible = false;
                this.m_textEditor.VerticalScrollBarVisible = true;
                this.m_textEditor.WhitespaceVisibleState = (int)scintilla.WhiteSpace.invisible;
                //this.m_textEditor.WrapStartIndent = 0;
                //this.m_textEditor.WrapVisualFlags = 0;
                //this.m_textEditor.WrapVisualFlagsLocation = 0;

                /* Now that the defaults are set we can override them with any settings that are defined in the config */
                for (int i = 0; i < m_textEditorConfig.globals.Length; i++)
                {
                    String globalName = m_textEditorConfig.globals[i].name;
                    String globalValue = m_textEditorConfig.globals[i].val;
                    switch (globalName)
                    {
                        case "caret-fore":
                            this.m_textEditor.CaretForeground = parseColorValue(globalValue);
                            break;
                        case "caret-line":
                            int caretBack = parseColorValue(globalValue, -1);
                            if (caretBack != -1)
                            {
                                this.m_textEditor.CaretLineVisible = true;
                                this.m_textEditor.CaretLineBackground = caretBack;
                            }
                            break;
                        case "tab-width":
                            m_textEditor.TabWidth = parseInt(globalValue, m_textEditor.TabWidth);
                            break;
                        case "use-tabs":
                            /* != false so that it defaults to True */
                            this.m_textEditor.UseTabs = globalValue.ToLower() != "false";
                            break;
                        case "auto-indent":
                            /* != false so that it defaults to True */
                            this.m_doAutoIndent = (globalValue.ToLower() != "false");
                            break;
                    }
                }
                
                addEditorShortcutKeys(menuStrip1.Items);
                m_bAddedShortcutKeys = true;

                m_textEditor.UsePopUp = true;

                int mode = 1;
                switch (mode)
                {
                    case 0:
                        DefineFoldMarker(31 /* SC_MARKNUM_FOLDEROPEN */, 7 /* SC_MARK_MINUS */, 0xffffff, 0x000000);
                        DefineFoldMarker(30 /* SC_MARKNUM_FOLDER */, 8 /* SC_MARK_PLUS */, 0xffffff, 0x000000);
                        DefineFoldMarker(29 /* SC_MARKNUM_FOLDERSUB */, 5 /* SC_MARK_EMPTY */, 0xffffff, 0x000000);
                        DefineFoldMarker(28 /* SC_MARKNUM_FOLDERTAIL */, 5 /* SC_MARK_EMPTY */, 0xffffff, 0x000000);
                        DefineFoldMarker(25 /* SC_MARKNUM_FOLDEREND */, 5 /* SC_MARK_EMPTY */, 0xffffff, 0x000000);
                        DefineFoldMarker(26 /* SC_MARKNUM_FOLDEROPENMID */, 5 /* SC_MARK_EMPTY */, 0xffffff, 0x000000);
                        DefineFoldMarker(27 /* SC_MARKNUM_FOLDERMIDTAIL */, 5 /* SC_MARK_EMPTY */, 0xffffff, 0x000000);
                        break;
                    case 1:
                        DefineFoldMarker(31 /* SC_MARKNUM_FOLDEROPEN */, 14 /* SC_MARK_BOXMINUS */, 0xffffff, 0x808080);
                        DefineFoldMarker(30 /* SC_MARKNUM_FOLDER */, 12 /* SC_MARK_BOXPLUS */, 0xffffff, 0x808080);
                        DefineFoldMarker(29 /* SC_MARKNUM_FOLDERSUB */, 9 /* SC_MARK_VLINE */, 0xffffff, 0x808080);
                        DefineFoldMarker(28 /* SC_MARKNUM_FOLDERTAIL */, 10 /* SC_MARK_LCORNER */, 0xffffff, 0x808080);
                        DefineFoldMarker(25 /* SC_MARKNUM_FOLDEREND */, 13 /* SC_MARK_BOXPLUSCONNECTED */, 0xffffff, 0x808080);
                        DefineFoldMarker(26 /* SC_MARKNUM_FOLDEROPENMID */, 15 /* SC_MARK_BOXMINUSCONNECTED */, 0xffffff, 0x808080);
                        DefineFoldMarker(27 /* SC_MARKNUM_FOLDERMIDTAIL */, 11 /* SC_MARK_TCORNER */, 0xffffff, 0x808080);
                        break;
                };

                // configure Bookmark marker
                m_textEditor.MarkerSetFore(MARKER_BOOKMARK, 0x00007F);
                m_textEditor.MarkerSetBack(MARKER_BOOKMARK, 0x0000FF);

                String bookmarkBluegem = "" +
                    /* width height num_colors chars_per_pixel */
                    "    15    15      64            1" +
                    /* colors */ 
                    "  c none" +
                    ". c #0c0630" +
                    "# c #8c8a8c" +
                    "a c #244a84" +
                    "b c #545254" +
                    "c c #cccecc" +
                    "d c #949594" +
                    "e c #346ab4" +
                    "f c #242644" +
                    "g c #3c3e3c" +
                    "h c #6ca6fc" +
                    "i c #143789" +
                    "j c #204990" +
                    "k c #5c8dec" +
                    "l c #707070" +
                    "m c #3c82dc" +
                    "n c #345db4" +
                    "o c #619df7" +
                    "p c #acacac" +
                    "q c #346ad4" +
                    "r c #1c3264" +
                    "s c #174091" +
                    "t c #5482df" +
                    "u c #4470c4" +
                    "v c #2450a0" +
                    "w c #14162c" +
                    "x c #5c94f6" +
                    "y c #b7b8b7" +
                    "z c #646464" +
                    "A c #3c68b8" +
                    "B c #7cb8fc" +
                    "C c #7c7a7c" +
                    "D c #3462b9" +
                    "E c #7c7eac" +
                    "F c #44464c" +
                    "G c #a4a4a4" +
                    "H c #24224c" +
                    "I c #282668" +
                    "J c #5c5a8c" +
                    "K c #7c8ebc" +
                    "L c #dcd7e4" +
                    "M c #141244" +
                    "N c #1c2e5c" +
                    "O c #24327c" +
                    "P c #4472cc" +
                    "Q c #6ca2fc" +
                    "R c #74b2fc" +
                    "S c #24367c" +
                    "T c #b4b2c4" +
                    "U c #403e58" +
                    "V c #4c7fd6" +
                    "W c #24428c" +
                    "X c #747284" +
                    "Y c #142e7c" +
                    "Z c #64a2fc" +
                    "0 c #3c72dc" +
                    "1 c #bcbebc" +
                    "2 c #6c6a6c" +
                    "3 c #848284" +
                    "4 c #2c5098" +
                    "5 c #1c1a1c" +
                    "6 c #243250" +
                    "7 c #7cbefc" +
                    "8 c #d4d2d4" +
                    /* pixels */
                    "    yCbgbCy    " +
                    "   #zGGyGGz#   " +
                    "  #zXTLLLTXz#  " +
                    " p5UJEKKKEJU5p " +
                    " lfISa444aSIfl " +
                    " wIYij444jsYIw " +
                    " .OsvnAAAnvsO. " +
                    " MWvDuVVVPDvWM " +
                    " HsDPVkxxtPDsH " +
                    " UiAtxohZxtuiU " +
                    " pNnkQRBRhkDNp " +
                    " 1FrqoR7Bo0rF1 " +
                    " 8GC6aemea6CG8 " +
                    "  cG3l2z2l3Gc  " +
                    "    1GdddG1    ";

                m_textEditor.MarkerDefine(MARKER_BOOKMARK, 0 /* SC_MARK_CIRCLE */);
                //m_textEditor.MarkerDefinePixmap(MARKER_BOOKMARK, bookmarkBluegem);

                showLineNumbers(m_showLineNumbers);
                showWordWrap(m_showWordWrap);
                showWhiteSpace(m_showWhiteSpace);
                showEndOfLine(m_showEndOfLine);
                showMargin(m_showMargin);
                showFoldMargin(m_showFoldMargin);
                showAutoComplete(m_showAutoComplete);
                showHotspots(m_showHotspots);
                showIndentionGuides(m_showIndentionGuides);
                viewStatus(m_showStatus);

                updateKeywordList();

                bInitialized = true;
            }
            else
            {
                MessageBox.Show("Cannot locate iRuler.xml configuration file", "Incomplete Installation.");
                Application.Exit();
            }
            return bInitialized;
        }
        protected void addEditorShortcutKeys(ToolStripItemCollection tsic)
        {
            if (!m_bAddedShortcutKeys)
            {
                //ToolStripItemCollection tsic = menuStrip1.Items;
                for (int i = 0; i < tsic.Count; i++)
                {
                    // only get child items that are of type ToolStripMenuItem
                    if (tsic[i].GetType().Equals(typeof(ToolStripMenuItem)))
                    {
                        ToolStripMenuItem tsmi = (ToolStripMenuItem)tsic[i];
                        if (null != tsmi)
                        {
                            if (tsmi.ShortcutKeys != System.Windows.Forms.Keys.None)
                            {
                                m_textEditor.AddIgnoredKey(tsmi.ShortcutKeys, System.Windows.Forms.Keys.None);
                            }
                            addEditorShortcutKeys(tsmi.DropDownItems);
                        }
                    }
                }
            }
        }
        protected void monitorNotifications(bool bMonitor)
        {
            m_textEditor.ModEventMask = (bMonitor) ?
                (0x1 | 0x2) /* SC_MOD_INSERTTEXT | SC_MOD_DELETETEXT */ :
                0;
        }
        private void DefineFoldMarker(int marker, int markerType, int fore, int back)
        {
            m_textEditor.MarkerDefine(marker, markerType);
            m_textEditor.MarkerSetFore(marker, fore);
            m_textEditor.MarkerSetBack(marker, back);
        }

        #endregion

        #region Internal Methods

		private void refreshiRules()
		{
            if (Clients.Connected)
            {
                //treeView_iRules.Nodes.Clear();
                treeView_iRules.Nodes.Remove(m_treeNodeConfiguration);
                treeView_iRules.Nodes.Remove(m_treeNodeGlobalLB);
                treeView_iRules.Nodes.Remove(m_treeNodeLocalLB);

                m_treeNodeLocalLB.ImageIndex = 1;
                m_treeNodeLocalLB.SelectedImageIndex = 1;
                m_treeNodeGlobalLB.ImageIndex = 2;
                m_treeNodeGlobalLB.SelectedImageIndex = 2;
                if (m_configurationEditing)
                {
                    m_treeNodeConfiguration.ImageIndex = 4;
                    m_treeNodeConfiguration.SelectedImageIndex = 4;
                }

                //if (0 == treeView_iRules.Nodes.Count)
                //{
                    treeView_iRules.Nodes.Add(m_treeNodeLocalLB);
                    if (Clients.ConnectionInfo.getGTMLicensed())
                    {
                        treeView_iRules.Nodes.Add(m_treeNodeGlobalLB);
                    }
                //}

                m_treeNodeLocalLB.Nodes.Clear();
                if (Clients.ConnectionInfo.getGTMLicensed())
                {
                    m_treeNodeGlobalLB.Nodes.Clear();
                }

                if (m_configurationEditing)
                {
                    treeView_iRules.Nodes.Add(m_treeNodeConfiguration);
                    m_treeNodeConfiguration.Nodes.Clear();
                }
                if (m_offlineEditing)
                {
                    m_treeNodeOffline.Nodes.Clear();
                }

                // Query LocalLB Rules

                iControl.LocalLBRuleRuleDefinition[] rule_defs = Clients.Rule.query_all_rules();
                //Array.Sort(rule_defs, new iRuler.Utility.LocalLBiRuleDefinitionComparer());

                String [] rule_descriptions = null;

                try
                {
                    String[] rule_names = Clients.Rule.get_list();
                    rule_descriptions = Clients.Rule.get_description(rule_names);
                }
                catch (Exception)
                {
                }

                for (int i = 0; i < rule_defs.Length; i++)
                {
                    //if (0 != rule_defs[i].rule_name.IndexOf("_sys_"))
                    if ( ! (rule_defs[i].rule_name.StartsWith("_sys_")) && ! (rule_defs[i].rule_name.Contains("/_sys_")) )
                    {
                        TreeNode tn = new TreeNode();
                        iRuleInfo iri = new iRuleInfo(rule_defs[i].rule_name, rule_defs[i].rule_definition, false);
                        iri.rule_type = iRuleInfo.RuleType.LOCALLB;
                        tn.Text = rule_defs[i].rule_name;
                        tn.Tag = iri;
                        tn.NodeFont = treeView_iRules.Font;
                        tn.NodeFont = new System.Drawing.Font(tn.NodeFont, FontStyle.Regular);
                        //treeView_iRules.Nodes.Add(tn);
                        if ( null != rule_descriptions )
                        {
                            if (0 != rule_descriptions[i].Length)
                            {
                                tn.ToolTipText = rule_descriptions[i];
                            }
                            else
                            {
                                tn.ToolTipText = "No Description. Why don't you set one in the properties?";
                            }
                        }
                        m_treeNodeLocalLB.Nodes.Add(tn);
                    }
                }
                m_treeNodeLocalLB.Expand();

                // Query GlobalLB Rules

                if (Clients.ConnectionInfo.getGTMLicensed())
                {
                    iControl.GlobalLBRuleRuleDefinition[] glb_rule_defs = Clients.GlobalLBRule.query_all_rules();
                    //Array.Sort(glb_rule_defs, new iRuler.Utility.GlobalLBiRuleDefinitionComparer());

                    for (int i = 0; i < glb_rule_defs.Length; i++)
                    {
                        if (0 != glb_rule_defs[i].rule_name.IndexOf("_"))
                        {
                            TreeNode tn = new TreeNode();
                            iRuleInfo iri = new iRuleInfo(glb_rule_defs[i].rule_name, glb_rule_defs[i].rule_definition, false);
                            iri.rule_type = iRuleInfo.RuleType.GLOBALLB;
                            tn.Text = glb_rule_defs[i].rule_name;
                            tn.Tag = iri;
                            tn.NodeFont = treeView_iRules.Font;
                            tn.NodeFont = new System.Drawing.Font(tn.NodeFont, FontStyle.Regular);
                            //treeView_iRules.Nodes.Add(tn);
                            m_treeNodeGlobalLB.Nodes.Add(tn);
                        }
                    }
                    m_treeNodeGlobalLB.Expand();
                }

                // Query the Configurations
                if (m_configurationEditing)
                {
                    try
                    {
                        string remote_file = "/config/bigip.conf";
                        string conf = iRuler.Utility.FileTransfer.downloadFile(Clients.Interfaces, remote_file);
                        TreeNode tnc = new TreeNode();
                        iRuleInfo iric = new iRuleInfo(remote_file, conf, false);
                        iric.rule_type = iRuleInfo.RuleType.CONFIG;
                        tnc.Text = "bigip.conf";
                        tnc.Tag = iric;
                        tnc.NodeFont = treeView_iRules.Font;
                        tnc.NodeFont = new System.Drawing.Font(tnc.NodeFont, FontStyle.Regular);
                        m_treeNodeConfiguration.Nodes.Add(tnc);

                        remote_file = "/config/bigip_base.conf";
                        conf = iRuler.Utility.FileTransfer.downloadFile(Clients.Interfaces, remote_file);
                        tnc = new TreeNode();
                        iric = new iRuleInfo(remote_file, conf, false);
                        iric.rule_type = iRuleInfo.RuleType.CONFIG;
                        tnc.Text = "bigip_base.conf";
                        tnc.Tag = iric;
                        tnc.NodeFont = treeView_iRules.Font;
                        tnc.NodeFont = new System.Drawing.Font(tnc.NodeFont, FontStyle.Regular);
                        m_treeNodeConfiguration.Nodes.Add(tnc);
                    }
                    catch (Exception)
                    {
                        // User most likely doesn't have privileges to download files...
                    }
                }

                // TODO: Query the offline iRules



                m_textEditor.Text = "";
            }
            else
            {
                m_treeNodeOffline.Nodes.Clear();
            }
            if (m_offlineEditing)
            {
                refreshOffline();
            }
		}
        private void refreshOffline()
        {
            // Check for Offline files
            String sArchiveDir = Configuration.getConfigSubDir("Offline");
            String [] files = System.IO.Directory.GetFiles(sArchiveDir, "*.txt");
            if (files.Length > 0)
            {
                DoDropFiles(files, false, m_treeNodeOffline);
                for (int i = 0; i < m_treeNodeOffline.Nodes.Count; i++)
                {
                    markItem(m_treeNodeOffline.Nodes[i], false);
                }
            }
        }
		private void updateMenus()
		{
            toolStripMenuItem_ViewLineNumbers.Checked = m_showLineNumbers;
            toolStripMenuItem_ViewWordWrap.Checked = m_showWordWrap;
            toolStripMenuItem_ViewWhiteSpace.Checked = m_showWhiteSpace;
            toolStripMenuItem_ViewEndOfLine.Checked = m_showEndOfLine;
            toolStripMenuItem_ViewMargin.Checked = m_showMargin;
            toolStripMenuItem_ViewFoldMargin.Checked = m_showFoldMargin;
            toolStripMenuItem_ViewAutoComplete.Checked = m_showAutoComplete;
            toolStripMenuItem_ViewHotspots.Checked = m_showHotspots;
            toolStripMenuItem_ViewIndentionGuides.Checked = m_showIndentionGuides;
		    toolStripMenuItem_ShowSplashScreen.Checked = m_showSplashScreen;
			ToolStripMenuItem_ToolsBIGIPConfigAutoSave.Checked = m_autoSaveConfig;

            bool hasSelection = (m_textEditor.SelectionStart != m_textEditor.SelectionEnd);
            toolStripMenuItem_EditCut.Enabled = hasSelection;
            toolStripMenuItem_EditCopy.Enabled = hasSelection;
            toolStripMenuItem_EditDelete.Enabled = hasSelection;
            toolStripMenuItem_EditPaste.Enabled = m_textEditor.CanPaste;

            toolStripMenuItem_EditUndo.Enabled = m_textEditor.CanUndo;
            toolStripMenuItem_EditRedo.Enabled = m_textEditor.CanRedo;

            updateStatusLabels();
        }
		private void showButtons(bool visible)
		{
            bool bItemSelected = false;
            bool bGTMRule = false;
            TreeNode tn = getCurrentItem();
            if ((null != tn) && (null != tn.Tag))
            {
                bItemSelected = true;
                if (((iRuleInfo)tn.Tag).rule_type == iRuleInfo.RuleType.GLOBALLB)
                {
                    bGTMRule = true;
                }
            }

            toolStripMenuItem_FileNew.Enabled = visible;
            toolStripMenuItem_FileDelete.Enabled = visible && bItemSelected;
            toolStripMenuItem_FileSave.Enabled = visible && bItemSelected;
            toolStripMenuItem_FileSaveAll.Enabled = visible;
            toolStripMenuItem_FileArchiveExport.Enabled = visible;
            toolStripMenuItem_FileArchiveImport.Enabled = visible;
            toolStripMenuItem_ToolsDataGroupEditor.Enabled = visible;
            toolStripMenuItem_ToolsShare.Enabled = visible && bItemSelected;
            toolStripMenuItem_ToolsGenerateTraffic.Enabled = visible;
			ToolStripMenuItem_ToolsBIGIPConfigSaveConfig.Enabled = visible;
            toolStripMenuItem_CopyOffline.Enabled = visible;

            //toolStripButton_Connect.Enabled = true;
            toolStripButton_New.Enabled = visible;
            toolStripButton_Save.Enabled = visible && bItemSelected;
            toolStripButton_Delete.Enabled = visible && bItemSelected;
            toolStripButton_Share.Enabled = visible && bItemSelected;
            toolStripButton_CheckSyntax.Enabled = visible && bItemSelected;
            toolStripButton_DataGroups.Enabled = visible;
            toolStripButton_RefreshList.Enabled = visible;
            toolStripButton_GenerateTraffic.Enabled = visible;

            toolStripMenuItem_Save.Enabled = visible && bItemSelected;
            toolStripMenuItem_Delete.Enabled = visible && bItemSelected;
            toolStripMenuItem_CheckSyntax.Enabled = visible && bItemSelected;
            toolStripMenuItem_Share.Enabled = visible && bItemSelected;
            toolStripMenuItem_Reset.Enabled = visible && bItemSelected;

            // HACK, until we get GTM stats working
            toolStripMenuItem_Properties.Enabled = visible && bItemSelected && !bGTMRule;

			//m_textEditor.Enabled = visible;

            if ((null != tn) && (m_treeNodeOffline == tn.Parent))
            {
                toolStripMenuItem_FileNew.Enabled = true;
                toolStripMenuItem_FileSave.Enabled = true;
                toolStripMenuItem_FileDelete.Enabled = true;

                toolStripButton_New.Enabled = true;
                toolStripButton_Save.Enabled = true;
                toolStripButton_Delete.Enabled = true;
                toolStripButton_RefreshList.Enabled = true;

                toolStripMenuItem_Save.Enabled = true;
                toolStripMenuItem_Delete.Enabled = true;
                toolStripMenuItem_Reset.Enabled = true;

                toolStripButton_CheckSyntax.Enabled = false;
                toolStripMenuItem_CopyOffline.Enabled = false;
                toolStripMenuItem_CheckSyntax.Enabled = false;
                toolStripMenuItem_Share.Enabled = false;
                toolStripMenuItem_Properties.Enabled = false;
            }
            else if (m_treeNodeOffline == tn)
            {
                toolStripMenuItem_FileNew.Enabled = true;
                toolStripMenuItem_FileDelete.Enabled = true;

                toolStripButton_New.Enabled = true;
                toolStripButton_RefreshList.Enabled = true;

                toolStripMenuItem_CopyOffline.Enabled = false;
                toolStripMenuItem_CheckSyntax.Enabled = false;
                toolStripMenuItem_Share.Enabled = false;
                toolStripMenuItem_Properties.Enabled = false;
            }
		}
		private void updateTitle(bool modified)
		{
            String newTitle = APP_TITLE;

            if (Clients.Connected)
            {
                newTitle = newTitle + " - " + Clients.ConnectionInfo.hostname;
				if (m_currentPartition.Length > 0)
				{
					newTitle = newTitle + " (" + m_currentPartition + ")";
				}
            }

            TreeNode tn = getCurrentItem();
            if (null != tn)
            {
                iRuleInfo iri = (iRuleInfo)tn.Tag;
                if (null != iri)
                {
                    newTitle = newTitle + " - " + iri.rule_name;
                    if (iri.modified)
                    {
                        newTitle = newTitle + "*";
                    }
                }
            }
            if (!this.Text.Equals(newTitle))
            {
                this.Text = newTitle;
            }
		}
        private void uncheckAllChildMenus(ToolStripMenuItem tsmi)
        {
            tsmi.Checked = false;
            foreach(ToolStripItem tsi in tsmi.DropDownItems)
            {
                uncheckAllChildMenus((ToolStripMenuItem)tsi);
            }
        }
        private ToolStripMenuItem findChildMenu(ToolStripMenuItem tsmi, string tag)
        {
            ToolStripMenuItem childMenu = null;
            foreach (ToolStripItem tsi in tsmi.DropDownItems)
            {
                if (tsi.Tag.Equals(tag))
                {
                    childMenu = (ToolStripMenuItem)tsi;
                }
                else
                {
                    childMenu = findChildMenu((ToolStripMenuItem)tsi, tag);
                }
                if (null != childMenu)
                {
                    break;
                }
            }
            return childMenu;
        }

        private void resetPartitionMenus(Boolean bCheckActive = true)
        {
            // Partitions
            if (toolStripMenuItem_FilePartition.Enabled)
            {
                // Uncheck all sub menu items
                uncheckAllChildMenus(toolStripMenuItem_FilePartition);
                String active_partition = Clients.Interfaces.ManagementPartition.get_active_partition();
                
                // Find the sub menu item that matches the current partition
                ToolStripMenuItem tsmi = findChildMenu(toolStripMenuItem_FilePartition, active_partition);
                if (null != tsmi)
                {
                    tsmi.Checked = true;
                }

            }

            // Folders
            if (ToolStripMenuItem_FileFolder.Enabled)
            {
                // uncheck all sub menu items
                String active_folder = Clients.Interfaces.SystemSession.get_active_folder();
                uncheckAllChildMenus(ToolStripMenuItem_FileFolder);

                // Find the sub menu item that matches the current folder
                ToolStripMenuItem tsmi = findChildMenu(toolStripMenuItem_FilePartition, active_folder);
                if (null != tsmi)
                {
                    tsmi.Checked = true;
                }
            }
        }
		private void updatePartitionInfo()
		{
			// Remove sub menu items
			toolStripMenuItem_FilePartition.DropDownItems.Clear();

			try 
			{
				// Enable the Menu Item
				toolStripMenuItem_FilePartition.Enabled = true;

				// Query the partition list and dynamically create menu items.
                ToolStripMenuItem tsi2 =
                    (ToolStripMenuItem)toolStripMenuItem_FilePartition.DropDownItems.Add("[All]", null, this.toolStripMenuItem_DynamicClick);
                tsi2.Tag = "[All]";
                tsi2.Enabled = false;

				iControl.ManagementPartitionAuthZPartition [] partition_list = Clients.Interfaces.ManagementPartition.get_partition_list();
				foreach (iControl.ManagementPartitionAuthZPartition partition in partition_list)
				{
					//ToolStripItem tsi = new ToolStripItem();
					//tsi.Text = partition.partition_name;
					//tsi.Enabled = false;
					//tsi.Click += new System.EventHandler(this.toolStripMenuItem_DynamicClick);
					tsi2 = (ToolStripMenuItem)toolStripMenuItem_FilePartition.DropDownItems.Add(partition.partition_name, null, this.toolStripMenuItem_DynamicClick);
                    tsi2.Tag = partition.partition_name;
                    tsi2.Enabled = false;
				}

				// Query the permissions for the given user.
				iControl.ManagementUserManagementUserPermission [] perms = 
					Clients.Interfaces.ManagementUserManagement.get_my_permission();
				foreach (ManagementUserManagementUserPermission perm in perms)
				{
					if ( perm.partition.ToLower().Equals("[all]") )
					{
						for (int i = 0; i < toolStripMenuItem_FilePartition.DropDownItems.Count; i++)
						{
							toolStripMenuItem_FilePartition.DropDownItems[i].Enabled = true;
						}
						break;
					}
					else
					{
						for (int i = 0; i < toolStripMenuItem_FilePartition.DropDownItems.Count; i++)
						{
							if (toolStripMenuItem_FilePartition.DropDownItems[i].Text.Equals(perm.partition) )
							{
                                toolStripMenuItem_FilePartition.DropDownItems[i].Enabled = true;
                                //switch (perm.role)
                                //{
                                //    case ManagementUserManagementUserRole.USER_ROLE_ADMINISTRATOR:
                                //        {
                                //            toolStripMenuItem_FilePartition.DropDownItems[i].Enabled = true;
                                //        }
                                //        break;
                                //    case ManagementUserManagementUserRole.USER_ROLE_MANAGER:
                                //        {
                                //            toolStripMenuItem_FilePartition.DropDownItems[i].Enabled = true;
                                //        }
                                //        break;
                                //    /*
                                //    case ManagementUserManagementUserRole.USER_ROLE_APPLICATION_EDITOR:
                                //    case ManagementUserManagementUserRole.USER_ROLE_ASM_POLICY_EDITOR:
                                //    case ManagementUserManagementUserRole.USER_ROLE_CERTIFICATE_MANAGER:
                                //    case ManagementUserManagementUserRole.USER_ROLE_EDITOR:
                                //    case ManagementUserManagementUserRole.USER_ROLE_GUEST:
                                //    case ManagementUserManagementUserRole.USER_ROLE_INVALID:
                                //    case ManagementUserManagementUserRole.USER_ROLE_TRAFFIC_MANAGER:
                                //    case ManagementUserManagementUserRole.USER_ROLE_USER_MANAGER:
                                //    */
                                //}
							}
						}
					}
				}

				// Select the active partition
				String active_partition = Clients.Interfaces.ManagementPartition.get_active_partition();

                // Ensure that the user has perms for the active partition.  If not, change it to one in their list of perms.
                Boolean bHasPermForActive = false;
                foreach (ManagementUserManagementUserPermission perm in perms)
                {
                    if (perm.partition.Equals("[All]"))
                    {
                        bHasPermForActive = true;
                        break;
                    }
                    else if (perm.partition.Equals(active_partition))
                    {
                        bHasPermForActive = true;
                        break;
                    }
                }
                if (!bHasPermForActive)
                {
                    String partToUse = perms[0].partition;
                    foreach (ToolStripItem tsi in toolStripMenuItem_FilePartition.DropDownItems)
                    {
                        if (tsi.Text.Equals(partToUse))
                        {
                            Clients.Interfaces.ManagementPartition.set_active_partition(tsi.Text);
                            active_partition = tsi.Text;
                            break;
                        }
                    }
                }

				for (int i = 0; i < toolStripMenuItem_FilePartition.DropDownItems.Count; i++)
				{
					ToolStripMenuItem tsmi = (ToolStripMenuItem)toolStripMenuItem_FilePartition.DropDownItems[i];
					if (tsmi.Text.Equals(active_partition))
					{
						tsmi.Checked = true;
					}
					else
					{
						tsmi.Checked = false;
					}
					m_currentPartition = active_partition;
				}


			}
			catch(Exception)
			{
				toolStripMenuItem_FilePartition.Enabled = false;
			}
		}
        private void updateFolderInfo()
        {
            try
            {
                ToolStripMenuItem_FileFolder.Enabled = true;

                CommonEnabledState old_state = Clients.Interfaces.SystemSession.get_recursive_query_state();

                Clients.Interfaces.SystemSession.set_recursive_query_state(old_state == CommonEnabledState.STATE_DISABLED ? CommonEnabledState.STATE_ENABLED : CommonEnabledState.STATE_DISABLED);

                String old_folder = Clients.Interfaces.SystemSession.get_active_folder();
                Clients.Interfaces.SystemSession.set_active_folder("/");

                String [] folder_list = Clients.Interfaces.ManagementFolder.get_list();
                Array.Sort(folder_list);

                ToolStripMenuItem tsiRoot = 
                    (ToolStripMenuItem)ToolStripMenuItem_FileFolder.DropDownItems.Add("/", null, this.toolStripMenuItem_FolderDynamicClick);
                tsiRoot.Tag = "/";

                foreach (String folder in folder_list)
                {
                    if (!folder.Equals("/"))
                    {
                        // format /common/folder/foo
                        String[] tokens = folder.Split(new char[] { '/' });
                        ToolStripMenuItem tsi = tsiRoot;

                        for (int i = 1; i < tokens.Length; i++)
                        {
                            Boolean bFound = false;
                            // First look for existing children
                            for (int j = 0; j < tsi.DropDownItems.Count; j++)
                            {
                                if (tsi.DropDownItems[j].Text.Equals(tokens[i]))
                                {
                                    bFound = true;
                                    tsi = (ToolStripMenuItem)tsi.DropDownItems[j];
                                    break;
                                }
                            }
                            if (!bFound)
                            {
                                tsi = (ToolStripMenuItem)tsi.DropDownItems.Add(tokens[i], null, this.toolStripMenuItem_FolderDynamicClick);
                                tsi.Tag = folder;
                            }
                        }
                    }
                }


                Clients.Interfaces.SystemSession.set_active_folder(old_folder);
                Clients.Interfaces.SystemSession.set_recursive_query_state(old_state);
            }
            catch (Exception)
            {
                ToolStripMenuItem_FileFolder.Enabled = false;
            }
        }

		private void updateIndentionSettings()
		{
			this.m_textEditor.UseTabs = m_useTabs;
			this.m_textEditor.Indent = m_indentSize;
			this.m_textEditor.TabWidth = m_tabSize;
		}

        public void updateStatusLabels()
        {
            int pos = m_textEditor.CurrentPos;
            int character = pos+1;
            int line = pos+1;
            int col = pos+1;
            if (pos > 0)
            {
                line = m_textEditor.LineFromPosition(pos) + 1;
                col = m_textEditor.GetColumn(pos) + 1;
            }
            toolStripStatusLabel_Character.Text = "Ch " + character.ToString();
            toolStripStatusLabel_Line.Text = "Ln " + line.ToString();
            toolStripStatusLabel_Column.Text = "Col " + col.ToString();
        }
        private void markItem(TreeNode tn, bool bDirty)
		{
            if (null != tn)
            {
                iRuleInfo iri = (iRuleInfo)tn.Tag;
                if (null != iri)
                {
                    //bool bModified = !m_textEditor.Text.Equals(iri.original_rule_details);
                    //iri.modified = bModified;
                    iri.modified = bDirty;
                    if (iri.modified)
                    {
                        if (!tn.NodeFont.Bold)
                        {
                            tn.NodeFont = new System.Drawing.Font(treeView_iRules.Font, FontStyle.Bold);
                        }
                        if (!tn.Text.EndsWith("*"))
                        {
                            tn.Text = tn.Text + "*";
                        }
                    }
                    else
                    {
                        if (tn.NodeFont.Bold)
                        {
                            tn.NodeFont = new System.Drawing.Font(treeView_iRules.Font, FontStyle.Regular);
                        }
                        if (tn.Text.EndsWith("*"))
                        {
                            tn.Text = tn.Text.Remove(tn.Text.Length - 1, 1);
                        }
                    }
                    updateTitle(iri.modified);
                }
            }
		}
        private TreeNode getCurrentItem()
        {
            TreeNode tn = treeView_iRules.SelectedNode;

            // If none selected, fall back to last selected node.
            if (null == tn)
            {
                tn = m_lastTreeViewNode;
            }
            return tn;
        }

        public void viewStatus(bool bVisible)
        {
            toolStripMenuItem_ViewStatus.Checked = bVisible;
            m_showStatus = bVisible;
            if (!bVisible)
            {
                splitContainer2.SplitterDistance = splitContainer2.Height;
            }
            else
            {
                int lines = textBox_Status.Lines.Length;
                if (0 == lines)
                {
                    lines++;
                }
                int font_height = textBox_Status.Font.Height;
                int status_height = (lines * font_height) + 5;
                if (status_height < 20)
                {
                    status_height = 25;
                }
                if (status_height > splitContainer2.Height / 3)
                {
                    status_height = splitContainer2.Height / 3;
                }
                splitContainer2.SplitterDistance = splitContainer2.Height - status_height;
                textBox_Status.Refresh();
            }
        }
        public void setStatus(String sText, bool bVisible)
        {
            textBox_Status.Text = sText;
            viewStatus(bVisible);
        }
        public string getStatus()
        {
            return textBox_Status.Text;
        }
        public void appendStatus(String sText, bool bVisible)
        {
            setStatus(textBox_Status.Text + "\n" + sText, bVisible);
        }
        public bool getStatusVisible()
		{
            return (0 != splitContainer2.SplitterDistance);
		}

        public String getCurrentWord(int position)
        {
            String sCurrentWord  = "";

            //position--;
            if (position < 0)
            {
                position = 0;
            }
            char[] chars = m_textEditor.Text.ToCharArray();

            if (position >= chars.Length)
            {
                position = chars.Length - 1;
            }


            // Try to determine the hotspot token
            int index = position;
            int start = 0;
            int end = 0;
            int i = 0;
            for (i = position; i >= 0; i--)
            {
                if (Char.IsNumber(chars[i]) || Char.IsLetter(chars[i]) || (':' == chars[i]) || ('_' == chars[i]) || ('.' == chars[i]))
                {
                    continue;
                }
                else
                {
                    start = i + 1;
                    break;
                }
            }
            for (i = position; i < chars.Length; i++)
            {
				if (Char.IsNumber(chars[i]) || Char.IsLetter(chars[i]) || (':' == chars[i]) || ('_' == chars[i]) || ('.' == chars[i]))
                {
                    continue;
                }
                else
                {
                    end = i - 1;
                    break;
                }
            }
            if ((0 == end) && (chars.Length == i))
            {
                end = chars.Length - 1;
            }

            if ((0 != end) && ((end - start) > 0))
            {
                for (i = start; i <= end; i++)
                {
                    sCurrentWord = sCurrentWord + chars[i];
                }
            }

            return sCurrentWord;
        }
        public String getListOfMatches(String word)
        {
            String matchList = "";
            TreeNode tn = getCurrentItem();
            if ((null != tn) && (null != tn.Tag))
            {
                iRuleInfo iri = (iRuleInfo)tn.Tag;
                if (iRuleInfo.RuleType.LOCALLB == iri.rule_type)
                {
                    for (int i = 0; i < m_keyWordListLTM.Length; i++)
                    {
                        if (m_keyWordListLTM[i].StartsWith(word))
                        {
                            if (matchList.Length > 0)
                            {
                                matchList = matchList + ';';
                            }
                            matchList = matchList + m_keyWordListLTM[i];
                        }
                    }
                }
                else if (iRuleInfo.RuleType.GLOBALLB == iri.rule_type)
                {
                    for (int i = 0; i < m_keyWordListGTM.Length; i++)
                    {
                        if (m_keyWordListGTM[i].StartsWith(word))
                        {
                            if (matchList.Length > 0)
                            {
                                matchList = matchList + ';';
                            }
                            matchList = matchList + m_keyWordListGTM[i];
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < m_keyWordListLTM.Length; i++)
                {
                    if (m_keyWordListLTM[i].StartsWith(word))
                    {
                        if (matchList.Length > 0)
                        {
                            matchList = matchList + ';';
                        }
                        matchList = matchList + m_keyWordListLTM[i];
                    }
                }
            }
            return matchList;
        }

		public void showWordWrap(bool bShow)
		{
			m_showWordWrap = bShow;
			m_textEditor.WrapMode = bShow ? 1 : 0;
			updateMenus();
		}
        public void showWhiteSpace(bool bShow)
		{
			m_showWhiteSpace = bShow;
			m_textEditor.WhitespaceVisibleState = m_showWhiteSpace ? 1 : 0;
			updateMenus();
		}
		public void showEndOfLine(bool bShow)
		{
			m_showEndOfLine = bShow;
			//m_textEditor.EndOfLineMode = m_showEndOfLine ? 1 : 0;
			m_textEditor.EOLCharactersVisible = m_showEndOfLine;
			updateMenus();
		}
		public void showLineNumbers(bool bShow)
		{
			int pixels = 0;
			int lineNumWidth = 1;
			int lineNumbersWidth = 4;
			m_showLineNumbers = bShow;
			if ( m_showLineNumbers )
			{
				int lineCount = m_textEditor.LineCount;
				lineNumWidth = 1;
				while(lineCount >= 10)
				{
					lineCount /= 10;
					++lineNumWidth;
				}
				if ( lineNumWidth < lineNumbersWidth)
				{
					lineNumWidth = lineNumbersWidth;
				}
				int textWidth = m_textEditor.TextWidth(9 /*STYLE_LINENUMBER*/, "9");
				int pixelWidth = 4 + (lineNumWidth * textWidth);

				m_textEditor.set_MarginWidthN(0, pixelWidth);
			}
			else
			{
				m_textEditor.set_MarginWidthN(0, pixels);
			}
			updateMenus();
		}
		public void showMargin(bool bShow)
		{
			m_showMargin = bShow;
			int marginWidthDefault = 20;
			m_textEditor.set_MarginWidthN(1, m_showMargin ? marginWidthDefault : 0);
			updateMenus();

		}
		public void showFoldMargin(bool bShow)
		{
			m_showFoldMargin = bShow;
			int foldMarginWidthDefault = 14;
			m_textEditor.set_MarginWidthN(2, m_showFoldMargin ? foldMarginWidthDefault : 0);
			updateMenus();
		}
        public void showSplashScreen(bool bShow)
        {
            m_showSplashScreen = bShow;
            updateMenus();
        }
        public void showAutoComplete(bool bShow)
        {
            m_showAutoComplete = bShow;
            updateMenus();
        }
        public void showHotspots(bool bShow)
        {
            m_showHotspots = bShow;
            //m_textEditor.StyleSetHotSpot(4, bShow);	// word in quote
            m_textEditor.StyleSetHotspot(12, bShow);  // iRule commmands
            m_textEditor.StyleSetHotspot(13, bShow);  // iRule Events
            m_textEditor.StyleSetHotspot(14, bShow);  // tcl commands
            m_textEditor.StyleSetHotspot(15, bShow);  // tcl not supported
            updateMenus();
        }
        public void showIndentionGuides(bool bShow)
        {
            m_showIndentionGuides = bShow;
            m_textEditor.IndentationGuidesVisible = bShow;
            updateMenus();
        }
        private bool showCommandAC(String sWord)
        {
            bool bProcessed = false;
            String[][] paramLists = new String[][]
                {
                    //new String [] {"log", "local0. ;local1. ;local2. ;local3. ;local4. "},
                    //new String [] {"string", "bytelength ;compare ;equal ;first ;index ;is alnum ;is alpha ;is ascii ;is boolean ;is control ;is digit ;is double ;is false ;is graph ;is integer ;is lower ;is print ;is punct ;is space ;is true ;is upper ;is wideinteger ;is wordchar ;is xdigit ;last ;length ;map ;match ;range ;repeat ;replace ;tolower ;totitle ;toupper ;trim ;trimleft ;trimright ;wordend ;wordstart "},
                    //new String [] {"HTTP::cookie", "names ;count ;version ;path ;domain ;\nports ;insert ;remove ;sanitize ;exists ;maxage ;expires ;comment ;secure ;commenturl ;discard ;encrypt ;decrypt "},
                    //new String [] {"HTTP::header", "names ;count ;at ;exists ;insert ;replace ;remove ;insert_modssl_fields ;sanitize "},
                    //new String [] {"HTTP::payload", "length ;replace "},
                    new String [] {"HTTP::cookie", "names"},
                    new String [] {"HTTP::cookie", "count"},
                    new String [] {"HTTP::cookie", "[value] <name> [<string>]"},
                    new String [] {"HTTP::cookie", "version <name> [version]"},
                    new String [] {"HTTP::cookie", "path <name> [path]"},
                    new String [] {"HTTP::cookie", "domain <name> [domain]"},
                    new String [] {"HTTP::cookie", "ports <name> [portlist]"},
                    new String [] {"HTTP::cookie", "insert name <name> value <value> [path <path>] [domain <domain>] [version <0 | 1 | 2>]"},
                    new String [] {"HTTP::cookie", "remove <name>"},
                    new String [] {"HTTP::cookie", "sanitize [attribute]+"},
                    new String [] {"HTTP::cookie", "exists <name>"},
                    new String [] {"HTTP::cookie", "maxage <name> [seconds]"},
                    new String [] {"HTTP::cookie", "expires <name> [seconds] [absolute | relative]"},
                    new String [] {"HTTP::cookie", "comment <name> [comment]"},
                    new String [] {"HTTP::cookie", "secure <name> [enable|disable]"},
                    new String [] {"HTTP::cookie", "commenturl <name> [commenturl]"},
                    new String [] {"HTTP::cookie", "discard <name> [enable|disable]"},
                    new String [] {"HTTP::cookie", "encrypt <name> <pass phrase> <data> [\"128\" | \"192\" | \"256\"]"},
                    new String [] {"HTTP::cookie", "decrypt <name> <pass phrase> <data> [\"128\" | \"192\" | \"256\"]"},
                };
            String sTooltip = "";
            for (int i = 0; i < paramLists.Length; i++)
            {
                if (sWord.Equals(paramLists[i][0]))
                {
                    //m_textEditor.AutoCShow(0, paramLists[i][1]);
                    //m_textEditor.CallTipShow(m_textEditor.CurrentPos, paramLists[i][1]);
                    if (0 != sTooltip.Length)
                    {
                        sTooltip = sTooltip + "\n";
                    }
                    sTooltip = sTooltip + paramLists[i][1];
                    bProcessed = true;
                    //break;
                }
            }
            if (0 != sTooltip.Length)
            {
                m_textEditor.CallTipShow(m_textEditor.CurrentPos, sTooltip);
                bProcessed = true;
            }
            return bProcessed;
        }
		private void autoSaveConfiguration(bool bAutoSaveConfig)
		{
			m_autoSaveConfig = bAutoSaveConfig;
			updateMenus();
		}

        private void DoConnect()
        {
            if (!DoDisconnect())
            {

                //ConnectionDialog cd = new ConnectionDialog(); 
                iControl.Dialogs.ConnectionDialog cd = new iControl.Dialogs.ConnectionDialog();
                cd.ConnectionInfo = Clients.ConnectionInfo;

                cd.centerX = this.Location.X + (this.Width / 2);
                cd.centerY = this.Location.Y + (this.Height / 2);
                DialogResult dr = cd.ShowDialog(this);

                if (DialogResult.OK == dr)
                {
                    Clients.initialize();

                    if (Clients.Connected)
                    {
                        toolStripMenuItem_FileConnect.Text = "Dis&connect";
                        toolStripButton_Connect.Image = global::iRuler.Properties.Resources.ToolbarDisconnect;
                        toolStripButton_Connect.Text = "Disconnect.  Click the Connect button...";
                        statusStripLabel_Connection.Text = "Connected to " + Clients.ConnectionInfo.hostname;
                        setStatus(statusStripLabel_Connection.Text, getStatusVisible());

                        updatePartitionInfo();
                        //updateFolderInfo();
                        refreshiRules();
                        showButtons(true);
                        updateTitle(false);
                    }
                }
                else
                {
                    setStatus("The host you have specified must be a v9.x BIG-IP", true);
                }
            }
        }

        private void DoConnect(string sHostname, string sUsername, string sPassword)
        {
            DoDisconnect();
            // Check to see if we received valid arguments and connect if possible 
            if (!string.IsNullOrEmpty(sHostname) && !string.IsNullOrEmpty(sUsername) && !string.IsNullOrEmpty(sPassword))
            {
                Clients.ConnectionInfo.hostname = sHostname;
                Clients.ConnectionInfo.username = sUsername;
                Clients.ConnectionInfo.password = sPassword;
                Clients.initialize();

                iControl.SystemProductInformation prodInfo = Clients.SystemInfo.get_product_information();
                if (null != prodInfo.product_code)
                {
                    Clients.ConnectionInfo.setHostType(prodInfo.product_code);
                }

                // Check for GTM Support
                bool bGTMLicensed = false;
                for (int i = 0; i < prodInfo.product_features.Length; i++)
                {
                    if (prodInfo.product_features[i].Equals("GTM Rules"))
                    {
                        bGTMLicensed = true;
                        break;
                    }
                }
                Clients.ConnectionInfo.setGTMLicensed(bGTMLicensed);


                if (Clients.Connected)
                {
                    toolStripMenuItem_FileConnect.Text = "Dis&connect";
                    toolStripButton_Connect.Image = global::iRuler.Properties.Resources.ToolbarDisconnect;
                    toolStripButton_Connect.Text = "Disconnect.  Click the Connect button...";
                    statusStripLabel_Connection.Text = "Connected to " + Clients.ConnectionInfo.hostname;
                    setStatus(statusStripLabel_Connection.Text, getStatusVisible());

                    updatePartitionInfo();
                    //updateFolderInfo();
                    refreshiRules();
                    showButtons(true);
                    updateTitle(false);
                }
            }
        }
        private bool DoDisconnect()
        {
            bool bDisconnected = false;
            if (Clients.Connected)
            {
                Clients.Connected = false;
                toolStripMenuItem_FileConnect.Text = "&Connect";
                statusStripLabel_Connection.Text = "Disconnected. Click the Connect button...";
                toolStripButton_Connect.Image = global::iRuler.Properties.Resources.ToolbarConnect;
                toolStripButton_Connect.Text = "Connect";
                //treeView_iRules.Nodes.Clear();
                treeView_iRules.Nodes.Remove(m_treeNodeConfiguration);
                treeView_iRules.Nodes.Remove(m_treeNodeLocalLB);
                treeView_iRules.Nodes.Remove(m_treeNodeGlobalLB);
                m_textEditor.Text = "";
                m_lastTreeViewNode = null;
                showButtons(false);
                setStatus("Disconnected", getStatusVisible());
                m_currentPartition = "";
                updateTitle(false);
                bDisconnected = true;
            }
            return bDisconnected;
        } 

        private void DoConnect2()
        {
            if (Clients.Connected)
            {
                Clients.Connected = false;
                toolStripMenuItem_FileConnect.Text = "&Connect";
                statusStripLabel_Connection.Text = "Disconnected. Click the Connect button...";
                toolStripButton_Connect.Image = global::iRuler.Properties.Resources.ToolbarConnect;
                toolStripButton_Connect.Text = "Connect";
                //treeView_iRules.Nodes.Clear();
                treeView_iRules.Nodes.Remove(m_treeNodeConfiguration);
                treeView_iRules.Nodes.Remove(m_treeNodeLocalLB);
                treeView_iRules.Nodes.Remove(m_treeNodeGlobalLB);
                m_textEditor.Text = "";
                m_lastTreeViewNode = null;
                showButtons(false);
                setStatus("Disconnected", getStatusVisible());
				m_currentPartition = "";
                updateTitle(false);
            }
            else
            {
                //ConnectionDialog cd = new ConnectionDialog();
				iControl.Dialogs.ConnectionDialog cd = new iControl.Dialogs.ConnectionDialog();
				cd.ConnectionInfo = Clients.ConnectionInfo;

                cd.centerX = this.Location.X + (this.Width / 2);
                cd.centerY = this.Location.Y + (this.Height / 2);
                DialogResult dr = cd.ShowDialog(this);

                if (DialogResult.OK == dr)
                {
                    Clients.initialize();

                    toolStripMenuItem_FileConnect.Text = "Dis&connect";
                    toolStripButton_Connect.Image = global::iRuler.Properties.Resources.ToolbarDisconnect;
                    toolStripButton_Connect.Text = "Disconnect.  Click the Connect button...";
                    statusStripLabel_Connection.Text = "Connected to " + Clients.ConnectionInfo.hostname;
                    setStatus(statusStripLabel_Connection.Text, getStatusVisible());

					updatePartitionInfo();
                    //updateFolderInfo();
					refreshiRules();
                    showButtons(true);
                    updateTitle(false);
                }
                else
                {
                    setStatus("The host you have specified must be a v9.x BIG-IP", true);
                }
            }
        }
        private bool DoNew()
		{
			bool bNew = false;
			PromptDialog pd = new PromptDialog();

			// build a list of existing iRule Names
			String[] iRuleNames = new String[m_treeNodeGlobalLB.Nodes.Count + m_treeNodeLocalLB.Nodes.Count];
			for (int i = 0; i < m_treeNodeGlobalLB.Nodes.Count; i++)
			{
				iRuleNames[i] = m_treeNodeGlobalLB.Nodes[i].Text;
			}
			for (int i = 0; i < m_treeNodeLocalLB.Nodes.Count; i++)
			{
				iRuleNames[m_treeNodeGlobalLB.Nodes.Count + i] = m_treeNodeLocalLB.Nodes[i].Text;
			}
			pd.m_existingiRules = iRuleNames;

			DialogResult dr = pd.ShowDialog();
			if ( DialogResult.OK == dr )
			{
				String sRule = pd.m_ruleName;
				String sRuleDef = "when HTTP_REQUEST {\n}";
				if ( pd.m_ruleDefault.Length > 0 )
				{
					sRuleDef = pd.m_ruleDefault;
				}

                TreeNode tn = new TreeNode();
                tn.Text = sRule + "*";
                tn.NodeFont = new System.Drawing.Font(treeView_iRules.Font, FontStyle.Regular);
                iRuleInfo iri = new iRuleInfo(sRule, sRuleDef, true);
                iri.rule_type = pd.m_ruleType;
                tn.Tag = iri;
                tn.ImageIndex = 0;
                //int index = treeView_iRules.Nodes.Add(tn);
                //treeView_iRules.Nodes.Insert(0,tn);
                TreeNode tnCurr = getCurrentItem();
                if (null != tnCurr)
                {
                    if (tnCurr.Parent == m_treeNodeOffline)
                    {
                        m_treeNodeOffline.Nodes.Insert(0, tn);
                    }
                    else if (!Clients.Connected)
                    {
                        m_treeNodeOffline.Nodes.Insert(0, tn);
                    }
                    else
                    {
                        switch (iri.rule_type)
                        {
                            case iRuleInfo.RuleType.GLOBALLB:
                                if (Clients.ConnectionInfo.getGTMLicensed())
                                {
                                    m_treeNodeGlobalLB.Nodes.Insert(0, tn);
                                }
                                break;
                            case iRuleInfo.RuleType.LOCALLB:
                            default:
                                m_treeNodeLocalLB.Nodes.Insert(0, tn);
                                break;
                        }
                    }
                }
                // TODO
                //tn.IsSelected = true;
                treeView_iRules.SelectedNode = tn;
                treeView_iRules.Select();
                treeView_iRules.Focus();

                markItem(tn, true);
            }
			return bNew;
		}
		private bool DoDelete()
		{
            TreeNode tn = getCurrentItem();
            bool bDeleted = false;

            if ((null != tn) && (m_treeNodeOffline == tn.Parent))
            {
                DoDeleteOffline(tn);
            }
            else if ( Clients.Connected )
			{
                if ( (null != tn) && (null != tn.Tag) )
				{
                    iRuleInfo iri = (iRuleInfo)tn.Tag;
                    string sRule = iri.rule_name;
					DialogResult dr = MessageBox.Show("Are you sure you want to permanently delete iRule '" + sRule + "'?\nThis will delete the iRule from your BIG-IP with no recovery options.", "Confirm Delete", MessageBoxButtons.YesNo);
					if ( DialogResult.Yes == dr )
					{
						// delete iRule
						try
						{
							Clients.Rule.delete_rule(new string[] { sRule });
							bDeleted = true;
                            treeView_iRules.Nodes.Remove(tn);
                            treeView_iRules.Select();
						}
						catch (Exception ex)
						{
							if ( -1 != ex.Message.IndexOf("was not found") )
							{
								// Ok, local rule not on the server.
								bDeleted = true;
                                treeView_iRules.Nodes.Remove(tn);
                                treeView_iRules.Select();
                            }
							else
							{
								setStatus(ex.Message, true);
							}
						}
					}
				}
			}
            if (bDeleted)
            {
				DoSaveConfiguration();
            }

			return bDeleted;
		}
        private bool DoDeleteOffline(TreeNode tn)
        {
            bool bDeleted = false;
            iRuleInfo iri = (iRuleInfo)tn.Tag;
            if ( null != iri )
            {
                String sDir = Configuration.getConfigSubDir("Offline");
                String sFile = sDir + iri.rule_name + ".txt";
                try
                {
                    string sRule = iri.rule_name;
					DialogResult dr = MessageBox.Show("Are you sure you want to permanently delete iRule '" + sRule + "'?\nThis will delete the iRule from your offline cache with no recovery options.", "Confirm Delete", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == dr)
                    {
                        if (System.IO.File.Exists(sFile))
                        {
                            System.IO.File.Delete(sFile);
                        }
                        tn.Parent.Nodes.Remove(tn);
                        bDeleted = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting offline iRule: " + ex.Message.ToString(), "Error");
                }
             }
            return true;
        }
		private bool DoSanityCheck(String sRuleDef)
		{
			bool bValid = true;

			// TODO: Sanity Check
			
			return bValid;
		}
		private bool DoSaveConfiguration()
		{
			return DoSaveConfiguration(false);
		}
		private bool DoSaveConfiguration(bool bForce)
		{
			bool bSaved = false;
			if (m_autoSaveConfig || bForce)
			{
				try
				{
                    string oldstatus = getStatus();
                    setStatus("Please wait while I persist the BIG-IP configuration to disk...\n\n\n\n\n", true);
					Clients.ConfigSync.save_configuration("/config/bigip.conf", SystemConfigSyncSaveMode.SAVE_HIGH_LEVEL_CONFIG);
                    setStatus(oldstatus, false);
					bSaved = true;
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "Error Saving Configuration");
				}

				if (!bSaved)
				{
					MessageBox.Show("An error occurred while saving the BIG-IP configuration to disk.  AutoSave will be turned of.  You can turn it back on under the Tools.BIG-IP Config menu item");
					m_autoSaveConfig = false;
					updateMenus();
				}
			}
			return bSaved;
		}
		private bool DoSave()
		{
			bool bSaved = false;
            TreeNode tn = getCurrentItem();

			if ( Clients.Connected || (tn.Parent == m_treeNodeOffline) )
			{
                if (null == tn)
                {
                    ValuePromptDialog vpd = new ValuePromptDialog();
                    vpd.Title = "New iRule";
                    vpd.Description = "You are working in the offline buffer.  Please enter a name for your new iRule";
                    DialogResult dr = vpd.ShowDialog();
                    if (DialogResult.OK == dr)
                    {
                        String sRule = vpd.Value;
                        String sRuleDef = m_textEditor.Text;

                        tn = new TreeNode();
                        tn.Text = sRule;
                        tn.NodeFont = treeView_iRules.Font;
                        iRuleInfo iri = new iRuleInfo(sRule, sRuleDef, true);
                        tn.Tag = iri;
                        tn.ImageIndex = 0;
                        int index = treeView_iRules.Nodes.Add(tn);
                        // TODO
                        //tn.IsSelected = true;
                        treeView_iRules.SelectedNode = tn;
                        treeView_iRules.Select();
                        treeView_iRules.Focus();
                    }
                }

                if (null != tn)
                {
                    iRuleInfo iri = (iRuleInfo)tn.Tag;
                    if (null != iri)
                    {
                        iri.rule_details = m_textEditor.Text;
                        bSaved = DoSaveNode(tn);
                    }
                }
			}

            if (bSaved)
            {
				DoSaveConfiguration();
            }

			return bSaved;
		}
        private bool DoSaveNode(TreeNode tn)
        {
            bool bSuccess = false;
            if (null != tn)
            {
                if (m_treeNodeLocalLB == tn.Parent)
                {
                    bSuccess = DoSaveNodeLTM(tn);
                }
                else if (m_treeNodeGlobalLB == tn.Parent)
                {
                    bSuccess = DoSaveNodeGTM(tn);
                }
                else if (m_treeNodeConfiguration == tn.Parent)
                {
                    bSuccess = DoSaveConfiguration(tn);
                }
                else if (m_treeNodeOffline == tn.Parent)
                {
                    bSuccess = DoSaveOffline(tn);
                }
            }
            return bSuccess;
        }
        private bool DoSaveNodeLTM(TreeNode tn)
        {
            bool bSaved = false;
            if ((null != tn) && (null != tn.Tag))
            {
                iRuleInfo iri = (iRuleInfo)tn.Tag;
                String sRule = iri.rule_name;
                //String sRuleDef = m_textEditor.Text;
                String sRuleDef = iri.rule_details.Trim();
                if (iri.modified)
                {
					bool bValid = DoSanityCheck(sRuleDef);
					if (bValid)
					{
						if (sRuleDef.Length > 0)
						{
							iControl.LocalLBRuleRuleDefinition[] rule_defs = new iControl.LocalLBRuleRuleDefinition[1];
							rule_defs[0] = new iControl.LocalLBRuleRuleDefinition();
							rule_defs[0].rule_name = sRule;
							rule_defs[0].rule_definition = sRuleDef;

							try
							{
								Clients.Rule.create(rule_defs);
								iri.rule_details = sRuleDef;
								iri.original_rule_details = sRuleDef;
								markItem(tn, false);
								bSaved = true;
							}
							catch (Exception ex)
							{
								// Check to see if rule doesn't exist and they try to create it.
								if (-1 != ex.Message.IndexOf("already exists"))
								{
									try
									{
										Clients.Rule.modify_rule(rule_defs);
										iri.rule_details = sRuleDef;
										iri.original_rule_details = sRuleDef;
										bSaved = true;
										markItem(tn, false);
									}
									catch (Exception ex1)
									{
										treeView_iRules.SelectedNode = tn;
										bookmarksFromStatus(ex1.Message);
									}
								}
								else
								{
									treeView_iRules.SelectedNode = tn;
									bookmarksFromStatus(ex.Message);
								}
							}
						}
						else
						{
							MessageBox.Show("Your iRule must contain more than whitespace characters.", "Nice Try...");
						}
					}
					else
					{
						//MessageBox.Show("iRule failed Sanity Check.", "Nice Try...");
					}
                }

            }
            else
            {
                MessageBox.Show("You must select a rule to save", "Error");
            }
            if (bSaved)
            {
                setStatus("iRule successfully saved.", getStatusVisible());
            }
            return bSaved;
        }
        private bool DoSaveNodeGTM(TreeNode tn)
        {
            bool bSaved = false;
            if ((null != tn) && (null != tn.Tag))
            {
                iRuleInfo iri = (iRuleInfo)tn.Tag;
                String sRule = iri.rule_name;
                //String sRuleDef = m_textEditor.Text;
                String sRuleDef = iri.rule_details.Trim();
                if (iri.modified)
                {
					if (sRuleDef.Length > 0)
					{
						iControl.GlobalLBRuleRuleDefinition[] rule_defs = new iControl.GlobalLBRuleRuleDefinition[1];
						rule_defs[0] = new iControl.GlobalLBRuleRuleDefinition();
						rule_defs[0].rule_name = sRule;
						rule_defs[0].rule_definition = sRuleDef;

						try
						{
							Clients.GlobalLBRule.create(rule_defs);
							iri.rule_details = sRuleDef;
							iri.original_rule_details = sRuleDef;
							markItem(tn, false);
							bSaved = true;
						}
						catch (Exception ex)
						{
							// Check to see if rule doesn't exist and they try to create it.
							if (-1 != ex.Message.IndexOf("already exists"))
							{
								try
								{
									Clients.GlobalLBRule.modify_rule(rule_defs);
									iri.rule_details = sRuleDef;
									iri.original_rule_details = sRuleDef;
									bSaved = true;
									markItem(tn, false);
								}
								catch (Exception ex1)
								{
									treeView_iRules.SelectedNode = tn;
									bookmarksFromStatus(ex1.Message);
								}
							}
							else
							{
								treeView_iRules.SelectedNode = tn;
								bookmarksFromStatus(ex.Message);
							}
						}
					}
					else
					{
						MessageBox.Show("Your iRule must contain more than whitespace characters.", "Nice Try...");
					}
				}

            }
            else
            {
                MessageBox.Show("You must select a rule to save", "Error");
            }
            if (bSaved)
            {
                setStatus("iRule successfully saved.", getStatusVisible());
            }
            return bSaved;
        }
		private bool DoSaveConfiguration(TreeNode tn)
		{
			bool bSaved = false;

			if ((null != tn) && (null != tn.Tag))
			{
				iRuleInfo iri = (iRuleInfo)tn.Tag;
				String sRemoteFile = iri.rule_name;
				String sConfigDef = iri.rule_details;
				iControl.SystemConfigSyncLoadMode lm = SystemConfigSyncLoadMode.LOAD_HIGH_LEVEL_CONFIG;
				switch (sRemoteFile)
				{
					case "/config/bigip.conf":
						{
							lm = SystemConfigSyncLoadMode.LOAD_HIGH_LEVEL_CONFIG;
							break;
						}
					case "/config/bigip_base.conf":
						{
							lm = SystemConfigSyncLoadMode.LOAD_BASE_LEVEL_CONFIG;
							break;
						}
				}

				bool bUploaded = iRuler.Utility.FileTransfer.uploadFile(Clients.Interfaces, sRemoteFile, sConfigDef);
				if (bUploaded)
				{
					try
					{
						Clients.Interfaces.SystemConfigSync.load_configuration(sRemoteFile, lm);
                        // HACK
						bSaved = true;
                        markItem(tn, false);
                    }
					catch (Exception ex)
					{
						setStatus(ex.Message.ToString(), true);
					}
				}
			}

			return bSaved;
		}
        private bool DoSaveOffline(TreeNode tn)
        {
            bool bSaved = false;
            String sOfflineDir = Configuration.getConfigSubDir("Offline");
            if (m_treeNodeOffline.Nodes.Count > 0)
            {
                iRuleInfo iri = (iRuleInfo)tn.Tag;
                try
                {
                    Configuration.saveLocalFile(sOfflineDir + iri.rule_name + ".txt", iri.rule_details);
                    markItem(tn, false);
                    bSaved = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving local file: " + ex.Message.ToString(), "Error");
                }
            }
            if (bSaved)
            {
                setStatus("Offline iRule successfully saved.", getStatusVisible());
            }
            return bSaved;
        }
        private void DoSaveAll()
        {
            for (int i = 0; i < m_treeNodeLocalLB.Nodes.Count; i++)
            {
                TreeNode tn = m_treeNodeLocalLB.Nodes[i];
                DoSaveNode(tn);
            }
            for (int i = 0; i < m_treeNodeGlobalLB.Nodes.Count; i++)
            {
                TreeNode tn = m_treeNodeGlobalLB.Nodes[i];
                DoSaveNode(tn);
            }
        }
        private void DoReset()
		{
            TreeNode tn = getCurrentItem();
            if (null != tn)
            {
                iRuleInfo iri = (iRuleInfo)tn.Tag;
                iri.rule_details = iri.original_rule_details;
                iri.modified = false;
                m_textEditor.Text = iri.rule_details;
                markItem(tn, false);
                setStatus("", getStatusVisible());
            }
            else
            {
                MessageBox.Show("Please select an iRule to reset");
            }
		}
        private void DoReload()
        {
            TreeNode tn = getCurrentItem();
            if (null != tn)
            {
                try
                {
                    String sRuleName = tn.Text;
                    if (sRuleName.EndsWith("*"))
                    {
                        sRuleName = sRuleName.Remove(tn.Text.Length - 1, 1);
                    }

                    iControl.LocalLBRuleRuleDefinition[] rule_list =
                        Clients.Rule.query_rule(new string[] { sRuleName });
                    iRuleInfo iri = (iRuleInfo)tn.Tag;
                    iri.rule_details = rule_list[0].rule_definition;
                    iri.original_rule_details = rule_list[0].rule_definition;
                    iri.modified = false;
                    iri.download_time = DateTime.Now;
                    m_textEditor.Text = iri.rule_details;
                    markItem(tn, false);
                    setStatus("", getStatusVisible());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please select an iRule to reload from the server");
            }
        }
		private bool DoRefresh()
		{
			bool bRefreshed = false;
			bool bPrompt = false;
			bool bRefresh = true;
			for(int i=0; i<m_treeNodeLocalLB.Nodes.Count; i++)
			{
				iRuleInfo iri = (iRuleInfo)m_treeNodeLocalLB.Nodes[i].Tag;
				if ( iri.modified )
				{
					bPrompt = true;
					break;
				}
			}
            for (int i = 0; i < m_treeNodeGlobalLB.Nodes.Count; i++)
            {
                iRuleInfo iri = (iRuleInfo)m_treeNodeGlobalLB.Nodes[i].Tag;
                if (iri.modified)
                {
                    bPrompt = true;
                    break;
                }
            }

            for (int i = 0; i < m_treeNodeOffline.Nodes.Count; i++)
            {
                iRuleInfo iri = (iRuleInfo)m_treeNodeOffline.Nodes[i].Tag;
                if (iri.modified)
                {
                    bPrompt = true;
                    break;
                }
            }


            if ( bPrompt )
			{
				DialogResult dr = MessageBox.Show("Refresh will discard any changes you have made.  Click OK to continue?", "Are you sure?", MessageBoxButtons.OKCancel);
				if ( DialogResult.Cancel == dr )
				{
					bRefresh = false;
				}
			}
			if ( bRefresh )
			{
                refreshiRules();
                setStatus("", getStatusVisible());
				bRefreshed = true;
            }
			return bRefreshed;
		}
		private void DoParse()
		{
            bookMarkRemoveAll();

            // check if selected node is LTM or GTM.
            TreeNode tn = getCurrentItem();
            if (null != tn)
            {
                if (m_treeNodeLocalLB == tn.Parent)
                {
                    DoParseLTM();
                }
                else if (m_treeNodeGlobalLB == tn.Parent)
                {
                    DoParseGTM();
                }
            }
		}
        private void DoParseLTM()
        {
            String sRule = "iRuler_Parse_Test_Rule";
            String sRuleDef = m_textEditor.Text;

            iControl.LocalLBRuleRuleDefinition[] rule_defs = new iControl.LocalLBRuleRuleDefinition[1];
            rule_defs[0] = new iControl.LocalLBRuleRuleDefinition();
            rule_defs[0].rule_name = sRule;
            rule_defs[0].rule_definition = sRuleDef;
            try
            {
                Clients.Rule.delete_rule(new string[] { sRule });
            }
            catch (Exception)
            {
            }
            try
            {
                Clients.Rule.create(rule_defs);
                Clients.Rule.delete_rule(new string[] { sRule });
                MessageBox.Show("The text is a valid iRule!", "Success", MessageBoxButtons.OK);
                setStatus("The text is a valid iRule!", getStatusVisible());
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Parse Failure", "Parse Failure", MessageBoxButtons.OK);
                //setStatus(ex.Message, true);
                bookmarksFromStatus(ex.Message);
            }
        }
        private void DoParseGTM()
        {
            String sRule = "iRuler_Parse_Test_Rule";
            String sRuleDef = m_textEditor.Text;

            iControl.GlobalLBRuleRuleDefinition[] rule_defs = new iControl.GlobalLBRuleRuleDefinition[1];
            rule_defs[0] = new iControl.GlobalLBRuleRuleDefinition();
            rule_defs[0].rule_name = sRule;
            rule_defs[0].rule_definition = sRuleDef;
            try
            {
                Clients.GlobalLBRule.delete_rule(new string[] { sRule });
            }
            catch (Exception)
            {
            }
            try
            {
                Clients.GlobalLBRule.create(rule_defs);
                Clients.GlobalLBRule.delete_rule(new string[] { sRule });
                MessageBox.Show("The text is a valid iRule!", "Success", MessageBoxButtons.OK);
                setStatus("The text is a valid iRule!", getStatusVisible());
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Parse Failure", "Parse Failure", MessageBoxButtons.OK);
                //setStatus(ex.Message, true);
                bookmarksFromStatus(ex.Message);
            }
        }
		private void DoViewStatus()
		{
			//viewStatus(!panel_Status.Visible);
            viewStatus(!m_showStatus);
		}
		private void DoCheckForUpdates(bool prompt, bool showstatus)
		{
			Updater updater = new Updater();
			updater.m_mainForm = this;
            if (updater.checkForUpdates(prompt, showstatus))
            {
                updateAutoCompleteList();
            }
            m_lastUpdate = DateTime.Now.Ticks;
        }
        private void DoDataGroups()
        {
            DataGroupsDialog dlg = new DataGroupsDialog();
            DialogResult dr = dlg.ShowDialog();
        }
        private void DoShare()
        {
            TreeNode tn = getCurrentItem();
            if ((null != tn) && (null != tn.Tag))
            {
                iRuleInfo iri = (iRuleInfo)treeView_iRules.SelectedNode.Tag;
                String sRule = iri.rule_name;
                String sRuleDef = m_textEditor.Text;
                ShareDialog sd = new ShareDialog();
                sd.rule_name = iri.rule_name;
                sd.rule_details = m_textEditor.Text;
                sd.ShowDialog();
            }
            else
            {
                MessageBox.Show("You must first save your iRule before you share it.");
            }
        }

        private String RuleNameToFileName(String rulename)
        {
            String filename = rulename;

            // Look for format
            // my_rule_name
            if (filename.StartsWith("/"))
            {
                // /Commmon/Path/my_rule_name
                filename = filename.Replace("/", "++");
                // -> ++Common++Path++my_rule_name
            }

            return filename;
        }

        private String FileNameToRuleName(String filename)
        {
            string rulename = filename.Replace("++", "/");
            return rulename;
        }

        private void DoExport()
        {
            int numArchived = 0;
            DoMigrateImportExport();
            String sArchiveDir = m_archiveDirectory;
            String sLTMDir = sArchiveDir + "\\LTM\\";
            if (m_treeNodeLocalLB.Nodes.Count > 0)
            {
                for (int i = 0; i < m_treeNodeLocalLB.Nodes.Count; i++)
                {
                    iRuleInfo iri = (iRuleInfo)m_treeNodeLocalLB.Nodes[i].Tag;
                    Configuration.saveLocalFile(sLTMDir + RuleNameToFileName(iri.rule_name) + ".txt", iri.rule_details);
                }
                numArchived += m_treeNodeLocalLB.Nodes.Count;
            }

            String sGTMDir = sArchiveDir + "\\GTM\\";
            if (m_treeNodeGlobalLB.Nodes.Count > 0)
            {
                for (int i = 0; i < m_treeNodeGlobalLB.Nodes.Count; i++)
                {
                    iRuleInfo iri = (iRuleInfo)m_treeNodeGlobalLB.Nodes[i].Tag;
                    Configuration.saveLocalFile(sGTMDir + RuleNameToFileName(iri.rule_name) + ".txt", iri.rule_details);
                }
                numArchived += m_treeNodeGlobalLB.Nodes.Count;
            }

            MessageBox.Show("Successfully archived " + numArchived + " iRules");
            Configuration.LaunchProcess(sArchiveDir);
        }
        private void DoImport()
        {
            int numImported = 0;
            DoMigrateImportExport();
            String sArchiveDir = m_archiveDirectory + "\\LTM"; 

            string[] files = System.IO.Directory.GetFiles(sArchiveDir, "*.txt");
            if (files.Length > 0)
            {
                DoDropFiles(files, false, m_treeNodeLocalLB);
                numImported += files.Length;
            }


            if (Clients.ConnectionInfo.getGTMLicensed())
            {
                sArchiveDir = m_archiveDirectory + "\\GTM";

                files = System.IO.Directory.GetFiles(sArchiveDir, "*.txt");
                if (files.Length > 0)
                {
                    DoDropFiles(files, false, m_treeNodeGlobalLB);
                    numImported += files.Length;
                }
            }

            if ( 0 == numImported )
            {
                MessageBox.Show("Your local archive folder is empty.  You'll need to perform an Export before you can Import", "Error");
            }
        }
        private void DoMigrateImportExport()
        {
            String sArchiveDir = m_archiveDirectory;
            String [] OldFileList = System.IO.Directory.GetFiles(sArchiveDir, "*.txt");
            System.IO.Directory.CreateDirectory(sArchiveDir + "\\LTM");
            System.IO.Directory.CreateDirectory(sArchiveDir + "\\GTM");
            for (int i = 0; i < OldFileList.Length; i++)
            {
                String sNewFile = OldFileList[i].Replace("Archive", "Archive\\LTM");
                System.IO.File.Move(OldFileList[i], sNewFile);
            }

        }
        private void DoDropFiles(String [] fileDropList, bool bPrompt, TreeNode tnParent)
        {
            if (null != fileDropList)
            {
                for (int i = 0; i < fileDropList.Length; i++)
                {
                    // Attempt to open file and create iRule based on the contents and name.
                    String fileName = System.IO.Path.GetFileNameWithoutExtension(fileDropList[i]);
                    String sContents = null;
                    bool bCreateNewNode = true;
                    bool bContinue = true;
                    try
                    {
                        fileName = FileNameToRuleName(fileName);
                        System.IO.StreamReader sr = System.IO.File.OpenText(fileDropList[i]);
                        sContents = sr.ReadToEnd();
                        sr.Close();

                        if (null != findTreeNode(fileName, tnParent))
                        {
                            if (bPrompt)
                            {
                                DialogResult dr = MessageBox.Show("iRule '" + fileName + "' already exists.  Do you wish to overwrite it?", "iRule Already Exists", MessageBoxButtons.YesNo);
                                if (DialogResult.Yes == dr)
                                {
                                    bCreateNewNode = false;
                                }
                                else
                                {
                                    // Create new node name based on given file name
                                    for (int j = 0; j < 1000; j++)
                                    {
                                        fileName = fileName + "_" + j.ToString();
                                        if (null == findTreeNode(fileName, tnParent))
                                        {
                                            break;
                                        }
                                    }
                                    bContinue = false;
                                }
                            }
                            else
                            {
                                bCreateNewNode = false;
                            }
                        }

                        TreeNode tn = null;

                        if (bContinue)
                        {
                            if (bCreateNewNode)
                            {
                                tn = new TreeNode();
                                tn.NodeFont = treeView_iRules.Font;
                                tn.Text = fileName + "*";
                                iRuleInfo iri = new iRuleInfo(fileName, sContents, true);
                                tn.Tag = iri;
                                int index = tnParent.Nodes.Add(tn);
                            }
                            else
                            {
                                tn = findTreeNode(fileName, tnParent);
                                tn.NodeFont = treeView_iRules.Font;
                                tn.Text = fileName + "*";
                                iRuleInfo iri = (iRuleInfo)tn.Tag;
                                if (null != iri)
                                {
                                    iri.rule_details = sContents;
                                    iri.modified = true;
                                }
                                if (tn == m_lastTreeViewNode)
                                {
                                    // make sure editor contents are up to date
                                    m_textEditor.Text = sContents;
                                }
                            }
                            treeView_iRules.SelectedNode = tn;
                            treeView_iRules.Select();
                        }
                    }
                    catch (Exception)
                    {
                    }

                }
            }
            this.Focus();
        }
        private void DoSearchFind()
        {
            FindDialog fd = new FindDialog();
            fd.m_mainForm = this;
            fd.m_si = m_si;
            fd.Show(this);
        }
        public int DoSearchFind(bool bReverseDirection)
        {
            if (m_si.searchString.Length == 0)
            {
                m_si.down = !bReverseDirection;
                DoSearchFind();
                return -1;
            }
            int docLen = m_textEditor.Text.Length;
            int lenFind = m_si.searchString.Length;
            int selStart = m_textEditor.SelectionStart;
            int selEnd = m_textEditor.SelectionEnd;
            int startPosition = selEnd;
            int endPosition = docLen-1;
            if (bReverseDirection)
            {
                startPosition = selStart;
                endPosition = 0;
            }
            int flags = (m_si.matchWholeWord ? 2 /* SCFIND_WHOLEWORD */ : 0) |
                (m_si.matchCase ? 4 /* SCFIND_MATCHCASE */ : 0 ) |
                (m_si.regex ? 0x00200000 /* SCFIND_REGEXP */ : 0);
            m_textEditor.SearchFlags = flags;
            int posFind = findInTarget(m_si.searchString, lenFind, startPosition, endPosition);
            if ((-1 == posFind) && (m_si.wrapAround))
            {
                if (bReverseDirection)
                {
                    startPosition = docLen;
                    endPosition = 0;
                }
                else
                {
                    startPosition = 0;
                    endPosition = docLen;
                }
                posFind = findInTarget(m_si.searchString, lenFind, startPosition, endPosition);
            }
            if (-1 == posFind)
            {
                MessageBox.Show("Can not find the string " + m_si.searchString);
            }
            else
            {
                int start = m_textEditor.TargetStart;
                int end = m_textEditor.TargetEnd;
                ensureRangeVisible(start, end);
                m_textEditor.SetSel(start, end);
            }
            return posFind;
        }
        public void DoSearchMarkAll()
        {
            bookMarkRemoveAll();

            int posCurrent = m_textEditor.CurrentPos;
            int marked = 0;
            int posFirstFound = DoSearchFind(false);

            int endStyled = m_textEditor.EndStyled;
            if (-1 != posFirstFound)
            {
                int posFound = posFirstFound;
                do
                {
                    marked++;
                    int line = m_textEditor.LineFromPosition(posFound);
                    bookmarkAdd(line);
                    m_textEditor.StartStyling(posFound, 0X80 /* INDIC2_MASK */);
                    m_textEditor.SetStyling(m_textEditor.TargetEnd - posFound, 0x80 /* INDIC2_MASK */);
                    posFound = DoSearchFind(false);
                } while ((-1 != posFound) && (posFound != posFirstFound));
            }
            m_textEditor.StartStyling(endStyled, 31);
            //m_textEditor.CurrentPos = posCurrent;
        }
        private void DoPrint()
        {
        }
        private void DoGenerateTraffic()
        {
            GenTrafficDialog gtd = new GenTrafficDialog();
            gtd.Show();
        }
        private void DoCopyOffline(TreeNode tn)
        {
            if (null != tn)
            {
                iRuleInfo iri = (iRuleInfo)tn.Tag;
                if (null != iri)
                {
                    bool bContinue = false;
                    bool bCreateNewNode = true;
                    bool bExisting = false;
                    TreeNode matchingNode = findTreeNode(iri.rule_name, m_treeNodeOffline);
                    if (null != matchingNode)
                    {
                        DialogResult dr = MessageBox.Show("iRule '" + iri.rule_name + "' already exists in the offline cache.  Would you like to overwrite it?");
                        if (DialogResult.OK == dr)
                        {
                            bCreateNewNode = false;
                        }
                        else
                        {
                            bContinue = false;
                        }
                    }
                    else
                    {
                        bContinue = true;
                    }
                    if (bContinue)
                    {
                        if (bCreateNewNode)
                        {
                            TreeNode tnNew = new TreeNode();
                            tnNew.NodeFont = treeView_iRules.Font;
                            tnNew.Text = iri.rule_name + "*";
                            iRuleInfo iriNew = new iRuleInfo(iri.rule_name, iri.rule_details, true);
                            tnNew.Tag = iriNew;
                            int index = m_treeNodeOffline.Nodes.Add(tnNew);
                            DoSaveOffline(tnNew);
                        }
                        else
                        {
                            iRuleInfo iriMatching = (iRuleInfo)matchingNode.Tag;
                            if (null != iriMatching)
                            {
                                iriMatching.rule_details = iri.rule_details;
                                iriMatching.modified = true;
                                DoSaveOffline(matchingNode);
                            }
                        }
                    }

                }
            }
        }

        public int findInTarget(String sText, int len, int start, int end)
        {
            m_textEditor.TargetStart = start;
            m_textEditor.TargetEnd = end;
            int posFind = m_textEditor.SearchInTarget(len, sText);
            return posFind;
        }
        public void ensureRangeVisible(int start, int end)
        {
            int lineStart = m_textEditor.LineFromPosition(start);
            int lineEnd = m_textEditor.LineFromPosition(end);
            for (int line = lineStart; line <= lineEnd; line++)
            {
                m_textEditor.EnsureVisible(line);
            }
        }

        private void Editor_FoldAll()
        {
            m_textEditor.Colourise(0, -1);
            int maxLine = m_textEditor.LineCount;
            bool expanding = true;
            for (int lineSeek = 0; lineSeek < maxLine; lineSeek++)
            {
                if (Convert.ToBoolean(m_textEditor.GetFoldLevel(lineSeek) & 0x2000 /* SC_FOLDLEVELHEADERFLAG */))
                {
                    expanding = !m_textEditor.GetFoldExpanded(lineSeek);
                    break;
                }
            }
            for (int line = 0; line < maxLine; line++)
            {
                int level = m_textEditor.GetFoldLevel(line);
                if (Convert.ToBoolean(level & 0x2000 /* SC_FOLDLEVELHEADERFLAG */) &&
                     Convert.ToBoolean
                        (
                            0x400 /* SC_FOLDLEVELBASE */ == (level & 0x0FFF /* SC_FOLDLEVELNUMBERMASK */ )
                        )
                    )
                {
                    if (expanding)
                    {
                        m_textEditor.SetFoldExpanded(line, true);
                        Editor_Expand(ref line, true, false, 0, level);
                        line--;
                    }
                    else
                    {
                        int linemaxSubord = m_textEditor.GetLastChild(line, -1);
                        m_textEditor.SetFoldExpanded(line, false);
                        if (linemaxSubord > line)
                        {
                            m_textEditor.HideLines(line + 1, linemaxSubord);
                        }
                    }
                }
            }
        }
        private void Editor_EnsureAllChidrenVisible(int line, int level)
        {
            m_textEditor.SetFoldExpanded(line, true);
            Editor_Expand(ref line, true, true, 100, level);
        }
        private void Editor_ToggleFoldRecursive(int line, int level)
        {
            if (m_textEditor.GetFoldExpanded(line))
            {
                m_textEditor.SetFoldExpanded(line, false);
                Editor_Expand(ref line, false, true, 0, level);
            }
            else
            {
                m_textEditor.SetFoldExpanded(line, true);
                Editor_Expand(ref line, true, true, 100, level);
            }
        }
        private void Editor_Expand(ref int line, bool doExpand, bool force, int visLevels, int level)
        {
            int lineMaxSubord = m_textEditor.GetLastChild
            (
                line,
                level & 0x0FFF /* SC_FOLDLEVELNUMBERMASK */
            );
            line++;
            while (line <= lineMaxSubord)
            {
                if (force)
                {
                    if (visLevels > 0)
                    {
                        m_textEditor.ShowLines(line, line);
                    }
                    else
                    {
                        m_textEditor.HideLines(line, line);
                    }
                }
                else
                {
                    if (doExpand)
                    {
                        m_textEditor.ShowLines(line, line);
                    }
                }
                int levelLine = level;
                if (levelLine == -1)
                {
                    levelLine = m_textEditor.GetFoldLevel(line);
                }
                if (Convert.ToBoolean(levelLine & 0x2000 /* SC_FOLDLEVELHEADERFLAG */))
                {
                    if (force)
                    {
                        if (visLevels > 1)
                        {
                            m_textEditor.SetFoldExpanded(line, true);
                        }
                        else
                        {
                            m_textEditor.SetFoldExpanded(line, false);
                        }
                        Editor_Expand(ref line, doExpand, force, visLevels - 1, -1);
                    }
                    else
                    {
                        if (doExpand)
                        {
                            if (!m_textEditor.GetFoldExpanded(line))
                            {
                                m_textEditor.SetFoldExpanded(line, true);
                            }
                            Editor_Expand(ref line, true, force, visLevels - 1, -1);
                        }
                        else
                        {
                            Editor_Expand(ref line, false, force, visLevels - 1, -1);
                        }
                    }
                }
                else
                {
                    line++;
                }
            }
        }

        private void bookMarkRemoveAll()
        {
            if (m_bPossibleBookmarks)
            {
                for (int i = 0; i < m_textEditor.LineCount; i++)
                {
                    bookmarkDelete(i);
                }
                toolStripMenuItem_ViewBookmarks.Checked = false;
            }
        }
        private void bookmarkAdd(int linenumber)
        {
            if (!bookmarkPresent(linenumber))
            {
                m_textEditor.MarkerAdd(linenumber, MARKER_BOOKMARK);
                toolStripMenuItem_ViewBookmarks.Checked = true;
                m_bPossibleBookmarks = true;
            }
        }
        private void bookmarkDelete(int linenumber)
        {
            if (bookmarkPresent(linenumber))
            {
                m_textEditor.MarkerDelete(linenumber, MARKER_BOOKMARK);
            }
        }
        private bool bookmarkPresent(int linenumber)
        {
            int state = m_textEditor.MarkerGet(linenumber);
            return (0 != (state & (1 << MARKER_BOOKMARK)));
        }
        private void bookmarksFromStatus(String message)
        {
            try
            {
                String statusMessage = "";
                String[] sLines = message.Split(new char[] { '\n' });
                for (int i = 0; i < sLines.Length; i++)
                {
                    // selection is in this line!
                    if (sLines[i].StartsWith("line "))
                    {
                        if (statusMessage.Length > 0)
                        {
                            statusMessage = statusMessage + "\n";
                        }
                        statusMessage = statusMessage + sLines[i];
                        String sLineNumber = sLines[i].Substring(5, sLines[i].Length - 5);
                        String[] sTokens = sLineNumber.Split(new char[] { ':' });
                        if (sTokens.Length > 0)
                        {
                            int lineNumber = Convert.ToInt32(sTokens[0]);
                            // Hightlight line.
                            lineNumber--;
                            bookmarkAdd(lineNumber);
                        }
                    }
                }
                if (statusMessage.Length > 0)
                {
                    setStatus(statusMessage, true);
                }
                else
                {
                    setStatus(message, true);
                }
            }
            catch (Exception)
            {
            }
        }

        private TreeNode findTreeNode(String sName, TreeNode tnParent)
        {
            TreeNode tn = null;
            if (null != tnParent)
            {
                for (int i = 0; i < tnParent.Nodes.Count; i++)
                {
                    String sNode = tnParent.Nodes[i].Text;
                    if (sNode.EndsWith("*"))
                    {
                        sNode = sNode.Remove(sNode.Length - 1, 1);
                    }
                    if (sNode.Equals(sName))
                    {
                        tn = tnParent.Nodes[i];
                        break;
                    }
                }
            }
            return tn;
        }
        private String[] getDragDropFileList(DragEventArgs e)
        {
            String[] fileDropList = null;
            String[] formats = e.Data.GetFormats();
            bool bGotFileDrop = false;
            for (int i = 0; i < formats.Length; i++)
            {
                if (formats[i].Equals("FileDrop"))
                {
                    bGotFileDrop = true;
                    break;
                }
            }
            if (bGotFileDrop)
            {
                object fileDrop = e.Data.GetData("FileDrop");
                if (fileDrop.GetType().Equals(typeof(System.String[])))
                {
                    fileDropList = (String[])fileDrop;
                }
            }
            return fileDropList;
        }

		#endregion

        #region Form Handlers

        private void iRulerMain_Load(object sender, System.EventArgs e)
		{
            treeView_iRules.TreeViewNodeSorter = new iRuler.Utility.NodeSorter();

            // Read Configuration from Registry
            loadConfiguration();

            // position window
            if ((-1 != m_startLocationX) && (-1 != m_startLocationY) &&
                (-1 != m_startWidth) && (-1 != m_startHeight))
            {
                this.Location = new System.Drawing.Point(m_startLocationX, m_startLocationY);
                this.Width = m_startWidth;
                this.Height = m_startHeight;
            }

//            this.Refresh();
//            this.Show();
            if (m_showSplashScreen)
            {
                AboutBox.showSplashScreen();
            }
            Application.DoEvents();

			if ( initializeEditor() )
			{
				m_textEditor.Focus();
                splitContainer2.SplitterDistance = 0;
				showButtons(false);

                DateTime dt2 = DateTime.Now;
                DateTime dt1 = new DateTime(m_lastUpdate);
                TimeSpan ts = dt2 - dt1;
                if (ts.Days >= 1)
                {
                    DoCheckForUpdates(true, false);
                }
                updateAutoCompleteList();
				updateIndentionSettings();
                viewStatus(m_showStatus);

                // Insert Offline node
                if (m_offlineEditing)
                {
                    m_treeNodeOffline.ImageIndex = 5;
                    m_treeNodeOffline.SelectedImageIndex = 5;
                    treeView_iRules.Nodes.Add(m_treeNodeOffline);
                    m_treeNodeOffline.Nodes.Clear();
                    refreshOffline();
                }

                loadCommandArgs();
                DoConnect(m_hostName, m_userName, m_password);
			}
			else
			{
				Application.Exit();
			}
		}
        private void iRulerMain_Activated(object sender, EventArgs e)
        {
            m_textEditor.Focus();
        }
        private void iRulerMain_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            Configuration.LaunchProcess(Configuration.getWebHelpURL());
        }

        /// <summary>
        /// Gets the last non-whitespace character of the previous line.
        /// </summary>
        /// <param name="sci">The scintilla. control</param>
        /// <param name="pos">The position to search from.</param>
        /// <returns>The last non-whitespace character in the previous line.</returns>
        private char getEndOfLastLine(scintilla.ScintillaControl sci, int pos)
        {
            int newlinesSeen = 0;
            char[] contents = sci.Text.ToCharArray();
            --pos;
            if (pos > contents.Length) { return '\0'; }
            while (pos >= 0 && newlinesSeen < 2)
            {
                char c = contents[pos];
                switch (c)
                {
                    case '\n':
                        ++newlinesSeen;
                        break;
                    case ' ':
                    case '\t':
                    case '\r':
                        break;
                    default:
                        if (newlinesSeen == 1)
                        {
                            return c;
                        }
                        break;
                }
                --pos;
            }

            return '\0';
        }
        /// <summary>
        /// Gets the previous non-whitespace character in the current line.
        /// </summary>
        /// <param name="sci">The scintilla. control</param>
        /// <param name="pos">The position to search from</param>
        /// <returns>The previous non-whitespace character in the current line or '\0' if there isn't one.</returns>
        private char getPreviousNonWhitespaceChar(scintilla.ScintillaControl sci, int pos)
        {
            char[] contents = sci.Text.ToCharArray();
            --pos;
            if (pos > contents.Length) { return '\0'; }
            while (pos >= 0)
            {
                char c = contents[pos];
                switch (c)
                {
                    case '\n':
                        return '\0';
                    case ' ':
                    case '\t':
                    case '\r':
                        break;
                    default:
                        return c;
                }
                --pos;
            }

            return '\0';
        }
        /// <summary>
        /// Calculates the length (number of characters) of a particular indent.
        /// The length of an indent depends on whether or not tabs are enabled
        /// and the width of a tab.
        /// </summary>
        /// <param name="sci">The scintilla. control</param>
        /// <param name="indent">The indent to measure</param>
        /// <returns>The length of th eindent.</returns>
        private int calcLengthOfIndent(scintilla.ScintillaControl sci, int indent)
        {
            if (indent <= 0) { return 0; }
            if (sci.UseTabs)
            {
                return indent / sci.TabWidth;
            }
            else
            {
                return indent;
            }
        }
        /// <summary>
        /// Checks to see if a line needs to be auto indented and indents it if
        /// it does.  Auto indenting follows these rules:
        /// <list>
        ///     <item>
        ///         If a new line has been created it is given the same indent
        ///         as the previous line.
        ///     </item>
        ///     <item>
        ///         If a new line is created and the previous line ends with an
        ///         opening brace then the new line is indented one level more
        ///         than the previous line
        ///     </item>
        ///     <item>
        ///         If a closing brace is added and it is the first
        ///         non-whitespace character on the line and the current line
        ///         has the same indent as the previous line then the line is
        ///         unindented one level.
        ///     </item>
        /// </list>
        /// </summary>
        /// <param name="sci">The scintilla. control</param>
        /// <param name="ch">The character that was just added</param>
        private void autoIndentLine(scintilla.ScintillaControl sci, char ch)
        {
			if ( m_autoIndent )
			{
				if (ch == '}')
				{
					int currPos = sci.CurrentPos;
					int currLine = sci.LineFromPosition(currPos);

					if (currLine > 0)
					{
						char lastChar = getPreviousNonWhitespaceChar(sci, currPos - 1);
						if (lastChar == '\0')
						{
							int currIndent = sci.GetLineIndentation(currLine);

							int prevIndent = sci.GetLineIndentation(currLine - 1);

							if ((currIndent >= sci.TabWidth) /* && (currIndent == prevIndent) */)
							{
								int newIndent = currIndent - sci.TabWidth;
								sci.SetLineIndentation(currLine, newIndent);
								int newPos = currPos - (calcLengthOfIndent(sci, currIndent) - calcLengthOfIndent(sci, newIndent));
								sci.SetSel(newPos, newPos);
							}
						}
					}
				}
				else if (ch == '\n')
				{
					int currLine = sci.LineFromPosition(sci.CurrentPos);
					if (currLine > 0)
					{
						int prevIndent = sci.GetLineIndentation(currLine - 1);
						int newIndent = prevIndent;

						/* Check to see if the previous line ends in an opening
						 * brace.  If it does we'll add an extra indent.
						 * We can't just use pSender.GetLine(currLine - 1) because
						 * the string returned seems to have junk characters at the
						 * end of it, making it difficult to see what the actual
						 * last character is. */
						char lastChar = getEndOfLastLine(sci, sci.CurrentPos);
						bool openBrace = (lastChar == '{');

						if (openBrace)
						{
							newIndent += sci.TabWidth;
						}

						sci.SetLineIndentation(currLine, newIndent);
						int newPos = sci.CurrentPos + calcLengthOfIndent(sci, newIndent);
						sci.SetSel(newPos, newPos);
					}
				}
            }
        }
        private void m_textEditor_CharAdded(scintilla.ScintillaControl pSender, char CharacterAdded)
        {
			String[] log_facilities = new String[] {
				"alert", "crit", "debug", "emerg", "err", "error", "info", "none", "notice", "panic", "warn", "warning"
			};

            markItem(m_lastTreeViewNode, true);

            if (m_doAutoIndent)
            {
                autoIndentLine(pSender, CharacterAdded);
            }

            // check for autocomplete
            if (m_showAutoComplete && (m_eventList.Length > 0))
            {
                int position = m_textEditor.CurrentPos;
                if (' ' == CharacterAdded)
                {
                    position--;
                }
                if (position > 0)
                {
                    position--;
                }

                String sWord = getCurrentWord(position);
				System.Diagnostics.Debug.WriteLine("Current Word: '" + sWord + "'");
                if (0 == sWord.Length)
                {
                    // Nada...
                }
                if (sWord.Equals("when") && (' ' == CharacterAdded))
                {
                    if ((null != m_lastTreeViewNode) && (null != m_lastTreeViewNode.Tag))
                    {
                        iRuleInfo iri = (iRuleInfo)m_lastTreeViewNode.Tag;
                        if (iRuleInfo.RuleType.LOCALLB == iri.rule_type)
                        {
                            m_textEditor.AutoCShow(0, m_eventList);
                        }
                        else if (iRuleInfo.RuleType.GLOBALLB == iri.rule_type)
                        {
                            m_textEditor.AutoCShow(0, m_eventListGTM);
                        }
                    }
                    else
                    {
                        m_textEditor.AutoCShow(0, m_eventList);
                    }
                }
                else if (showCommandAC(sWord))
                {
                    // nada, work done in method
                }
                else if (sWord.Equals("log") && (' ' == CharacterAdded))
                {
					String tokens = "";
					for (int i = 0; i < 8; i++)
					{
						if (tokens.Length > 0) { tokens = tokens + ";"; }
						for (int j = 0; j < log_facilities.Length; j++)
						{
							tokens = tokens + "local" + i.ToString() + "." + log_facilities[j];
							if (j < log_facilities.Length-1)
							{
								tokens = tokens + ";";
							}
						}
					}
                    m_textEditor.AutoCShow(0, tokens);
                }
				else if ((sWord.Length == 7) && sWord.StartsWith("local") && sWord.EndsWith("."))
				{
					String tokens = "";
					for (int j = 0; j < log_facilities.Length; j++)
					{
						tokens = tokens + log_facilities[j] + " ";
						if (j < log_facilities.Length - 1)
						{
							tokens = tokens + ";";
						}
					}
					m_textEditor.AutoCShow(0, tokens);
				}
				else if (sWord.Equals("string") && (' ' == CharacterAdded))
				{
					m_textEditor.AutoCShow(0, "bytelength ;compare ;equal ;first ;index ;is alnum ;is alpha ;is ascii ;is boolean ;is control ;is digit ;is double ;is false ;is graph ;is integer ;is lower ;is print ;is punct ;is space ;is true ;is upper ;is wideinteger ;is wordchar ;is xdigit ;last ;length ;map ;match ;range ;repeat ;replace ;tolower ;totitle ;toupper ;trim ;trimleft ;trimright ;wordend ;wordstart ");
				}
				else if (sWord.Length > 2)
				{
					// Look for a match...
					String matchList = getListOfMatches(sWord);
					if ((null != matchList) && (matchList.Length > 0))
					{
						m_textEditor.AutoCShow(sWord.Length, matchList);
					}
				}
            }
        }
        private int m_textEditor_HotSpotClick(scintilla.ScintillaControl pSender, int modifiers, int position)
        {
            String sToken = getCurrentWord(position).Replace(':', '_');
            
            if (sToken.Length > 0)
            {
                int style = m_textEditor.get_StyleAt(position);
                String sUrl = null;
                switch (style)
                {
                    case 12: /* iRule LTM tokens */
                        //sUrl = "http://devcentral.f5.com/Wiki/print.aspx/iRules." + sToken;
                        //sUrl = "http://devcentral.f5.com/Wiki/default.aspx/iRules." + sToken;
                        sUrl = "https://devcentral.f5.com/wiki/iRules." + sToken + ".ashx";
                        break;
                    case 13: /* iRule GTM tokens */
                        //sUrl = "http://devcentral.f5.com/Wiki/print.aspx/iRules." + sToken;
                        //sUrl = "http://devcentral.f5.com/Wiki/default.aspx/iRules." + sToken;
                        sUrl = "https://devcentral.f5.com/wiki/iRules." + sToken + ".ashx";
                        break;
                    case 14: /* tcl commands */
						//sUrl = "http://tmml.sourceforge.net/doc/tcl/" + sToken + ".html";
						sUrl = "http://www.tcl.tk/man/tcl8.4/TclCmd/" + sToken + ".htm";
                        break;
                }
                Configuration.LaunchProcess(sUrl);
            }
            return default(int);
        }
        private int m_textEditor_DwellStart(scintilla.ScintillaControl pSender, int position, int x, int y)
        {
            m_textEditor.CallTipShow(position, "Click this link to go to the online documentation");
            return default(int);
        }
        private int m_textEditor_Modified(scintilla.ScintillaControl pSender)
        {
            toolStripMenuItem_EditUndo.Enabled = m_textEditor.CanUndo;
            toolStripMenuItem_EditRedo.Enabled = m_textEditor.CanRedo;
            updateMenus();
            markItem(getCurrentItem(), true);
            bookMarkRemoveAll();
            return default(int);
        }
        private int m_textEditor_UpdateUI(scintilla.ScintillaControl pSender)
        {
            updateMenus();
            return default(int);
        }
        private int m_textEditor_MarginClick(scintilla.ScintillaControl pSender, int modifiers, int position, int margin)
        {
            //int position = m_textEditor.CurrentPos;
            //int modifiers = 0; // HACK
            int lineClick = m_textEditor.LineFromPosition(position);
            if (Convert.ToBoolean(modifiers & 1 /* SCMOD_SHIFT */) && Convert.ToBoolean(modifiers & 2 /* SCMOD_CTRL*/))
            {
                // Fold All
                Editor_FoldAll();
            }
            else
            {
                int levelClick = m_textEditor.GetFoldLevel(lineClick);
                if (Convert.ToBoolean(levelClick & 0x2000 /* SC_FOLDLEVELHEADERFLAG */ ))
                {
                    if (Convert.ToBoolean(modifiers & 1 /* SCMOD_SHIFT */))
                    {
                        Editor_EnsureAllChidrenVisible(lineClick, levelClick);
                    }
                    else if (Convert.ToBoolean(modifiers & 2 /* SCMOD_CTRL */))
                    {
                        Editor_ToggleFoldRecursive(lineClick, levelClick);
                    }
                    else
                    {
                        m_textEditor.ToggleFold(lineClick);
                    }
                }
            }
            return default(int);
        }

		private void toolStripMenuItem_DynamicClick(object sender, EventArgs e)
		{
			String new_partition = sender.ToString();

			String old_partition = Clients.Interfaces.ManagementPartition.get_active_partition();

			Clients.Interfaces.ManagementPartition.set_active_partition(new_partition);
			if (DoRefresh())
			{
				ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
				if (!tsmi.Checked)
				{
					for (int i = 0; i < toolStripMenuItem_FilePartition.DropDownItems.Count; i++)
					{
						ToolStripMenuItem tsmi2 = (ToolStripMenuItem)toolStripMenuItem_FilePartition.DropDownItems[i];
						tsmi2.Checked = false;
					}
					tsmi.Checked = true;
				}
				m_currentPartition = new_partition;
			}
			else
			{
				Clients.Interfaces.ManagementPartition.set_active_partition(old_partition);
			}
			updateTitle(false);
		}
        private void toolStripMenuItem_FolderDynamicClick(object sender, EventArgs e)
        {
            try
            {
                String old_folder = Clients.Interfaces.SystemSession.get_active_folder();

                //String folder = sender.ToString();
                ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
                String folder = tsmi.Tag.ToString();

                Clients.Interfaces.SystemSession.set_active_folder(folder);
                if (DoRefresh())
                {
                    uncheckAllChildMenus(ToolStripMenuItem_FileFolder);
                    tsmi.Checked = true;
                }
                else
                {
                    Clients.Interfaces.SystemSession.set_active_folder(old_folder);
                }
            }
            catch (Exception)
            {
            }
        }
		private void toolStripMenuItem_FileConnect_Click(object sender, EventArgs e)
        {
            DoConnect();
        }
        private void toolStripMenuItem_FileNew_Click(object sender, EventArgs e)
        {
            DoNew();
        }
        private void toolStripMenuItem_FileSave_Click(object sender, EventArgs e)
        {
            DoSave();
        }
        private void toolStripMenuItem_FileSaveAll_Click(object sender, EventArgs e)
        {
            DoSaveAll();
        }
        private void toolStripMenuItem_FileDelete_Click(object sender, EventArgs e)
        {
            DoDelete();
        }
        private void toolStripMenuItem_FileArchiveExport_Click(object sender, EventArgs e)
        {
            DoExport();
        }
        private void toolStripMenuItem_FileArchiveImport_Click(object sender, EventArgs e)
        {
            DoImport();
        }
        private void toolStripMenuItem_FileArchiveOpen_Click(object sender, EventArgs e)
        {
            Configuration.LaunchProcess(m_archiveDirectory);
        }
        private void toolStripMenuItem_FileArchiveSetLocation_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = m_archiveDirectory;
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                m_archiveDirectory = fbd.SelectedPath;
            }
        }
        private void toolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
        private void toolStripMenuItem_EditUndo_Click(object sender, EventArgs e)
        {
            m_textEditor.Undo();
        }
        private void toolStripMenuItem_EditRedo_Click(object sender, EventArgs e)
        {
            m_textEditor.Redo();
        }
        private void toolStripMenuItem_EditCut_Click(object sender, EventArgs e)
        {
            m_textEditor.Cut();
        }
        private void toolStripMenuItem_EditCopy_Click(object sender, EventArgs e)
        {
            m_textEditor.Copy();
        }
        private void toolStripMenuItem_EditPaste_Click(object sender, EventArgs e)
        {
            m_textEditor.Paste();
        }
        private void toolStripMenuItem_EditDelete_Click(object sender, EventArgs e)
        {
            m_textEditor.Clear();
        }
        private void toolStripMenuItem_EditSelectAll_Click(object sender, EventArgs e)
        {
            m_textEditor.SelectAll();
        }
        private void toolStripMenuItem_SearchFind_Click(object sender, EventArgs e)
        {
            DoSearchFind();
        }
        private void toolStripMenuItem_SearchFindNext_Click(object sender, EventArgs e)
        {
            DoSearchFind(false);
        }
        private void toolStripMenuItem_SearchFindPrevious_Click(object sender, EventArgs e)
        {
            DoSearchFind(true);
        }
        private void toolStripMenuItem_ViewLineNumbers_Click(object sender, EventArgs e)
        {
            showLineNumbers(!m_showLineNumbers);
        }
        private void toolStripMenuItem_ViewIndentionGuides_Click(object sender, EventArgs e)
        {
            showIndentionGuides(!m_showIndentionGuides);
        }
        private void toolStripMenuItem_ViewMargin_Click(object sender, EventArgs e)
        {
            showMargin(!m_showMargin);
        }
        private void toolStripMenuItem_ViewFoldMargin_Click(object sender, EventArgs e)
        {
            showFoldMargin(!m_showFoldMargin);
        }
        private void toolStripMenuItem_ViewWordWrap_Click(object sender, EventArgs e)
        {
            showWordWrap(!m_showWordWrap);
        }
        private void toolStripMenuItem_ViewWhiteSpace_Click(object sender, EventArgs e)
        {
            showWhiteSpace(!m_showWhiteSpace);
        }
        private void toolStripMenuItem_ViewEndOfLine_Click(object sender, EventArgs e)
        {
            showEndOfLine(!m_showEndOfLine);
        }
        private void toolStripMenuItem_ViewBookmarks_Click(object sender, EventArgs e)
        {
            bookMarkRemoveAll();
        }
        private void toolStripMenuItem_ViewAutoComplete_Click(object sender, EventArgs e)
        {
            showAutoComplete(!m_showAutoComplete);
        }
        private void toolStripMenuItem_ViewHotspots_Click(object sender, EventArgs e)
        {
            showHotspots(!m_showHotspots);
        }
        private void toolStripMenuItem_ViewStatus_Click(object sender, EventArgs e)
        {
            DoViewStatus();
        }
        private void toolStripMenuItem_ShowSplashScreen_Click(object sender, EventArgs e)
        {
            showSplashScreen(!m_showSplashScreen);
        }
		private void ToolStripMenuItem_ViewChangeIndentionSettings_Click(object sender, EventArgs e)
		{
			IndentionSettingsDialog isd = new IndentionSettingsDialog();
			isd.m_AutoIndent = m_autoIndent;
			isd.m_UseTabs = m_useTabs;
			isd.m_IndentSize = m_indentSize;
			isd.m_TabSize = m_tabSize;

			DialogResult dr = isd.ShowDialog();
			if (dr == DialogResult.OK)
			{
				m_autoIndent = isd.m_AutoIndent;
				m_useTabs = isd.m_UseTabs;
				m_indentSize = isd.m_IndentSize;
				m_tabSize = isd.m_TabSize;

				updateIndentionSettings();
			}
		}
		private void toolStripMenuItem_ToolsDataGroupEditor_Click(object sender, EventArgs e)
        {
            DoDataGroups();
        }
        private void toolStripMenuItem_ToolsLogViewer_Click(object sender, EventArgs e)
        {
            LogViewerDialog lvd = new LogViewerDialog();
            lvd.Show();
        }
        private void toolStripMenuItem_ToolsShare_Click(object sender, EventArgs e)
        {
            DoShare();
        }
        private void toolStripMenuItem_ToolsGenerateTraffic_Click(object sender, EventArgs e)
        {
            DoGenerateTraffic();
        }
        private void toolStripMenuItem_ToolsCheckForUpdates_Click(object sender, EventArgs e)
        {
            DoCheckForUpdates(true, true);
        }
        private void toolStripMenuItem_ToolsReloadConfig_Click(object sender, EventArgs e)
        {
            initializeEditor();
        }
        private void toolStripMenuItem_ToolsResetConfig_Click(object sender, EventArgs e)
        {
            if (exportConfig())
            {
                initializeEditor();
            }
        }
		private void ToolStripMenuItem_ToolsEditConfig_Click(object sender, EventArgs e)
		{
			editConfig();
		}
		private void ToolStripMenuItem_ToolsBIGIPConfigSaveConfig_Click(object sender, EventArgs e)
		{
			DoSaveConfiguration(true);
		}
		private void ToolStripMenuItem_ToolsBIGIPConfigAutoSave_Click(object sender, EventArgs e)
		{
			autoSaveConfiguration(!m_autoSaveConfig);
		}
		private void toolStripMenuItem_HelpiRuler_Click(object sender, EventArgs e)
        {
            Configuration.LaunchProcess(Configuration.getWebHelpURL());
        }
        private void toolStripMenuItem_HelpiRuler_Click_1(object sender, EventArgs e)
        {
            Configuration.LaunchProcess(Configuration.getWebHelpURL());
        }
        private void toolStripMenuItem_HelpDevCentral_Click(object sender, EventArgs e)
        {
            Configuration.LaunchProcess("http://devcentral.f5.com");
        }
        private void toolStripMenuItem_HelpForums_Click(object sender, EventArgs e)
        {
            Configuration.LaunchProcess("http://devcentral.f5.com/forums");
        }
        private void toolStripMenuItem_HelpiRulesReference_Click(object sender, EventArgs e)
        {
            Configuration.LaunchProcess("https://devcentral.f5.com/wiki/iRules.HomePage.ashx");
        }
        private void toolStripMenuItem_HelpTCLReference_Click(object sender, EventArgs e)
        {
            //Configuration.LaunchProcess("http://tmml.sourceforge.net/doc/tcl/index.html");
			Configuration.LaunchProcess("http://www.tcl.tk/man/tcl8.4/TclCmd/contents.htm");
        }
        private void toolStripMenuItem_HelpAbout_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }
        private void toolStripMenuItem_HelpTipOfTheDay_Click(object sender, EventArgs e)
        {
            TipOfDayDialog td = new TipOfDayDialog();
            td.ShowDialog();
        }
        private void toolStripMenuItem_Properties_Click(object sender, EventArgs e)
        {
            TreeNode tn = getCurrentItem();
            if (null != tn.Tag)
            {
                iRuleInfoDialog dlg = new iRuleInfoDialog();
                dlg.m_tn = getCurrentItem();
                DialogResult dr = dlg.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    DoSaveConfiguration(false);
                }
            }
        }
        private void toolStripMenuItem_Reset_Click(object sender, EventArgs e)
        {
            DoReset();
        }
        private void toolStripMenuItem_Reload_Click(object sender, EventArgs e)
        {
            DoReload();
        }
        private void toolStripMenuItem_CopyOffline_Click(object sender, EventArgs e)
        {
            // TODO:
            TreeNode tn = getCurrentItem();
            if (null != tn)
            {
                DoCopyOffline(tn);
            }
        }


        private void contextMenuStrip_TreeView_Opened(object sender, EventArgs e)
        {
            /*
            if (null == treeView_iRules.SelectedNode)
            {
                toolStripMenuItem_Properties.Enabled = false;
                toolStripMenuItem_Reset.Enabled = false;
            }
            else
            {
                toolStripMenuItem_Properties.Enabled = true;
                toolStripMenuItem_Reset.Enabled = true;
            }
            */
        }

        private void toolStripButton_Connect_Click(object sender, EventArgs e)
        {
            DoConnect();
        }
        private void toolStripButton_New_Click(object sender, EventArgs e)
        {
            DoNew();
        }
        private void toolStripButton_Save_Click(object sender, EventArgs e)
        {
            DoSave();
        }
        private void toolStripButton_Delete_Click(object sender, EventArgs e)
        {
            DoDelete();
        }
        private void toolStripButton_Share_Click(object sender, EventArgs e)
        {
            DoShare();
        }
        private void toolStripButton_CheckSyntax_Click(object sender, EventArgs e)
        {
            DoParse();
        }
        private void toolStripButton_DataGroups_Click(object sender, EventArgs e)
        {
            DoDataGroups();
        }
        private void toolStripButton_GenerateTraffic_Click(object sender, EventArgs e)
        {
            DoGenerateTraffic();
        }
        private void toolStripButton_RefreshList_Click(object sender, EventArgs e)
        {
            DoRefresh();
        }
        private void toolStripButton_DevCentral_Click(object sender, EventArgs e)
        {
            Configuration.LaunchProcess("http://devcentral.f5.com");
        }
        private void toolStripButton_DevCentralForums_Click(object sender, EventArgs e)
        {
            Configuration.LaunchProcess("http://devcentral.f5.com/Community/TopicGroups/tabid/1082223/asg/50/showtab/groupforums/Default.aspx");
        }
        private void toolStripButton_Wiki_Click(object sender, EventArgs e)
        {
            Configuration.LaunchProcess("http://devcentral.f5.com/wiki/iRules.HomePage.ashx");
        }
        private void toolStripButton_TCL_Click(object sender, EventArgs e)
        {
            //Configuration.LaunchProcess("http://tmml.sourceforge.net/doc/tcl/index.html");
			Configuration.LaunchProcess("http://www.tcl.tk/man/tcl8.4/TclCmd/contents.htm");
		}
        private void toolStripMenuItem_Save_Click(object sender, EventArgs e)
        {
            DoSave();
        }
        private void toolStripMenuItem_Delete_Click(object sender, EventArgs e)
        {
            DoDelete();
        }
        private void toolStripMenuItem_CheckSyntax_Click(object sender, EventArgs e)
        {
            DoParse();
        }
        private void toolStripMenuItem_Share_Click(object sender, EventArgs e)
        {
            DoShare();
        }

        private void treeView_iRules_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = getCurrentItem();
            // update last list view item with updates
            if ((null != m_lastTreeViewNode) && (m_lastTreeViewNode != tn))
            {
                iRuleInfo iri = (iRuleInfo)m_lastTreeViewNode.Tag;
                if (null != iri)
                {
                    iri.rule_details = m_textEditor.Text;
                }
            }

            if (null != tn)
            {
                m_lastTreeViewNode = tn;
                iRuleInfo iri = (iRuleInfo)tn.Tag;
                if (null != iri)
                {
                    m_iri = iri;
                    monitorNotifications(false);
                    m_textEditor.Text = iri.rule_details;
                    monitorNotifications(true);
                }
                else
                {
                    m_textEditor.Text = "";
                }
                updateTitle(false);
                showButtons(Clients.Connected);
                m_textEditor.EmptyUndoBuffer();
            }
        }
        private void treeView_iRules_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode tn = getCurrentItem();
            if (null != tn.Tag)
            {
                iRuleInfoDialog dlg = new iRuleInfoDialog();
                dlg.m_tn = tn;
                DialogResult dr = dlg.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    DoSaveConfiguration(false);
                }
            }
        }
        private void treeView_iRules_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Create Temporary File
            TreeNode tn = (TreeNode)e.Item;
            iRuleInfo iri = (iRuleInfo)tn.Tag;
            if ( null != tn.Tag )
            {
                String sTempFile = Configuration.createTemporaryFile(iri.rule_name + ".txt", iri.rule_details);
                String[] files = new String[1];
                files[0] = sTempFile;
                System.Windows.Forms.DataObject data = new System.Windows.Forms.DataObject();
                data.SetData(DataFormats.FileDrop, files);
                data.SetData(DataFormats.Text, iri.rule_details);
                DoDragDrop(data, DragDropEffects.Copy);

                // Cleanup
                //System.IO.File.Delete(sTempFile);
            }
        }
        private void treeView_iRules_DragOver(object sender, DragEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("treeView_iRules_Dragover(" + e.X.ToString() + "," + e.Y.ToString() + ")");
            e.Effect = DragDropEffects.None;

            // Test for Auto Scroll
            const Single ScrollRegion = 20;
            System.Drawing.Point pt = treeView_iRules.PointToClient(Cursor.Position);
            if ( (pt.Y + ScrollRegion) > treeView_iRules.Height )
            {
                //System.Diagnostics.Debug.WriteLine("Auto Scrolling up");
                SendMessage(treeView_iRules.Handle, (int)277, (int)1, 0);
                return;
            }
            else if ( pt.Y < (treeView_iRules.Top + ScrollRegion) )
            {
                //System.Diagnostics.Debug.WriteLine("Auto Scrolling down");
                SendMessage(treeView_iRules.Handle, (int)277, (int)0, 0);
                return;
            }

            TreeNode tn = treeView_iRules.GetNodeAt(
                treeView_iRules.PointToClient(new System.Drawing.Point(e.X, e.Y)));

            if (null != tn)
            {
                System.Diagnostics.Debug.WriteLine("treeView_iRules_Dragover() : Node: " + tn.Text);

                //            if (Clients.Connected)
                if ((tn == m_treeNodeLocalLB) || (tn == m_treeNodeGlobalLB) || (tn == m_treeNodeOffline))
                {
                    String[] fileDropList = getDragDropFileList(e);
                    System.Diagnostics.Debug.WriteLine("treeView_iRules_Dragover() : droplist length: " + fileDropList.Length);
                    if (null != fileDropList)
                    {
                        // Check for a .txt file extension
                        bool bAllValid = true;
                        for (int i = 0; i < fileDropList.Length; i++)
                        {
                            if (!fileDropList[i].ToLower().EndsWith(".txt"))
                            {
                                System.Diagnostics.Debug.WriteLine("treeView_iRules_Dragover() : bAllValid");
                                bAllValid = false;
                            }
                        }

                        e.Effect = DragDropEffects.None;
                        if ((fileDropList.Length > 0) && bAllValid && (null != tn))
                        {
                            if ((tn == m_treeNodeLocalLB) || (tn == m_treeNodeGlobalLB) || (tn == m_treeNodeOffline))
                            {
                                e.Effect = DragDropEffects.Copy;
                            }
                        }
                    }
                }
            }
        }
        private void treeView_iRules_DragEnter(object sender, DragEventArgs e)
        {
        }
        private void treeView_iRules_DragLeave(object sender, EventArgs e)
        {
        }
        private void treeView_iRules_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!e.Node.IsSelected)
            {
                treeView_iRules.SelectedNode = e.Node;
            }
        }
        private void treeView_iRules_DragDrop(object sender, DragEventArgs e)
        {
            String[] fileDropList = getDragDropFileList(e);

            TreeNode tn = treeView_iRules.GetNodeAt(
                treeView_iRules.PointToClient(new System.Drawing.Point(e.X, e.Y)));

            DoDropFiles(fileDropList, true, tn);
        }

        private void textBox_Status_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                int curSelection = textBox_Status.SelectionStart;
                int count = 0;
                String[] sLines = textBox_Status.Text.Split(new char[] { '\n' });
                for (int i = 0; i < sLines.Length; i++)
                {
                    int lineLength = sLines[i].Length;
                    if ((curSelection >= count) && (curSelection <= (count + lineLength)))
                    {
                        // selection is in this line!
                        if (sLines[i].StartsWith("line "))
                        {
                            String sLineNumber = sLines[i].Substring(5, sLines[i].Length - 5);
                            String [] sTokens = sLineNumber.Split(new char[] { ':'});
                            if (sTokens.Length > 0)
                            {
                                int lineNumber = Convert.ToInt32(sTokens[0]);
                                // Hightlight line.
                                lineNumber--;
                                m_textEditor.GotoLine(lineNumber);
                                m_textEditor.SetSel(m_textEditor.SelectionStart, m_textEditor.GetLineEndPosition(lineNumber));
                            }
                            break;
                        }
                    }
                    count += (lineLength+1);
                }
            }
            catch (Exception)
            {
            }
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
        private void toolStripContainer2_ContentPanel_Load(object sender, EventArgs e)
        {

        }
        private void panel_Middle_Paint(object sender, PaintEventArgs e)
        {

        }
        private void panel_Top_Paint(object sender, PaintEventArgs e)
        {

        }

        #endregion
	}
}

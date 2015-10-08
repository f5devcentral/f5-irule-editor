//===========================================================================
//
// File         : PromptDialog.cs
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
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iRuler.Utility;

namespace iRuler.Dialogs
{
	/// <summary>
	/// Summary description for TestForm.
	/// </summary>
	public partial class PromptDialog : System.Windows.Forms.Form
	{
        public int m_mode = 0;
        public String m_ruleName = "";
        public String m_ruleDefault = "";
        public String[] m_LTMEvents = null;
        public String[] m_GTMEvents = null;
		public String[] m_existingiRules = null;
        public iRuleInfo.RuleType m_ruleType = iRuleInfo.RuleType.LOCALLB;


		public PromptDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		private void loadTemplates()
		{
            String sConfigPath = Configuration.getConfigSubDir("Templates");

			string [] templates = Directory.GetFiles(sConfigPath, "*.txt");
			for(int i=0; i<templates.Length; i++)
			{
				String sTemplateName = Path.GetFileNameWithoutExtension(templates[i]);

				if ( ! sTemplateName.StartsWith("_") )
				{
					StreamReader sr = File.OpenText(templates[i]);
					String sContents = sr.ReadToEnd();
                    TreeNode tn = new TreeNode();
                    tn.Text = sTemplateName;
                    tn.Tag = sContents;
                    treeView_Templates.Nodes.Add(tn);
                    sr.Close();
                }
			}
		}

		private void loadEvents()
		{
            String sConfigPath = Configuration.getConfigSubDir("Templates");
            String sEventsFile = sConfigPath + "_Events.txt";

			if ( File.Exists(sEventsFile) )
			{
				StreamReader sr = File.OpenText(sEventsFile);
				String input;
				while ((input=sr.ReadLine())!=null) 
				{
					listBox_Events.Items.Add(input);
				}
				sr.Close();

                if (listBox_Events.Items.Count > 0)
                {
                    m_LTMEvents = new String[listBox_Events.Items.Count];
                    for (int i = 0; i < listBox_Events.Items.Count; i++)
                    {
                        m_LTMEvents[i] = listBox_Events.Items[i].ToString();
                    }
                    listBox_Events.Items.Clear();
                }
			}

            sEventsFile = sConfigPath + "_GTMEvents.txt";

            if (File.Exists(sEventsFile))
            {
                StreamReader sr = File.OpenText(sEventsFile);
                String input;
                while ((input = sr.ReadLine()) != null)
                {
                    listBox_Events.Items.Add(input);
                }
                sr.Close();

                if (listBox_Events.Items.Count > 0)
                {
                    m_GTMEvents = new String[listBox_Events.Items.Count];
                    for (int i = 0; i < listBox_Events.Items.Count; i++)
                    {
                        m_GTMEvents[i] = listBox_Events.Items[i].ToString();
                    }
                    listBox_Events.Items.Clear();
                }
            }

		}

        private void fillEventsListBox(String[] list)
        {
            if (null != list)
            {
                listBox_Events.Items.Clear();
                for (int i = 0; i < list.Length; i++)
                {
                    listBox_Events.Items.Add(list[i]);
                }
            }
        }

        private void button_OK_Click(object sender, System.EventArgs e)
		{
			if ( textBox_Name.Text.Trim().Length > 0 )
			{
				bool bRuleExists = false;
				m_ruleName = textBox_Name.Text.Trim();

				// Check to make sure that this name wasn't already used...
				for (int i = 0; i < m_existingiRules.Length; i++)
				{
					if (m_ruleName.ToLower().Equals(m_existingiRules[i].ToLower()))
					{
						bRuleExists = true;
						break;
					}
				}

				if (bRuleExists)
				{
					MessageBox.Show("You must enter a unique name for your iRule", "Error");
				}
				else
				{
					// Check for invalid characters
					//System.Text.RegularExpressions.Regex validNamePattern = new System.Text.RegularExpressions.Regex("[^a-zA-Z.*/\\-:_?=@,]");
					System.Text.RegularExpressions.Regex validNamePattern = new System.Text.RegularExpressions.Regex("[^a-zA-Z0-9._\\-]");
					bool bMatch = validNamePattern.IsMatch(m_ruleName);
					if ( bMatch )
					{
						MessageBox.Show("Invalid characters in the iRule name.  Only alpha characters, numbers, and the following special characters are allowed (._-)", "Error");
					}
					else
					{
						if (0 == tabControl_Options.SelectedIndex)
						{
							// already handled by the SelectedIndexChanged event.
						}
						else if (1 == tabControl_Options.SelectedIndex)
						{
							m_ruleDefault = "";
							if (listBox_Events.SelectedItems.Count > 0)
							{
								for (int i = 0; i < listBox_Events.SelectedItems.Count; i++)
								{
									m_ruleDefault = m_ruleDefault +
										"when " + listBox_Events.SelectedItems[i].ToString() + " {\n" +
										"  log local0. \"in " + listBox_Events.SelectedItems[i].ToString() + "\"\n" +
										"}\n\n";
								}
							}
						}
						this.DialogResult = DialogResult.OK;
						this.Close();
					}
				}
			}
			else
			{
				MessageBox.Show("An iRule with this name already exists.  Please select a unique name.", "Error");
			}

		}

		private void button_Cancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void textBox_Name_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void label2_Click(object sender, System.EventArgs e)
		{
		
		}

		private void PromptDialog_Load(object sender, System.EventArgs e)
		{
            RuleTypeComboBox.Items.Add("Local Traffic Management");
            if (Clients.ConnectionInfo.getGTMLicensed())
            {
                RuleTypeComboBox.Items.Add("Global Traffic Management");
            }
            RuleTypeComboBox.SelectedIndex = 0;
			loadTemplates();
			loadEvents();
            fillEventsListBox(m_LTMEvents);
		}

		private void tabControl_Options_TabIndexChanged(object sender, System.EventArgs e)
		{
			m_mode = tabControl_Options.SelectedIndex;
		}

        private void treeView_Templates_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (null != treeView_Templates.SelectedNode)
            {
                m_ruleDefault = treeView_Templates.SelectedNode.Tag.ToString();
            }
        }

        private void PromptDialog_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            Configuration.LaunchProcess(Configuration.getWebHelpURL() + "#NewiRuleDialog");
        }

        private void RuleTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RuleTypeComboBox.SelectedIndex == 0)
            {
                m_ruleType = iRuleInfo.RuleType.LOCALLB;
                fillEventsListBox(m_LTMEvents);
            }
            else
            {
                m_ruleType = iRuleInfo.RuleType.GLOBALLB;
                fillEventsListBox(m_GTMEvents);
            }
        }

	}
}

//===========================================================================
//
// File         : ShareDialog.cs
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iRuler.Utility;

namespace iRuler.Dialogs
{
    public partial class ShareDialog : Form
    {
        public String rule_name = "";
        public String rule_details = "";
        public String rule_description = "";
        public String author_name = "";
        public String author_email = "";

        public ShareDialog()
        {
            InitializeComponent();
        }

        private bool shareiRule()
        {
            bool bShared = false;
            try
            {
                System.Net.WebClient webClient = new System.Net.WebClient();
                System.Collections.Specialized.NameValueCollection coll = new System.Collections.Specialized.NameValueCollection();
                coll.Add("rule_name", rule_name);
                coll.Add("author_name", author_name);
                coll.Add("author_email", author_email);
                coll.Add("rule_description", rule_description);
                coll.Add("rule_details", rule_details);
                byte[] responseArray = webClient.UploadValues(Configuration.getShareUrl(), "POST", coll);
                String sResponse = "";
                if (null != responseArray)
                {
                    for (int i = 0; i < responseArray.Length; i++)
                    {
                        sResponse += (char)responseArray[i];
                    }
                }
                if (sResponse.Length > 0)
                {
                    if (sResponse.StartsWith("SUCCESS"))
                    {
                        MessageBox.Show("iRule successfully submitted to DevCentral!\nAfter it is reviewed by the DevCentral Staff it will be available to the public.", "Thank you for your contribution!");
                        bShared = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error sharing iRule");
            }
            return bShared;
        }

        private bool validateFields()
        {
            rule_name = textBox_RuleName.Text;
            rule_details = textBox_iRule.Text;
            rule_description = textBox_Description.Text;
            author_name = textBox_AuthorName.Text;
            author_email = textBox_Email.Text;

            bool bValid = true;
            if (0 == textBox_RuleName.Text.Length)
            {
                MessageBox.Show("You must enter a name for your iRule!");
                textBox_RuleName.Focus();
                bValid = false;
            }
            else if (0 == textBox_Description.Text.Length)
            {
                MessageBox.Show("You must enter a description for your iRule!");
                textBox_Description.Focus();
                bValid = false;
            }
            else if (0 == textBox_iRule.Text.Length)
            {
                MessageBox.Show("You must enter content for your iRule!");
                textBox_iRule.Focus();
                bValid = false;
            }
            else if (!checkBox_Accept.Checked)
            {
                MessageBox.Show("You must accept the terms and conditions before submitting your iRule");
                bValid = false;
            }

            return bValid;
        }

        private void ShareDialog_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            Configuration.LaunchProcess(Configuration.getConfigDir() + "#ShareDialog");
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (validateFields())
            {
                if (shareiRule())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ShareDialog_Load(object sender, EventArgs e)
        {
            textBox_RuleName.Text = rule_name;
            textBox_Description.Text = rule_description;
            textBox_iRule.Text = rule_details;
            richTextBox_Acknowledgement.Text = "I agree that the iRule I am submitting to share with the " +
                "F5 DevCentral Developer Community does not contain code that is the intellectual " +
                "property of another individual or organization.  I also agree that by clicking " +
                "the Submit button, I grant F5 Networks permission to share the contents of this " +
                "form to any and all public audiences.";

        }

    }
}
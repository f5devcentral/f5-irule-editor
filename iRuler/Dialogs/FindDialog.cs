//===========================================================================
//
// File         : FindDialog.cs
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
    public partial class FindDialog : Form
    {
        public iRulerMain m_mainForm = null;
        public SearchInfo m_si = null;
        public FindDialog()
        {
            InitializeComponent();
        }

        private void FindDialog_Load(object sender, EventArgs e)
        {
            if (null != m_si)
            {
                textBox_SearchString.Text = m_si.searchString;
                checkBox_MatchCase.Checked = m_si.matchCase;
                checkBox_MatchWholeWord.Checked = m_si.matchWholeWord;
                checkBox_Regex.Checked = m_si.regex;
                checkBox_TransformBackslash.Checked = m_si.transform;
                checkBox_WrapAround.Checked = m_si.wrapAround;
                radioButton_Down.Checked = m_si.down;
                radioButton_Up.Checked = !m_si.down;

            }

        }

        private void button_FindNext_Click(object sender, EventArgs e)
        {
            if (textBox_SearchString.Text.Length > 0)
            {
                m_mainForm.DoSearchFind(radioButton_Up.Checked);
            }
            else
            {
                textBox_SearchString.Focus();
            }
        }
        private void button_MarkAll_Click(object sender, EventArgs e)
        {
            if (textBox_SearchString.Text.Length > 0)
            {
                m_mainForm.DoSearchMarkAll();
            }
            else
            {
                textBox_SearchString.Focus();
            }
        }
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void textBox_SearchString_TextChanged(object sender, EventArgs e)
        {
            bool bEnabled = (textBox_SearchString.Text.Length > 0);
            button_FindNext.Enabled = bEnabled;
            button_MarkAll.Enabled = bEnabled;
            m_si.searchString = textBox_SearchString.Text;
        }

        private void checkBox_MatchWholeWord_CheckedChanged(object sender, EventArgs e)
        {
            m_si.matchWholeWord = checkBox_MatchWholeWord.Checked;
        }
        private void checkBox_MatchCase_CheckedChanged(object sender, EventArgs e)
        {
            m_si.matchCase = checkBox_MatchCase.Checked;
        }
        private void checkBox_Regex_CheckedChanged(object sender, EventArgs e)
        {
            m_si.regex = checkBox_Regex.Checked;
        }
        private void checkBox_WrapAround_CheckedChanged(object sender, EventArgs e)
        {
            m_si.wrapAround = checkBox_WrapAround.Checked;
        }
        private void checkBox_TransformBackslash_CheckedChanged(object sender, EventArgs e)
        {
            m_si.transform = checkBox_TransformBackslash.Checked;
        }
    }
}
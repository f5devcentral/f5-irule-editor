//===========================================================================
//
// File         : IndentionSettings.cs
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

namespace iRuler.Dialogs
{
	public partial class IndentionSettingsDialog : Form
	{
		public bool m_AutoIndent = true;
		public bool m_UseTabs = true;
		public int m_TabSize = 4;
		public int m_IndentSize = 4;

		public IndentionSettingsDialog()
		{
			InitializeComponent();
		}

		private void button_OK_Click(object sender, EventArgs e)
		{
			m_AutoIndent = checkBox_AutoIndent.Checked;
			m_UseTabs = checkBox_UseTabs.Checked;
			m_TabSize = (int)numericUpDown_TabSize.Value;
			m_IndentSize = (int)numericUpDown_IndentSize.Value;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void button_Cancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void IndentionSettings_Load(object sender, EventArgs e)
		{
			numericUpDown_IndentSize.Value = m_IndentSize;
			numericUpDown_TabSize.Value = m_TabSize;
			checkBox_AutoIndent.Checked = m_AutoIndent;
			checkBox_UseTabs.Checked = m_UseTabs;
		}
	}
}
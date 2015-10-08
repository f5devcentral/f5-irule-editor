//===========================================================================
//
// File         : StatusWindow.cs
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
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iRuler.Dialogs
{
	/// <summary>
	/// Summary description for StatusWindow.
	/// </summary>
	public class StatusWindow : System.Windows.Forms.Form
	{
		private System.Windows.Forms.RichTextBox richTextBox_Status;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public StatusWindow()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public void setText(String sText)
		{
			richTextBox_Status.Text = sText;
		}

		public void appendText(String sText)
		{
			richTextBox_Status.Text = richTextBox_Status.Text + sText;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.richTextBox_Status = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// richTextBox_Status
			// 
			this.richTextBox_Status.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox_Status.Location = new System.Drawing.Point(0, 0);
			this.richTextBox_Status.Name = "richTextBox_Status";
			this.richTextBox_Status.Size = new System.Drawing.Size(450, 312);
			this.richTextBox_Status.TabIndex = 0;
			this.richTextBox_Status.Text = "";
			// 
			// StatusWindow
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(450, 312);
			this.Controls.Add(this.richTextBox_Status);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StatusWindow";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "iRuler Status Window";
			this.Load += new System.EventHandler(this.StatusWindow_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void StatusWindow_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}

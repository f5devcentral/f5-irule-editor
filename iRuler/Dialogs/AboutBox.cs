//===========================================================================
//
// File         : AboutBox.cs
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
    public partial class AboutBox : Form
    {
        static AboutBox m_frmAboutBox = null;
        static System.Threading.Thread m_thread = null;
        public bool m_bAutoClose = false;
        public int m_timeout = 3000;
        public AboutBox()
        {
            InitializeComponent();
        }

        static public void showSplashScreen()
        {
            if (null != m_frmAboutBox)
            {
                return;
            }
            m_thread = new System.Threading.Thread(new System.Threading.ThreadStart(SplashForm));
            m_thread.IsBackground = true;
            m_thread.SetApartmentState(System.Threading.ApartmentState.MTA);
            m_thread.Start();

        }
        static public void SplashForm()
        {
            m_frmAboutBox = new AboutBox();
            m_frmAboutBox.m_timeout = 5000;
            m_frmAboutBox.m_bAutoClose = true;
            Application.Run(m_frmAboutBox);
        }

        private void AboutBox_Load(object sender, EventArgs e)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            if (null != assembly)
            {
                System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
                textBox_Version.Text = "version " + fvi.FileVersion;
            }


            richTextBox_Copyright.Text = 
                "The Initial Developer of the Original Code is F5 Networks, Inc. Seattle, WA, USA. " +
                "Portions created by F5 are Copyright (C) 2006 F5 Networks, Inc. All Rights Reserved. " +
                "iControl (TM), BIG-IP and iRules are registered trademarks or trademarks of F5 Networks, Inc. in the U.S. and certain other countries. " +
                "F5 Networks' trademarks may not be used in connection with any product or service except as permitted in writing by F5.";

            richTextBox_Credits.Text =
                "Portions of this application make use of the scintilla text editor control (http://www.scintilla.org) " +
                "which is Copyright 1998-2003 by Neil Hodgson <neilh@scintilla.org>.";

            /*
                            "F5, F5 Networks, the F5 logo, BIG-IP, iControl, GLOBAL-SITE, SEE-IT, EDGE-FX, FireGuard, " +
                            "iRules, PACKET VELOCITY, SYN Check, CONTROL YOUR WORLD, " +
                            "OneConnect, ZoneRunner, uRoam, FirePass, and TrafficShield are registered trademarks or trademarks of F5 Networks, Inc., " +
                            "in the U.S. and certain other countries.\n" +
                            "All other trademarks mentioned in this document are the property of their respective owners. " +
                            "F5 Networks' trademarks may not be used in connection with any product or service except as permitted in writing by F5.";
            */
            // The Initial Developer of the Original Code is F5 Networks, Inc.
            // Seattle, WA, USA.
            // Portions created by F5 are Copyright (C) 2004 F5 Networks, Inc.
            // All Rights Reserved.
            // iControl (TM) is a registered trademark of F5 Networks, Inc.        

            if (m_bAutoClose)
            {
                timer_AutoClose.Interval = m_timeout;
                timer_AutoClose.Start();
            }
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (!m_bAutoClose)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void timer_AutoClose_Tick(object sender, EventArgs e)
        {
            if (m_bAutoClose)
            {
                timer_AutoClose.Stop();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
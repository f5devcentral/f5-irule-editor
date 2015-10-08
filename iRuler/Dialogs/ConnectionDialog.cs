//===========================================================================
//
// File         : ConnectionDialog.cs
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
using iRuler.Utility;

namespace iRuler.Dialogs
{
	/// <summary>
	/// Summary description for ConnectionInfo.
	/// </summary>
	public partial class ConnectionDialog : System.Windows.Forms.Form
	{
        public int centerX;
        public int centerY;

        //public ConnectionInfo ci;

		public ConnectionDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		private void ConnectionDialog_Load(object sender, System.EventArgs e)
		{
			int newX = centerX - (this.Width/2);
			int newY = centerY - (this.Height/2);
			this.SetDesktopLocation(newX, newY);
			Clients.ConnectionInfo.clear();

            this.Show();

            // load up the child keys
            HostnameComboBox.Items.AddRange(Clients.ConnectionInfo.getAccounts());

            fillupForm(Clients.ConnectionInfo.getLastAccount());
		}

        private void fillupForm(String sHostname)
        {
            HostnameComboBox.Text = sHostname;
            UsernameTextBox.Text = "";
            //PortTextBox.Text = "";
            PasswordTextBox.Text = "";

            Clients.ConnectionInfo.loadFromRegistry(sHostname);
            HostnameComboBox.Focus();
            if (Clients.ConnectionInfo.hostname.Length > 0)
            {
                HostnameComboBox.Text = Clients.ConnectionInfo.hostname;
                UsernameTextBox.Focus();
            }
            if (Clients.ConnectionInfo.port > 0)
            {
                PortTextBox.Text = Convert.ToString(Clients.ConnectionInfo.port);
            }
            if (Clients.ConnectionInfo.username.Length > 0)
            {
                UsernameTextBox.Text = Clients.ConnectionInfo.username;
                PasswordTextBox.Focus();
            }
        }

        private void OKLinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
            if (0 == HostnameComboBox.Text.Length)
            {
                MessageBox.Show("Please enter a hostname.", "Missing information");
                HostnameComboBox.Focus();
            }
            else if (0 == PortTextBox.Text.Length)
            {
                MessageBox.Show("Please enter a port.", "Missing information");
                PortTextBox.Text = "443";
                PortTextBox.Focus();
            }
            else if (0 == EndpointTextBox.Text.Length)
            {
                MessageBox.Show("Please enter a endpoint (default of /iControl/iControlPortal.cgi).", "Missing information");
                EndpointTextBox.Text = "/iControl/iControlPortal.cgi";
                EndpointTextBox.Focus();
            }
            else if (0 == UsernameTextBox.Text.Length)
            {
                MessageBox.Show("Please enter a username.", "Missing information");
                UsernameTextBox.Focus();
            }
            else if (0 == PasswordTextBox.Text.Length)
            {
                MessageBox.Show("Please enter a password.", "Missing information");
                PasswordTextBox.Focus();
            }
            else
            {
                Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;

                Clients.ConnectionInfo.setEndpoint(HostnameComboBox.Text, Convert.ToInt32(PortTextBox.Text), EndpointTextBox.Text);
                Clients.ConnectionInfo.setCredentials(UsernameTextBox.Text, PasswordTextBox.Text);

                // Now verify if we can connect to the host
                iControl.SystemSystemInfo sysInfo = new iControl.SystemSystemInfo();
                sysInfo.Credentials = Clients.ConnectionInfo.creds;
                sysInfo.PreAuthenticate = true;

                try
                {
                    sysInfo.Url = Clients.ConnectionInfo.buildURL();
                    iControl.SystemProductInformation prodInfo = sysInfo.get_product_information();
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

                    sysInfo.Dispose();
                    Cursor.Current = System.Windows.Forms.Cursors.Default;
                    this.DialogResult = DialogResult.OK;

                    if (SaveConfigCheckBox.Checked)
                    {
                        Clients.ConnectionInfo.saveToRegistry(HostnameComboBox.Text);
                    }

                    this.Close();
                }
                catch (System.Net.WebException)
                {
                    MessageBox.Show(this, "Connection could not be established to specified host", "Error");
                }
                catch (System.UriFormatException)
                {
                    MessageBox.Show(this, "Connection could not be established to specified host", "Error");
                }

                sysInfo.Dispose();
                Cursor.Current = System.Windows.Forms.Cursors.Default;
            }
        }
    	private void CancelLinkLabel_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
        private void ConnectionDialog_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            Configuration.LaunchProcess(Configuration.getWebHelpURL() + "#ConnectionDialog");
        }

        private void HostnameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillupForm(HostnameComboBox.Text);
        }

        private void ClearLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Clients.ConnectionInfo.clearAccounts();
            HostnameComboBox.Items.Clear();
        }

	}
}

//===========================================================================
//
// File         : GenTrafficDialog.cs
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
using System.Web;

namespace iRuler.Dialogs
{
    public partial class GenTrafficDialog : Form
    {
        iControl.CommonIPPortDefinition m_vs_def = null;

        public GenTrafficDialog()
        {
            InitializeComponent();
        }

        private bool validateHTTP()
        {
            bool bValid = true;
            if (bValid && (null == m_vs_def))
            {
                statusMessage("You must select a Virtual Server from the list");
                bValid = false;
            }
            if (bValid && (0 == comboBox_HTTPMethod.Text.Length))
            {
                statusMessage("You must select a HTTP Method");
                bValid = false;
            }
			if (bValid && UseProxyCheckBox.Checked && (0 == ProxyServerTextBox.Text.Trim().Length))
			{
				statusMessage("If you are going to use a proxy server, please specify an address");
				bValid = false;
			}
			if (bValid && UseProxyCheckBox.Checked && (0 == ProxyPortTextBox.Text.Trim().Length))
			{
				statusMessage("If you are going to use a proxy server, please specify a port");
				bValid = false;
			}
			if (bValid)
            {
                statusMessage("");
            }

            return bValid;
        }

        private void statusMessage(String sMessage)
        {
            String sMessageText = "";
            if (sMessage.Length > 0)
            {
                String sTimestamp = System.DateTime.Now.ToString();
                sMessageText = richTextBox_Status.Text;
                if ( sMessageText.Length > 0 )
                {
                    sMessageText = sMessageText + "\n";
                }
                sMessageText = sMessageText + sTimestamp + ":" + sMessage;
            }
            richTextBox_Status.Text = sMessageText;
        }
        private void setError(String sMessage)
        {
            label_Error.Text = sMessage;
        }

        private void DoStart()
        {
            button_StartStop.Text = "Stop";
            statusMessage("");

            generateTraffic();
            if (numericUpDown_Interval.Value > 0)
            {
                timer_GenTraffic.Enabled = true;
            }
            else
            {
                timer_GenTraffic.Enabled = false;
                button_StartStop.Text = "Start";
            }
        }
        private void DoStop()
        {
            cancelTraffic();
            timer_GenTraffic.Enabled = false;
            button_StartStop.Text = "Start";
        }
        private void generateTraffic()
        {
            if (validateHTTP())
            {
                if (!backgroundWorker_traffic.IsBusy)
                {
                    ThreadInfo ti = new ThreadInfo();
                    ti.vs_def = m_vs_def;
                    ti.uri = textBox_URI.Text;
                    ti.method = comboBox_HTTPMethod.Text;
                    ti.username = textBox_HTTPUsername.Text;
                    ti.password = textBox_HTTPPassword.Text;
                    ti.param_names = new String[listView_HTTPParameters.Items.Count];
                    ti.param_values = new String[listView_HTTPParameters.Items.Count];
                    for (int i = 0; i < listView_HTTPParameters.Items.Count; i++)
                    {
                        ti.param_names[i] = listView_HTTPParameters.Items[i].Text;
                        ti.param_values[i] = listView_HTTPParameters.Items[i].SubItems[1].Text;
                    }
                    ti.header_names = new String[listView_HTTPHeaders.Items.Count];
                    ti.header_values = new String[listView_HTTPHeaders.Items.Count];
                    for (int i = 0; i < listView_HTTPHeaders.Items.Count; i++)
                    {
                        ti.header_names[i] = listView_HTTPHeaders.Items[i].Text;
                        ti.header_values[i] = listView_HTTPHeaders.Items[i].SubItems[1].Text;
                    }

					if (UseProxyCheckBox.Checked)
					{
						if ((0 != ProxyServerTextBox.Text.Trim().Length) && (0 != ProxyPortTextBox.Text.Trim().Length))
						{
							ti.proxy = new System.Net.WebProxy(ProxyServerTextBox.Text, Convert.ToInt32(ProxyPortTextBox.Text));
						}
					}

					richTextBox_Status.Text = "";
					richTextBox_Status.Refresh();

                    backgroundWorker_traffic.RunWorkerAsync(ti);
                }
            }
            else
            {
                DoStop();
            }
        }
        private void cancelTraffic()
        {
            if (backgroundWorker_traffic.IsBusy)
            {
                backgroundWorker_traffic.CancelAsync();
            }
        }

        private void GenTrafficDialog_Load(object sender, System.EventArgs e)
        {
            if ( Clients.Connected )
            {
                String [] vs_list = Clients.VirtualServer.get_list();
                for (int i = 0; i < vs_list.Length; i++)
                {
                    comboBox_VirtualServer.Items.Add(vs_list[i]);
                }
                comboBox_VirtualServer.SelectedIndex = 0;
                comboBox_HTTPMethod.SelectedIndex = 1;
            }
        }

        private void comboBox_VirtualServer_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            String vs = comboBox_VirtualServer.Items[comboBox_VirtualServer.SelectedIndex].ToString();

            iControl.CommonIPPortDefinition[] vs_def_list = Clients.VirtualServer.get_destination(new string[] { vs });
            if (vs_def_list.Length > 0)
            {
                m_vs_def = vs_def_list[0];
            }
            else
            {
                // user typed in address/port
                String[] sSplit = vs.Split(new char[] { ':' });
                if (sSplit.Length == 2)
                {
                    m_vs_def = new iControl.CommonIPPortDefinition();
                    m_vs_def.address = sSplit[0];
                    m_vs_def.port = Convert.ToInt32(sSplit[1]);
                }
                else
                {
                    MessageBox.Show("Virtual Server must either exist on the BIG-IP or you must enter a addr:port combination");
                    m_vs_def = null;
                }
            }
        }
        private void comboBox_VirtualServer_TextChanged(object sender, EventArgs e)
        {
        }
        private void comboBox_VirtualServer_Leave(object sender, EventArgs e)
        {
            String vs = comboBox_VirtualServer.Text;
            if (comboBox_VirtualServer.SelectedIndex >= 0)
            {
                iControl.CommonIPPortDefinition[] vs_def_list = Clients.VirtualServer.get_destination(new string[] { vs });
                if (vs_def_list.Length > 0)
                {
                    m_vs_def = vs_def_list[0];
                }
            }
            else
            {
                // user typed in address/port
                String[] sSplit = vs.Split(new char[] { ':' });
                if (sSplit.Length == 2)
                {
                    m_vs_def = new iControl.CommonIPPortDefinition();
                    m_vs_def.address = sSplit[0];
                    m_vs_def.port = Convert.ToInt32(sSplit[1]);
                }
                else
                {
                    MessageBox.Show("Virtual Server must either exist on the BIG-IP or you must enter a addr:port combination");
                    comboBox_VirtualServer.Focus();
                    m_vs_def = null;
                }
            }
        }

        private void listView_HTTPHeaders_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_HTTPHeaderRemove.Enabled = true;
        }
        private void listView_HTTPParameters_SelectedIndexChanged(object sender, EventArgs e)
        {
            button_HTTPParamRemove.Enabled = true;
        }

        private void textBox_HTTPHeaderName_TextChanged(object sender, EventArgs e)
        {
            if (textBox_HTTPHeaderName.Text.Length > 0)
            {
                button_HTTPHeaderAdd.Enabled = true;
            }
        }
        private void textBox_HTTPParamName_TextChanged(object sender, EventArgs e)
        {
            if (textBox_HTTPParamName.Text.Length > 0)
            {
                button_HTTPParamAdd.Enabled = true;
            }
        }
        private void textBox_HTTPParamValue_TextChanged(object sender, EventArgs e)
        {
        }

        private void button_HTTPHeaderAdd_Click(object sender, EventArgs e)
        {
            String sName = "";
            String sValue = "";
            if (textBox_HTTPHeaderName.Text.Length > 0)
            {
                sName = textBox_HTTPHeaderName.Text;
                sValue = textBox_HTTPHeaderValue.Text;
                ListViewItem lvi = new ListViewItem();
                lvi.Text = sName;
                lvi.SubItems.Add(sValue);
                listView_HTTPHeaders.Items.Add(lvi);
                textBox_HTTPHeaderName.Text = "";
                textBox_HTTPHeaderValue.Text = "";
            }
        }
        private void button_HTTPHeaderRemove_Click(object sender, EventArgs e)
        {
            if (0 != listView_HTTPHeaders.SelectedIndices.Count)
            {
                int index = listView_HTTPHeaders.SelectedIndices[0];
                ListViewItem lvi = listView_HTTPHeaders.Items[index];
                textBox_HTTPHeaderName.Text = lvi.Text;
                textBox_HTTPHeaderValue.Text = lvi.SubItems[1].Text;
                listView_HTTPHeaders.Items.RemoveAt(index);
            }
            if (0 == listView_HTTPHeaders.SelectedIndices.Count)
            {
                button_HTTPHeaderRemove.Enabled = false;
            }
        }
        private void button_HTTPParamAdd_Click(object sender, System.EventArgs e)
        {
            String sName = "";
            String sValue = "";
            if (textBox_HTTPParamName.Text.Length > 0)
            {
                sName = textBox_HTTPParamName.Text;
                sValue = textBox_HTTPParamValue.Text;
                ListViewItem lvi = new ListViewItem();
                lvi.Text = sName;
                lvi.SubItems.Add(sValue);
                listView_HTTPParameters.Items.Add(lvi);
                textBox_HTTPParamName.Text = "";
                textBox_HTTPParamValue.Text = "";
            }
        }
        private void button_HTTPParamRemove_Click(object sender, System.EventArgs e)
        {
            if (0 != listView_HTTPParameters.SelectedIndices.Count)
            {
                int index = listView_HTTPParameters.SelectedIndices[0];
                ListViewItem lvi = listView_HTTPParameters.Items[index];
                textBox_HTTPParamName.Text = lvi.Text;
                textBox_HTTPParamValue.Text = lvi.SubItems[1].Text;
                listView_HTTPParameters.Items.RemoveAt(index);
            }
            if (0 == listView_HTTPParameters.SelectedIndices.Count)
            {
                button_HTTPParamRemove.Enabled = false;
            }
        }
        
        private void button_StartStop_Click(object sender, EventArgs e)
        {
            if (button_StartStop.Text.Equals("Start"))
            {
                DoStart();
            }
            else
            {
                DoStop();
            }
        }
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            DoStop();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void backgroundWorker_traffic_DoWork(object sender, DoWorkEventArgs e)
        {
            ThreadInfo ti = (ThreadInfo)e.Argument;
            if (null != ti)
            {
                BackgroundWorker worker = sender as BackgroundWorker;
                worker.ReportProgress(0);

                System.Net.WebClient webClient = new System.Net.WebClient();
                System.Collections.Specialized.NameValueCollection coll = new System.Collections.Specialized.NameValueCollection();
                String sUrl = "";
                String sMethod = ti.method;

                // build uri
                String sProtocol = (checkBox_SSL.Checked) ? "https" : "http";
                sUrl = sProtocol + "://" + ti.vs_def.address + ":" + ti.vs_def.port.ToString() + ti.uri;

                if (sMethod.Equals("GET"))
                {

                }

                // add headers
                for (int i = 0; i < ti.header_names.Length; i++)
                {
                    webClient.Headers.Add(ti.header_names[i], ti.header_values[i]);
                }

                // Loop through the listview items
                for (int i = 0; i < ti.param_names.Length; i++)
                {
                    if (sMethod.Equals("POST"))
                    {
                        // add the name value pairs to the value collection
                        coll.Add(ti.param_names[i], ti.param_values[i]);
                    }
                    else
                    {
                        // for GET's let's build the parameter list onto the URL.
                        if (0 == i)
                        {
                            sUrl = sUrl + "?";
                        }
                        else
                        {
                            sUrl = sUrl + "&";
                        }
                        sUrl = sUrl + ti.param_names[i] + "=" + ti.param_values[i];
                    }
                }

                worker.ReportProgress(25);

                System.Net.NetworkCredential creds = new System.Net.NetworkCredential(ti.username, ti.password);
                webClient.Credentials = creds;

				if (null != ti.proxy)
				{
					webClient.Proxy = ti.proxy;
				}

                try
                {
                    worker.ReportProgress(50);

                    byte[] responseArray = null;

                    if (sMethod.Equals("POST"))
                    {
                        responseArray = webClient.UploadValues(sUrl, sMethod, coll);
                    }
                    else
                    {
                        responseArray = webClient.DownloadData(sUrl);
                    }
                    worker.ReportProgress(75);
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
                        e.Result = "Request Succeeded\n" + sResponse;
                    }
                }
                catch (Exception ex)
                {
                    e.Result = ex.Message.ToString();
                }
                webClient.Dispose();
                worker.ReportProgress(100);
            }
        }
        private void backgroundWorker_traffic_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar_Status.Value = e.ProgressPercentage;
			progressBar_Status.Focus();
			progressBar_Status.Refresh();
        }
        private void backgroundWorker_traffic_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (null != e.Error)
            {
                statusMessage(e.Error.Message.ToString());
                DoStop();
            }
            else if (e.Cancelled)
            {
                statusMessage("Request cancelled by user");
                DoStop();
            }
            else if (null != e.Result)
            {
                statusMessage(e.Result.ToString());
				if (!e.Result.ToString().StartsWith("Request Succeeded"))
				{
					DoStop();
				}
            }
            else
            {
                statusMessage("Request succeeded.");
            }
            progressBar_Status.Value = 0;
        }

        private void numericUpDown_Interval_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown_Interval.Value > 0)
            {
                timer_GenTraffic.Interval = Convert.ToInt32(numericUpDown_Interval.Value * 1000);
            }
        }
        private void timer_GenTraffic_Tick(object sender, EventArgs e)
        {
            generateTraffic();
        }

		private void UseProxyCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			ProxyServerTextBox.Enabled = UseProxyCheckBox.Checked;
			ProxyPortTextBox.Enabled = UseProxyCheckBox.Checked;
		}

    }

    public class ThreadInfo
    {
        //public ListView.ListViewItemCollection paramCollection = null;
        public String[] param_names = null;
        public String[] param_values = null;
        public String[] header_names = null;
        public String[] header_values = null;
        public iControl.CommonIPPortDefinition vs_def = null;
        public String uri = "";
        public String method = "";
        public String username = "";
        public String password = "";
		public System.Net.WebProxy proxy = null;
    };
}
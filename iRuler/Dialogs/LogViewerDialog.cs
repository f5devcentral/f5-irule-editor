//===========================================================================
//
// File         : LogViewerDialog.cs
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
    public partial class LogViewerDialog : Form
    {
        public LogViewerDialog()
        {
            InitializeComponent();
        }

        private bool isEof(iControl.SystemConfigSyncFileTransferContext ctx)
        {
            bool bEof = true;
            if (null != ctx)
            {
                if ((ctx.chain_type == iControl.CommonFileChainType.FILE_LAST) ||
                     (ctx.chain_type == iControl.CommonFileChainType.FILE_FIRST_AND_LAST))
                {
                    bEof = true;
                }
                else
                {
                    bEof = false;
                }
            }
            return bEof;
        }

        private void processLine(int line_num, String sLine)
        {
            //  0  1        2       3                4 
            //May 24 04:02:01 theboss syslog-ng[1222]: new configuration initialized

            //May 26 16:01:01 theboss logger: 011d0002: No diskmonitor entries in database

            String sTimestamp = "";
            String sHost = "";
            String sService = "";
            String sStatus = "";
            String sEvent = sLine;

            String[] sSplit = sLine.Split(new char[] { ' ' });
            if (sSplit.Length >= 3)
            {
                sTimestamp = sSplit[0] + " " + sSplit[1] + " " + sSplit[2];
            }
            if (sSplit.Length >= 4)
            {
                sHost = sSplit[3];
            }
            if (sSplit.Length >= 5)
            {
                sService = sSplit[4];
                if (sService.EndsWith(":"))
                {
                    sService = sService.Remove(sService.Length-1);
                }
            }
            if (sSplit.Length > 6)
            {
                sEvent = "";
                for (int i = 5; i < sSplit.Length; i++)
                {
                    if ( (5 == i) && (sSplit[i].EndsWith(":")) )
                    {
                        sStatus = sSplit[i].Remove(sSplit[i].Length - 1);
                    }
                    else
                    {
                        sEvent = sEvent + sSplit[i] + " ";
                    }
                }
            }

            ListViewItem lvi = new ListViewItem();
            lvi.Text = line_num.ToString();
            lvi.SubItems.Add(sTimestamp);
            lvi.SubItems.Add(sHost);
            lvi.SubItems.Add(sService);
            lvi.SubItems.Add(sStatus);
            lvi.SubItems.Add(sEvent);
            listView_Log.Items.Insert(0, lvi);
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            listView_Log.Items.Clear();

            String file_name = comboBox_LogFile.Text;
            int lines_to_show = Convert.ToInt32(numericUpDown_Lines.Value);

            long chunk_size = 65536;
            long file_offset = 0;
            iControl.SystemConfigSyncFileTransferContext ctx;
            String log_buffer = "";

            System.IO.StringWriter sw = new System.IO.StringWriter();

            if ( file_name.Trim().Length > 0 )
            {
                do
                {
                    ctx = Clients.ConfigSync.download_file(file_name, chunk_size, ref file_offset);
                    //log_buffer = log_buffer + Convert.ToString(ctx.file_data);
                    for (int i = 0; i < ctx.file_data.Length; i++)
                    {
                        sw.Write((char)ctx.file_data[i]);
                    }
                } while (!isEof(ctx));
            }

            // process log buffer
            log_buffer = sw.ToString();
            System.IO.StringReader sr = new System.IO.StringReader(log_buffer);
            int total_lines = 0;
            String sLine = null;
            while (null != (sLine = sr.ReadLine()))
            {
                total_lines++;
            }
            sr.Dispose();

            int start_line = 0;
            if (total_lines > lines_to_show)
            {
                start_line = total_lines - lines_to_show;
            }

            sr = new System.IO.StringReader(log_buffer);
            int cur_line = 0;
            while (null != (sLine = sr.ReadLine()))
            {
                if (cur_line >= start_line)
                {
                    processLine(cur_line, sLine);
                }
                cur_line++;
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LogViewerDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
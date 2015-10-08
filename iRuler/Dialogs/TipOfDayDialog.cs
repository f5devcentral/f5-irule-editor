//===========================================================================
//
// File         : TipOfDayDialog.cs
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
using System.IO;
using System.Windows.Forms;
using iRuler.Utility;

namespace iRuler.Dialogs
{
    public partial class TipOfDayDialog : Form
    {
        private String[] tipList = null;
        private int curIndex = -1;
        Random m_rand = new Random();


        public TipOfDayDialog()
        {
            InitializeComponent();
        }

        private void shuffleList(String[] list)
        {
            for(int i=list.Length; i>1; i--)
            {
                int rand_index = m_rand.Next(0, i-1);
                String tmp = list[rand_index];
                list[rand_index] = list[i-1];
                list[i-1] = tmp;
            }
        }

        private void nextTip(bool bNext)
        {
            if (null != tipList)
            {
                if (bNext)
                {
                    curIndex++;
                    // Next Tip
                    if (curIndex < 0)
                    {
                        curIndex = 0;
                    }
                    else if (curIndex >= tipList.Length)
                    {
                        curIndex = 0;
                    }
                    richTextBox_Tip.Text = tipList[curIndex];
                }
                else
                {
                    curIndex--;
                    // Previous
                    if (curIndex < 0)
                    {
                        curIndex = tipList.Length - 1;
                    }
                    else if (curIndex >= tipList.Length)
                    {
                        curIndex = tipList.Length - 1;
                    }
                    richTextBox_Tip.Text = tipList[curIndex];
                }
            }
        }

        private void TipOfDayDialog_Load(object sender, EventArgs e)
        {
            String sConfigPath = Configuration.getConfigSubDir("Templates");
            String sTipsFile = sConfigPath + "_Tips.txt";

            if (File.Exists(sTipsFile))
            {
                // get the number of lines
                int numLines = 0;
                StreamReader sr = File.OpenText(sTipsFile);
                String input;
                while ((input = sr.ReadLine()) != null)
                {
                    input = input.Trim();
                    if (input.Length > 0)
                    {
                        numLines++;
                    }
                }
                sr.Close();

                curIndex = m_rand.Next(0, numLines - 1);
                tipList = new String[numLines];
                sr = File.OpenText(sTipsFile);
                int i = 0;
                while ((input = sr.ReadLine()) != null)
                {
                    input = input.Trim();
                    if (input.Length > 0)
                    {
                        tipList[i] = input;
                        i++;
                    }
                }
                sr.Close();

                nextTip(true);
            }
        }
        private void button_NextTip_Click(object sender, EventArgs e)
        {
            nextTip(true);
        }
        private void button_PrevTip_Click(object sender, EventArgs e)
        {
            nextTip(false);
        }
        private void TipOfDayDialog_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
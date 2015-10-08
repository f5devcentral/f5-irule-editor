//===========================================================================
//
// File         : Printing.cs
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
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

namespace iRuler.Utility
{
    class Printing
    {
        // HACK
        //private scintilla.ScintillaControl m_editor;
        private scintilla.ScintillaControl m_editor;
        private String m_title;
        bool printDocument(scintilla.ScintillaControl editor, String sTitle)
        {
            bool bStatus = false;
            m_title = sTitle;

            if (null != editor)
            {
                m_editor = editor;
                if (0 == m_editor.Length)
                {
                    MessageBox.Show("Printing an empty document is fairly useless...");
                    return false;
                }

                PrintDocument docToPrint = new PrintDocument();
                docToPrint.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);

                PrintDialog pdlg = new PrintDialog();
                pdlg.Document = docToPrint;

                DialogResult dr = pdlg.ShowDialog(editor);
                if (DialogResult.OK == dr)
                {
                    docToPrint.Print();
                    bStatus = true;
                }

            }
            return bStatus;
        }

        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            ev.Graphics.DrawString(m_title, m_editor.Font, System.Drawing.Brushes.Black, 10, 10);
        }

    }
}

//===========================================================================
//
// File         : SearchInfo.cs
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

namespace iRuler.Utility
{
    public class SearchInfo
    {
        private String m_searchString = "";
        private bool m_matchWholeWord = false;
        private bool m_matchCase = false;
        private bool m_regex = false;
        private bool m_wrapAround = true;
        private bool m_transform = false;
        private bool m_down = true;

        public String searchString
        {
            get { return m_searchString; }
            set { m_searchString = value; }
        }

        public bool matchWholeWord
        {
            get { return m_matchWholeWord; }
            set { m_matchWholeWord = value; }
        }

        public bool matchCase
        {
            get { return m_matchCase; }
            set { m_matchCase = value; }
        }

        public bool regex
        {
            get { return m_regex; }
            set { m_regex = value; }
        }

        public bool wrapAround
        {
            get { return m_wrapAround; }
            set { m_wrapAround = value; }
        }

        public bool transform
        {
            get { return m_transform; }
            set { m_transform = value; }
        }

        public bool down
        {
            get { return m_down; }
            set { m_down = value; }
        }
    }
}

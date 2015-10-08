//===========================================================================
//
// File         : iRuleInfo.cs
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

namespace iRuler.Utility
{
	/// <summary>
	/// Summary description for iRuleInfo.
	/// </summary>
	public class iRuleInfo
	{
        public enum RuleType
        {
            LOCALLB = 0,
            GLOBALLB = 1,
			CONFIG = 2
        };

        public RuleType rule_type = RuleType.LOCALLB;
		public String rule_name = "";
		public String rule_details = "";
		public String original_rule_details = "";
		public bool modified = false;
        public DateTime download_time;

		public iRuleInfo()
		{
            download_time = DateTime.Now;
		}
		public iRuleInfo(String rulename, String ruledetails, bool rulemodified)
		{
			rule_name = rulename;
			rule_details = ruledetails;
			original_rule_details = ruledetails;
			modified = rulemodified;
		}
        public TimeSpan Age()
        {
            return DateTime.Now - download_time;
        }
	}
}

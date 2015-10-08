//===========================================================================
//
// File         : Clients.cs
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
using iRuler;
using iControl;

namespace iRuler.Utility
{
    static class Clients
    {
        private static bool m_bConnected = false;
		private static iControl.Interfaces m_interfaces = new iControl.Interfaces();
		private static iControl.ConnectionInfo m_ci = new iControl.ConnectionInfo();
		private static System.Net.NetworkCredential m_creds = new System.Net.NetworkCredential();

        public static bool Connected
        {
            get { return m_bConnected; }
            set { m_bConnected = value; }
        }
		public static iControl.Interfaces Interfaces
		{
			get { return m_interfaces; }
		}
        public static iControl.LocalLBRule Rule
        {
			get { return m_interfaces.LocalLBRule; }
        }
        public static iControl.LocalLBVirtualServer VirtualServer
        {
			get { return m_interfaces.LocalLBVirtualServer; }
        }
        public static iControl.LocalLBPool Pool
        {
			get { return m_interfaces.LocalLBPool; }
        }
        public static iControl.LocalLBClass Class
        {
			get { return m_interfaces.LocalLBClass; }
        }
        public static iControl.SystemConfigSync ConfigSync
        {
			get { return m_interfaces.SystemConfigSync; }
        }
        public static iControl.SystemSystemInfo SystemInfo
        {
			get { return m_interfaces.SystemSystemInfo; }
        }
        public static iControl.GlobalLBRule GlobalLBRule
        {
			get { return m_interfaces.GlobalLBRule; }
        }
        public static iControl.ConnectionInfo ConnectionInfo
        {
            get { return m_ci; }
        }
        public static System.Net.NetworkCredential Credentials
        {
            get { return m_creds; }
        }

        public static bool initialize()
        {
            try
            {
				System.Net.WebProxy proxy = m_ci.getWebProxy();
				if (null == proxy)
				{
					m_bConnected = m_interfaces.initialize(m_ci.hostname, m_ci.port, m_ci.username, m_ci.password);
				}
				else
				{
					m_bConnected = m_interfaces.initialize(m_ci.hostname, 443, m_ci.username, m_ci.password,
						proxy.Address.Host, proxy.Address.Port, 
						((System.Net.NetworkCredential)proxy.Credentials).UserName,
						((System.Net.NetworkCredential)proxy.Credentials).Password);
				}
            }
            catch (Exception)
            {
                m_bConnected = false;
            }
            return m_bConnected;
        }
    }
}

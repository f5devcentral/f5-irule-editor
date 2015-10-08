//===========================================================================
//
// File         : ConnectionInfo.cs
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
	/// Summary description for ConnectionInfo.
	/// </summary>
	public class ConnectionInfo
	{
        String CONFIG_KEY = "Software\\F5 Networks\\iRuler";
        String ACCOUNTS_KEY = "Software\\F5 Networks\\iRuler\\Accounts";
        
        public String sHostname;
		public String sPort;
		public String sEndpoint;
		public String sUsername;
		public String sPassword;
		public String sHostType;
        public Boolean bGTMLicensed = false;
		public System.Net.NetworkCredential creds;

		public ConnectionInfo()
		{
			//
			// TODO: Add constructor logic here
			//
            creds = new System.Net.NetworkCredential();
		}
		public String buildURL()
		{
			String sURL;
			sURL = "http";
			if ( "443" == sPort ) 
			{
				sURL = sURL + "s";
			}
			sURL = sURL + "://" + sHostname  + ":" + sPort + sEndpoint;
			return sURL;
		}
		public void clear()
		{
			sHostname = "";
			sPort = "";
			sEndpoint = "";
			sUsername = "";
			sPassword = "";
			sHostType = "";
		}

        public void setEndpoint(String hostname, String port, String endpoint)
		{
			sHostname = hostname;
			sPort = port;
			sEndpoint = endpoint;
		}
		public void setCredentials(string username, string password)
		{
			creds.UserName = username;
			creds.Password = password;
            sUsername = username;
            sPassword = password;
        }
		public void setHostType(string hosttype)
		{
			sHostType = hosttype;
		}
        public void setGTMLicensed(bool bLicensed)
        {
            // HACK, really set the value when we are ready to release GTM support.
            bGTMLicensed = bLicensed;
        }
        public bool getGTMLicensed()
        {
            return bGTMLicensed;
        }

        public Boolean isValid()
		{
			Boolean bValid = false;
			if ( (0 != sHostname.Length) && (0 != sPort.Length) &&
				(0 != sEndpoint.Length) &&
				(0 != sUsername.Length) && (0 != sPassword.Length) )
			{
				bValid = false;
			}
			return bValid;
		}
        public void loadFromRegistry()
        {
            loadFromRegistry("");
        }
        public void loadFromRegistry(String sRequestedHostname)
        {
            migrateOldSettings();
            Microsoft.Win32.RegistryKey cu = Microsoft.Win32.Registry.CurrentUser;
            String accountKey = CONFIG_KEY;

            if (sRequestedHostname.Length > 0)
            {
                accountKey = ACCOUNTS_KEY + "\\" + sRequestedHostname;
            }

            Microsoft.Win32.RegistryKey f5Key = cu.OpenSubKey(accountKey);
            if (null != f5Key)
            {
                Object obj = null;
                if (null != (obj = f5Key.GetValue("Hostname")))
                {
                    sHostname = Convert.ToString(obj);
                }
                if (null != (obj = f5Key.GetValue("Port")))
                {
                    sPort = Convert.ToString(obj);
                }
                if (null != (obj = f5Key.GetValue("Username")))
                {
                    sUsername = Convert.ToString(obj);
                }
                f5Key.Close();
            }
        }
        public void saveToRegistry()
        {
            Microsoft.Win32.RegistryKey cu = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey f5Key = cu.CreateSubKey(CONFIG_KEY);
            if (null != f5Key)
            {
                f5Key.SetValue("Hostname", sHostname);
                f5Key.SetValue("Port", sPort);
                f5Key.SetValue("Username", sUsername);
            }
            f5Key.Close();
        }
        public void saveToRegistry(String sHostname)
        {
            Microsoft.Win32.RegistryKey cu = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey f5Key = cu.CreateSubKey(ACCOUNTS_KEY + "\\" + sHostname);
            if (null != f5Key)
            {
                f5Key.SetValue("Hostname", sHostname);
                f5Key.SetValue("Port", sPort);
                f5Key.SetValue("Username", sUsername);
            }
            f5Key.Close();

            setLastAccount(sHostname);
        }

        public String[] getAccounts()
        {
            String [] name_list = null;
            Microsoft.Win32.RegistryKey cu = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey accountsKey = cu.CreateSubKey(ACCOUNTS_KEY);
            if (null != accountsKey)
            {
                name_list = accountsKey.GetSubKeyNames();
            }
            accountsKey.Close();
            return name_list;
        }
        public void clearAccounts()
        {
            Microsoft.Win32.Registry.CurrentUser.DeleteSubKey(ACCOUNTS_KEY);
        }
        public String getLastAccount()
        {
            string sLastAccount = "";
            Microsoft.Win32.RegistryKey cu = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey f5Key = cu.OpenSubKey(CONFIG_KEY);
            if (null != f5Key)
            {
                Object obj = null;
                if (null != (obj = f5Key.GetValue("LastAccount")))
                {
                    sLastAccount = Convert.ToString(obj);
                }
                f5Key.Close();
            }
            return sLastAccount;
        }
        public void setLastAccount(String sHostname)
        {
            Microsoft.Win32.RegistryKey cu = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey f5Key = cu.CreateSubKey(CONFIG_KEY);
            if (null != f5Key)
            {
                f5Key.SetValue("LastAccount", sHostname);
            }
            f5Key.Close();
        }

        public void migrateOldSettings()
        {
            Microsoft.Win32.RegistryKey cu = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey f5Key = cu.CreateSubKey(CONFIG_KEY);
            if (null != f5Key)
            {
                Object obj = null;
                if (null != (obj = f5Key.GetValue("Hostname")))
                {
                    sHostname = Convert.ToString(obj);
                    f5Key.DeleteValue("Hostname");

                    Microsoft.Win32.RegistryKey accountKey = f5Key.CreateSubKey("Accounts\\" + sHostname);
                    if (null != accountKey)
                    {
                        accountKey.SetValue("Hostname", sHostname);

                        // Create account and delete keys
                        if (null != (obj = f5Key.GetValue("Port")))
                        {
                            sPort = Convert.ToString(obj);
                            accountKey.SetValue("Port", sPort);
                            f5Key.DeleteValue("Port");

                        }
                        if (null != (obj = f5Key.GetValue("Username")))
                        {
                            sUsername = Convert.ToString(obj);
                            accountKey.SetValue("Username", sUsername);
                            f5Key.DeleteValue("Username");
                        }
                        accountKey.Close();
                    }
                }
                f5Key.Close();
            }
        }
	}
}

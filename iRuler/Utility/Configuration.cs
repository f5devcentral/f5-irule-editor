//===========================================================================
//
// File         : Configuration.cs
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
using Microsoft.Win32;
using System.Windows.Forms;

namespace iRuler.Utility
{
    static class Configuration
    {
        public static String getTempDir()
        {
            String sTempDir = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) + "\\";
            return sTempDir;
        }
        public static String getConfigDir()
        {
            String sConfigDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            sConfigDir += "\\F5 Networks\\iRuler\\";
            setupDirectory(sConfigDir);
            return sConfigDir;
        }

        public static String getConfigSubDir(String subDir)
        {
            String sPath = getConfigDir() + subDir + "\\";
            setupDirectory(sPath);
            return sPath;
        }

        public static String getConfigFile(String sFile)
        {
            return getConfigDir() + sFile;
        }

        public static void setupDirectory(String sPath)
        {
            if (!System.IO.Directory.Exists(sPath))
            {
                System.IO.Directory.CreateDirectory(sPath);
            }
        }

        public static void LaunchProcess(String sUrl)
        {
			if ((null != sUrl) && (0 != sUrl.Length))
			{
                //if (sUrl.StartsWith("http"))
                //{
                //    LaunchProcess(getDefaultBrowser(), sUrl);
                //}
                //else
                //{
					LaunchProcess(sUrl, "");
				//}
			}
        }

		public static void LaunchProcess(String sProgram, String sArguments)
		{
			if ((null != sProgram) && (0 != sProgram.Length))
			{
				System.Diagnostics.Process proc = new System.Diagnostics.Process();
				proc.StartInfo.FileName = sProgram;
				if (sArguments.Length > 0)
				{
					proc.StartInfo.Arguments = sArguments;
				}
				try
				{
					proc.Start();
				}
				catch (Exception e)
				{
					MessageBox.Show(e.Message.ToString());
				}
			}
		}

        private static string getDefaultBrowser()
        {
            String browser = string.Empty;
            RegistryKey key = null;
            try
            {
				key = Registry.CurrentUser.OpenSubKey(@"Software\Clients\StartMenuInternet", false);
				if (null == key)
				{
					key = Registry.LocalMachine.OpenSubKey(@"Software\Clients\StartMenuInternet", false);
				}
				if (null != key)
				{
					String id = key.GetValue(null).ToString();
					String newkey = @"Software\Clients\StartMenuInternet\" + id + @"\shell\open\command";
					key = Registry.LocalMachine.OpenSubKey(newkey, false);
					if ( null != key )
					{
						//trim off quotes
						browser = key.GetValue(null).ToString().ToLower().Replace("\"", "");
						if (!browser.EndsWith("exe"))
						{
							//get rid of everything after the ".exe"
							browser = browser.Substring(0, browser.LastIndexOf(".exe") + 4);
						}
					}
				}
				else
				{
					key = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);
					if (null != key)
					{
						//trim off quotes
						browser = key.GetValue(null).ToString().ToLower().Replace("\"", "");
						if (!browser.EndsWith("exe"))
						{
							//get rid of everything after the ".exe"
							browser = browser.Substring(0, browser.LastIndexOf(".exe") + 4);
						}
					}
				}
            }
            finally
            {
                if (key != null) key.Close();
            }
            return browser;
        }

        public static String getWebsiteDirectory()
        {
            return "http://devcentral.f5.com/apps/iRuler";
        }
        public static String getWebHelpURL()
        {
            return getWebsiteDirectory() + "/iRuler.htm";
        }

        public static String getShareUrl()
        {
            return "http://devcentral.f5.com/iRuleShare/default.aspx";
        }

        public static void saveLocalFile(String localPath, String contents)
        {
			//System.IO.FileStream fsOut = System.IO.File.Create(localPath);
			//System.IO.StreamWriter sw = new System.IO.StreamWriter(fsOut);
			//sw.Write(contents);
			//sw.Close();
			//fsOut.Close();

            String sNewPath = localPath.Replace("/", "\\").Replace("\\\\", "\\");

            //Walk through directory path and ensure it exists
            System.IO.FileInfo file = new System.IO.FileInfo(sNewPath);
            file.Directory.Create();
            System.IO.File.WriteAllText(file.FullName, contents);
        }

        public static String createTemporaryFile(String fileName, String contents)
        {
            String sFullPath = getTempDir() + fileName;
            saveLocalFile(sFullPath, contents);
            return sFullPath;
        }
    }
}

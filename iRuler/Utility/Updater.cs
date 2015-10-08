//===========================================================================
//
// File         : Updater.cs
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
using System.Windows.Forms;

namespace iRuler.Utility
{
	/// <summary>
	/// Summary description for Updater.
	/// </summary>
	public class Updater
	{
		public iRulerMain m_mainForm = null;

		public Updater()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public String getUpdatesFile()
		{
			String sUpdateFile = "";
			// request the list of templates 
			System.Uri uri = new System.Uri("http://devcentral.f5.com/apps/iRuler/Templates/_Manifest.txt");
			System.Net.WebRequest webRequest = System.Net.WebRequest.Create(uri);
            webRequest.Proxy = System.Net.WebProxy.GetDefaultProxy();

			System.Net.WebResponse webResponse = webRequest.GetResponse();
			System.IO.Stream outStream = webResponse.GetResponseStream();
			System.IO.StreamReader sr = new System.IO.StreamReader(outStream);
			sUpdateFile = sr.ReadToEnd();

			sr.Close();
			outStream.Close();
			return sUpdateFile;
		}

		public bool updatesAvailable(String sUpdatesFile)
		{
			// Make sure Templates directory exists
			bool bUpdateExists = false;

			if ( 0 == sUpdatesFile.Length )
			try
			{
				sUpdatesFile = getUpdatesFile();
			}
			catch(Exception)
			{
				return bUpdateExists;
			}

            String sConfigPath = Configuration.getConfigSubDir("Templates");

			String sLocalFile = readLocalFile(sConfigPath + "_Manifest.txt");
			if ( null == sLocalFile )
			{
				bUpdateExists = true;
			}
			if ( (null != sLocalFile) && (!sLocalFile.Equals(sUpdatesFile)) )
			{
				bUpdateExists = true;
			}

			return bUpdateExists;
		}

        public bool checkForUpdates(bool prompt, bool showstatus)
        {
            bool bUpdated = checkForConfigUpdates(prompt, showstatus);
            launchProgramUpdater();
            return bUpdated;
        }


		public bool checkForConfigUpdates(bool prompt, bool showstatus)
		{
			// Make sure Templates directory exists
			bool bUpdateExists = false;
            bool bUpdated = false;

			try
			{
                // First look for software updates

                // Next look for configuration updates.

				String sConfigPath = Configuration.getConfigSubDir("Templates");
				String sUpdatesFile = getUpdatesFile();
				bUpdateExists = updatesAvailable(sUpdatesFile);
				if ( bUpdateExists )
				{
					DialogResult dr = DialogResult.Yes;
					if ( prompt )
					{
						dr = MessageBox.Show("Configuration updates exist, would you like to download them?", "Configuration Updates Exist", MessageBoxButtons.YesNo);
					}
					if ( System.Windows.Forms.DialogResult.Yes == dr )
					{
						m_mainForm.setStatus("Downloading Updates", m_mainForm.getStatusVisible());

						System.IO.StringReader sr = new System.IO.StringReader(sUpdatesFile);

						// read input
						String strTemplate = null;
						while( null != (strTemplate = sr.ReadLine()) )
						{
                            strTemplate = strTemplate.Trim();
                            String[] sSplit = strTemplate.Split(new char[] { ',' });
                            if (sSplit.Length == 2)
                            {
                                strTemplate = sSplit[0];
                            }

                            // Check for file size
							String sTemplateUri = "http://devcentral.f5.com/apps/iRuler/Templates/" + strTemplate;
							String sContents = downloadFile(sTemplateUri);
							if ( null != sContents )
							{
								String localFile = sConfigPath + strTemplate;
								saveLocalFile(localFile, sContents);
                                bUpdated = true;
								m_mainForm.appendStatus(strTemplate + "...", m_mainForm.getStatusVisible());
							}
						}
						sr.Close();
						m_mainForm.appendStatus("Update Successful!", m_mainForm.getStatusVisible());
					}
				}
				else
				{
					if ( showstatus )
					{
						MessageBox.Show("No configuration updates are available at this time.");
					}
				}
			}
			catch(Exception)
			{
			}
            return bUpdated;
		}

        public void launchProgramUpdater()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetCallingAssembly();
            System.Reflection.Module module = assembly.GetModule("iRuler.exe");
            string updater = System.IO.Path.GetDirectoryName(module.FullyQualifiedName) + "\\iRulerUpdater.exe";

            if (!System.IO.File.Exists(updater))
            {
                updater = updater.Replace("iRulerUpdater.exe", "iRulerUpdater2.exe");
            }

            String sVersion = assembly.GetName().Version.ToString();

            try
            {
                //System.Diagnostics.Process proc = System.Diagnostics.Process.Start(updater);
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = updater;
                proc.StartInfo.Arguments = sVersion;
                proc.Start();
                proc.WaitForExit(300 * 1000);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
            }
        }

		private String downloadFile(String sUrl)
		{
			String strContents = null;
			try
			{
				System.Uri uri = new System.Uri(sUrl);
				System.Net.WebRequest webRequest = System.Net.WebRequest.Create(uri);
                webRequest.Proxy = System.Net.WebProxy.GetDefaultProxy();
				System.Net.WebResponse webResponse = webRequest.GetResponse();
				System.IO.Stream outStream = webResponse.GetResponseStream();
				System.IO.StreamReader sr = new System.IO.StreamReader(outStream);
				strContents = sr.ReadToEnd();
			}
			catch(Exception)
			{
			}
			return strContents;
		}

		private void saveLocalFile(String localPath, String contents)
		{
			System.IO.FileStream fsOut = System.IO.File.Create(localPath);
			System.IO.StreamWriter sw = new System.IO.StreamWriter(fsOut);
			sw.Write(contents);
			sw.Close();
			fsOut.Close();
		}

		private String readLocalFile(String localPath)
		{
			String sContents = null;
			try
			{
				System.IO.StreamReader sr = System.IO.File.OpenText(localPath);
				sContents = sr.ReadToEnd();
				sr.Close();
			}
			catch(Exception)
			{
			}
			return sContents;
		}

	}
}

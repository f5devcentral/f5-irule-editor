//===========================================================================
//
// File         : iRuleInfoDialog.cs
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iRuler.Utility;

namespace iRuler.Dialogs
{
	/// <summary>
	/// Summary description for iRuleInfoDialog.
	/// </summary>
	public partial class iRuleInfoDialog : System.Windows.Forms.Form
	{
		public TreeNode m_tn = null;
		private const int METRIC_CYCLES = 0;
		private const int METRIC_RUNTIME = 1;
		private const int METRIC_CPUUSAGE = 2;
		private const int METRIC_MAX_REQUESTS = 3;

		public iRuleInfoDialog()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		private UInt64 build64(iControl.CommonULong64 ul64)
		{
			return (UInt64)((UInt64)(ul64.high<<32) | (UInt64)ul64.low);
		}

		private void refreshDetails()
		{
			iRuleInfo iri = (iRuleInfo)m_tn.Tag;
			this.Text = "iRule '" + iri.rule_name + "' information";
			label_Name.Text = iri.rule_name;
			label_Lines.Text = getNumLines(iri.rule_details).ToString();
			label_Chars.Text = iri.rule_details.Length.ToString();
		}

        private void refreshStatistics()
        {
            iRuleInfo iri = (iRuleInfo)m_tn.Tag;
            if (null != iri)
            {
                if (iri.rule_type == iRuleInfo.RuleType.GLOBALLB)
                {
                    refreshStatisticsGTM();
                }
                else
                {
                    refreshStatisticsLTM();
                }
            }
        }
		private void refreshStatisticsLTM()
		{
			iRuleInfo iri = (iRuleInfo)m_tn.Tag;
			iControl.LocalLBRuleRuleStatistics stats = Clients.Rule.get_statistics(new string [] {iri.rule_name});

			listView_Statistics.Items.Clear();
			listView_Statistics.Refresh();

			for(int i=0; i<stats.statistics.Length; i++)
			{
				String eventName = "";
				long priority = 0;
				UInt64 aborts = 0;
				UInt64 avg_cycles = 0;
				UInt64 failures = 0;
				UInt64 max_cycles = 0;
				UInt64 min_cycles = 0;
				UInt64 total_executions = 0;

				eventName = stats.statistics[i].event_name;
				priority = stats.statistics[i].priority;
				for(int j=0; j<stats.statistics[i].statistics.Length; j++)
				{
					switch(stats.statistics[i].statistics[j].type)
					{
						case iControl.CommonStatisticType.STATISTIC_RULE_ABORTS:
							aborts = build64(stats.statistics[i].statistics[j].value);
							break;
						case iControl.CommonStatisticType.STATISTIC_RULE_AVERAGE_CYCLES:
							avg_cycles = build64(stats.statistics[i].statistics[j].value);
							break;
						case iControl.CommonStatisticType.STATISTIC_RULE_FAILURES:
							failures = build64(stats.statistics[i].statistics[j].value);
							break;
						case iControl.CommonStatisticType.STATISTIC_RULE_MAXIMUM_CYCLES:
							max_cycles = build64(stats.statistics[i].statistics[j].value);
							break;
						case iControl.CommonStatisticType.STATISTIC_RULE_MINIMUM_CYCLES:
							min_cycles = build64(stats.statistics[i].statistics[j].value);
							break;
						case iControl.CommonStatisticType.STATISTIC_RULE_TOTAL_EXECUTIONS:
							total_executions = build64(stats.statistics[i].statistics[j].value);
							break;
					}
				}
				double dMin = 0;
				double dAvg = 0;
				double dMax = 0;

				String sMin = "";
				String sAvg = "";
				String sMax = "";

				double speedMhz = Convert.ToDouble(textBox_CPUSpeed.Text);
				UInt64 speed = Convert.ToUInt64(1000000 * speedMhz);

				switch (comboBox_Metric.SelectedIndex)
				{
					case METRIC_CYCLES:
						{
							sMin = min_cycles.ToString();
							sAvg = avg_cycles.ToString();
							sMax = max_cycles.ToString();
						}
						break;
					case METRIC_RUNTIME:
						{
							dMin = Convert.ToDouble(min_cycles) * (1000.0 / speed);
							dAvg = Convert.ToDouble(avg_cycles) * (1000.0 / speed);
							dMax = Convert.ToDouble(max_cycles) * (1000.0 / speed);
							sMin = dMin.ToString("N4") + " ms.";
							sAvg = dAvg.ToString("N4") + " ms.";
							sMax = dMax.ToString("N4") + " ms.";
						}
						break;
					case METRIC_CPUUSAGE:
						{
							dMin = 100.0 * (Convert.ToDouble(min_cycles) / Convert.ToDouble(speed));
							dAvg = 100.0 * (Convert.ToDouble(avg_cycles) / Convert.ToDouble(speed));
							dMax = 100.0 * (Convert.ToDouble(max_cycles) / Convert.ToDouble(speed));
							sMin = dMin.ToString("N4") + "%";
							sAvg = dAvg.ToString("N4") + "%";
							sMax = dMax.ToString("N4") + "%";
						}
						break;
					case METRIC_MAX_REQUESTS:
						{
							sMin = "Unknown";
							if (0 != min_cycles)
							{
								//dMin = Convert.ToDouble(speed) / Convert.ToDouble(min_cycles);
								//sMin = dMin.ToString("N2");
								sMin = Convert.ToInt64(speed / min_cycles).ToString();
							}
							sAvg = "Unknown";
							if (0 != avg_cycles)
							{
								//dAvg = Convert.ToDouble(speed) / Convert.ToDouble(avg_cycles);
								//sAvg = dAvg.ToString("N2");
								sAvg = Convert.ToInt64(speed / avg_cycles).ToString();
							}
							sMax = "Uknown";
							if (0 != max_cycles)
							{
								//dMax = Convert.ToDouble(speed) / Convert.ToDouble(max_cycles);
								//sMax = dMax.ToString("N2");
								sMax = Convert.ToInt64(speed / max_cycles).ToString();
							}
						}
						break;

				}

				ListViewItem lvi = new ListViewItem();
				lvi.Text = eventName;
				//lvi.SubItems.Add(eventName);
				lvi.SubItems.Add(priority.ToString());
				lvi.SubItems.Add(total_executions.ToString());
				lvi.SubItems.Add(failures.ToString());
				lvi.SubItems.Add(aborts.ToString());
				lvi.SubItems.Add(sMin);
				lvi.SubItems.Add(sAvg);
				lvi.SubItems.Add(sMax);
				listView_Statistics.Items.Add(lvi);
			}
		}
        private void refreshStatisticsGTM()
        {
            iRuleInfo iri = (iRuleInfo)m_tn.Tag;
            iControl.GlobalLBRuleRuleStatistics stats = Clients.GlobalLBRule.get_statistics(new string[] { iri.rule_name });

            listView_Statistics.Items.Clear();
            listView_Statistics.Refresh();

            for (int i = 0; i < stats.statistics.Length; i++)
            {
                String eventName = "";
                long priority = 0;
                UInt64 aborts = 0;
                UInt64 avg_cycles = 0;
                UInt64 failures = 0;
                UInt64 max_cycles = 0;
                UInt64 min_cycles = 0;
                UInt64 total_executions = 0;

                eventName = stats.statistics[i].event_name;
                priority = stats.statistics[i].priority;
                for (int j = 0; j < stats.statistics[i].statistics.Length; j++)
                {
                    switch (stats.statistics[i].statistics[j].type)
                    {
                        case iControl.CommonStatisticType.STATISTIC_RULE_ABORTS:
                            aborts = build64(stats.statistics[i].statistics[j].value);
                            break;
                        case iControl.CommonStatisticType.STATISTIC_RULE_AVERAGE_CYCLES:
                            avg_cycles = build64(stats.statistics[i].statistics[j].value);
                            break;
                        case iControl.CommonStatisticType.STATISTIC_RULE_FAILURES:
                            failures = build64(stats.statistics[i].statistics[j].value);
                            break;
                        case iControl.CommonStatisticType.STATISTIC_RULE_MAXIMUM_CYCLES:
                            max_cycles = build64(stats.statistics[i].statistics[j].value);
                            break;
                        case iControl.CommonStatisticType.STATISTIC_RULE_MINIMUM_CYCLES:
                            min_cycles = build64(stats.statistics[i].statistics[j].value);
                            break;
                        case iControl.CommonStatisticType.STATISTIC_RULE_TOTAL_EXECUTIONS:
                            total_executions = build64(stats.statistics[i].statistics[j].value);
                            break;
                    }
                }
                ListViewItem lvi = new ListViewItem();
                lvi.Text = eventName;
                //lvi.SubItems.Add(eventName);
                lvi.SubItems.Add(priority.ToString());
                lvi.SubItems.Add(total_executions.ToString());
                lvi.SubItems.Add(failures.ToString());
                lvi.SubItems.Add(aborts.ToString());
                lvi.SubItems.Add(min_cycles.ToString());
				lvi.SubItems.Add(avg_cycles.ToString());
				lvi.SubItems.Add(max_cycles.ToString());
                listView_Statistics.Items.Add(lvi);
            }
        }

        private void refreshMembership()
        {
            iRuleInfo iri = (iRuleInfo)m_tn.Tag;
            if (null != iri)
            {
                if (iri.rule_type == iRuleInfo.RuleType.GLOBALLB)
                {
                    refreshMembershipGTM();
                }
                else
                {
                    refreshMembershipLTM();
                }
            }
        }
        private void refreshMembershipLTM()
		{
            bool bFoundMatch = false;
			String [] vs_list = Clients.VirtualServer.get_list();
			iControl.LocalLBVirtualServerVirtualServerRule [][] rule_lists = Clients.VirtualServer.get_rule(vs_list);

			iRuleInfo iri = (iRuleInfo)m_tn.Tag;

			listBox_VirtualServersUsing.Items.Clear();
            listBox_VirtualServersNotUsing.Items.Clear();
            listBox_VirtualServersUsing.Refresh();
            listBox_VirtualServersNotUsing.Refresh();

            if (vs_list.Length > 0)
            {
                // Loop over virtual servers
                for (int i = 0; i < rule_lists.Length; i++)
                {
                    bFoundMatch = false;
                    for (int j = 0; j < rule_lists[i].Length; j++)
                    {
                        // found a match!
                        if (rule_lists[i][j].rule_name.Equals(iri.rule_name))
                        {
                            listBox_VirtualServersUsing.Items.Add(vs_list[i]);
                            bFoundMatch = true;
                        }
                    }
                    if (!bFoundMatch)
                    {
                        listBox_VirtualServersNotUsing.Items.Add(vs_list[i]);
                    }
                }
            }
            else
            {
                //listBox_VirtualServersUsing.Items.Add("No Virtual Servers Found")
            }

            // search for pools
            listBox_Pools.Items.Clear();
            listBox_Pools.Refresh();
			int matchCount = 0;
			String [] pool_list = Clients.Pool.get_list();
			for(int i=0; i<pool_list.Length; i++)
			{
				if ( -1 != iri.rule_details.IndexOf(pool_list[i]) )
				{
					listBox_Pools.Items.Add(pool_list[i]);
					matchCount++;
				}
			}
			if ( 0 == matchCount )
			{
				listBox_Pools.Items.Add("*None Found*");
			}
		}
        private void refreshMembershipGTM()
        {
            // TODO, add Wideip members code here.
        }
        private void refreshDescription()
        {
            try
            {
    			iRuleInfo iri = (iRuleInfo)m_tn.Tag;
                String [] description_list = Clients.Interfaces.LocalLBRule.get_description(new String[] { iri.rule_name });
                if ((null != description_list) && (null != description_list[0]))
                {
                    textBox_Description.Text = description_list[0];
                }
            }
            catch (Exception)
            {
                label_Description.Visible = false;
                button_ApplyDescription.Visible = false;
                textBox_Description.Visible = false;
            }
        }

		protected long getNumLines(String sInput)
		{
			long lLines = 0;
			char [] cArray = sInput.ToCharArray();
			for(int i=0; i<cArray.Length; i++)
			{
				if ( '\n' == cArray[i] )
				{
					lLines++;
				}
			}
			return lLines;
		}


		private void iRuleInfoDialog_Load(object sender, System.EventArgs e)
		{
			comboBox_Metric.SelectedIndex = 0;
            iRuleInfo iri = (iRuleInfo)m_tn.Tag;
            if (null != iri)
            {
                // HACK, until we insert GTM Wideip Membership code
                if (iri.rule_type == iRuleInfo.RuleType.GLOBALLB)
                {
                    tabPage_Membership_LTM.Hide();
                }
            }
			refreshDetails();
			refreshStatistics();
			refreshMembership();
            refreshDescription();
		}

		private void button_ResetStats_Click(object sender, System.EventArgs e)
		{
			iRuleInfo iri = (iRuleInfo)m_tn.Tag;
			DialogResult dr = MessageBox.Show("Are you sure you want to reset statistics for rule '" + iri.rule_name + "'", "Are you sure?", MessageBoxButtons.YesNo);
			if ( DialogResult.Yes == dr )
			{
				Clients.Rule.reset_statistics(new string[] { iri.rule_name } );
				refreshStatistics();
			}
		}
		private void button_OK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
		private void button_Cancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
		private void button_Refresh_Click(object sender, System.EventArgs e)
		{
			refreshStatistics();
		}
        private void button_RefreshMembership_Click(object sender, EventArgs e)
        {
            refreshMembership();
        }
        private void button_AddVirtual_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ListBox.SelectedIndexCollection selItems = listBox_VirtualServersNotUsing.SelectedIndices;
            if (selItems.Count > 0)
            {
                iControl.LocalLBVirtualServerVirtualServerRule[][] rules = new iControl.LocalLBVirtualServerVirtualServerRule[selItems.Count][];
                String[] vs_list = new String[selItems.Count];
                iRuleInfo iri = (iRuleInfo)m_tn.Tag;

                for (int i = 0; i < selItems.Count; i++)
                {
                    vs_list[i] = listBox_VirtualServersNotUsing.Items[selItems[i]].ToString();
                    rules[i] = new iControl.LocalLBVirtualServerVirtualServerRule[1];
                    rules[i][0] = new iControl.LocalLBVirtualServerVirtualServerRule();
                    rules[i][0].rule_name = iri.rule_name;
                    rules[i][0].priority = 500;

                    // Look for a specified priority in the iRule itself
                    System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("priority\\s+(?<pri>[0-9]+)\\s+");
                    System.Text.RegularExpressions.Match match = regex.Match(iri.rule_details);
                    if ( null != match )
                    {
                        int pri = 500;
                        try
                        {
                            String sPri = match.Groups["pri"].Value;
                            pri = Convert.ToInt32(sPri);
                        }
                        catch(Exception)
                        {
                        }
                        rules[i][0].priority = pri;
                    }

                }

                // Query old iRules for selected VIPs (to look for matching priorities)
                iControl.LocalLBVirtualServerVirtualServerRule[][] existing_rules =
                    Clients.VirtualServer.get_rule(vs_list);

                for (int i = 0; i < vs_list.Length; i++)
                {
                    for (int j = 0; j < existing_rules[i].Length; j++)
                    {
                        if (rules[i][0].priority == existing_rules[i][j].priority)
                        {
                            // Increment it and try again...
                            rules[i][0].priority++;
                            j = -1;
                            continue;
                        }
                    }
                }

                // Apply the iRules to the selected Virtuals
                try
                {
                    Clients.VirtualServer.add_rule(vs_list, rules);
                    for (int i = 0; i < selItems.Count; i++)
                    {
                        listBox_VirtualServersNotUsing.Items.RemoveAt(selItems[i]);
                        listBox_VirtualServersUsing.Items.Add(vs_list[i]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Occurred");
                }
            }
        }
        private void button_RemoveVirtual_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.ListBox.SelectedIndexCollection selItems = listBox_VirtualServersUsing.SelectedIndices;
            if (selItems.Count > 0)
            {
                iControl.LocalLBVirtualServerVirtualServerRule[][] rules = new iControl.LocalLBVirtualServerVirtualServerRule[selItems.Count][];
                String[] vs_list = new String[selItems.Count];
                iRuleInfo iri = (iRuleInfo)m_tn.Tag;

                for (int i = 0; i < selItems.Count; i++)
                {
                    vs_list[i] = listBox_VirtualServersUsing.Items[selItems[i]].ToString();
                    rules[i] = new iControl.LocalLBVirtualServerVirtualServerRule[1];
                    rules[i][0] = new iControl.LocalLBVirtualServerVirtualServerRule();
                    rules[i][0].rule_name = iri.rule_name;
                    rules[i][0].priority = 500;
                }

                try
                {
                    Clients.VirtualServer.remove_rule(vs_list, rules);
                    for (int i = 0; i < selItems.Count; i++)
                    {
                        listBox_VirtualServersUsing.Items.RemoveAt(selItems[i]);
                        listBox_VirtualServersNotUsing.Items.Add(vs_list[i]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Occurred");
                }
            }
        }
        private void listBox_VirtualServersNotUsing_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listBox_VirtualServersUsing_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void iRuleInfoDialog_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            Configuration.LaunchProcess(Configuration.getWebHelpURL() + "#PropertiesDialog");
        }

		private void comboBox_Metric_SelectedIndexChanged(object sender, EventArgs e)
		{
			refreshStatistics();
		}

		private void linkLabel_Guess_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			iControl.SystemSystemInformation sysInfo = Clients.SystemInfo.get_system_information();
			//sysInfo.platform (D63)
			//sysInfo.product_category (6400)
			String speed = "1600.000";

			switch (sysInfo.product_category)
			{
				case "1500":
					speed = "2500.000";  // 2.5 Ghz Celeron
					break;
				case "3400":
					speed = "2800.000";  // 2.8 Ghz Pentium IV
					break;
				case "3410":
					speed = "2800.000";  // 2.8 Ghz Pentium IV
					break;
				case "4100":
					speed = "1600.000";  // Dual 1.6 Ghz Opteron
					break;
				case "6400":
					speed = "1600.000";  // Dual 1.6 Ghz Opteron
					break;
				case "6800":
					speed = "2400.000";  // Dual 2.4 Ghz Opteron
					break;
				case "8400":
					speed = "2600.000";  // Dual 2.6 Ghz Opteron
					break;
				case "8800":
					speed = "2600.000";  // 2x Dual 2.6 Ghz Opteron
					break;
			}
			MessageBox.Show("Your BIG-IP identified itself as being a platform \"" +
				sysInfo.platform + "-" + sysInfo.product_category +
				"\".  We have guessed the CPU speed to be " + speed.ToString() +
				" MHz.\nTo verify the actual value, run \"cat /proc/cpuinfo\" from the BIG-IP shell.");
		}

        private void button_ApplyDescription_Click(object sender, EventArgs e)
        {
            try
            {
                iRuleInfo iri = (iRuleInfo)m_tn.Tag;
                Clients.Interfaces.LocalLBRule.set_description(new String[] { iri.rule_name }, new String[] { textBox_Description.Text });
                m_tn.ToolTipText = textBox_Description.Text;
            }
            catch (Exception)
            {
            }
            button_ApplyDescription.Enabled = false;
        }

        private void textBox_Description_TextChanged(object sender, EventArgs e)
        {
            button_ApplyDescription.Enabled = true;
        }

	}
}

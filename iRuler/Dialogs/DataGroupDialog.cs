//===========================================================================
//
// File         : DataGroupDialog.cs
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
    public partial class DataGroupDialog : Form
    {
        public iControl.LocalLBClassClassType m_type = iControl.LocalLBClassClassType.CLASS_TYPE_UNDEFINED;
        public DialogMode m_mode = DialogMode.DIALOGMODE_UNKNOWN;
        public String m_name;

        public enum DialogMode
        {
            DIALOGMODE_UNKNOWN,
            DIALOGMODE_NEW,
            DIALOGMODE_EDIT
        };

        public Boolean m_bLTMSupportsValues = true;

        public DataGroupDialog()
        {
            InitializeComponent();
        }

        private bool isInteger(String sValue)
        {
            bool bSuccess = false;
            try
            {
                int intval = Convert.ToInt32(sValue);
                bSuccess = true;
            }
            catch (FormatException)
            {
            }
            return bSuccess;
        }
        private String getAddress(String sValue)
        {
            String newValue = null;
            try
            {
                int val = Convert.ToInt32(sValue);
                newValue = val.ToString();
            }
            catch(Exception)
            {
                // First try to convert to an integer.  Want to rule out shorthand notations
                try
                {
                    System.Net.IPAddress addr = System.Net.IPAddress.Parse(sValue);
                    newValue = addr.ToString();
                }
                catch (Exception)
                {
                }
            }
            return newValue;
        }
        private bool isAddress(String sValue)
        {
            bool bSuccess = false;
            // First try to convert to an integer.  Want to rule out shorthand notations
            try
            {
                int val = Convert.ToInt32(sValue);
            }
            catch (Exception)
            {
                // We want this exception!
                bSuccess = true;
                try
                {
                    System.Net.IPAddress addr = System.Net.IPAddress.Parse(sValue);
                    bSuccess = true;
                }
                catch (Exception)
                {
                }
            }
            return bSuccess;
        }

        private void refreshClass()
        {
            if ( (null != Clients.Class) && (DialogMode.DIALOGMODE_EDIT == m_mode) )
            {
                switch (m_type)
                {
                    case iControl.LocalLBClassClassType.CLASS_TYPE_ADDRESS:
                        {
                            iControl.LocalLBClassAddressClass[] class_list = Clients.Class.get_address_class(new String[] { m_name });

                            String[][] class_data_valueAofA = null;
                            try
                            {
                                class_data_valueAofA = Clients.Class.get_address_class_member_data_value(class_list);
                            }
                            catch (Exception)
                            {
                                m_bLTMSupportsValues = false;
                                textBox_DataValue.Visible = false;
                                label_DataValue.Visible = false;
                            }

                            textBox_Name.Text = class_list[0].name;
                            for (int i = 0; i < class_list[0].members.Length; i++)
                            {
                                String sValue = class_list[0].members[i].address;
                                long shorthand = CIDRHelper.getShorthand(class_list[0].members[i].netmask);
                                switch(shorthand)
                                {
                                    case -1:
                                        // Not a CIDR shorthand
                                        sValue = sValue + "/" + class_list[0].members[i].netmask;
                                        break;
                                    case 32:
                                        // full netmask so ignore it
                                        break;
                                    default:
                                        // a valid shorthand so use it.
                                        sValue = sValue + "/" + shorthand.ToString();
                                        break;
                                }
                                /*if (!class_list[0].members[i].netmask.Equals("255.255.255.255"))
                                {
                                    sItem = sItem + "/" + class_list[0].members[i].netmask;
                                }*/

                                String sDataValue = (null != class_data_valueAofA) ? class_data_valueAofA[0][i] : "";
                                //String sItem = sValue;
                                //if (sDataValue.Length > 0) { sItem += " := " + sDataValue; }

                                //listBox_Members.Items.Add(sItem);

                                ListViewItem lvi = new ListViewItem();
                                lvi.Text = sValue;
                                if (0 != sDataValue.Length)
                                {
                                    lvi.SubItems.Add(sDataValue);
                                }
                                listView_Members.Items.Add(lvi);
                            }
                        }
                        break;
                    case iControl.LocalLBClassClassType.CLASS_TYPE_VALUE:
                        {
                            iControl.LocalLBClassValueClass[] class_list = Clients.Class.get_value_class(new String[] { m_name });
                            String[][] class_data_valueAofA = null;
                            try
                            {
                                class_data_valueAofA = Clients.Class.get_value_class_member_data_value(class_list);
                            }
                            catch (Exception)
                            {
                                m_bLTMSupportsValues = false;
                                textBox_DataValue.Visible = false;
                                label_DataValue.Visible = false;
                            }

                            textBox_Name.Text = class_list[0].name;
                            for (int i = 0; i < class_list[0].members.Length; i++)
                            {
                                String sValue = class_list[0].members[i].ToString();
                                String sDataValue = (null != class_data_valueAofA) ? class_data_valueAofA[0][i] : "";
                                //String sItem = sValue;
                                //if (sDataValue.Length > 0) { sItem += " := " + sDataValue; }
                                //listBox_Members.Items.Add(sItem);

                                ListViewItem lvi = new ListViewItem();
                                lvi.Text = sValue;
                                if (0 != sDataValue.Length)
                                {
                                    lvi.SubItems.Add(sDataValue);
                                }
                                listView_Members.Items.Add(lvi);
                            }
                        }
                        break;
                    case iControl.LocalLBClassClassType.CLASS_TYPE_STRING:
                        {
                            iControl.LocalLBClassStringClass[] class_list = Clients.Class.get_string_class(new String[] { m_name });
                            String[][] class_data_valueAofA = null;
                            try
                            {
                                class_data_valueAofA = Clients.Class.get_string_class_member_data_value(class_list);
                            }
                            catch (Exception)
                            {
                                m_bLTMSupportsValues = false;
                                textBox_DataValue.Visible = false;
                                label_DataValue.Visible = false;
                            }

                            textBox_Name.Text = class_list[0].name;
                            for (int i = 0; i < class_list[0].members.Length; i++)
                            {
                                String sValue = class_list[0].members[i];
                                //String sDataValue = class_data_valueAofA[0][i];
                                String sDataValue = (null != class_data_valueAofA) ? class_data_valueAofA[0][i] : "";
                                //String sItem = sValue;
                                //if (sDataValue.Length > 0) { sItem += " := " + sDataValue; }
                                //listBox_Members.Items.Add(sItem);

                                ListViewItem lvi = new ListViewItem();
                                lvi.Text = sValue;
                                if (0 != sDataValue.Length)
                                {
                                    lvi.SubItems.Add(sDataValue);
                                }
                                listView_Members.Items.Add(lvi);
                            }
                        }
                        break;
                }
            }
        }
        private bool createClass()
        {
            bool bCreated = false;
            //int num_members = listBox_Members.Items.Count;
            int num_members = listView_Members.Items.Count;
            String sItem = "";
            switch (m_type)
            {
                case iControl.LocalLBClassClassType.CLASS_TYPE_ADDRESS:
                    {
                        // address/mask := datavalue
                        iControl.LocalLBClassAddressClass [] class_list = new iControl.LocalLBClassAddressClass[1];
                        class_list[0] = new iControl.LocalLBClassAddressClass();
                        class_list[0].name = textBox_Name.Text;
                        class_list[0].members = new iControl.LocalLBClassAddressEntry[num_members];

                        String[][] data_values = new String[1][];
                        data_values[0] = new String[num_members];

                        for (int i = 0; i < num_members; i++)
                        {
                            class_list[0].members[i] = new iControl.LocalLBClassAddressEntry();

                            //String[] tokens = listBox_Members.Items[i].ToString().Split(new String[] { " := " }, StringSplitOptions.RemoveEmptyEntries);
                            //sItem = tokens[0];

                            //String[] sSplit = sItem.Split(new char[] { '/' });

                            //class_list[0].members[i].address = sSplit[0];
                            //class_list[0].members[i].netmask = "255.255.255.255";
                            //if (sSplit.Length > 1)
                            //{
                            //    if (isAddress(sSplit[1]))
                            //    {
                            //        class_list[0].members[i].netmask = sSplit[1];
                            //    }
                            //    else
                            //    {
                            //        class_list[0].members[i].netmask = CIDRHelper.getMask(Convert.ToInt32(sSplit[1]));

                            //    }
                            //}
                            //data_values[0][i] = (tokens.Length > 1) ? tokens[1] : "";

                            sItem = listView_Members.Items[i].Text.ToString();
                            String[] sSplit = sItem.Split(new char[] { '/' });
                            class_list[0].members[i].address = sSplit[0];
                            class_list[0].members[i].netmask = "255.255.255.255";
                            if (sSplit.Length > 1)
                            {
                                if (isAddress(sSplit[1]))
                                {
                                    class_list[0].members[i].netmask = getAddress(sSplit[1]);
                                }
                                else
                                {
                                    class_list[0].members[i].netmask = CIDRHelper.getMask(Convert.ToInt32(sSplit[1]));
                                }
                            }
                            if ( listView_Members.Items[i].SubItems.Count > 1 )
                            {
                                data_values[0][i] = listView_Members.Items[i].SubItems[1].Text.ToString();
                            } 
                            else
                            {
                                data_values[0][i] = "";
                            }

                        }
                        try
                        {
                            Clients.Class.create_address_class(class_list);
                            if (m_bLTMSupportsValues)
                            {
                                Clients.Class.set_address_class_member_data_value(class_list, data_values);
                            }
                            bCreated = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Error");
                        }
                    }
                    break;
                case iControl.LocalLBClassClassType.CLASS_TYPE_VALUE:
                    {
                        iControl.LocalLBClassValueClass[] class_list = new iControl.LocalLBClassValueClass[1];
                        class_list[0] = new iControl.LocalLBClassValueClass();
                        class_list[0].name = textBox_Name.Text;
                        class_list[0].members = new long[num_members];

                        String[][] data_values = new String[1][];
                        data_values[0] = new String[num_members];

                        for (int i = 0; i < num_members; i++)
                        {
                            //String[] tokens = listBox_Members.Items[i].ToString().Split(new String[] { " := " }, StringSplitOptions.RemoveEmptyEntries);
                            //sItem = tokens[0];
                            //class_list[0].members[i] = Convert.ToInt32(sItem);
                            //data_values[0][i] = (tokens.Length > 1) ? tokens[1] : "";

                            class_list[0].members[i] = Convert.ToInt32(listView_Members.Items[i].Text.ToString());
                            if ( listView_Members.Items[i].SubItems.Count > 1 )
                            {
                                data_values[0][i] = listView_Members.Items[i].SubItems[1].Text.ToString();
                            } 
                            else
                            {
                                data_values[0][i] = "";
                            }
                        }
                        try
                        {
                            Clients.Class.create_value_class(class_list);
                            if (m_bLTMSupportsValues)
                            {
                                Clients.Class.set_value_class_member_data_value(class_list, data_values);
                            }
                            bCreated = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Error");
                        }
                    }
                    break;
                case iControl.LocalLBClassClassType.CLASS_TYPE_STRING:
                    {
                        iControl.LocalLBClassStringClass[] class_list = new iControl.LocalLBClassStringClass[1];
                        class_list[0] = new iControl.LocalLBClassStringClass();
                        class_list[0].name = textBox_Name.Text;
                        class_list[0].members = new String[num_members];

                        String[][] data_values = new String[1][];
                        data_values[0] = new String[num_members];

                        for (int i = 0; i < num_members; i++)
                        {
                            //String[] tokens = listBox_Members.Items[i].ToString().Split(new String[] { " := " }, StringSplitOptions.RemoveEmptyEntries);
                            //sItem = tokens[0];
                            //class_list[0].members[i] = sItem;
                            //data_values[0][i] = (tokens.Length > 1) ? tokens[1] : "";

                            class_list[0].members[i] =listView_Members.Items[i].Text.ToString();
                            if ( listView_Members.Items[i].SubItems.Count > 1 )
                            {
                                data_values[0][i] = listView_Members.Items[i].SubItems[1].Text.ToString();
                            } 
                            else
                            {
                                data_values[0][i] = "";
                            }

                        }
                        try
                        {
                            Clients.Class.create_string_class(class_list);
                            Clients.Class.set_string_class_member_data_value(class_list, data_values);
                            bCreated = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Error");
                        }
                    }
                    break;
            }
            if (bCreated)
            {
                try
                {
                    Clients.ConfigSync.save_configuration("", iControl.SystemConfigSyncSaveMode.SAVE_HIGH_LEVEL_CONFIG);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Saving Configuration");
                }
            }
            return bCreated;
        }
        private bool modifyClass()
        {
            // TODO: Add data value support
            bool bModified = false;
            //int num_members = listBox_Members.Items.Count;
            int num_members = listView_Members.Items.Count;
            String sItem = "";
            switch (m_type)
            {
                case iControl.LocalLBClassClassType.CLASS_TYPE_ADDRESS:
                    {
                        iControl.LocalLBClassAddressClass[] class_list = new iControl.LocalLBClassAddressClass[1];
                        class_list[0] = new iControl.LocalLBClassAddressClass();
                        class_list[0].name = textBox_Name.Text;
                        class_list[0].members = new iControl.LocalLBClassAddressEntry[num_members];

                        String[][] data_values = new String[1][];
                        data_values[0] = new String[num_members];

                        for (int i = 0; i < num_members; i++)
                        {
                            //String[] tokens = listBox_Members.Items[i].ToString().Split(new String[] { " := " }, StringSplitOptions.RemoveEmptyEntries);
                            //sItem = tokens[0];
                            ////sItem = listBox_Members.Items[i].ToString();
                            //String[] sSplit = sItem.Split(new char[] { '/' });

                            //class_list[0].members[i] = new iControl.LocalLBClassAddressEntry();
                            //class_list[0].members[i].address = sSplit[0];
                            //class_list[0].members[i].netmask = "255.255.255.255";
                            //if (sSplit.Length > 1)
                            //{
                            //    if (isAddress(sSplit[1]))
                            //    {
                            //        class_list[0].members[i].netmask = sSplit[1];
                            //    }
                            //    else
                            //    {
                            //        class_list[0].members[i].netmask = CIDRHelper.getMask(Convert.ToInt32(sSplit[1]));
                            //    }
                            //}
                            //data_values[0][i] = (tokens.Length > 1) ? tokens[1] : "";

                            sItem = listView_Members.Items[i].Text.ToString();
                            String[] sSplit = sItem.Split(new char[] { '/' });
                            class_list[0].members[i] = new iControl.LocalLBClassAddressEntry();
                            class_list[0].members[i].address = sSplit[0];
                            class_list[0].members[i].netmask = "255.255.255.255";
                            if (sSplit.Length > 1)
                            {
                                if (isAddress(sSplit[1]))
                                {
                                    class_list[0].members[i].netmask = getAddress(sSplit[1]);
                                }
                                else
                                {
                                    class_list[0].members[i].netmask = CIDRHelper.getMask(Convert.ToInt32(sSplit[1]));
                                }
                            }
                            if (listView_Members.Items[i].SubItems.Count > 1)
                            {
                                data_values[0][i] = listView_Members.Items[i].SubItems[1].Text.ToString();
                            }
                            else
                            {
                                data_values[0][i] = "";
                            }
                        }
                        try
                        {
                            //try
                            //{
                            //    Clients.Class.delete_class(new String[] { textBox_Name.Text });
                            //}
                            //catch (Exception) { }

                            //Clients.Class.create_address_class(class_list);
                            Clients.Class.modify_address_class(class_list);
                            if (m_bLTMSupportsValues)
                            {
                                Clients.Class.set_address_class_member_data_value(class_list, data_values);
                            }
                            bModified = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Error");
                        }
                    }
                    break;
                case iControl.LocalLBClassClassType.CLASS_TYPE_VALUE:
                    {
                        iControl.LocalLBClassValueClass[] class_list = new iControl.LocalLBClassValueClass[1];
                        class_list[0] = new iControl.LocalLBClassValueClass();
                        class_list[0].name = textBox_Name.Text;
                        class_list[0].members = new long[num_members];

                        String[][] data_values = new String[1][];
                        data_values[0] = new String[num_members];

                        for (int i = 0; i < num_members; i++)
                        {
                            //String[] tokens = listBox_Members.Items[i].ToString().Split(new String[] { " := " }, StringSplitOptions.RemoveEmptyEntries);
                            //sItem = tokens[0];
                            //class_list[0].members[i] = Convert.ToInt32(sItem);
                            //data_values[0][i] = (tokens.Length > 1) ? tokens[1] : "";

                            class_list[0].members[i] = Convert.ToInt32(listView_Members.Items[i].Text.ToString());
                            if (listView_Members.Items[i].SubItems.Count > 1)
                            {
                                data_values[0][i] = listView_Members.Items[i].SubItems[1].Text.ToString();
                            }
                            else
                            {
                                data_values[0][i] = "";
                            }
                        }
                        try
                        {
                            //Clients.Class.delete_class(new String[] { textBox_Name.Text });
                            //Clients.Class.create_value_class(class_list);
                            Clients.Class.modify_value_class(class_list);
                            if (m_bLTMSupportsValues)
                            {
                                Clients.Class.set_value_class_member_data_value(class_list, data_values);
                            }
                            bModified = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Error");
                        }
                    }
                    break;
                case iControl.LocalLBClassClassType.CLASS_TYPE_STRING:
                    {
                        iControl.LocalLBClassStringClass[] class_list = new iControl.LocalLBClassStringClass[1];
                        class_list[0] = new iControl.LocalLBClassStringClass();
                        class_list[0].name = textBox_Name.Text;
                        class_list[0].members = new String[num_members];

                        String[][] data_values = new String[1][];
                        data_values[0] = new String[num_members];
                        for (int i = 0; i < num_members; i++)
                        {
                            //String[] tokens = listBox_Members.Items[i].ToString().Split(new String[] { " := " }, StringSplitOptions.RemoveEmptyEntries);
                            //sItem = tokens[0];
                            //class_list[0].members[i] = sItem;
                            //data_values[0][i] = (tokens.Length > 1) ? tokens[1] : "";

                            class_list[0].members[i] = listView_Members.Items[i].Text.ToString();
                            if (listView_Members.Items[i].SubItems.Count > 1)
                            {
                                data_values[0][i] = listView_Members.Items[i].SubItems[1].Text.ToString();
                            }
                            else
                            {
                                data_values[0][i] = "";
                            }
                        }
                        try
                        {
                            //Clients.Class.delete_class(new String[] { textBox_Name.Text });
                            //Clients.Class.create_string_class(class_list);
                            Clients.Class.modify_string_class(class_list);
                            if (m_bLTMSupportsValues)
                            {
                                Clients.Class.set_string_class_member_data_value(class_list, data_values);
                            }
                            bModified = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Error");
                        }
                    }
                    break;
            }
            if (bModified)
            {
                try
                {
                    Clients.ConfigSync.save_configuration("", iControl.SystemConfigSyncSaveMode.SAVE_HIGH_LEVEL_CONFIG);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Saving Configuration");
                }
            }
            return bModified;
        }

        private void updateButtons()
        {
            //bool bItemSelected = (-1 != listBox_Members.SelectedIndex);
            bool bItemSelected = (0 != listView_Members.SelectedItems.Count);
            button_Edit.Enabled = bItemSelected;
            button_Delete.Enabled = bItemSelected;

            bItemSelected = (0 != textBox_Value.Text.Length);
            button_Add.Enabled = bItemSelected;

            //bItemSelected = ((0 != textBox_Name.Text.Length) && (0 != listBox_Members.Items.Count));
            bItemSelected = ((0 != textBox_Name.Text.Length) && (0 != listView_Members.Items.Count));
            button_OK.Enabled = bItemSelected;
        }

        private void DataGroupDialog_Load(object sender, EventArgs e)
        {
            switch (m_type)
            {
                case iControl.LocalLBClassClassType.CLASS_TYPE_ADDRESS:
                    label_ItemType.Text = "Address";
                    //textBox_Value.Width = 149;
                    //label_AddressSeparator.Enabled = true;
                    //textBox_Netmask.Enabled = true;
                    label_AddressSeparator.Visible = true;
                    textBox_Netmask.Visible = true;
                    tableLayoutPanel2.ColumnStyles[3].SizeType = SizeType.Percent;
                    tableLayoutPanel2.ColumnStyles[3].Width = 50;

                    break;
                case iControl.LocalLBClassClassType.CLASS_TYPE_STRING:
                    label_ItemType.Text = "String";
                    //textBox_Value.Width = 314;
                    //label_AddressSeparator.Enabled = false;
                    //textBox_Netmask.Enabled = false;
                    label_AddressSeparator.Visible = false;
                    textBox_Netmask.Visible = false;
                    tableLayoutPanel2.ColumnStyles[3].SizeType = SizeType.AutoSize;
                    break;
                case iControl.LocalLBClassClassType.CLASS_TYPE_VALUE:
                    label_ItemType.Text = "Integer";
                    //textBox_Value.Width = 314;
                    //label_AddressSeparator.Enabled = false;
                    //textBox_Netmask.Enabled = false;
                    label_AddressSeparator.Visible = false;
                    textBox_Netmask.Visible = false;
                    tableLayoutPanel2.ColumnStyles[3].SizeType = SizeType.AutoSize;
                    break;
            }

            switch (m_mode)
            {
                case DialogMode.DIALOGMODE_NEW:
                    break;
                case DialogMode.DIALOGMODE_EDIT:
                    textBox_Name.Enabled = false;
                    break;
            }
            refreshClass();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            bool bContinue = true;
            bool bShowMessage = true;
            if (0 != textBox_Value.Text.Length)
            {
                String sItem = textBox_Value.Text;
                switch (m_type)
                {
                    case iControl.LocalLBClassClassType.CLASS_TYPE_ADDRESS:

                        // Check for CIDR format;
                        if (!isAddress(sItem))
                        {
                            MessageBox.Show("'" + textBox_Value.Text + "' is not a valid network address!", "Input Error");
                            bShowMessage = false;
                            textBox_Value.Focus();
                            textBox_Value.SelectAll();
                            bContinue = false;
                        }
                        else
                        {
                            // Valid address, now find out which kind.

                            System.Net.IPAddress ipAddr = System.Net.IPAddress.Parse(sItem);
                            if (ipAddr.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                            {
                                bContinue = false;

                                // IPv6
                                try
                                {
                                    if (textBox_Netmask.Text.Length == 0)
                                    {
                                        bContinue = true;
                                    }
                                    else
                                    {
                                        int v = Convert.ToInt32(textBox_Netmask.Text);
                                        if ((v >= 0) && (v <= 128))
                                        {
                                            sItem = getAddress(sItem) + "/" + textBox_Netmask.Text.ToString();
                                            bContinue = true;
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                    // Toss away exception
                                }
                            }
                            else if ((textBox_Netmask.Text.Length > 0) && 
                                !(textBox_Netmask.Text.Equals("255.255.255.255") || textBox_Netmask.Text.Equals("32")) )
                            {
                                bContinue = false;

                                // IPv4
                                if (isAddress(textBox_Netmask.Text))
                                {
                                    if (CIDRHelper.isValidNetworkAddress(textBox_Value.Text, textBox_Netmask.Text))
                                    {
                                        sItem = getAddress(sItem) + "/" + getAddress(textBox_Netmask.Text);
                                        bContinue = true;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Invalid address and mask.  Address must equal address & mask", "Input error");
                                        bShowMessage = false;
                                        textBox_Value.Focus();
                                        textBox_Value.SelectAll();
                                        bContinue = false;
                                    }
                                }
                                else
                                {
                                    // Check for CIDR foramt.
                                    try
                                    {
                                        int shorthand = Convert.ToInt32(textBox_Netmask.Text);
                                        String sMask = CIDRHelper.getMask(shorthand);

                                        if (null != sMask)
                                        {
                                            if (CIDRHelper.isValidNetworkAddress(textBox_Value.Text, sMask))
                                            {
                                                sItem = getAddress(sItem) + "/" + shorthand.ToString();
                                                bContinue = true;
                                            }
                                            else
                                            {
                                                MessageBox.Show("Invalid address and mask.  Address must equal address & mask", "Input error");
                                                bShowMessage = false;
                                                textBox_Value.Focus();
                                                textBox_Value.SelectAll();
                                                bContinue = false;
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                            }
                            
                            if ( !bContinue )
                            {
                                // Cannot specify both a CIDR and netmask
                                if (bShowMessage)
                                {
                                    MessageBox.Show("'" + textBox_Netmask.Text + "' is not a valid network address or CIDR format!", "Input Error");
                                }
                                bShowMessage = false;
                                textBox_Value.Focus();
                                textBox_Value.SelectAll();
                                bContinue = false;
                            }
                        }



                        break;
                    case iControl.LocalLBClassClassType.CLASS_TYPE_VALUE:
                        if ( !isInteger(sItem) )
                        {
                            MessageBox.Show("'" + textBox_Value.Text + "' is not a valid integer!", "Input Error");
                            bShowMessage = false;
                            textBox_Value.Focus();
                            textBox_Value.SelectAll();
                            bContinue = false;
                        }
                        break;
                    case iControl.LocalLBClassClassType.CLASS_TYPE_STRING:
                        break;
                }

                if (bContinue)
                {
                    // Check for duplicates
                    bool bDuplicate = false;
                    //for(int i=0; i<listBox_Members.Items.Count; i++)
                    for(int i=0; i<listView_Members.Items.Count; i++)
                    {
                        // Extract out the datavalue format
                        // key := datavalue

                        // String sEntry = listBox_Members.Items[i].ToString();
                        //String[] tokens = listBox_Members.Items[i].ToString().Split(new String[] { " := " }, StringSplitOptions.RemoveEmptyEntries);
                        //String sEntry = tokens[0];
                        String sEntry = listView_Members.Items[i].Text.ToString();

                        if (sEntry.Equals(sItem))
                        {
                            bDuplicate = true;
                            break;
                        }
                    }
                    if (bDuplicate)
                    {
                        MessageBox.Show("ERROR: Data Groups cannot contain duplicate entries");
                    }
                    else
                    {
                        // Add support for datavalues.
                        //if (textBox_DataValue.Text.Length > 0)
                        //{
                        //    sItem += " := " + textBox_DataValue.Text;
                        //}

                        //listBox_Members.Items.Add(sItem);
                        //textBox_Value.Text = "";
                        //textBox_Netmask.Text = "";
                        //textBox_Value.Focus();
                        ListViewItem lvi = new ListViewItem(sItem);
                        listView_Members.Items.Add(lvi);
                        if (textBox_DataValue.Text.Length > 0)
                        {
                            lvi.SubItems.Add(textBox_DataValue.Text);
                        }
                    }
                }

                if (m_mode == DialogMode.DIALOGMODE_NEW)
                {
                    button_OK.Text = "Create";
                    switch(m_type)
                    {
                        case iControl.LocalLBClassClassType.CLASS_TYPE_ADDRESS:
                            this.Text = "New Address Data Group";
                            break;
                        case iControl.LocalLBClassClassType.CLASS_TYPE_VALUE:
                            this.Text = "New Integer Data Group";
                            break;
                        case iControl.LocalLBClassClassType.CLASS_TYPE_STRING:
                            this.Text = "New String Data Group";
                            break;
                    }
                }
                else
                {
                    button_OK.Text = "Update";
                    switch (m_type)
                    {
                        case iControl.LocalLBClassClassType.CLASS_TYPE_ADDRESS:
                            this.Text = "Editing Address Data Group";
                            break;
                        case iControl.LocalLBClassClassType.CLASS_TYPE_VALUE:
                            this.Text = "Editing Integer Data Group";
                            break;
                        case iControl.LocalLBClassClassType.CLASS_TYPE_STRING:
                            this.Text = "Editing String Data Group";
                            break;
                    }
                }
            }
        }
        private void button_Edit_Click(object sender, EventArgs e)
        {
            //int index = listBox_Members.SelectedIndex;
            //if (-1 != index)
            //ListView.SelectedIndexCollection indexes = listView_Members.SelectedIndices;
            if (0 != listView_Members.SelectedIndices.Count)
            {
                ListView.SelectedIndexCollection indicies = listView_Members.SelectedIndices;
                int index = indicies[0];

                //String sItem = listBox_Members.Items[index].ToString();
                //String[] tokens = listBox_Members.Items[index].ToString().Split(new String[] { " := " }, StringSplitOptions.RemoveEmptyEntries);
                //String sItem = tokens[0];
                //String sDataValue = (tokens.Length > 1) ? tokens[1] : null;

                String sItem = listView_Members.Items[index].Text.ToString();
                String sDataValue = null;
                if (listView_Members.Items[index].SubItems.Count > 1)
                {
                    sDataValue = listView_Members.Items[index].SubItems[1].Text;
                }

                switch (m_type)
                {
                    case iControl.LocalLBClassClassType.CLASS_TYPE_ADDRESS:
                        String [] sSplit = sItem.Split(new char[] { '/' });
                        textBox_Value.Text = sSplit[0];
                        if (sSplit.Length > 1)
                        {
                            textBox_Netmask.Text = sSplit[1];
                        }
                        break;
                    case iControl.LocalLBClassClassType.CLASS_TYPE_STRING:
                    case iControl.LocalLBClassClassType.CLASS_TYPE_VALUE:
                        textBox_Value.Text = sItem;
                        break;
                }
                if (null != sDataValue)
                {
                    textBox_DataValue.Text = sDataValue;
                }
                //listBox_Members.Items.RemoveAt(index);
                listView_Members.Items.RemoveAt(index);
            }
        }
        private void button_Delete_Click(object sender, EventArgs e)
        {
            //int index = listBox_Members.SelectedIndex;
            //if (-1 != index)
            //{
            //    listBox_Members.Items.RemoveAt(index);
            //}
            if (0 != listView_Members.SelectedIndices.Count)
            {
                ListView.SelectedIndexCollection indicies = listView_Members.SelectedIndices;
                int index = indicies[0];
                listView_Members.Items.RemoveAt(index);
            }

        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            bool bSuccess = false;
            // attempt to update class...
            switch (m_mode)
            {
                case DialogMode.DIALOGMODE_NEW:
                    bSuccess = createClass();
                    break;
                case DialogMode.DIALOGMODE_EDIT:
                    bSuccess = modifyClass();
                    break;
            }
            if (bSuccess)
            {
                this.m_name = textBox_Name.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void DataGroupDialog_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            Configuration.LaunchProcess(Configuration.getWebHelpURL() + "#DataGroupDialog");

        }
        private void DataGroupDialog_Paint(object sender, PaintEventArgs e)
        {
            updateButtons();
        }
        private void listBox_Members_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateButtons();
        }
        private void listView_Members_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateButtons();
        }
        private void textBox_Value_TextChanged(object sender, EventArgs e)
        {
			if (m_type == iControl.LocalLBClassClassType.CLASS_TYPE_ADDRESS)
			{
				// check for shortcut symbol
				if (textBox_Value.Text.EndsWith("/"))
				{
					textBox_Value.Text = textBox_Value.Text.Remove(textBox_Value.Text.Length - 1, 1);
					textBox_Netmask.Focus();
					textBox_Netmask.SelectAll();
				}
			}
            updateButtons();
        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
//===========================================================================
//
// File         : DataGroupsDialog.cs
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
    public partial class DataGroupsDialog : Form
    {
        public DataGroupsDialog()
        {
            InitializeComponent();
        }

        private void refreshClasses()
        {
            if (null != Clients.Class)
            {
                getAddressClasses();
                getIntegerClasses();
                getStringClasses();
            }
        }
        private void getAddressClasses()
        {
            listBox_Address.Items.Clear();
            String [] class_list = Clients.Class.get_address_class_list();
            for (int i = 0; i < class_list.Length; i++)
            {
                listBox_Address.Items.Add(class_list[i]);
            }
        }
        private void getIntegerClasses()
        {
            listBox_Integer.Items.Clear();
            String[] class_list = Clients.Class.get_value_class_list();
            for (int i = 0; i < class_list.Length; i++)
            {
                listBox_Integer.Items.Add(class_list[i]);
            }
        }
        private void getStringClasses()
        {
            listBox_String.Items.Clear();
            String[] class_list = Clients.Class.get_string_class_list();
            for (int i = 0; i < class_list.Length; i++)
            {
                listBox_String.Items.Add(class_list[i]);
            }
        }

        private void addClass(System.Windows.Forms.ListBox lb, iControl.LocalLBClassClassType type)
        {
            DataGroupDialog dlg = new DataGroupDialog();
            dlg.m_type = type;
            dlg.m_mode = DataGroupDialog.DialogMode.DIALOGMODE_NEW;
            DialogResult dr = dlg.ShowDialog();
            if (DialogResult.OK == dr)
            {
                lb.Items.Add(dlg.m_name);
            }
        }
        private void editClass(System.Windows.Forms.ListBox lb, iControl.LocalLBClassClassType type)
        {
            int index = lb.SelectedIndex;
            if (-1 != index)
            {
                DataGroupDialog dlg = new DataGroupDialog();
                dlg.m_type = type;
                dlg.m_name = lb.Items[index].ToString();
                dlg.m_mode = DataGroupDialog.DialogMode.DIALOGMODE_EDIT;
                DialogResult dr = dlg.ShowDialog();
            }
        }
        private void deleteClass(System.Windows.Forms.ListBox lb)
        {
            int index = lb.SelectedIndex;
            if ( -1 != index )
            {
                String sItem = lb.Items[index].ToString();
                DialogResult dr = MessageBox.Show("Are you sure you want to delete the '" + sItem + "' data group?",
                    "Are you sure?", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == dr)
                {
                    try
                    {
                        Clients.Class.delete_class(new String[] { sItem });
                        Clients.ConfigSync.save_configuration("", iControl.SystemConfigSyncSaveMode.SAVE_HIGH_LEVEL_CONFIG);
                        lb.Items.RemoveAt(index);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString(), "Error");
                    }
                }
            }
        }

        private void updateButtons()
        {
            bool bItemSelected = (-1 != listBox_Address.SelectedIndex);
            button_DeleteAddress.Enabled = bItemSelected;
            button_EditAddress.Enabled = bItemSelected;

            bItemSelected = (-1 != listBox_Integer.SelectedIndex);
            button_DeleteInteger.Enabled = bItemSelected;
            button_EditInteger.Enabled = bItemSelected;

            bItemSelected = (-1 != listBox_String.SelectedIndex);
            button_DeleteString.Enabled = bItemSelected;
            button_EditString.Enabled = bItemSelected;
        }


        private void DataGroupsDialog_Load(object sender, EventArgs e)
        {
            refreshClasses();
        }

        private void button_AddAddress_Click(object sender, EventArgs e)
        {
            addClass(listBox_Address, iControl.LocalLBClassClassType.CLASS_TYPE_ADDRESS);
        }
        private void button_EditAddress_Click(object sender, EventArgs e)
        {
            editClass(listBox_Address, iControl.LocalLBClassClassType.CLASS_TYPE_ADDRESS);
        }
        private void button_DeleteAddress_Click(object sender, EventArgs e)
        {
            deleteClass(listBox_Address);
        }

        private void button_AddInteger_Click(object sender, EventArgs e)
        {
            addClass(listBox_Integer, iControl.LocalLBClassClassType.CLASS_TYPE_VALUE);
        }
        private void button_EditInteger_Click(object sender, EventArgs e)
        {
            editClass(listBox_Integer, iControl.LocalLBClassClassType.CLASS_TYPE_VALUE);
        }
        private void button_DeleteInteger_Click(object sender, EventArgs e)
        {
            deleteClass(listBox_Integer);
        }

        private void button_AddString_Click(object sender, EventArgs e)
        {
            addClass(listBox_String, iControl.LocalLBClassClassType.CLASS_TYPE_STRING);
        }
        private void button_EditString_Click(object sender, EventArgs e)
        {
            editClass(listBox_String, iControl.LocalLBClassClassType.CLASS_TYPE_STRING);
        }
        private void button_DeleteString_Click(object sender, EventArgs e)
        {
            deleteClass(listBox_String);
        }

        private void listBox_Address_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateButtons();
        }
        private void listBox_Integer_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateButtons();
        }
        private void listBox_String_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateButtons();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void button_Refresh_Click(object sender, EventArgs e)
        {
            refreshClasses();
        }

        private void DataGroupsDialog_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            Configuration.LaunchProcess(Configuration.getWebHelpURL() + "#DataGroupsDialog");
        }

        private void DataGroupsDialog_Paint(object sender, PaintEventArgs e)
        {
            updateButtons();
        }



    }
}
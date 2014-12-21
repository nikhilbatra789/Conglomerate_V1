using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Conglomerate.Classes;

namespace Conglomerate
{
    public partial class DeleteUser : Form
    {
        Query q = Conglomerate.Properties.Settings.Default.q;
        string prefix;
        public DeleteUser()
        {
            InitializeComponent();

            this.userOltp.SelectedIndexChanged +=
            new System.EventHandler(userOltp_SelectedIndexChanged);
            string activeUser = Conglomerate.Properties.Settings.Default.Gusername;
            string[] prefixarr = activeUser.Split('_');
            prefix = prefixarr[0];
            //userOltp.Items.Add(prefix);
            //userOltp.SelectedIndex = 0;

            int role = q.getrole(activeUser, prefix);
            if (role == 3)
            {
                object[] projectnames = q.getAllProjNames(prefix);
                int i = 0;
                foreach (object[] item in projectnames)
                {
                    if (item[0].ToString() != "ALL")
                    {
                        userOltp.Items.Add(item[0].ToString());
                        i++;
                    }
                }
                foreach (object[] item in projectnames)
                {
                    if (item[0].ToString() != "ALL")
                    {
                        adminOltp.Items.Add(item[0].ToString());
                        i++;
                    }
                }
            }
            else if (role == 1)
            {
                label2.Visible = false;
                adminOltp.Visible = false;
                adminName.Visible = false;
                deladmin.Visible = false;
                object[] projectnames = q.getAllProjNames(prefix);
                int i = 0;
                foreach (object[] item in projectnames)
                {
                    if (item[0].ToString() != "ALL")
                    {
                        userOltp.Items.Add(item[0].ToString());
                        i++;
                    }
                }
            }
        }

        private void DeleteUser_Load(object sender, EventArgs e)
        {

        }

        private void userOltp_SelectedIndexChanged(object sender, EventArgs e)
        {
            userName.Items.Clear();
            Object[] usernames = q.getAllUsers(prefix, userOltp.Text);
            int i = 0;
            foreach (object[] item in usernames)
            {
                if (item[0].ToString() != "ALL")
                {
                   userName.Items.Add(item[0].ToString());
                    i++;
                }
            }
        }

        private void adminOltp_SelectedIndexChanged(object sender, EventArgs e)
        {
            adminName.Items.Clear();
            Object[] usernames = q.getAllAdmins(prefix, adminOltp.Text);
            int i = 0;
            foreach (object[] item in usernames)
            {
                if (item[0].ToString() != "ALL")
                {
                    adminName.Items.Add(item[0].ToString());
                    i++;
                }
            }
        }

        private void deluser_Click(object sender, EventArgs e)
        {
            if (userOltp.Text == "")
            {
                toolTip1.ToolTipTitle = "Oltp of user not selected";
                toolTip1.Show("Select an Oltp of user", userOltp, 5000);
                return;
            }
            else if (userName.Text == "")
            {
                toolTip1.ToolTipTitle = "User Name not selected";
                toolTip1.Show("Select a user to be deleted", userName, 5000);
                return;
            }
            q.deluser(prefix, userName.Text);
            
            MessageBox.Show("User Deleted");

        }

        private void deladmin_Click_1(object sender, EventArgs e)
        {
            if (adminOltp.Text == "")
            {
                toolTip1.ToolTipTitle = "Oltp of admin not selected";
                toolTip1.Show("Select an Oltp of admin", adminOltp, 5000);
                return;
            }

            else if (adminName.Text == "")
            {
                toolTip1.ToolTipTitle = "Admin Name not selected";
                toolTip1.Show("Select an admin to be deleted", adminName, 5000);
                return;
            }
            q.deluser(prefix, adminName.Text);
            MessageBox.Show("Admin Deleted");
        }

    }
}

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
    public partial class SetPassword : Form
    {
        Query q = Conglomerate.Properties.Settings.Default.q;
        General g = new General();
        public string username;

        public SetPassword(string user)
        {
            InitializeComponent();
            username = user;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string[] arr = username.Split('_');
            if (q.checklogin(username,g.GetSHA1HashData(txtOldPassword.Text.Trim()),arr[0]))
            {
                if (txtNewPassword.Text == txtConfirmPassword.Text)
                {
                    string pass = g.GetSHA1HashData(txtNewPassword.Text.Trim());
                   
                    q.ChangeInitialPassword(arr[0],username,pass);
                   
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Your New passwords do not match");
                    txtConfirmPassword.Text = "";
                    txtNewPassword.Text = "";
                }
            }
            else {
                MessageBox.Show("Your Old Password is incorrect");
                txtOldPassword.Text = "";
                txtNewPassword.Text = "";
                txtConfirmPassword.Text = "";
            }
        }
    }
}

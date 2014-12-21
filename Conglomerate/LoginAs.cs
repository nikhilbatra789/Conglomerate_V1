using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Conglomerate.Classes;
using System.Threading;

namespace Conglomerate
{
    public partial class LoginAs : Form
    {
        Query q = Conglomerate.Properties.Settings.Default.q;
        General g = new General();
        public string user;
        public string prefix;
        public LoginAs()
        {
            InitializeComponent();
            user= Conglomerate.Properties.Settings.Default.Gusername;
            string[] prefixarr = user.Split('_');
         prefix = prefixarr[0].ToString();
            object[] projectnames = q.getAllProjNames(prefix);
            int i = 0;
            foreach (object[] item in projectnames)
            {
                if (item[0].ToString() != "ALL")
                {
                comboBox1.Items.Add(item[0].ToString());
                    i++;
                }
            }

            if (comboBox1.Items.Count == 0)
                return;
            g.mustdo();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        public void loadBasicDetails()
        {
            Basic_Details basic = new Basic_Details(user);
            basic.ShowDialog();
        }

        public void loadDBA()
        {
            DBA dba = new DBA();
            dba.ShowDialog();
        }

        public void loadMainbackend()
        {
            MainBackend m = new MainBackend(user);
            m.ShowDialog();
        }

        private void Login()
        {

            string Username = comboBox2.Text;
            string Password = q.getPass(comboBox2.Text,prefix);
        

            string[] arr = Username.Split('_');
            bool b = false;
            //try
            //{
            //    b = q.checklogin(Username, g.GetSHA1HashData(Password.Trim()), arr[0].Trim());
            //}
            //catch
            //{
            //    //MessageBox.Show("Sorry your credentials were wrong. Please try again");
            //    //Password = "";
            //    //Username = "";
            //}
            //if (b)
            //{
            //    if (q.checkFirstLogin(arr[0].Trim(), Username.Trim()))
            //    {
            //        SetPassword pass = new SetPassword(Username);
            //        pass.ShowDialog();
            //    }
                int roleid = q.getrole(Username.Trim(), arr[0].Trim());
                string config = q.checkprojectConfigured(arr[0]);
                if (roleid == 0)
                {
                    Thread tDBA = new Thread(loadDBA);
                    tDBA.Start();
                    this.Close();
                }
                else if (roleid == 1)
                {
                    user = Username.Trim();
                    if (config == "False")
                    {

                        Thread tBasicDetails = new Thread(loadBasicDetails);
                        tBasicDetails.Start();
                    }
                    else
                    {

                        Thread tMainBackend = new Thread(loadMainbackend);
                        tMainBackend.TrySetApartmentState(ApartmentState.STA);
                        tMainBackend.Start();
                    }
                    //Thread.Sleep(2000);
                    try
                    {
                        this.Close();
                    }
                    catch { }
                }
                else if (roleid == 2)
                {
                    user = Username.Trim();
                    if (config == "False")
                    {
                        MessageBox.Show("Sorry Database has not been configured by your Admin. Please try after some time");
                        return;
                    }
                    string OLTPName = q.getOLTPName(q.getProjID(user));
                    FormChoice frm = new FormChoice(user, OLTPName);
                    frm.ShowDialog();

                }
                else if (roleid == 3)
                {
                    user = Username.Trim();
                    Thread tMainBackend = new Thread(loadMainbackend);
                    tMainBackend.Start();
                    try
                    {
                        this.Close();
                    }
                    catch { }
                }
            }
            //else
            //{
            //    MessageBox.Show("Sorry your credentials were wrong. Please try again");
            //    Password = "";
            //    Username = "";
            //}
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string oltpname = comboBox1.Text;
            object[] usersnames = q.getAllOLTPusers(oltpname, prefix);
            foreach (object[] item in usersnames)
            {
                if (item[0].ToString() != user)
                {
                    comboBox2.Items.Add(item[0].ToString());

                
                }
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login();
        }

       
    }
}

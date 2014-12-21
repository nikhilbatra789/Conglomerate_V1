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
    public partial class Home : Form
    {
        delegate void SetCallback(Startup l,int i);
        public string user = "";
        General g = new General();
        
        
        public Home()
        {
            InitializeComponent();
            Load += new EventHandler(ProgramViwer_Load);

            register.Links.Add(0,30,"http://conglomerate.lyrusaviation.com/");            
        }

        private void ProgramViwer_Load(object sender, System.EventArgs e)
        {
            Startup sp = new Startup();
            Thread t = new Thread(()=>start(sp,0));
            t.Start();
            start(sp, 2);
          //  Thread.Sleep(5000);
            start(sp, 1);            
        }
      
        public void start(Startup sp,int i)
        {
            try
            {
                sp.checknetwork(i);
            }
            catch
            {
                if (sp.InvokeRequired)
                {
                    SetCallback d = new SetCallback(start);
                    this.Invoke(d, new object[] { sp, i });
                }

            }
        }

        

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Query q = Conglomerate.Properties.Settings.Default.q;
            string[] arr = txtUsername.Text.Split('_');
            bool b=false;
            try
            {
                b=q.checklogin(txtUsername.Text, g.GetSHA1HashData(txtPassword.Text.Trim()), arr[0].Trim());
            }
            catch
            {
                //MessageBox.Show("Sorry your credentials were wrong. Please try again");
                //txtPassword.Text = "";
                //txtUsername.Text = "";
            }
            if (b)
            {
                
                if (q.checkFirstLogin(arr[0].Trim(),txtUsername.Text.Trim()))
                {                   
                    SetPassword pass = new SetPassword(txtUsername.Text);
                    pass.ShowDialog();
                }
                
                int roleid = q.getrole(txtUsername.Text.Trim(), arr[0].Trim());
                Logs l = new Logs();
                l.createLogEvent(arr[0], txtUsername.Text, "Logged in Successfully", "Login");
                string config = q.checkprojectConfigured(arr[0]);
                if (roleid == 0)
                {
                    Thread tDBA = new Thread(loadDBA);
                    tDBA.Start();
                    this.Close();
                }
                else if (roleid == 1)
                {                    
                    user = txtUsername.Text.Trim();
                    //if (config == "False")
                    //{
                    //    l.createLogEvent(arr[0], txtUsername.Text, "Basic details page opened", "Basic Details");                        
                    //    Thread tBasicDetails = new Thread(loadBasicDetails);
                    //    tBasicDetails.Start();
                    //}
                    //else
                    {
                        l.createLogEvent(arr[0], txtUsername.Text, "Home page opened", "Home"); 
                        Thread tMainBackend = new Thread(loadMainbackend);
                        tMainBackend.TrySetApartmentState(ApartmentState.STA);
                        tMainBackend.Start();
                    }
                    try
                    {
                        this.Close();
                    }
                    catch { }
                }
                else if (roleid == 2)
                {
                    user = txtUsername.Text.Trim();
                    if (config == "False")
                    {
                        MessageBox.Show("Sorry Database has not been configured by your Admin. Please try after some time");
                        return;
                    }
                    string OLTPName=q.getOLTPName(q.getProjID(user));
                    l.createLogEvent(arr[0], txtUsername.Text, "Form choice page opened", "Form Choice"); 
                    Thread tFormChoice = new Thread(()=>loadformChoice(user,OLTPName));
                    tFormChoice.Start();
                    try
                    {
                        this.Close();
                    }
                    catch { }
                 }
                else if(roleid==3)
                {
                    user = txtUsername.Text.Trim();
                    l.createLogEvent(arr[0], txtUsername.Text, "Home page opened(Super Admin)", "Home"); 
                    Thread tMainBackend = new Thread(loadMainbackend);
                    tMainBackend.Start();
                    try
                    {
                        this.Close();
                    }
                    catch { }
                }
            }
            else
            {
                MessageBox.Show("Sorry your credentials were wrong. Please try again");
                txtPassword.Text = "";
                txtUsername.Text = "";
            }
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

        public void loadformChoice(string user,string OLTPName)
        {
            FormChoice frm = new FormChoice(user, OLTPName);
            frm.ShowDialog();
        }

        private void register_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://conglomerate.lyrusaviation.com/");
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Thread t = new Thread(loadForgotPassword);
            t.Start();
            
        }

        public void loadForgotPassword()
        {
            ForgotPassword fgt = new ForgotPassword();
            fgt.ShowDialog();
            //this.Visible = true;
        }

        
    }
}

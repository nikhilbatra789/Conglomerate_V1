using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Conglomerate.Classes;

namespace Conglomerate
{
    public partial class MainBackend : Form
    {
        delegate void SetCallback(Table_Details tbd);

        Query q = Conglomerate.Properties.Settings.Default.q;
        General g = new General();
        Logs l=new Logs();
        public string username="",prefix="";
        
        public MainBackend(string username)
        {          
           
            InitializeComponent();
            Conglomerate.Properties.Settings.Default.Gusername = username;
            Conglomerate.Properties.Settings.Default.Save();
            label1.Text = "Welcome "+username;
            this.WindowState=FormWindowState.Maximized;
            this.DefineOLTP.Click+=new EventHandler(button1_Click_1);
            int height = panel1.Height;
            string[] prefixarr = username.Split('_');
            prefix = prefixarr[0];
            object[] Projarr = q.getProjID(username, prefix);
            int role = q.getrole(username, prefix);
            label3.Text = prefixarr[0].ToString();
            if (role == 1)
                label2.Text = "(Admin)";
            else if (role == 3)
                label2.Text = "(SuperAdmin)";

            Conglomerate.Properties.Settings.Default.ProjName = Projarr[0].ToString();
            Conglomerate.Properties.Settings.Default.Save();
            ///////////////////////////////////////////////////////////
            ////////////            Logs               ////////////////
            ///////////////////////////////////////////////////////////

            loadLogs(username);

            ///////////////////////////////////////////////////////////
            //////////           Components               /////////////
            ///////////////////////////////////////////////////////////
            if (role == 1)
            {
                LoginAs.Visible = false;
                LoginAs.Enabled = false;
                OLTPSettings.Visible = true;
                loginAsStripMenuItem.Enabled = false;
                if (q.isOLTPConfigured(Projarr[0].ToString()))
                {
                    DefineOLTP.Enabled = false;
                    defineOLTPToolStripMenuItem.Enabled = false;
                }
                else
                {
                    AddUser.Enabled = false;
                    OLTPSettings.Enabled = false;
                    ViewTables.Enabled = false;
                    userToolStripMenuItem.Enabled = false;
                    oLTPToolStripMenuItem.Enabled = false;
                                       
                    
                    string initializestring = "Your OLTP has not been defined. In order to use full functionality as Admin please first define your OLTP";
                    g.mustdo();
                    OpeningForm tbd = new OpeningForm(initializestring);
                    int hieght = panel1.Height;
                    tbd.Height = hieght;
                    tbd.Width = panel1.Width;
                    tbd.TopLevel = false;
                    tbd.Visible = true;
                    panel1.Controls.Add(tbd);
                }

            }
            if (role == 3)
            {
                DefineOLTP.Enabled = false;
                LoginAs.Visible = true;
                OLTPSettings.Visible = false;
                OLTPSettings.Enabled = false;
                settingsToolStripMenuItem.Enabled = false;
                defineOLTPToolStripMenuItem.Enabled = false;
                delOLTPToolStripMenuItem.Enabled = false;
            }


            starttimer();

            

        }

        private void loadLogs(string username)
        {
            TextBox tb1 = new TextBox();
            tb1.Text = "Action";
            tb1.Location = new Point(5, 5);
            tb1.Enabled = false;
            tb1.Size = new Size(850, 10);
            tb1.TextAlign = HorizontalAlignment.Center;
            panel2.Controls.Add(tb1);

            TextBox tb2 = new TextBox();
            tb2.Text = "Page";
            tb2.Location = new Point(855, 5);
            tb2.Enabled = false;
            tb2.Size = new Size(100, 10);
            tb2.TextAlign = HorizontalAlignment.Center;
            panel2.Controls.Add(tb2);

            TextBox tb3 = new TextBox();
            tb3.Text = "Date Time";
            tb3.Location = new Point(955, 5);
            tb3.Enabled = false;
            tb3.Size = new Size(120, 10);
            tb3.TextAlign = HorizontalAlignment.Center;
            panel2.Controls.Add(tb3);

            DataTable dt = q.getTopIndivisualLogs(username);
            for(int i=0;i<2;i++)            
            {
                    TextBox tb4 = new TextBox();
                    tb4.Text = dt.Rows[i].ItemArray[0].ToString();
                    tb4.Location = new Point(5, 24+(i*17));
                    tb4.Enabled = false;
                    tb4.Size = new Size(850, 10);
                    panel2.Controls.Add(tb4);

                    TextBox tb5 = new TextBox();
                    tb5.Text = dt.Rows[i].ItemArray[1].ToString();
                    tb5.Location = new Point(855, 24 + (i * 17));
                    tb5.Enabled = false;
                    tb5.Size = new Size(100, 10);
                    panel2.Controls.Add(tb5);

                    TextBox tb6 = new TextBox();
                    tb6.Text = dt.Rows[i].ItemArray[2].ToString();
                    tb6.Location = new Point(955, 24 + (i * 17));
                    tb6.Enabled = false;
                    tb6.Size = new Size(120, 10);
                    panel2.Controls.Add(tb6);
             }
            panel2.Refresh();

        }

        public double intervalValue;

        public void starttimer()
        {
            string OLTPName = Conglomerate.Properties.Settings.Default.ProjName;
            System.Timers.Timer myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(CleanStart);

            string user = Conglomerate.Properties.Settings.Default.Gusername;
            string[] prefix = user.Split('_');
            int role = q.getrole(user, prefix[0]);
            if (role != 3)
            {
                string[] settings=new string[]{};
                try
                {
                    settings = q.getOLTPSetting(prefix[0] + "_" + OLTPName + "Setting");
                }
                catch
                {
                    return;
                }
                if (settings[6] == "0")
                    return;

                string[] obj = q.getTimerInfo(OLTPName);
                intervalValue = Convert.ToDouble(obj[0]);
                TimeSpan ts = (DateTime.Now - DateTime.Now);
                if (obj[1] == "")
                {
                    myTimer.Interval = Convert.ToDouble(obj[0]);
                    q.setLastTimer(OLTPName);
                }
                else
                {
                    ts = (DateTime.Now) - Convert.ToDateTime(obj[1]);
                    if (ts.TotalMilliseconds > Convert.ToDouble(obj[0]))
                    {
                        myTimer.Interval = 1;
                    }
                    else
                    {
                        myTimer.Interval = intervalValue - ts.TotalMilliseconds;
                    }
                }


                myTimer.Start();
            }
        }

        void CleanStart(object sender, System.Timers.ElapsedEventArgs e)
        {
            string OLTPName = Conglomerate.Properties.Settings.Default.ProjName;
            ((System.Timers.Timer)sender).Stop();
            //Console.WriteLine(DateTime.Now.ToString("HH.mm.ss"));
            Cleansing cl = new Cleansing();
            cl.shiftData();
            GC.Collect();
            string[] obj = q.getTimerInfo(OLTPName);
            intervalValue = Convert.ToDouble(obj[0]);
            ((System.Timers.Timer)sender).Interval = intervalValue;
            q.setLastTimer(OLTPName);
            ((System.Timers.Timer)sender).Start();
        }       
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            loadDefineOLTP();
        }

        private void loadDefineOLTP()
        {
            string username=Conglomerate.Properties.Settings.Default.Gusername;
            l.createLogEvent(prefix,username, "Initialized defination of OLTP", "Define OLTP");
            g.mustdo();
            DefineOLTP tbd = new DefineOLTP();
            int hieght = panel1.Height;
            tbd.Height = hieght;
            tbd.Width = panel1.Width;
            tbd.TopLevel = false;
            tbd.Visible = true;
            panel1.Controls.Add(tbd);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            loadAddUser();
            
        }

        private void loadAddUser()
        {
            string username = Conglomerate.Properties.Settings.Default.Gusername;
            l.createLogEvent(prefix, username, "Add User Page opened", "Add User");
            g.mustdo();
            Add_User db = new Add_User();
            int hieght = panel1.Height;
            db.Height = hieght;
            db.Width = panel1.Width;
            db.TopLevel = false;
            db.Visible = true;
            panel1.Controls.Add(db);
        }            

        private void button3_Click(object sender, EventArgs e)
        {
            loadViewLogs();
        }

        private void loadViewLogs()
        {
            string username = Conglomerate.Properties.Settings.Default.Gusername;
            l.createLogEvent(prefix, username, "Page opened for viewing logs", "View Logs");
            g.mustdo();
            ViewLogs tbd = new ViewLogs();
            int hieght = panel1.Height;
            tbd.Height = hieght;
            tbd.Width = panel1.Width;
            tbd.TopLevel = false;
            tbd.Visible = true;
            panel1.Controls.Add(tbd);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadOLTPSettings();
        }

        private void loadOLTPSettings()
        {
            string username = Conglomerate.Properties.Settings.Default.Gusername;
            l.createLogEvent(prefix, username, "OLTP Settings Page opened", "OLTP Settings");
            g.mustdo();
            OLTPSettings tbd = new OLTPSettings();
            int hieght = panel1.Height;
            tbd.Height = hieght;
            tbd.Width = panel1.Width;
            tbd.TopLevel = false;
            tbd.Visible = true;
            panel1.Controls.Add(tbd);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadViewTables();
        }

        private void loadViewTables()
        {
            string username = Conglomerate.Properties.Settings.Default.Gusername;
            l.createLogEvent(prefix, username, "View Tables Page opened", "View Tables");
            g.mustdo();
            ViewTables tbd = new ViewTables();
            int hieght = panel1.Height;
            tbd.Height = hieght;
            tbd.Width = panel1.Width;
            tbd.TopLevel = false;
            tbd.Visible = true;
            panel1.Controls.Add(tbd);
        }

        private void loToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Logoff from the application. Please save your data before Logoff otherwise there might be loss of some data.", "Conglomerate: Application Logoff", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string username = Conglomerate.Properties.Settings.Default.Gusername;
                l.createLogEvent(prefix, username, "User logged of successfully ", "Home");
                this.Close();
                Thread t = new Thread(loadHome);
                t.Start();
            }            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit the application. Please save your data before exit otherwise there might be loss of some data.", "Conglomerate: Application Exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string username = Conglomerate.Properties.Settings.Default.Gusername;
                l.createLogEvent(prefix, username, "User Closed the application successfully", "Home");
                Application.Exit();
            }            
        }

        public void loadHome()
        {
            Query q = new Query();
            Conglomerate.Properties.Settings.Default.q = q;
            Application.Run(new Home());
        }

        private void LoginAs_Click(object sender, EventArgs e)
        {
            loadLoginAs();
        }

        private void loadLoginAs()
        {
            string username = Conglomerate.Properties.Settings.Default.Gusername;
            l.createLogEvent(prefix, username, "Login As Page opened", "Login As");
            g.mustdo();
            LoginAs tbd = new LoginAs();
            int hieght = panel1.Height;
            tbd.Height = hieght;
            tbd.Width = panel1.Width;
            tbd.TopLevel = false;
            tbd.Visible = true;
            panel1.Controls.Add(tbd);
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadAddUser();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string username = Conglomerate.Properties.Settings.Default.Gusername;
            l.createLogEvent(prefix, username, "Delete User Page opened", "Delete User");
            g.mustdo();
            DeleteUser tbd = new DeleteUser();
            int hieght = panel1.Height;
            tbd.Height = hieght;
            tbd.Width = panel1.Width;
            tbd.TopLevel = false;
            tbd.Visible = true;
            panel1.Controls.Add(tbd);
        }

        private void defineOLTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadDefineOLTP();
        }

        private void delOLTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string username = Conglomerate.Properties.Settings.Default.Gusername;
            l.createLogEvent(prefix, username, "Delete OLTP page opened", "Delete OLTP");
            g.mustdo();
            DeleteOLTP tbd = new DeleteOLTP();
            int hieght = panel1.Height;
            tbd.Height = hieght;
            tbd.Width = panel1.Width;
            tbd.TopLevel = false;
            tbd.Visible = true;
            panel1.Controls.Add(tbd);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadOLTPSettings();
        }

        private void viewTablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadViewTables();
        }

        private void executeQueryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string username = Conglomerate.Properties.Settings.Default.Gusername;
            l.createLogEvent(prefix, username, "Execute Query Page Opened", "Execute Query");
            g.mustdo();
            ExecuteQuery tbd = new ExecuteQuery();
            int hieght = panel1.Height;
            tbd.Height = hieght;
            tbd.Width = panel1.Width;
            tbd.TopLevel = false;
            tbd.Visible = true;
            panel1.Controls.Add(tbd);
        }

        private void loginAsStripMenuItem_Click(object sender, EventArgs e)
        {
            loadLoginAs();
        }

        private void changePasswordtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            string username = Conglomerate.Properties.Settings.Default.Gusername;
            l.createLogEvent(prefix, username, "Change Password Page opened", "Change Password");
            g.mustdo();
            SetPassword tbd = new SetPassword(username);
            int hieght = panel1.Height;
            tbd.Height = hieght;
            tbd.Width = panel1.Width;
            tbd.TopLevel = false;
            tbd.Visible = true;
            panel1.Controls.Add(tbd);
        }

        private void viewLogstoolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadViewLogs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = Conglomerate.Properties.Settings.Default.Gusername;
            loadLogs(user);
        }

        
    }
}

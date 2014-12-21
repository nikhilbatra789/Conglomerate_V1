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
    public partial class OLTPSettings : Form
    {
        Query q = Conglomerate.Properties.Settings.Default.q;
        string OLTPName = "OLTPName";//Conglomerate.Properties.Settings.Default.ProjName;
        public string tablename;
        string CmpPrefix;
        public OLTPSettings()
        {
            InitializeComponent();

            //string OLTPName = "OLTPName";//Conglomerate.Properties.Settings.Default.ProjName;
            string Username = "ABC_Anchit";//Conglomerate.Properties.Settings.Default.ProjName;
            string[] temp = Username.Split('_');
            CmpPrefix = temp[0];
            tablename =CmpPrefix+"_"+ OLTPName + "Setting";

            if (q.CheckTableExsists(tablename))
            {
                label2.Visible = false;
                label3.Visible = false;
                tabControl1.Visible = true;
            }
            else
            {
                label2.Visible = true;
                label3.Visible = true;
                tabControl1.Visible = false;
                return;
            }

            string[] settings = q.getOLTPSetting(tablename);
            if (settings[0] == "1")
            {
                CamelOn.Checked = true;
                CamelOff.Checked=false;
            }
            else
            {
                CamelOn.Checked = false;
                CamelOff.Checked = true;
            }
            if (settings[1] == "1")
            {
                SpaceOn.Checked = true;
                SpaceOff.Checked = false;
            }
            else
            {
                SpaceOff.Checked = true;
                SpaceOn.Checked = false;
            }
            if (settings[2] == "1")
            {
                TitlesOn.Checked = true;
                TitlesOFF.Checked = false;
            }
            else
            {
                TitlesOn.Checked = false;
                TitlesOFF.Checked = true;
            }
            if (settings[4] == "1")
            {
                AbbOn.Checked = true;
                AbbOff.Checked = false;
            }
            else
            {
                AbbOn.Checked = false;
                AbbOff.Checked = true;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int val;
            if(CamelOn.Checked==true)
                val=1;
            else val=0;
            q.setRecord(tablename,"CamelCase",val.ToString());
            MessageBox.Show("Camel Case Setting Saved");
        }

        private void SpaceSave_Click(object sender, EventArgs e)
        {
            int val;
            if (SpaceOn.Checked == true)
                val = 1;
            else val = 0;
            q.setRecord(tablename, "Spaces", val.ToString());
            MessageBox.Show("Multiple Space Setting Saved");
        }

        private void TitlesSave_Click(object sender, EventArgs e)
        {
            int val;
            if (TitlesOn.Checked == true)
                val = 1;
            else val = 0;
            q.setRecord(tablename, "Titles", val.ToString());
            MessageBox.Show("Titles Setting Saved");
        }

        private void btnTimerStop_Click(object sender, EventArgs e)
        {
            if (q.setRecord(tablename, "Timer", "0"))
                MessageBox.Show("Timer has been stopped");
            else
                MessageBox.Show("Timer failed to stop");
        }

        private void btnTimerStart_Click(object sender, EventArgs e)
        {
            if (q.setRecord(tablename, "Timer", "1"))
            {
                starttimer();
                MessageBox.Show("Timer has been Started");
            }
            else
            {
                MessageBox.Show("Timer failed to Start");
            }

        }

        public double intervalValue;
        public void starttimer()
        {
            string OLTPName = Conglomerate.Properties.Settings.Default.ProjName;
            System.Timers.Timer myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new System.Timers.ElapsedEventHandler(CleanStart);

           
            string[] settings = q.getOLTPSetting(CmpPrefix + "_" + OLTPName + "Setting");
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

        void CleanStart(object sender, System.Timers.ElapsedEventArgs e)
        {
            string OLTPName = Conglomerate.Properties.Settings.Default.ProjName;
            ((System.Timers.Timer)sender).Stop();
            //Console.WriteLine(DateTime.Now.ToString("HH.mm.ss"));
            Cleansing cl = new Cleansing();
            cl.shiftData();
            GC.Collect();
            ((System.Timers.Timer)sender).Interval = intervalValue;
            q.setLastTimer(OLTPName);
            ((System.Timers.Timer)sender).Start();
        }

        private void btnTimerReset_Click(object sender, EventArgs e)
        {
            if (q.resetTimer(OLTPName))
            {
                MessageBox.Show("Timer has been reset");

            }
            else
            {
                MessageBox.Show("Timer failed to reset");
            }
        }

        private void btnSaveAbb_Click(object sender, EventArgs e)
        {
            int val;
            if (AbbOn.Checked == true)
                val = 1;
            else val = 0;
            q.setRecord(tablename, "Abbreviation", val.ToString());
            MessageBox.Show("Abbreviation Setting Saved");
        }

        private void btnChangeinterval_Click(object sender, EventArgs e)
        {
            if (q.changeinterval(OLTPName, txtInterval.Text.Trim()))
            {
                MessageBox.Show("Interval has been succesfully changed");
            }
            else
            {
                MessageBox.Show("Interval Failed to Change");
            }
        }

        private void btnTitlesAdvancedSettings_Click(object sender, EventArgs e)
        {
            TitlesAdvancedSettings TAS = new TitlesAdvancedSettings();
            TAS.ShowDialog();
        }

        private void btnAbbAdvancedSettings_Click(object sender, EventArgs e)
        {
            AbbAdvancedSettings AAS = new AbbAdvancedSettings();
            AAS.ShowDialog();
        }

       



        

        
    }
}

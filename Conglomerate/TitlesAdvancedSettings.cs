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
    public partial class TitlesAdvancedSettings : Form
    {

        Query q = Conglomerate.Properties.Settings.Default.q;
        string OLTPName = "OLTPName";//Conglomerate.Properties.Settings.Default.ProjName;
        public string Username = "ABC_Anchit";//Conglomerate.Properties.Settings.Default.ProjName;
        public string tablename;
        public string CmpPrefix;
        public string[] settings;
        string[] keyvalue;
        public TitlesAdvancedSettings()
        {
            InitializeComponent();
            string[] temp = Username.Split('_');
            CmpPrefix = temp[0];
            tablename = CmpPrefix + "_" + OLTPName + "Setting";
            Initialize();
        }

        private void Initialize()
        {
            cmbTitles.Items.Clear();
            settings = q.getOLTPSetting(tablename);
            keyvalue = settings[3].Split('@');
            cmbTitles.Items.AddRange(keyvalue);
            cmbTitles.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < keyvalue.Length; i++)
            {
                if (keyvalue[i] == cmbTitles.Text)
                {
                    if (keyvalue.Length > 1)
                    {
                        keyvalue[i] = null;
                    }
                    else
                    {
                        MessageBox.Show("There is only one value in the Titles List. It cannot be deleted");
                        return;
                    }
                }

            }


            List<string> lis1 = keyvalue.ToList<string>();
            lis1.RemoveAll(p => string.IsNullOrEmpty(p));
            keyvalue = lis1.ToArray();

            string newKeyValues = String.Join("@", keyvalue);
            if (q.setRecord(tablename, "TitleValue", newKeyValues))
            {
                MessageBox.Show("Title Deleted succesfully");
            }
            Initialize();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            settings[3] += "@" + textBox1.Text+" ";
            if (q.setRecord(tablename, "TitleValue", settings[3]))
            {
                MessageBox.Show("Abbreviation Added successfully");
            }
            else
            {
                MessageBox.Show("Abbreviation could not be Added due to some error");
            }
            textBox1.Text = "";
            Initialize();
        }
    }
}

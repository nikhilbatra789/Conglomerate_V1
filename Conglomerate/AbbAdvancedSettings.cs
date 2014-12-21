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
    public partial class AbbAdvancedSettings : Form
    {

        Query q=Conglomerate.Properties.Settings.Default.q;
        Logs l = new Logs();
        string OLTPName = Conglomerate.Properties.Settings.Default.ProjName;
        public string Username = Conglomerate.Properties.Settings.Default.Gusername;
        public string tablename;
        public string CmpPrefix;
        public string[] settings;
        string[] keyvalue;

        public AbbAdvancedSettings()
        {
            InitializeComponent();
            string[] temp = Username.Split('_');
            CmpPrefix = temp[0];
            tablename = CmpPrefix + "_" + OLTPName + "Setting";
            Initialize();

        }

        private void Initialize()
        {
            comboBox4.Items.Clear();
            settings = q.getOLTPSetting(tablename);
            keyvalue = settings[5].Split('@');
            comboBox4.Items.AddRange(keyvalue);
            comboBox4.SelectedIndex = 0;
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < keyvalue.Length; i++)
            {
                if (keyvalue[i] == comboBox4.Text )
                {
                    if (keyvalue.Length > 1)
                    {
                        keyvalue[i] = null;
                    }
                    else
                    {
                        MessageBox.Show("There is only one value in the Abbreviation List. It cannot be deleted");
                        return;
                    }
                }
               
            }
            

            List<string> lis1 = keyvalue.ToList<string>();
            lis1.RemoveAll(p => string.IsNullOrEmpty(p));
            keyvalue = lis1.ToArray();

            string newKeyValues = String.Join("@",keyvalue);
            if (q.setRecord(tablename, "AbbreviationValue", newKeyValues))
            {
                l.createLogEvent(CmpPrefix, Username, "Abbreviation deleted successfully: " + comboBox4.Text, "Abbreviation Advanced Settings");
                MessageBox.Show("Abbreviation Deleted succesfully");
            }
            Initialize();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            settings[5] += "@" + textBox1.Text + "," + textBox2.Text;
            if (q.setRecord(tablename, "AbbreviationValue", settings[5]))
            {
                l.createLogEvent(CmpPrefix, Username, "Abbreviation added successfully: "+textBox1.Text + "," + textBox2.Text,"Abbreviation Advanced Settings");
                MessageBox.Show("Abbreviation Added successfully");
            }
            else
            {
                MessageBox.Show("Abbreviation could not be Added due to some error");
            }
            textBox1.Text = textBox2.Text = "";
            Initialize();
        }

       
    }
}

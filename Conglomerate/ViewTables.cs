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
    public partial class ViewTables : Form
    {
        Query q = Conglomerate.Properties.Settings.Default.q;
        public string prefix="0";
        public ViewTables()
        {
            InitializeComponent();
              
            string username = Conglomerate.Properties.Settings.Default.Gusername;
            string [] prefixarr=username.Split('_');
            prefix = prefixarr[0];
            int roleid = q.getrole(username, prefix);
            
           
            if (roleid == 3)
            {
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
               comboBox2.Items.Add(prefix);
            }
            else if (roleid == 1)
            {
                string projname = q.getProjName(username);
                comboBox1.Items.Add(projname);
            
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string oltpname = comboBox1.Text;
            object[] oltpdetails = q.getOLTPDetails(oltpname);
            string tableNames = oltpdetails[2].ToString();
            if (tableNames == null || tableNames == "")
                return;
            string[] tablearr = tableNames.Split('@');
            
            foreach (string tab in tablearr)
            {
                string add = prefix + "_" + oltpname + "_" + tab;
                comboBox2.Items.Add(add);
            }
            foreach (string tab in tablearr)
            {
                string add = "Cleansed"+"_"+prefix + "_" + oltpname + "_" + tab;
                comboBox2.Items.Add(add);
            
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tablename = comboBox2.Text;
            DataTable db = q.getTableData(tablename, prefix);
            dV.ReadOnly = true;
            dV.DataSource = db;

            
        }
    }
}

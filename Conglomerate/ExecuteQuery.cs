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
    public partial class ExecuteQuery : Form
    {
        Query q = Conglomerate.Properties.Settings.Default.q;
        string username = "",prefix="";
        public ExecuteQuery()
        {
            InitializeComponent();

            panel2.Visible = false;
            Result.Visible = false;
            label2.Visible = false;

            Command.SelectedIndex = 0;
            LoadPanel1();
            username = Conglomerate.Properties.Settings.Default.Gusername;
            string[] arr = username.Split('_');
            prefix = arr[0];
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

                comboBox1.SelectedIndex = 0;
                
            }
            else
            {
                MessageBox.Show("You are not Super Admin. This is a restricted area so you will be logged out immediately");
                //code for log out to be inserted here
            }
        }

        private void LoadPanel1()
        {
            if (Command.SelectedIndex == 0)
            {
                textBox1.Visible = textBox2.Visible = textBox3.Visible = true;
                Tables.Location = new Point(55, 57);
                textBox1.Location = new Point(132, 31);

            }

            if (Command.SelectedIndex == 1 || Command.SelectedIndex == 2)
            {
                textBox3.Visible = textBox2.Visible = false;
                Tables.Location = new Point(132, 31);
                textBox1.Location = new Point(4, 59);
            }

            if (Command.SelectedIndex == 3)
            {
                textBox1.Visible = textBox2.Visible = textBox3.Visible = false;
                Tables.Location = new Point(132, 31);
            }
        }

        private void Command_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPanel1();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tables.Items.Clear();
            string oltpname = comboBox1.Text;
            object[] oltpdetails = q.getOLTPDetails(oltpname);
            string tableNames = oltpdetails[2].ToString();
            string[] tablearr = tableNames.Split('@');

            foreach (string tab in tablearr)
            {
                string add = prefix + "_" + oltpname + "_" + tab;
                Tables.Items.Add(add);
            }
            foreach (string tab in tablearr)
            {
                string add = "Cleansed" + "_" + prefix + "_" + oltpname + "_" + tab;
                Tables.Items.Add(add);

            }

            Tables.Items.Add(prefix);
            Tables.Items.Add(prefix+"_Logs");
            Tables.SelectedIndex = 0;
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            label2.Visible = false;
            Result.Visible = false;
            string where = "", query = "";
            string tb = "";
            string tablename="";
            
            
            if (Tables.Text == prefix)
            {
                tablename = "dbo."+Tables.Text;
                tb = "GEN";
            }
            else if (Tables.Text.Contains("Cleansed"))
            {
                tablename = "dbo." + Tables.Text.Replace("Cleansed_", "");
                tb = "DW";
            }
            else
            {
                tablename = "dbo." + Tables.Text;
                tb = "OLTP";
            }
            if (Command.SelectedIndex == 0)
            {
                if (textBox3.Text != "")
                {
                    where = textBox3.Text.Trim();
                }   
                query=Command.Text+" "+textBox1.Text+" from "+tablename+" "+where;
                try
                {
                    Result.DataSource = q.executeSelectQuery(query.Trim(), tb);
                    label2.Visible = false;
                    Result.Visible = true;
                    panel2.Visible = true;
                }
                catch(Exception ex)
                {
                    panel2.Visible = true;
                    label2.Visible = true;
                    label2.Text = ex.Message;
                }
                
            }
            else if (Command.SelectedIndex == 1 || Command.SelectedIndex == 2)
            {
                if (textBox1.Text != "")
                {
                    where = textBox1.Text.Trim();
                }

                if (Command.SelectedIndex == 2)
                {
                    query = Command.Text + " from " + tablename + " " + where;
                }
                else
                {
                    query = Command.Text + " " + tablename + " " + where;
                }
                try
                {
                    if (q.executequery(query.Trim(), tb))
                        label2.Text = "Command executed successfully";
                    else
                        label2.Text = "Command failed to execute";
                    panel2.Visible = true;
                    label2.Visible = true;

                }
                catch (Exception ex)
                {
                    panel2.Visible = true;
                    label2.Visible = true;
                    label2.Text = ex.Message;
                }
                
            }
            else if (Command.SelectedIndex == 3)
            {
                query = Command.Text + " " + tablename;
                try
                {
                    if (q.executequery(query.Trim(), tb))
                        label2.Text = "Command executed successfully";
                    else
                        label2.Text = "Command failed to execute";
                    panel2.Visible = true;
                    label2.Visible = true;

                }
                catch (Exception ex)
                {
                    panel2.Visible = true;
                    label2.Visible = true;
                    label2.Text = ex.Message;
                }
            }

            textBox1.Text = "";
            textBox3.Text = "";
        }
    }
}

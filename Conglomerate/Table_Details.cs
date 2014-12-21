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
    public partial class Table_Details : Form
    {
        Query q = Conglomerate.Properties.Settings.Default.q;

        public static int no_of_tables=0;
        public static string schema="";
        public String[] properties;
        public string username = "";
        public Table_Details(int n,string user)
        {
            InitializeComponent();
            no_of_tables = n;
            username = user;
            properties = new String[no_of_tables];
        //    int tabsToCreate = n; //just change the value according your requirement

        //    //Assume that there is "tabControl1" is already on the form

        //    //Clear the TabPages everytime
        //    tabControl1.TabPages.Clear();

        //    for (int i = 0; i < tabsToCreate; i++)
        //    {
        //        TabPage tabPage = new TabPage("TABLE" + (i + 1).ToString());
        //        tabControl1.TabPages.Add(tabPage);
        //    }
        }

        private void Table_Details_Load(object sender, EventArgs e)
        {
            for (int i = 5; i > (no_of_tables-1); i--)
            {

                
                tabControl1.TabPages.RemoveAt(i);
            }
        }


        public void loadDefineOLTP()
        {
            DefineOLTP df = new DefineOLTP();
            df.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (checktable())
            {
                string[] queries=generateschema();
                for (int i = 0; i < queries.Length; i++)
                    try
                    {
                        string[] arr = username.Split('_');
                        q.generatetables(queries[i]);
                        q.projectConfigured(arr[0]);
                        System.Threading.Thread t = new System.Threading.Thread(loadDefineOLTP);
                        t.Start();
                        this.Close();
                    }
                    catch (Exception F) 
                    {
                        MessageBox.Show(F.Message);                    
                    }    
            }
        }

        public bool checktable()
        {
            
            string error = "";
            int[] temparr=new int[no_of_tables];
            for(int i=0;i<temparr.Length;i++)
                temparr[i]=0;
            for (int i = 0; i < no_of_tables; i++)
            {
                
                if (tabControl1.TabPages[i].Controls["table" + (i+1).ToString() + "name"].Text == "")
                {
                    error += "Table name not provided of Table"+(i+1).ToString()+"\r\n";
                }
            }

            for (int i = 0; i < no_of_tables; i++)
            {
                

                for (int j = 1; j <= 8; j++)
                {
                    
                    string value=getnametype(i,j);
                    string[] arr=value.Split(' ');
                    string name=arr[0];
                    string type=arr[1];
                    if ((name == "") ^ (type == ""))
                    {
                        error += "Error in Table " + (i + 1).ToString() + " Attribute " + j.ToString() + "\r\n";
                    }
                    if (!(name == ""))
                        if (!(type == ""))
                            temparr[i] = 1;

                    if ((name != "") && (type != ""))
                    { }

                }
            }

            for (int i = 0; i < temparr.Length; i++)
            {
                if (temparr[i] == 0)
                    error += "Give atleast 1 attribute in "+(i+1).ToString()+" Table\r\n";
            }

            if(error != "")
                MessageBox.Show(error);
            // string ss = panel1.Controls["t1t1"].Text;
            if (error.Equals(""))
                return true;
            else
                return false;
        }

        public string getnametype(int i,int j)
        {
            Panel p = new Panel();

            switch (i)
            {
                case 0: p = panel1;
                    break;
                case 1: p = panel2;
                    break;
                case 2: p = panel3;
                    break;
                case 3: p = panel4;
                    break;
                case 4: p = panel5;
                    break;
                case 5: p = panel6;
                    break;
            }
            string n = "t" + (i + 1).ToString() + "n" + j.ToString();
            string name = p.Controls[n].Text.Trim();
            string t = "t" + (i + 1).ToString() + "t" + j.ToString();
            string type = p.Controls[t].Text.Trim();

            return (name + " " + type);
        }

        public string[] generateschema()
        {
            string schema = "";
            string[] tables = new string[no_of_tables];
            for (int i = 0; i < no_of_tables; i++)
            {
                int n = 0;
                
                for (int j = 1; j <= 8; j++)
                {

                    string value = getnametype(i, j);
                    string[] arr = value.Split(' ');
                    string name = arr[0];
                    string type = arr[1];
                    if (!(name == ""))
                        if (!(type == ""))
                            n++;
                }
                string[] attributes=new string[n];
                int k = 0;
                for (int j = 0; j <8; j++)
                {
                    
                    string value = getnametype(i, j+1);
                    string[] arr = value.Split(' ');
                    string name = arr[0];
                    string type = arr[1];
                    if (!(name == ""))
                        if (!(type == ""))
                            attributes[k++] = name + " " + type+" NOT NULL";
                }
                string att = string.Join(",", attributes);
                string query = "Create Table dbo." + tabControl1.TabPages[i].Controls["table" + (i + 1).ToString() + "name"].Text + "("+att+")";
                properties[i] = tabControl1.TabPages[i].Controls["table" + (i + 1).ToString() + "name"].Text + "," + att;
                tables[i]=query;
            }

            return tables;
        }

       

       

    }
}

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
    public partial class DeleteOLTP : Form
    {
        string OLTPname = "SalesManagementSystem";//Conglomerate.Properties.Settings.Default.ProjName;
        string Username = "LUF_Deepak";//Conglomerate.Properties.Settings.Default.Gusername;
        Query q = new Query();
        public DeleteOLTP()
        {
            InitializeComponent();
            OLTPName.Text = OLTPname;
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            object[] OLTPDetails=q.getOLTPDetails(OLTPname);
            string[] tablenames = OLTPDetails[2].ToString().Split('@');
            int no_of_queries = tablenames.Length;
            string[] DWQueries = new string[no_of_queries]; 
            string[] OLTPqueries=new string[no_of_queries+5];
            string[] prefix = Username.Split('_');

            int i = 0;
            for (i = 0; i < tablenames.Length; i++)
            {
                string tablename = prefix[0] + "_" + OLTPname + "_" + tablenames[i];
                OLTPqueries[i] = "Drop dbo."+tablename;
                DWQueries[i] = "Drop dbo." + tablename; 
            }

            DWQueries[i+0] = "Drop table dbo." + prefix[0] + "_" + OLTPname + "Form";
            DWQueries[i+1] = "Drop table dbo." + prefix[0] + "_" + OLTPname + "Map";
            DWQueries[i+2] = "Drop table dbo." + prefix[0] + "_" + OLTPname + "Table";
            DWQueries[i+3] = "Drop table dbo." + prefix[0] + "_" + OLTPname + "Setting";
            DWQueries[i + 4] = "Delete from dbo.OLTPDeatils where OLTPName='"+OLTPname+"'";


            string result = "";
            try
            {
                result = q.executeOLTPTransaction(OLTPqueries, "DW");
            }
            catch { }
            if (result == "")
            {
                try
                {
                    result = q.executeOLTPTransaction(DWQueries, "OLTP");
                }
                catch { }
                if (result == "")
                {
                    MessageBox.Show("OLTP has been deleted successfully. Please note that for technical reasons you will now be logged out of the system");
                    //Code for logout
                }
                else
                {
                    MessageBox.Show("Due to some reason some of the tables will not be deleted. Your database is in a state of transaction.PLease click the delete button again. Here are failure reasons. \r\n" + result);
                }
            }
            else
            {
                MessageBox.Show("Deletion of OLTP Failed please try again. If problem persists contact the developers.");
            }
        }
    }
}

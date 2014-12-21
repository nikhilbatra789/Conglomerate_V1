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
    public partial class Basic_Details : Form
    {
        Query q = Conglomerate.Properties.Settings.Default.q;
        
        public int tables = 0;
        string prefix = "";
        string username = "";

        public Basic_Details(string user)
        {
            InitializeComponent();
            username = user;
            string[] arr = user.Split('_');
            prefix=arr[0];
            c_name.Text = q.getCompany(prefix);
        }

        public void loadTableDetails()
        {
            Table_Details td = new Table_Details(tables,username);
            td.ShowDialog();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (p_name.Text.Trim() == "")
            {
                toolTip1.ToolTipTitle = "Project name cannot be left blank";
                toolTip1.Show("Please enter a valid Project Name", p_name, 5000);
                return;
            }

            if (dw_name.Text.Trim() == "")
            {
                toolTip1.ToolTipTitle = "Dataware House name cannot be left blank";
                toolTip1.Show("Please enter a valid Dataware House Name", dw_name, 5000);
                return;
            }

            if (no_of_table.Text == "")
            {
                toolTip1.ToolTipTitle = "Tables Cannot be left blank";
                toolTip1.Show("Please enter valid number of tables", no_of_table, 5000);
                return;
            }



            try
            {
                Convert.ToInt32(no_of_table.Text);
                
            }
            catch
            {
                toolTip1.ToolTipTitle = "Number of tables has to be an integer";
                toolTip1.Show("Please enter valid number of tables", no_of_table, 5000);
                return;
            }

            if (Convert.ToInt32(no_of_table.Text.Trim()) < 1)
            {
                toolTip1.ToolTipTitle="Tables Cannot be Zero or negitive";
                toolTip1.Show("Please enter valid number of tables",no_of_table,5000);
                return;
            }

            if (Convert.ToInt32(no_of_table.Text.Trim()) >6 )
            {
                toolTip1.ToolTipTitle = "Maximum Tables can be 6";
                toolTip1.Show("Please enter valid number of tables", no_of_table, 5000);
                return;
            }

            tables = Convert.ToInt32(no_of_table.Text);
            q.addProj(dw_name.Text,no_of_table.Text,prefix);
            Thread t = new Thread(loadTableDetails);
            t.Start();            
            this.Close();

        }

    }
}

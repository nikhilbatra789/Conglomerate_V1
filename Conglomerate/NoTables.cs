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
    public partial class NoTables : Form
    {
        public string[,] form;
        public int count=0;
        public NoTables(string[,] tempform)
        {
            
            InitializeComponent();
            form = tempform;
            
            int no_of_forms=form.Length/3;
            int k=0;
            for (int i = 0; i < no_of_forms; i++)
            {
                if (form[i, 2] == "True")
                {
                    string[] tempstr = form[i, 1].Split('@');
                    DataGridView dv = new DataGridView();
                    
                    
                    dv.ColumnCount = 1;
                    dv.Columns[0].Name = form[i, 0];
                    dv.Columns[0].ReadOnly = true;
                    dv.Size = new Size(140,200);

                    foreach (string str in tempstr)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dv);
                        row.Cells[0].Value = str;
                        dv.Rows.Add(row);
                    }
                    dv.Location = new Point((k*150)+10);
                    k++;
                    panel1.Controls.Add(dv);
                }
            }

            count = k;
         }

        private void btnGo_Click(object sender, EventArgs e)
        {

            if (txtTables.Text == "")
            {
                toolTip1.ToolTipTitle = "Number of Tables cannot be left blank";
                toolTip1.Show("Please enter valid number of tables", txtTables, 5000);
                return;
            }

            try
            {
                Convert.ToInt32(txtTables.Text);
            }
            catch
            {
                toolTip1.ToolTipTitle = "Number of Tables has to be an integer";
                toolTip1.Show("Please enter valid number of tables", txtTables, 5000);
                return;
            }
            if (Convert.ToInt32(txtTables.Text) < 0)
            {
                toolTip1.ToolTipTitle = "Number of Tables has to be an positive integer";
                toolTip1.Show("Please enter valid number of tables", txtTables, 5000);
                return;
            }
            int no_of_tables =Convert.ToInt32(txtTables.Text);
            General g = new General();
            g.mustdo();
            string[,] newForm=new string[form.Length/3,4];
            for (int i = 0; i < form.Length / 3; i++)
            {
                newForm[i, 0] = form[i, 0];
                newForm[i, 1] = form[i, 1];
                newForm[i, 2] = form[i, 2];
                newForm[i, 3] = "";
            }
            OldTableDetails OTD = new OldTableDetails(newForm,0,count,Convert.ToInt32(no_of_tables));
            OTD.TopLevel = false;
            OTD.Visible = true;
            for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (Application.OpenForms[index].Name == "MainBackend")
                {
                    MainBackend m = (MainBackend)Application.OpenForms[index];
                    m.panel1.Controls.Add(OTD);
                    int hieght = m.panel1.Height;
                    OTD.Height = hieght;
                    OTD.Width = m.panel1.Width;
                }
            }
        }



    }

     

}

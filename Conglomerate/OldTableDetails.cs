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
    public partial class OldTableDetails : Form
    {
        public string[,] form;
        public int i = 0,count=0,no_of_tables;
        public bool nextPage = false;
        public DataGridView dv;
        General g = new General();
        
        public OldTableDetails(string [,] tempform,int tempi,int tempcount, int temptables)
        {
            InitializeComponent();
            form = tempform;
            i = tempi;
            count = tempcount;
            no_of_tables = temptables;
            
            try
            {

                int no_of_forms = form.Length / 4;
                int k = 0;
                string[] formnames = new string[1] ;
                while (i < no_of_forms)
                {
                    if (form[i, 2] == "True")
                    {
                        string[] tempstr = form[i, 1].Split('@');
                        dv = new DataGridView();
                        formnames=new string[tempstr.Length];

                        dv.ColumnCount = 1;
                        dv.Columns[0].Name = form[i, 0];

                        dv.Columns[0].ReadOnly = true;
                        dv.Size = new Size(260, 200);

                        DataGridViewComboBoxColumn DGVCC = new DataGridViewComboBoxColumn();
                        DGVCC.Name = "Variables";
                        DGVCC.HeaderText = "Select variables";
                        DGVCC.Items.AddRange("int", "varchar(50)", "varchar(100)", "varchar(250)", "varchar(500)","float","char");
                        dv.Columns.Add(DGVCC);

                        int num = 0;
                        foreach (string str in tempstr)
                        {
                            DataGridViewRow row = new DataGridViewRow();
                            row.CreateCells(dv);
                            row.Cells[0].Value = str;
                            formnames[num++] = str;
                            row.Cells[1].Value = "int";
                            dv.Rows.Add(row);
                        }
                        dv.Location = new Point((k * 150) + 10);
                        k++;
                        panel1.Controls.Add(dv);

                        
                    }
                    i++;
                    if (i >= count)
                    {
                        nextPage = true;
                    }
                    break;
                }

                List<string> lis = formnames.ToList<string>();
                lis.RemoveAll(p => string.IsNullOrEmpty(p));
                formnames = lis.ToArray();

                primarykey.Items.AddRange(formnames);
                primarykey.SelectedIndex = 0;

            }
            catch { }


        }

        public void loadAgain()
        {
            //Thread.Sleep(50);
            g.mustdo();
            OldTableDetails old = new OldTableDetails(form,i,count,no_of_tables);
            old.TopLevel = false;
            old.Visible = true;
            for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (Application.OpenForms[index].Name == "MainBackend")
                {
                    MainBackend m = (MainBackend)Application.OpenForms[index];
                    m.panel1.Controls.Add(old);
                    int hieght = m.panel1.Height;
                    old.Height = hieght;
                    old.Width = m.panel1.Width;
                }
            }
            //old.ShowDialog();
        }

        public void loadNewTableDetails()
        {
            g.mustdo();
            NewTableDetails ntd1 = new NewTableDetails(form,no_of_tables);
            ntd1.TopLevel = false;
            ntd1.Visible = true;
            for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (Application.OpenForms[index].Name == "MainBackend")
                {
                    MainBackend m = (MainBackend)Application.OpenForms[index];
                    m.panel1.Controls.Add(ntd1);
                    int hieght = m.panel1.Height;
                    ntd1.Height = hieght;
                    ntd1.Width = m.panel1.Width;
                }
            }
            //ntd1.ShowDialog();
        }


        private void btnNext_Click(object sender, EventArgs e)
        {
            int rows;
            try
            {
                rows = dv.RowCount;
            }
            catch
            {
                rows = 0;
            }
            string[] tempstr = form[i-1, 1].Split('@');
            for (int k = 0; k < rows-1; k++)
            {
                string str = tempstr[k];
                str += "_" + dv.Rows[k].Cells[1].Value.ToString();
                tempstr[k] = str;
            }
            string joinstr = String.Join("@",tempstr);
            form[i - 1, 1] = joinstr;
            form[i - 1, 3] = primarykey.Text;
            try
            {
                dv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            }
            catch
            { }
            if (nextPage == false)
            {
                loadAgain();
                //Thread t = new Thread(loadAgain);
                //t.Start();
                this.Close();
            }
            else
            {
                loadNewTableDetails();
                //Thread t = new Thread(loadNewTableDetails);
                //t.Start();
                //this.Close();
            }
        }
    }
}

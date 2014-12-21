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
    public partial class NewTableDetails : Form
    {

        public string[,] form;
        public int i = 0, count = 0;
        public bool nextPage = false;
        public DataGridView dv;
        public int no_of_tables = 0;
        public string[,] tables;
        General g = new General();

        public NewTableDetails(string[,] tempform,int temptables)
        {
            InitializeComponent();
            form = tempform;
            no_of_tables = temptables;
            tables=new string[no_of_tables,2];

            if (temptables == 0)
            {
                tables = null;
                g.mustdo();
                Mapping map = new Mapping(form, tables);
                map.TopLevel = false;
                map.Visible = true;
                for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
                {
                    if (Application.OpenForms[index].Name == "MainBackend")
                    {
                        MainBackend m = (MainBackend)Application.OpenForms[index];

                        int hieght = m.panel1.Height;
                        map.Height = hieght;
                        map.Width = m.panel1.Width;
                        m.panel1.Controls.Add(map);
                    }
                }
            }
            
            int k = 0;
            while (i < no_of_tables)
            {
                dv = new DataGridView();
                dv.Name = "DGV" + i.ToString();
                dv.ColumnCount = 1;
                dv.Columns[0].Name = "Variable Name";
                dv.Size = new Size(260, 200);
                DataGridViewComboBoxColumn DGVCC = new DataGridViewComboBoxColumn();
                DGVCC.HeaderText = "Variable type";
                DGVCC.Items.AddRange("int", "varchar(50)", "varchar(100)", "varchar(250)", "varchar(500)", "float", "char");
                dv.Columns.Add(DGVCC);
                dv.Location = new Point((k * 150) + 10,40);
                
                panel1.Controls.Add(dv);

                Label l = new Label();
                l.Text = "Table Name";
                l.Location = new Point((k * 150) + 10, 12);
                l.Size = new Size(65,15);
                panel1.Controls.Add(l);

                TextBox t = new TextBox();
                t.Name = "textbox" + i.ToString();
                t.Location = new Point((k * 150) + 75, 10);
                panel1.Controls.Add(t);
                k=k+2;
                i++;
            }
             
            
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

            if (check())
            {
                for (int l = 0; l < i; l++)
                {
                    DataGridView DGV = (DataGridView)panel1.Controls["DGV" + (l).ToString()];
                    int no_of_rows = DGV.RowCount;
                    TextBox tb = (TextBox)panel1.Controls["textbox" + (l).ToString()];
                    tables[l, 0] = tb.Text;
                    string[] eachrow = new string[no_of_rows - 1];
                    string[] test = new string[no_of_rows - 1];

                    ///Check for columns spaces or special characters
                    for (int j = 0; j < no_of_rows - 1; j++)
                    {
                        string[] error = DGV.Rows[j].Cells[0].Value.ToString().Split(' ');
                        if (error.Length > 1)
                        {
                            MessageBox.Show(DGV.Rows[j].Cells[0].Value.ToString()+" is having spaces. Please remove them");
                            return;
                        }
                        if (DGV.Rows[j].Cells[0].Value.ToString().Contains("_") || DGV.Rows[j].Cells[0].Value.ToString().Contains("@"))
                        {
                            MessageBox.Show(DGV.Rows[j].Cells[0].Value.ToString() + " is having special character '_' or '@' or both. Please remove them");
                            return;
                        }
                        test[j] = DGV.Rows[j].Cells[0].Value.ToString().ToUpper();
                    }
                    if (test.Count() != test.Distinct().Count())
                    {
                        MessageBox.Show("There are duplicate coulumn names. Please remove them in order to continue");
                    }

                    for (int j = 0; j < no_of_rows - 1; j++)
                    {
                        eachrow[j] = DGV.Rows[j].Cells[0].Value.ToString() + "_" + DGV.Rows[j].Cells[1].Value.ToString();
                    }
                    tables[l, 1] = String.Join("@", eachrow);
                }

                g.mustdo();
                NewTablePrimaryKeys map = new NewTablePrimaryKeys(form,tables);
                map.TopLevel = false;
                map.Visible = true;
                for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
                {
                    if (Application.OpenForms[index].Name == "MainBackend")
                    {
                        MainBackend m = (MainBackend)Application.OpenForms[index];
                        
                        int hieght = m.panel1.Height;
                        map.Height = hieght;
                        map.Width = m.panel1.Width;
                        m.panel1.Controls.Add(map);
                    }
                }
            }
            else
            {
                MessageBox.Show("There is some error");
            }

        }

        public bool check()
        {
            for (int l = 0; l < i; l++)
            {
                DataGridView DGV = (DataGridView)panel1.Controls["DGV" + (l).ToString()];
                int no_of_rows = DGV.RowCount;
                if (no_of_rows < 2)
                    return false;
                TextBox tb = (TextBox)panel1.Controls["textbox"+(l).ToString()];
                if (tb.Text == "")
                    return false;
                for (int j = 0; j < no_of_rows-1; j++)
                {
                    bool a = false;
                    bool b = false;
                    try
                    {
                        if (DGV.Rows[j].Cells[0].Value.ToString() == "")
                            a = true;
                    }
                    catch
                    {
                        return false;
                    }
                    try
                    {
                        if (DGV.Rows[j].Cells[1].Value.ToString() == "")
                            b = true;
                    }
                    catch
                    {
                        return false;
                    }
                    bool c = a^b;
                    if (c)
                        return false;
                }
            }
            return true;
        }
    }
}

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
    public partial class NewTablePrimaryKeys : Form
    {
        public string[,] form;
        public string[,] table;
        public int no_of_tables = 0;
        string[,] newTable;
        General g = new General();
        public NewTablePrimaryKeys(string[,] tempform,string[,] temptable)
        {
            InitializeComponent();

            form = tempform;
            table = temptable;
            no_of_tables=table.Length/2;
            newTable=new string[no_of_tables,3];

            for (int i = 0; i < no_of_tables; i++)
            {
                newTable[i, 0] = table[i, 0];
                newTable[i, 1] = table[i, 1];

                TextBox tb = new TextBox();
                tb.Name = "Table@"+i.ToString();
                tb.Location = new Point(50,50+(30*i));
                tb.Text=table[i,0];
                tb.Enabled = false;
                panel1.Controls.Add(tb);


                ComboBox cmb = new ComboBox();
                string[] temp = table[i, 1].Split('@');
                for (int j = 0; j < temp.Length; j++)
                { 
                    string[] arr=temp[j].Split('_');
                    cmb.Items.Add(arr[0]);
                }
                cmb.Name = "Attr@"+i.ToString();
                cmb.SelectedIndex = 0;
                cmb.Location = new Point(200,50+(30*i));
                cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                panel1.Controls.Add(cmb);
            }

        }

        private void next_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < no_of_tables; i++)
            { 
                ComboBox cb=(ComboBox)panel1.Controls["Attr@"+i.ToString()];
                newTable[i, 2] = cb.Text;
                
            }

            g.mustdo();
            Mapping map = new Mapping(form, newTable);
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
    }
}

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
    public partial class FormDetails : Form
    {
        public int i;
        public string[,] form;
        public FormDetails(int tempi,string[,] tempforms)
        {
            InitializeComponent();
            form = tempforms;
            i = tempi;

            string warning = "Please do not use space or characters'_' or '@' for naming the form fields. It may lead to errer. For example Shipping Day or Shipping_Day or Shipping@Day are all invalid.";
            label2.Text = warning;

            string todo = "Please provide fields of the column of the form each in one line";
            label3.Text = todo;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            string[] text = txtDetails.Text.Split(new string[]{"\r\n"},StringSplitOptions.None);
            string[] test=new string[text.Length];

            for (int j = 0; j < text.Length; j++)
            {
                if (text[j].Contains("_") || text[j].Contains("@"))
                {
                    toolTip1.ToolTipTitle = text[j]+"contains '_' or '@' as intermeditae please do not use them";
                    toolTip1.Show("Please correct your mistake", txtDetails, 5000);
                    return;
                }
                test[j] = text[j].ToUpper();
            }
            if (test.Count() != test.Distinct().Count())
            {
                toolTip1.ToolTipTitle = "There are duplicate fields";
                toolTip1.Show("Please remove the dupliacte fields", txtDetails, 5000);
                return;
            }

            string formdetails = String.Join("@",text);
            form[i,1] = formdetails;
            form[i,0] = txtFormName.Text;
            if (chkTable.Checked)
            {
                form[i, 2] = "True";
            }
            else
            {
                form[i, 2] = "False";
            }
            General g = new General();
            if (i + 1 == (form.Length)/3)
            {
                g.mustdo();
                //this.Visible = true;
                NoTables t = new NoTables(form);
                t.TopLevel = false;
                t.Visible = true;
                for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
                {
                    if (Application.OpenForms[index].Name == "MainBackend")
                    {
                        MainBackend m = (MainBackend)Application.OpenForms[index];
                        int hieght = m.panel1.Height;
                        t.Height = hieght;
                        t.Width = m.panel1.Width;
                        m.panel1.Controls.Add(t);
                    }
                }
               
            }
            else
            {
                
                g.mustdo();
                FormDetails frm = new FormDetails(++i, form);
                frm.TopLevel = false;
                frm.Visible = true;
                for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
                {
                    if (Application.OpenForms[index].Name == "MainBackend")
                    {
                        MainBackend m = (MainBackend)Application.OpenForms[index];
                        int hieght = m.panel1.Height;
                        frm.Height = hieght;
                        frm.Width = m.panel1.Width;
                        m.panel1.Controls.Add(frm);
                    }
                }
             
            }
        }
    }
}

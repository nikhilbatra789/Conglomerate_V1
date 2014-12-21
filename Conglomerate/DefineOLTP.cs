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
    public partial class DefineOLTP : Form
    {
        Query q = Conglomerate.Properties.Settings.Default.q;
        public double interval { get; set; }
        public DefineOLTP()
        {
            InitializeComponent();
           //label5.Text= Conglomerate.Properties.Settings.Default.Gusername;
           textBox1.Text = Conglomerate.Properties.Settings.Default.ProjName;

        }

        public string OLTPname { get; set; }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                toolTip1.ToolTipTitle = "OLTP name cannot be left blank";
                toolTip1.Show("Please enter valid OLTP Name", textBox1, 5000);
                return;
            }

            if (no_of_forms.Text == "")
            {
                toolTip1.ToolTipTitle = "Number of Forms cannot be left blank";
                toolTip1.Show("If you have no forms them then enter 0", no_of_forms, 5000);
                return;
            }

            try
            {
                Convert.ToInt32(no_of_forms.Text);
            }
            catch (Exception)
            {
                toolTip1.ToolTipTitle = "Number of Forms has to be an integer";
                toolTip1.Show("Please enter valid number of forms", no_of_forms, 5000);
                return;
                
            }

            if (Convert.ToInt32(no_of_forms.Text) <= 0)
            {
                toolTip1.ToolTipTitle = "Number of Forms has to be an positive integer";
                toolTip1.Show("Please enter valid number of forms", no_of_forms, 5000);
                return;
            }

            if (textBox2.Text == "")
            {
                toolTip1.ToolTipTitle = "Transfer Interval cannot be left blank";
                toolTip1.Show("please enter the time in Seconds", textBox2, 5000);
                return;
            }
            if (textBox2.Text == "0")
            {
                toolTip1.ToolTipTitle = "Transfer Interval cannot be zero";
                toolTip1.Show("please enter the time in Minutes", textBox2, 5000);
                return;
            }

            OLTPname = textBox1.Text.Trim();
            interval =Convert.ToDouble(textBox2.Text)*1000*60;
            string[,] form = new string[Convert.ToInt32(no_of_forms.Text),3];
            General g = new General();
            g.mustdo();
            FormDetails frm = new FormDetails(0,form);
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

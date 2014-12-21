using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Conglomerate
{
    public partial class adminDashboard : Form
    {
        public adminDashboard()
        {
          
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        //    Basic_Details B = new Basic_Details();
        //    B.TopLevel = false;
        //    B.Visible = true;
        //    Table_Details t = new Table_Details();
        //    t.TopLevel = false;
        //    t.Visible = true;
          
        //   panel1.AutoSize = true;
        ////   panel1.AutoSizeMode = AutoSizeMode.GrowOnly;
        //   panel2.AutoSize = true;
        ////    panel1.AutoSizeMode = AutoSizeMode.GrowOnly;
        ////    panel3.AutoSize = true;
        //    panel1.Controls.Add(B);
        //    panel2.Controls.Add(t);
        }

        private void oLTPSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Basic_Details B = new Basic_Details();
            B.TopLevel = false;
            B.Visible = true;
            panel2.AutoSize = true;
            panel2.Controls.Add(B);
           

        }

  

        


        
       
    }
}

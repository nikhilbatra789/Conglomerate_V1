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
    public partial class Startup : Form
    {
        public Startup()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Turquoise;
            this.BackColor = Color.Turquoise;
            //this.Opacity = 0.0;
            label1.Parent = pictureBox1;
            label1.ForeColor = Color.White;
            label1.BackColor = Color.Transparent;
            OSUsername.Text = Environment.UserDomainName;
            OSUsername.Parent = pictureBox1;
            OSUsername.ForeColor = Color.White;
            OSUsername.BackColor = Color.Transparent;
        }

        public void checknetwork(int i)
        {
           
            switch (i)
            {
                case 0: this.ShowDialog();
                    break;
                case 1: this.Close();
                    break;

                case 2:
                    try
                    {
                        Query q = Conglomerate.Properties.Settings.Default.q;
                    }
                    catch(Exception e)
                    {
                        label1.Text = "Network Connection Failed";
                        Thread.Sleep(1000);
                        label1.Text = "Application will now close";
                        Thread.Sleep(1000);
                        Application.Exit();
                    }
                    break;
            }
            
                 
        }



        
    }
}

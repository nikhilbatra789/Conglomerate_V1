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
    public partial class CleansingDisplay : Form
    {
        public CleansingDisplay()
        {
            InitializeComponent();
            ld.ForeColor = Color.Red;
            Transform.ForeColor = Color.Red;
            Extract.ForeColor = Color.Red;
        }

        public void load(int i, string table)
        {
            Tablename.Text = table;
            switch (i)
            {
                case 1: this.ShowDialog();
                    break;
                case 2: ld.ForeColor = Color.Red;
                    Transform.ForeColor = Color.Red;
                    Extract.ForeColor = Color.Green;
                    break;
                case 3: ld.ForeColor = Color.Red;
                    Transform.ForeColor = Color.Green;
                    Extract.ForeColor = Color.Red;
                    break;
                case 4: ld.ForeColor = Color.Green;
                    Transform.ForeColor = Color.Red;
                    Extract.ForeColor = Color.Red;
                    break;
                case 5: this.Close();
                    break;
            }
        }
    }
}

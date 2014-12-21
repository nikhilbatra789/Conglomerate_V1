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
    public partial class OpeningForm : Form
    {
        public OpeningForm(string initializeString)
        {
            InitializeComponent();
            label1.Text = initializeString;
        }
    }
}

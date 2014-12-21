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
    public partial class OLTPMapping : Form
    {
        string[,] form;
        string[,] tables;
        int no_of_forms=0,no_of_tables=0;
        public OLTPMapping(string[,] tempform,string[,] temptables)
        {
            InitializeComponent();

            form = tempform;
            tables = temptables;

            no_of_forms=form.Length/3;
            no_of_tables=tables.Length/2;
            for (int i = 0; i < no_of_tables; i++)
            { }
        }
    }
}

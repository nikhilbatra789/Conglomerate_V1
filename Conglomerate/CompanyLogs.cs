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
    public partial class CompanyLogs : Form
    {
        Query q = Conglomerate.Properties.Settings.Default.q;
        public CompanyLogs()
        {
            InitializeComponent();

            string username = Conglomerate.Properties.Settings.Default.Gusername;
            string[] prefix = username.Split('_');
            DataTable dt = new DataTable();
            dt = q.getComapnayLogs(prefix[0]);
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;
        }
    }
}

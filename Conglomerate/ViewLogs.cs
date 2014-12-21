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
    public partial class ViewLogs : Form
    {
        Query q = Conglomerate.Properties.Settings.Default.q;
        string username = Conglomerate.Properties.Settings.Default.Gusername;
        public ViewLogs()
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            dt = q.getIndivisualLogs(username);
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;
            string[] prefix=username.Split('_');
            int roleid = q.getrole(username, prefix[0]);
            if (roleid == 3)
            {
                AdvancedLogs.Visible = true;
                AdvancedLogs.Enabled = true;
            }
            else
            {
                AdvancedLogs.Visible = false;
                AdvancedLogs.Enabled = false;
            }
        }

        private void AdvancedLogs_Click(object sender, EventArgs e)
        {
            General g = new General();
            g.mustdo();
            CompanyLogs frm = new CompanyLogs();
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

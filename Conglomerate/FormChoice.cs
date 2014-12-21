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
    public partial class FormChoice : Form
    {
        Query q = Conglomerate.Properties.Settings.Default.q;
        Logs l = new Logs();

        public string Username = "", OLTPName = "",choice="";
        public object[] OLTPDetails;
        public FormChoice(string tempUsername,string tempOLTPName)
        {
            InitializeComponent();
            Username = tempUsername;
            OLTPName = tempOLTPName;
            this.Text = "Conglomerate: " + Username;

            OLTPDetails = q.getOLTPDetails(OLTPName);
            string str = OLTPDetails[1].ToString();
            string[] arr = str.Split('@');
            drpformChoice.Items.AddRange(arr);
            drpformChoice.SelectedIndex = 0;
            
        }

        private void Load_Click(object sender, EventArgs e)
        {
            string[] arr = Username.Split('_');
            l.createLogEvent(arr[0], Username, "User opened form: "+drpformChoice.Text, "ForgotPassword");
            choice = drpformChoice.Text;
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(loadDynamicForm));
            t.Start();
            
            //df.ShowDialog();
        }

        public void loadDynamicForm()
        { 
            Application.Run(new DynamicForm(Username, OLTPName, OLTPDetails,choice));
        }

        
    }
}

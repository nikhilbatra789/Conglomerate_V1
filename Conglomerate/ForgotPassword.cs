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
    public partial class ForgotPassword : Form
    {

        Query q = Conglomerate.Properties.Settings.Default.q;
        General g = new General();
        Logs l = new Logs();
        public ForgotPassword()
        {
            InitializeComponent();            
        }

        public string generatePassword()
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            return BitConverter.ToUInt32(buffer, 8).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "")
            {
                toolTip1.ToolTipTitle = "Username cannot be left blank";
                toolTip1.Show("Please enter a valid username", textBox1, 5000);
                return;
            }
            string[] prefix=textBox1.Text.Split('_');
            if(prefix.Length<2)
            {
                toolTip1.ToolTipTitle = "Username is not valid";
                toolTip1.Show("Please enter a valid username", textBox1, 5000);
                return;
            }
            try
            {
                string password=generatePassword();
               object[] email= q.getUserEmail(textBox1.Text, prefix[0]);
               string Body = "Here is your new password.\r\nYour Username  :"+ textBox1.Text + "\r\nPassword:  " + password;
               Body += "\r\nPlease login with these credentials and setup new password";

               string Subject = "Conglomerate: Your Login Credentials";

               g.sendMail(email[1].ToString(), Body, Subject);

               q.setFirstLogin(textBox1.Text,prefix[0]);
               q.setPassword(g.GetSHA1HashData(password), textBox1.Text.Trim(), prefix[0]);
               MessageBox.Show("Please check your email. Instructions has been sent to it");
               string[] arr = textBox1.Text.Trim().Split('_');
               l.createLogEvent(arr[0], textBox1.Text, "Password Successfully changed", "ForgotPassword"); 
               this.Close();
            }
            catch
            {
                toolTip1.ToolTipTitle = "This username does not exist";
                toolTip1.Show("Please enter a valid username", textBox1, 5000);
                return;
            }
        }
    }
}

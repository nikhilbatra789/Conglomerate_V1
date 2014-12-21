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
    public partial class Add_User : Form
    {
        Query q = Conglomerate.Properties.Settings.Default.q;
        General g = new General();
        Validation v = new Validation();

        string EmailBody; 
        string Subject = "Conglomerate: Your Login Credentials";
        public Add_User()
        {
            InitializeComponent();
           

            this.cmbNames.SelectedIndexChanged +=
            new System.EventHandler(Cmbnames_SelectedIndexChanged);
            textBox5.Text = Conglomerate.Properties.Settings.Default.Gusername;
            string [] prefixarr=textBox5.Text.Split('_');
            string prefix = prefixarr[0];
            textBox6.Text = prefixarr[0]+"_";
            int role = q.getrole(textBox5.Text, prefix);
            if (role == 3)
            {
                radioButton2.Visible = false;
                radioButton1.Checked = true;
                radioButton3.Checked = true;
                
            }
            else if (role == 1)
            {
                radioButton1.Visible = false;
                radioButton2.Checked = true;

                textBox3.Enabled = false;
                textBox4.Enabled = false;
                cmbNames.Visible = false;
                object[] obj = q.getProjID(textBox5.Text,prefix);
                textBox3.Text = obj[0].ToString();
                textBox4.Text = obj[1].ToString();

                radioButton3.Visible = false;
                radioButton4.Visible = false;
            }
            object[] projectnames = q.getAllProjNames(prefix);
            int i = 0;
            foreach (object[] item in projectnames)
            {
                if (item[0].ToString() != "ALL")
                {
                    cmbNames.Items.Add(item[0].ToString());
                    i++;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { string [] prefixarr=textBox5.Text.Split('_');
            string prefix = prefixarr[0];
            string username = prefix +"_" + textBox1.Text.Trim();

            EmailBody = "Welcome on behalf of Conglomerate.\r\nYour Username  :"+username+"\r\nPassword:  "+textBox2.Text;
            EmailBody+="\r\nPlease login with these credentials and setup your project to start manipulating forms";
           
            string users = q.getuser(username, prefix);
            string role="";
            bool FirstLogin ;

            if (txtEmail.Text == "")
            {
                toolTip1.ToolTipTitle = "Email cannot be left blank";
                toolTip1.Show("Please enter a valid Email", txtEmail, 5000);
                return; 
            }

            if (!v.isValidEmail(txtEmail.Text))
            {
                toolTip1.ToolTipTitle = "Email ID is not Valid";
                toolTip1.Show("Please enter a valid Email", txtEmail, 5000);
                return;
            }

            if (textBox1.Text == "")
            {
                toolTip1.ToolTipTitle = "Username cannot be left blank";
                toolTip1.Show("Please enter a username", textBox1, 5000);
                return;
            }
            if (textBox2.Text == "")
            {
                toolTip1.ToolTipTitle = "Password cannot be left blank";
                toolTip1.Show("Please enter a password", textBox2, 5000);
                return;
            }
            
            if (textBox4.Text == "")
            {
                toolTip1.ToolTipTitle = "Project ID cannot be left blank";
                toolTip1.Show("Please enter a Project ID", textBox4, 5000);
                return;
            }
            if (users != null)
            {

                toolTip1.ToolTipTitle = "User already exists";
                toolTip1.Show("Please enter another username", textBox1, 5000);
            }
            else if (radioButton2.Checked)
            {
                if (textBox3.Text == "")
                {
                    toolTip1.ToolTipTitle = "Project name cannot be left blank";
                    toolTip1.Show("Please enter a Project name", textBox3, 5000);
                    return;
                }
                role = "User";
                FirstLogin = true;
                try
                {
                    q.addUser(prefix, username, g.GetSHA1HashData(textBox2.Text.Trim()), role, textBox3.Text, textBox4.Text, FirstLogin, txtEmail.Text.Trim());
                    q.addUser_To_OLTP(username, textBox4.Text);
                    g.sendMail(txtEmail.Text.Trim(), EmailBody, Subject);
                    MessageBox.Show("User added successfully");
                    
                }
                catch
                {
                    MessageBox.Show("Error Adding User");
                }

            }
            else {
                role = "Admin";
                FirstLogin = true;
                if(radioButton4.Checked)
                {
                    try
                    {
                        q.addUser(prefix, username, g.GetSHA1HashData(textBox2.Text.Trim()), role, cmbNames.SelectedItem.ToString(), textBox4.Text, FirstLogin, txtEmail.Text.Trim());
                        q.addUser_To_OLTP(username, textBox4.Text);
                        g.sendMail(txtEmail.Text.Trim(), EmailBody, Subject);
                        MessageBox.Show("Admin added successfully");
                    }
                    catch
                    {
                        MessageBox.Show("Error Adding Admin");
                    }
                }
                else
                {    if(textBox3.Text=="")
                    {
                        toolTip1.ToolTipTitle = "Project name cannot be left blank";
                        toolTip1.Show("Please enter a Project name", textBox3, 5000);
                        return;
                    }
                        
                        try
                        {
                            q.addUser(prefix, username, g.GetSHA1HashData(textBox2.Text.Trim()), role, textBox3.Text, textBox4.Text, FirstLogin, txtEmail.Text.Trim());
                            g.sendMail(txtEmail.Text.Trim(), EmailBody, Subject);
                            MessageBox.Show("Admin added successfully");
                        }
                        catch
                        {
                            MessageBox.Show("Error Adding Admin");
                        }
                    
                }
                
            }            
        }
 

        private void Add_User_Load(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            adjustDiplay();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            adjustDiplay();
        }
        public void adjustDiplay()
        {
            if (radioButton3.Checked == true)
            {
                cmbNames.Visible = false;
                textBox3.Visible = true;
                textBox4.Enabled = true;
                textBox4.Text = "";
            }
            else
            {
                textBox3.Visible = false;
                cmbNames.Visible = true;
                textBox4.Enabled = false;
                

            }
        }

        public void Cmbnames_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] prefixarr = textBox5.Text.Split('_');
            string prefix = prefixarr[0];
            textBox4.Text = q.getProjID1(cmbNames.Text,prefix);

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Conglomerate.Classes;
using System.Net;
using System.Net.Mail;

namespace Conglomerate
{
    public partial class DBA : Form
    {
        Query q = Conglomerate.Properties.Settings.Default.q;
        General g = new General();
        public DBA()
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
            if (!(drpCmpny.SelectedIndex < 0))
            {
                if (!q.checkPrefix(txtPrefix.Text))
                {

                    object[] tempobj = q.getallrequest();
                    int i = 0;
                    string username = "";
                    string email = "";
                    foreach (object[] temp in tempobj)
                    {
                       
                        if (i == drpCmpny.SelectedIndex)
                        {
                            username = temp[4].ToString();
                            email = temp[2].ToString();
                        }
                        i++;
                    }
                    string password=generatePassword();
                    try
                    {
                        string Body = "Welcome on behalf of Conglomerate.\r\nYour Username  :"+txtPrefix.Text+"_"+username+"\r\nPassword:  "+password;
                        Body+="\r\nPlease login with these credentials and setup your project to start manipulating forms";

                        string Subject = "Conglomerate: Your Login Credentials";

                        g.sendMail(email, Body, Subject);


                        q.addComapny(txtPrefix.Text.Trim(), drpCmpny.Text.Trim());
                        q.createCompany(txtPrefix.Text.Trim());
                        q.addFirstUser(txtPrefix.Text.Trim(),txtPrefix.Text.Trim()+"_"+username, g.GetSHA1HashData(password),email);
                        q.insertProj(txtPrefix.Text.Trim());
                        q.createLog(txtPrefix.Text.Trim());
                        MessageBox.Show("Company has been added");
                        q.deleterequest(drpCmpny.Text);

                        this.Hide();
                        DBA admin = new DBA();
                        this.Close();
                        admin.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("The following exception Occured while sending email. The Company has not been added to the database" + ex.ToString());
                    }                  
                    
                }
                else
                {
                    MessageBox.Show("This prefix already exists. Try Another Prefix");
                }
                
            }
            else
            {
                MessageBox.Show("No company has been selected");
            }
                    }

        private void DBA_Load(object sender, EventArgs e)
        {

            object[] tempobj=q.getallrequest();
            int length = 0;
            try
            {
                length = tempobj.Length;

                string[,] request = new string[length, 15];
                int i = 0;
                string[] drpcmpname = new string[length];

                foreach (object[] obj in tempobj)
                {
                    request[i, 0] = obj[0].ToString();////Company Name
                    request[i, 1] = obj[1].ToString();////Payment ID
                    request[i, 2] = obj[2].ToString();////Email
                    request[i, 3] = obj[3].ToString();////Mobile No

                    TextBox CmpName = new TextBox();
                    CmpName.Text = request[i, 0];
                    CmpName.Location = new Point(4, ((i) * 30) + 30);
                    CmpName.Enabled = false;
                    CmpName.Size = new Size(137, 20);

                    drpcmpname[i] += request[i, 0];

                    TextBox Payment = new TextBox();
                    Payment.Text = request[i, 1];
                    Payment.Location = new Point(146, ((i) * 30) + 30);
                    Payment.Enabled = false;
                    Payment.Size = new Size(65, 20);

                    TextBox Email = new TextBox();
                    Email.Text = request[i, 2];
                    Email.Location = new Point(217, ((i) * 30) + 30);
                    Email.Enabled = false;
                    Email.Size = new Size(135, 20);

                    TextBox MobileNO = new TextBox();
                    MobileNO.Text = request[i, 3];
                    MobileNO.Location = new Point(359, ((i) * 30) + 30);
                    MobileNO.Enabled = false;
                    MobileNO.Size = new Size(100, 20);

                    this.panelRequest.Controls.Add(CmpName);
                    this.panelRequest.Controls.Add(Payment);
                    this.panelRequest.Controls.Add(Email);
                    this.panelRequest.Controls.Add(MobileNO);

                    i++; ;
                }

                drpCmpny.Items.AddRange(drpcmpname);
            }
            catch
            {
               
            }       

            

            
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(loadHome);
            t.Start();
            this.Close();
        }

        public void loadHome()
        {
            Home h = new Home();
            h.ShowDialog();
        }
        
        
    }
}

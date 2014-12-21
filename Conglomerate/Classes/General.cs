using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Net.Mail;
using System.Net;

namespace Conglomerate.Classes
{
    class General
    {

        //Query q = Conglomerate.Properties.Settings.Default.q;
        //string OLTPName = Conglomerate.Properties.Settings.Default.ProjName;
        public void mustdo()
        {
            for (int index = Application.OpenForms.Count - 1; index >= 0; index--)
            {
                if (Application.OpenForms[index].Name != "MainBackend")
                {
                    try
                    {
                        Application.OpenForms[index].Close();
                    }
                    catch
                    { }
                }
            }


        }
        public string GetSHA1HashData(string data)
        {
            //create new instance of md5
            SHA1 sha1 = SHA1.Create();

            //convert the input text to array of bytes
            byte[] hashData = sha1.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();
        }

        public void sendMail(string email,string Body,string subject)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress("conglomerate.software@gmail.com");
            message.To.Add(new MailAddress(email));
            message.Subject = subject;
            message.Body = Body;

            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("conglomerate.software@gmail.com", "conglo@123");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
        }

        

    }
}

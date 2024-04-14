using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csharpProject_gestionStock.Utils
{
    public class Mail
    {
       public void SendMail(string from, string to, string subject, string body)
        {
            string fromMail = from;
            string fromPassword = "znmw ekrx lgrg vrhe";


            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromMail);
                message.Subject = subject;
                message.To.Add(new MailAddress(to));
                message.Body = $"<html> <body> {body} </body> </html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };

                smtpClient.Send(message);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erreur lors de l'envoi du mail");
            }
        }
    }
}

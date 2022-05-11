using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace AuditInspect.Utility
{
    public class EmailHelper
    {
        public bool SendEmail(string userEmail, string confirmationLink, string emailSubject)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("");
            mailMessage.To.Add(new MailAddress(userEmail));

            mailMessage.Subject = emailSubject;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = confirmationLink;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("", "");
            client.Host = "";
            client.Port = 587;
            client.EnableSsl = false;


            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                // log exception
            }
            return false;
        }

    }
}

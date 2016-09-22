using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace EmailService
{
    public class EmailSender : IEmailSender
    {
        private static readonly string _emailAddress = "smartsetdiscussionforum@gmail.com";
        private static readonly string _password = "discussionforum";
        private static readonly string _emailHost = "smtp.gmail.com";

        public void SendEmail(string subject, string message, string emailAddress)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_emailAddress, "SmartSet");
            mailMessage.To.Add(emailAddress);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = _emailHost;
            smtp.Credentials = new System.Net.NetworkCredential(_emailAddress, _password);
            smtp.EnableSsl = true;
            smtp.Send(mailMessage);
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}

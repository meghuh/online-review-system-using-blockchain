using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace OnlineReview
{
    public class SendEmail
    {
        public static void Send(string EmailID, string message,string sub)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("project.online567@gmail.com", "projectonline1234");
            smtp.EnableSsl = true;


            MailAddress _from = new MailAddress("project.online567@gmail.com");
            MailAddress _to = new MailAddress(EmailID);

            MailMessage mail = new MailMessage(_from, _to);
            mail.Subject = sub;
            mail.Body = "<font size=15> " +message+ "</font>";
            mail.IsBodyHtml = true;
            try
            {
                smtp.Send(mail);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
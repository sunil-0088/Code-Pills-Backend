using Code_Pills.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            string password = "tuvvstnrrfvgjtda";
            string fromMail = "gopal.sharma@qburst.com";
            //Configure SMTP settings using
            using (var smtpClient = new SmtpClient("smtp.gmail.com"))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(fromMail, password);
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                // Compose and send email
                using (var mailMessage = new MailMessage(fromMail, toEmail))
                {
                    mailMessage.Subject = subject;
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;
                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
        }
    }
}

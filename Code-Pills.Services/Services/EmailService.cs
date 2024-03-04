using Code_Pills.DataAccess.Context;
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.Services.Interface;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext dbContext;

        public EmailService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string link, bool isRegister)
        {

            string password = "tuvvstnrrfvgjtda";
            string fromMail = "gopal.sharma@qburst.com";
            //Configure SMTP settings using
            using (var smtpClient = new SmtpClient("smtp.gmail.com"))
            {
                string body = "";
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(fromMail, password);
                smtpClient.Port = 587;
                smtpClient.EnableSsl = true;
                if (isRegister)
                {
                    Random random = new Random();

                    // Generate a random 6-digit number
                    int randomNumber = random.Next(100000, 1000000);
                    body = await this.SendRegistrationEmail(link, randomNumber);
                    var dataRow = new UserOtp()
                    {
                        Id = Guid.NewGuid(),
                        Email = toEmail,
                        Otp = randomNumber,
                    };
                    await dbContext.UserOtp.AddAsync(dataRow);
                    await dbContext.SaveChangesAsync();
                }
                else
                {
                    body = await this.SendResetPasswordEmail(link);
                }

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

        public async Task<string> SendRegistrationEmail(string link, int otpcode)
        {
            Console.WriteLine(link);
            string body = $@"<!DOCTYPE html>
<html lang=""en"">
<head>
<meta charset=""UTF-8"">
<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
<title>Email Verification</title>
</head>
<body style=""font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px;"">
<div style=""max-width: 600px; margin: 0 auto; background-color: #ffffff; padding: 40px; border-radius: 10px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);"">
    <h2 style=""color: #333333;"">Email Verification</h2>
    <p style=""color: #666666;"">Hello,</p>
    <p style=""color: #666666;"">Thank you for registering on our website. To complete your registration, please enter the security code below to verify your email address:</p>
     <h2>Here is a your 6-digit code:</h2>
  <p style=""background-color: #f2f2f2; padding: 16px; border-radius: 5px; font-size:24px; text-align: center; letter-spacing:3"">
    <strong>{otpcode}</strong>
  </p>
    <p style=""color: #666666;"">If you have any questions or need assistance, please contact our support team at support@codepills.com.</p>
    <p style=""color: #666666;"">Thank you,<br/>The Codepills Team</p>
</div>
</body>
</html>";
            return body;
        }

        public async Task<string> SendResetPasswordEmail(string link)
        {
            string body = $@"<!DOCTYPE html>
<html lang=""en"">
<head>
<meta charset=""UTF-8"">
<meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
<title>Password Reset</title>
</head>
<body style=""font-family: Arial, sans-serif; background-color: #f4f4f4; padding: 20px;"">
<div style=""max-width: 600px; margin: 0 auto; background-color: #ffffff; padding: 40px; border-radius: 10px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);"">
    <h2 style=""color: #333333;"">Password Reset</h2>
    <p style=""color: #666666;"">You are receiving this email because a password reset request was made for your account.</p>
    <p style=""color: #666666;"">If you did not request a password reset, please ignore this email.</p>
    <p style=""color: #666666;"">To reset your password, please click the button below:</p>
    <p style=""text-align: center;"">
      <a href=""{link}"" style=""background-color: #6355D8; color: #ffffff; text-decoration: none; padding: 10px 20px; border-radius: 5px; display: inline-block;"">Reset Password</a>
    </p>
    <p style=""color: #666666;"">Alternatively, you can copy and paste the following link into your browser's address bar:</p>
    <p style=""color: #666666;"">If you have any questions or need assistance, please contact our support team at support@codepills.com.</p>
    <p style=""color: #666666;"">Thank you,<br/>The Codepills Team</p>
</div>
</body>
</html>";
            return body;
        }
    }
}

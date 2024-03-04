using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.Interface
{
    public interface IEmailService
    {
        Task SendEmailAsync(string toEmail, string subject, string link, bool isRegister);
        Task<string> SendRegistrationEmail(string link, int otp);
        Task<string> SendResetPasswordEmail(string link);
    }
}

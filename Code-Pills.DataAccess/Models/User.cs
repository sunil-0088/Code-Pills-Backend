using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.Models
{
    public class User :IdentityUser
    {
    }
    public class OtpDto
    {
        public int Otp { get; set; }
        public string Email { get; set; }
    }
}

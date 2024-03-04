using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.EntityModels
{
    public class UserOtp
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public int? Otp { get; set; }
    }
}

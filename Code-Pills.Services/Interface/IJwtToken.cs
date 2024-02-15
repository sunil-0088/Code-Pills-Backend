using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.Interface
{
    public interface IJwtToken
    {
        string CreateToken(IdentityUser user, List<string> roles);
    }
}

using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.Interface
{
    public interface IAuthRepo
    {
        Task<bool> AddPersonalInformation(string userId, string email);
    }
}

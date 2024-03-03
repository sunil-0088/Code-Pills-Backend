using Code_Pills.DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.Interface
{
    public interface IUserInfo
    {
        Task<PersonalInfo> GetPersonalInfo(string id);
    }
}

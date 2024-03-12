using Code_Pills.DataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.Interface
{
    public interface IProfileRepo
    {
        Task<string> SaveProfile(PersonalInfo profile);
        Task<PersonalInfo?> GetProfile(string userId);
        Task<string> SavePerformance(PerformanceMapping performance);
        Task<string> EditPerformance(PerformanceMapping performance);
        Task<bool> IsUserNameUnique(string userName);
    }
}

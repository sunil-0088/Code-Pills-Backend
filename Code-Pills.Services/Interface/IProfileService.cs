using Code_Pills.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.Interface
{
    public interface IProfileService
    {
        Task<string> SaveProfile(ProfileDTO profile);
        Task<string> SavePerformance(PerformanceDTO performance);
    }
}

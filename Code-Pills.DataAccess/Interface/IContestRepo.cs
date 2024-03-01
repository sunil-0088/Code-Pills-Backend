using Code_Pills.DataAccess.EntityModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.Interface
{
    public interface IContestRepo
    {
        Task<string> SaveContest(Contest contest);
        Task<string> SaveParticipation(ContestUserMapping applicant);
        Task<string> SaveContestResult(Contest results);
        Task<IEnumerable<Contest>> GetUpcomingContests();
        Task<IEnumerable<Contest>> GetRegisteredContests(string Id);
        Task<IEnumerable<Contest>> GetActiveContests(string Id);
    }
}

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
        Task<string> SaveContest(Contest contest, List<string> questions);
        Task<string> SaveParticipation(Guid contestId, string userId);
        Task<string> SaveContestResult(Contest results);
        Task<IEnumerable<Contest>> GetUpcomingContests(string userId);
        Task<IEnumerable<Contest>> GetRegisteredContests(string Id);
        Task<IEnumerable<Contest>> GetActiveContests();
        Task<IEnumerable<Contest>> GetCompletedContests(string Id);
        Task<Contest> GetContestById(Guid contestId);
    }
}

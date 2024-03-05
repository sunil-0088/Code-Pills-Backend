using Code_Pills.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.Interface
{
    public interface IContestService
    {
        Task<string> SaveContest(ContestDTO contest);
        Task<string> SaveParticipation(ContestApplicantDTO applicant);
        Task<string> SaveContestResult(ContestDTO results);
        Task<IEnumerable<ContestDTO>> GetUpcomingContests();
        Task<IEnumerable<ContestDTO>> GetRegisteredContests(string Id);
        Task<IEnumerable<ContestDTO>> GetActiveContests();
        Task<IEnumerable<ContestDTO>> GetCompletedContests(string Id);
    }
}

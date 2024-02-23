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
        Task<IEnumerable<ContestDTO>> GetContest();
        Task<IEnumerable<ContestDTO>> GetRegisteredContest(string Id);
    }
}

using AutoMapper;
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Interface;
using Code_Pills.Services.DTOs;
using Code_Pills.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.Services
{
    public class ContestService: IContestService
    {
        private readonly IContestRepo _contestRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ContestService(IContestRepo contestRepo, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _contestRepo = contestRepo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> SaveContest(ContestDTO contest)
        {
            Contest newContest = _mapper.Map<Contest>(contest);
            return await _contestRepo.SaveContest(newContest);
        }
        public async Task<string> SaveParticipation(Guid contestId)
        {
             string userId = "1234"; 
            //string userId = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            return await _contestRepo.SaveParticipation(contestId, userId);

        }
        public async Task<string> SaveContestResult(ContestDTO results)
        {
            Contest contestResult = _mapper.Map<Contest>(results);
            return await _contestRepo.SaveContestResult(contestResult);
        }
        public async Task<IEnumerable<ContestDTO>> GetUpcomingContests()
        {
            string userId = "1234";
            IEnumerable<Contest> activeContest = await _contestRepo.GetUpcomingContests(userId);
            IEnumerable<ContestDTO> contests = _mapper.Map<IEnumerable<ContestDTO>>(activeContest);
            foreach (ContestDTO contest in contests)
            {
                contest.status = "upcoming";
            }
            return contests;
        }
        public async Task<IEnumerable<ContestDTO>> GetRegisteredContests(string Id)
        {
            IEnumerable<Contest> registeredContest = await _contestRepo.GetRegisteredContests(Id);
            IEnumerable<ContestDTO> contests = _mapper.Map<IEnumerable<ContestDTO>>(registeredContest);
            foreach(ContestDTO contest in contests)
            {
                contest.status = "registered";
            }
            return contests;
        }
        public async Task<IEnumerable<ContestDTO>> GetActiveContests()
        {
            IEnumerable<Contest> registeredContest = await _contestRepo.GetActiveContests();
            IEnumerable<ContestDTO> contests = _mapper.Map<IEnumerable<ContestDTO>>(registeredContest);
            foreach (ContestDTO contest in contests)
            {
                contest.status = "active";
            }
            return contests;
        }
        public async Task<IEnumerable<ContestDTO>> GetCompletedContests(string Id)
        {
            IEnumerable<Contest> completedContest = await _contestRepo.GetCompletedContests(Id);
            IEnumerable<ContestDTO> contests = _mapper.Map<IEnumerable<ContestDTO>>(completedContest);
            foreach (ContestDTO contest in contests)
            {
                contest.status = "completed";
            }
            return contests;
        }

        public async Task<ContestDTO> GetContestById(Guid contestId)
        {
            ContestDTO contest = _mapper.Map<ContestDTO>(await _contestRepo.GetContestById(contestId));
            return contest;
        }
    }
}

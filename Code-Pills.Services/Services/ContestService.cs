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
        private readonly IJwtToken _tokenService;
        public ContestService(IContestRepo contestRepo, IMapper mapper, IJwtToken tokenService)
        {
            _contestRepo = contestRepo;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task<string> SaveContest(ContestDTO contest)
        {
            List<string> questions = contest.Questions.ToList();
            Contest newContest = _mapper.Map<Contest>(contest);
            return await _contestRepo.SaveContest(newContest, questions);
        }
        public async Task<string> SaveParticipation(Guid contestId)
        {
             string userId = _tokenService.GetUserId(); 
            return await _contestRepo.SaveParticipation(contestId, userId);

        }
        public async Task<string> SaveContestResult(ContestDTO results)
        {
            Contest contestResult = _mapper.Map<Contest>(results);
            return await _contestRepo.SaveContestResult(contestResult);
        }
        public async Task<IEnumerable<ContestDTO>> GetUpcomingContests()
        {
            string userId = _tokenService.GetUserId();
            IEnumerable<Contest> activeContest = await _contestRepo.GetUpcomingContests(userId);
            IEnumerable<ContestDTO> contests = _mapper.Map<IEnumerable<ContestDTO>>(activeContest);
            foreach (ContestDTO contest in contests)
            {
                contest.status = "upcoming";
            }
            return contests;
        }
        public async Task<IEnumerable<ContestDTO>> GetRegisteredContests()
        {
            string userId = _tokenService.GetUserId();
            IEnumerable<Contest> registeredContest = await _contestRepo.GetRegisteredContests(userId);
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
        public async Task<IEnumerable<ContestDTO>> GetCompletedContests()
        {
            string userId = _tokenService.GetUserId();
            IEnumerable<Contest> completedContest = await _contestRepo.GetCompletedContests(userId);
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

using AutoMapper;
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Interface;
using Code_Pills.Services.DTOs;
using Code_Pills.Services.Interface;
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
        public ContestService(IContestRepo contestRepo, IMapper mapper)
        {
            _contestRepo = contestRepo;
            _mapper = mapper;
        }
        public async Task<string> SaveContest(ContestDTO contest)
        {
            Contest newContest = _mapper.Map<Contest>(contest);
            return await _contestRepo.SaveContest(newContest);
        }
        public async Task<string> SaveParticipation(ContestApplicantDTO applicant)
        {
            ContestUserMapping newApplicant = _mapper.Map<ContestUserMapping>(applicant);
            return await _contestRepo.SaveParticipation(newApplicant);

        }
        public async Task<string> SaveContestResult(ContestDTO results)
        {
            Contest contestResult = _mapper.Map<Contest>(results);
            return await _contestRepo.SaveContestResult(contestResult);
        }
    }
}

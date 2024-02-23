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
    public class ProblemService: IProblemService
    {
        private readonly IProblemRepo _problemRepo;
        private readonly IMapper _mapper;

        public ProblemService(IProblemRepo problemRepo, IMapper mapper)
        {
            _problemRepo = problemRepo;
            _mapper = mapper;
        }
        public async Task<string> SaveQuestion(QuestionDTO problem)
        {
            Question newProblem = _mapper.Map<Question>(problem);
            return await _problemRepo.SaveQuestion(newProblem);
        }
        public async Task<string> SaveUserAttempt(QuestionAttemptDTO attempt)
        {
            UserQuestionMapping newAttempt = _mapper.Map<UserQuestionMapping>(attempt);
            return await _problemRepo.SaveUserAttempt(newAttempt);
        }
        public async Task<string> EditUserAttempt(QuestionAttemptDTO attempt)
        {
            UserQuestionMapping newAttempt = _mapper.Map<UserQuestionMapping>(attempt);
            return await _problemRepo.EditUserAttempt(newAttempt);
        }
    }
}

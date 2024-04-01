using AutoMapper;
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Interface;
using Code_Pills.DataAccess.Models;
using Code_Pills.Services.DTOs;
using Code_Pills.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
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
        private readonly IJwtToken _tokenService;
        public ProblemService(IProblemRepo problemRepo, IMapper mapper,IJwtToken tokenService)
        {
            _problemRepo = problemRepo;
            _mapper = mapper;
            _tokenService = tokenService;
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
        public async Task<IEnumerable<SearchQuestions>> SearchQuestions(string title)
        {
            if(title == "")
            {
                return new List<SearchQuestions>();
            }
            return await _problemRepo.SearchQuestions(title);
        }
        public async Task<IEnumerable<QuestionDTO>> GetAttemptedQuestions()
        {
            string userId = _tokenService.GetUserId();
            IEnumerable<QuestionDTO> attemptedQuestions = _mapper.Map<IEnumerable<QuestionDTO>>(await _problemRepo.GetAttemptedQuestions(userId));
            return attemptedQuestions;
        }
        public async Task<IEnumerable<QuestionDTO>> GetSolvedQuestions()
        {
            string userId = _tokenService.GetUserId();
            IEnumerable<QuestionDTO> solvedQuestions = _mapper.Map<IEnumerable<QuestionDTO>>(await _problemRepo.GetSolvedQuestions(userId));
            return solvedQuestions;
        }
        public async Task<IEnumerable<QuestionDTO>> GetIncompleteQuestions()
        {
            string userId = _tokenService.GetUserId();
            IEnumerable<QuestionDTO> incompleteQuestions = _mapper.Map<IEnumerable<QuestionDTO>>(await _problemRepo.GetIncompleteQuestions(userId));
            return incompleteQuestions;
        }
        public async Task<IEnumerable<QuestionDTO>> GetQuestionsByTags(List<int> Tags)
        {
            IEnumerable<QuestionDTO> questions = _mapper.Map<IEnumerable<QuestionDTO>>(await _problemRepo.GetQuestionsByTags(Tags));
            return questions;
        }
        public async Task<QuestionDTO> GetQuestionsById(string questionId)
        {
            QuestionDTO question = _mapper.Map<QuestionDTO>(await _problemRepo.GetQuestionsById(questionId));

            List<int> tags = await _problemRepo.GetQuestionTags(questionId);
            question.Tags = tags;

            return question;
        }

        public async Task<bool> QuestionTagMapping(List<int> tags, string questionId)
        {
           return await _problemRepo.QuestionTagMapping(tags, questionId);
        }

        public async Task<Guid> PostFeature(FeatureDTO feature)
        {
            feature.PillCount = feature.Questions.Count();
            Feature newFeature = _mapper.Map<Feature>(feature);
            return await _problemRepo.PostFeature(newFeature, feature.Questions);
        }
        public async Task<string> AddUserToFeature(Guid featureId)
        {
            string userId = _tokenService.GetUserId();
            return await _problemRepo.AddUserToFeature(featureId, userId);
        }

        public async Task<ProblemsResDTO> GetQuestions(QuestionSieveDTO questionSieveDTO)
        {
            var questionSieve = _mapper.Map<QuestionSieve>(questionSieveDTO);
            string userId = _tokenService.GetUserId();
            ProblemsRes problemsRes= await _problemRepo.GetQuestions(questionSieve);

            List<QuestionResDTO> problems = new List<QuestionResDTO>();

            foreach (var question in problemsRes.QuestionsRes)
            {
                UserQuestionMapping? userStatus=null;
                if(userId!=null)
                 userStatus = await _problemRepo
                    .GetQuestionStatus(userId, question.Id);

                problems.Add(new QuestionResDTO
                {
                    Id = question.Id,
                    Title = question.Title,
                    Status = userStatus != null ?
                    userStatus.IsSolved ? "Solved" : "Attemped" : "Not Attemped",
                    Difficulty = question.Difficulty

                });
            }

            return new ProblemsResDTO
            {
                TotalProblems = problemsRes.TotalProblems,
                QuestionRes = problems,

            };
        }

    }
}

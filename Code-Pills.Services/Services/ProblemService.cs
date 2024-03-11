using AutoMapper;
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Interface;
using Code_Pills.DataAccess.Models;
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
        public async Task<IEnumerable<SearchQuestions>> SearchQuestions(string title)
        {
            return await _problemRepo.SearchQuestions(title);
        }
        public async Task<IEnumerable<QuestionDTO>> GetAttemptedQuestions()
        {
            string userId = "1234";
            IEnumerable<QuestionDTO> attemptedQuestions = _mapper.Map<IEnumerable<QuestionDTO>>(await _problemRepo.GetAttemptedQuestions(userId));
            return attemptedQuestions;
        }
        public async Task<IEnumerable<QuestionDTO>> GetSolvedQuestions()
        {
            string userId = "1234";
            IEnumerable<QuestionDTO> solvedQuestions = _mapper.Map<IEnumerable<QuestionDTO>>(await _problemRepo.GetSolvedQuestions(userId));
            return solvedQuestions;
        }
        public async Task<IEnumerable<QuestionDTO>> GetIncompleteQuestions()
        {
            string userId = "1234";
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
            return question;
        }
    }
}

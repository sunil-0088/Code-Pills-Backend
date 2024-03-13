using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Models;
using Code_Pills.Services.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.Interface
{
    public interface IProblemService
    {
        Task<string> SaveQuestion(QuestionDTO problem);
        Task<string> SaveUserAttempt(QuestionAttemptDTO attempt);
        Task<string> EditUserAttempt(QuestionAttemptDTO attempt);
        Task<IEnumerable<SearchQuestions>> SearchQuestions(string title);
        Task<IEnumerable<QuestionDTO>> GetAttemptedQuestions();
        Task<IEnumerable<QuestionDTO>> GetSolvedQuestions();
        Task<IEnumerable<QuestionDTO>> GetIncompleteQuestions();
        Task<IEnumerable<QuestionDTO>> GetQuestionsByTags(List<int> Tags);
        Task<QuestionDTO> GetQuestionsById(string questionId);
        Task<bool> QuestionTagMapping(List<int> tags, string questionId);
        Task<string> PostFeature(FeatureDTO feature);
        Task<string> AddUserToFeature(Guid featureId);
    }
}

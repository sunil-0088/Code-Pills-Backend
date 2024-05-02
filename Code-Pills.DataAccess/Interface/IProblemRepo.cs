using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.Interface
{
    public interface IProblemRepo
    {
        Task<string> SaveQuestion(Question problem);
        Task<string> SaveUserAttempt(UserQuestionMapping attempt);
        Task<string> EditUserAttempt(UserQuestionMapping attempt);
        Task<IEnumerable<SearchQuestions>> SearchQuestions(string title);
        Task<IEnumerable<Question>> GetAttemptedQuestions(string userId);
        Task<IEnumerable<Question>> GetSolvedQuestions(string userId);
        Task<IEnumerable<Question>> GetIncompleteQuestions(string userId);
        Task<IEnumerable<Question>> GetQuestionsByTags(List<int> Tags);
        Task<Question> GetQuestionsById(string questionId);
        Task<bool> QuestionTagMapping(List<int> tags, string questionId);
        Task<Guid> PostFeature(Feature feature, List<string> questions);
        Task<string> AddUserToFeature(Guid featureId, string userId);
        Task<UserQuestionMapping?> GetQuestionStatus(string userId, string questionId);
        Task<List<int>> GetQuestionTags(string questionId);
        Task<ProblemsRes> GetQuestions(QuestionSieve questionSieve);

    }
}

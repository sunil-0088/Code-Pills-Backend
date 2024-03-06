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
    }
}

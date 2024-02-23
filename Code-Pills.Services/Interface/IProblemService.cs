using Code_Pills.DataAccess.EntityModels;
using Code_Pills.Services.DTOs;
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
    }
}

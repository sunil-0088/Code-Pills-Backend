using Code_Pills.DataAccess.Context;
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.Repositories
{
    public class ProblemRepo: IProblemRepo
    {

        private readonly ApplicationDbContext _dbContext;

        public ProblemRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> SaveQuestion(Question problem)
        {
            try
            {
                await _dbContext.Questions.AddAsync(problem);
                await _dbContext.SaveChangesAsync();
                return "Problem Added Successfully";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public async Task<string> SaveUserAttempt(UserQuestionMapping attempt)
        {
            try
            {
                Question question = await _dbContext.Questions
                    .Where(q => q.Id == attempt.QuestionId).FirstAsync();

                PerformanceMapping performance = await _dbContext.PerformanceMappings
                    .Where(user => user.UserId == attempt.UserId)
                    .FirstAsync();
                performance.Attempts = performance.Attempts + 1; 
                question.Attempts = question.Attempts + 1;
                if(attempt.IsSolved)
                {
                    performance.TotalCredits = performance.TotalCredits + question.Credits;
                    performance.CreditsLeft = performance.CreditsLeft + question.Credits;
                    performance.Solved = performance.Solved + 1;
                    question.Submissions = question.Submissions + 1;
                }
                await _dbContext.UserQuestionMappings.AddAsync(attempt);
                await _dbContext.SaveChangesAsync();
                return "Attempt Added Succesfully";
            }
            catch(Exception ex)
            {
                return "";
            }
        }
        public async Task<string> EditUserAttempt(UserQuestionMapping newAttempt)
        {
            try
            {
                UserQuestionMapping previousAttempt = await _dbContext.UserQuestionMappings.FirstOrDefaultAsync(map => map.UserId == newAttempt.UserId && map.QuestionId == newAttempt.QuestionId);

                if(previousAttempt != null)
                {
                    PerformanceMapping performance = await _dbContext.PerformanceMappings
                    .Where(user => user.UserId == newAttempt.UserId)
                    .FirstAsync();

                    Question question = await _dbContext.Questions
                        .Where(q => q.Id == newAttempt.QuestionId)
                        .FirstAsync();

                    previousAttempt.Solution = newAttempt.Solution;
                    question.Attempts = question.Attempts + 1;
                    performance.Attempts = performance.Attempts + 1;

                    if (previousAttempt.IsSolved == false && newAttempt.IsSolved)
                    {
                        previousAttempt.IsSolved = true;
                        performance.TotalCredits = performance.TotalCredits + question.Credits;
                        performance.CreditsLeft = performance.CreditsLeft + question.Credits;
                    }
                    if (newAttempt.IsSolved)
                    {
                        performance.Solved = performance.Solved + 1;
                        question.Submissions = question.Submissions + 1;
                    }
                    await _dbContext.SaveChangesAsync();
                    return "Attempt Edited Succesfully";
                }
                else
                {
                    return await SaveUserAttempt(newAttempt);
                }
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}

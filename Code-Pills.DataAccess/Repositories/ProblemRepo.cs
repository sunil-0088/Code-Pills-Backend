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
                UserQuestionMapping previousAttempt = await _dbContext.UserQuestionMappings.FirstOrDefaultAsync(map => map.PersonalInfoId == newAttempt.PersonalInfoId && map.QuestionId == newAttempt.QuestionId);
                previousAttempt.IsSolved = newAttempt.IsSolved;
                previousAttempt.Solution = newAttempt.Solution;
                await _dbContext.SaveChangesAsync();
                return "Attempt Edited Succesfully";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}

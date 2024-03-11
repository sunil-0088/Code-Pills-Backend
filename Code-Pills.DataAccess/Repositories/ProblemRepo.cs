using Code_Pills.DataAccess.Context;
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Interface;
using Code_Pills.DataAccess.Models;
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
        public async Task<IEnumerable<SearchQuestions>> SearchQuestions(string title)
        {
            try
            {
                title = title.ToLower();
                IEnumerable<SearchQuestions> matchingSearches = await _dbContext.Questions
                        .Where(q => q.Title.ToLower().Contains(title))
                        .Select(q => new SearchQuestions { Id = q.Id, Title = q.Title, Difficulty = q.Difficulty })
                        .ToListAsync();
                if (matchingSearches == null)
                {
                    return null;
                }
                return matchingSearches;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<Question>> GetAttemptedQuestions(string userId)
        {
            try
            {
                IEnumerable<Question> attemptedQuestions = await (
                        from question in _dbContext.Questions
                        join mapping in _dbContext.UserQuestionMappings
                        on question.Id equals mapping.QuestionId
                        where mapping.UserId == userId
                        select question
                    ).ToListAsync();
                return attemptedQuestions;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<Question>> GetSolvedQuestions(string userId)
        {
            try
            {
                IEnumerable<Question> solvedQuestions = await (
                        from question in _dbContext.Questions
                        join mapping in _dbContext.UserQuestionMappings
                        on question.Id equals mapping.QuestionId
                        where mapping.UserId == userId && mapping.IsSolved == true
                        select question
                    ).ToListAsync();
                return solvedQuestions;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<Question>> GetIncompleteQuestions(string userId)
        {
            try
            {
                IEnumerable<Question> incompleteQuestions = await (
                        from question in _dbContext.Questions
                        join mapping in _dbContext.UserQuestionMappings
                        on question.Id equals mapping.QuestionId
                        where mapping.UserId == userId && mapping.IsSolved == false
                        select question
                    ).ToListAsync();
                return incompleteQuestions;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<Question>> GetQuestionsByTags(List<int> Tags)
        {
            try
            {
                IEnumerable<Question> Questions = await (
                        from question in _dbContext.Questions
                        join tags in _dbContext.QuestionTagMappings
                        on question.Id equals tags.QuestionId
                        where Tags.Contains(tags.TagId)
                        select question
                    ).Distinct().ToListAsync();
                return Questions;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Question> GetQuestionsById(string questionId)
        {
            try
            {
                Question? question = await _dbContext.Questions
                    .Where(q => q.Id == questionId).FirstOrDefaultAsync();
                if(question == null)
                {
                    return null;
                }
                return question;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

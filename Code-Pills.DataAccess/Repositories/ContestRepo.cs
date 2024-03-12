using Code_Pills.DataAccess.Context;
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.Repositories
{
    public class ContestRepo: IContestRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public ContestRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> SaveContest(Contest contest, List<string> questions)
        {
            try
            {
                await _dbContext.Contests.AddAsync(contest);
                await _dbContext.SaveChangesAsync();
                await SaveContestQuestions(questions, contest.Id);
                return "Contest Created Successfully";
            }
            catch(Exception ex)
            {
                return ""; 
            }
        }

        public async Task<bool> SaveContestQuestions(List<string> questions, Guid contestId)
        {
            try
            {
                foreach (string question in questions)
                {
                    await  _dbContext.ContestQuestionMappings.AddAsync(new ContestQuestionMapping
                    {
                        ContestId = contestId,
                        QuestionId = question,
                    });
                    await _dbContext.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<string> SaveParticipation(Guid contestId, string userId)
        {
            try
            {
                Contest contest = await _dbContext.Contests.Where(c => c.Id == contestId).FirstOrDefaultAsync();
                contest.Attendees += 1;
                await _dbContext.ContestUserMappings.AddAsync(
                    new ContestUserMapping
                    {
                        UserId = userId,
                        ContestId = contestId,
                        TotalPoints = 0,
                        Status = "registered"
                    });
                await _dbContext.SaveChangesAsync();
                return "Participation Saved Successfully";
            }
            catch(Exception ex)
            {
                return "";
            }
        }
        public async Task<string> SaveContestResult(Contest results)
        {
            try
            {
                Contest? contest = await _dbContext.Contests.FirstOrDefaultAsync(c => c.Id == results.Id);
                contest.Winner1 = results.Winner1;
                contest.Winner2 = results.Winner2;
                contest.Winner3 = results.Winner3;
                await _dbContext.SaveChangesAsync();
                return "Results Saved Successfully";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public async Task<IEnumerable<Contest>> GetUpcomingContests(string userId)
        {
            try
            {
                List<Guid> registeredContestIds = await _dbContext.ContestUserMappings
                    .Where(c => c.Status == "registered").Select(c => c.ContestId).ToListAsync();

                IEnumerable<Contest> activeContest = await _dbContext.Contests
                    .Where(contest => contest.StartTime.Date > DateTime.Now.Date && !registeredContestIds.Contains(contest.Id)).ToListAsync();
                return activeContest;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<Contest>> GetRegisteredContests(string Id)
        {
            try
            {
                List<Guid> registerdContestIds = await _dbContext.ContestUserMappings.Where(user => user.UserId == Id && user.Status == "registered")
                    .Select(contest => contest.ContestId).ToListAsync();
                List<Contest> registerdContests = new List<Contest>();
                if (registerdContestIds.Count > 0)
                {
                    foreach (Guid contestId in registerdContestIds)
                    {
                        registerdContests.Add(await _dbContext.Contests
                           .Where(contest => contest.Id == contestId && contest.StartTime > DateTime.Now)
                           .FirstAsync());
                    }
                }
                return registerdContests;
            }catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<Contest>> GetActiveContests()
        {
            try
            {
                List<Contest> activeContests = new List<Contest>();
                foreach (Contest contest in _dbContext.Contests)
                {
                    if (contest.StartTime < DateTime.Now && contest.StartTime.AddMinutes(20) >= DateTime.Now)
                    {
                        activeContests.Add(contest);
                    }
                }
                return activeContests; ;
            }
            catch(Exception ex)
            {
                return null;

            }
        }
        public async Task<IEnumerable<Contest>> GetCompletedContests(string Id)
        {
            try
            {
                List<Guid> completedContestIds = await _dbContext.ContestUserMappings.Where(user => user.UserId == Id && user.Status == "completed")
                    .Select(contest => contest.ContestId).ToListAsync();
                List<Contest> completedContests = new List<Contest>();
                if (completedContestIds.Count > 0)
                {
                    foreach (Guid contestId in completedContestIds)
                    {
                        completedContests.Add(await _dbContext.Contests
                           .Where(contest => contest.Id == contestId && contest.StartTime > DateTime.Now)
                           .FirstAsync());
                    }
                }
                return completedContests;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Contest> GetContestById(Guid contestId)
        {
            try
            {
                Contest? contest =  await _dbContext.Contests.Where(c => c.Id == contestId).FirstOrDefaultAsync();
                if(contest == null)
                {
                    return null;
                }
                return contest;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}

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
        public async Task<string> SaveContest(Contest contest)
        {
            try
            {
                await _dbContext.Contests.AddAsync(contest);
                await _dbContext.SaveChangesAsync();
                return "Contest Created Successfully";
            }
            catch(Exception ex)
            {
                return ""; 
            }
        }
        public async Task<string> SaveParticipation(ContestUserMapping applicant)
        {
            try
            {
                applicant.TotalPoints = 0;
                Guid contestId = applicant.ContestId;
                Contest? contest = await _dbContext.Contests.FirstOrDefaultAsync(contest => contest.Id == contestId);
                contest.Attendees = contest.Attendees + 1;
                await _dbContext.ContestUserMappings.AddAsync(applicant);
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
        public async Task<IEnumerable<Contest>> GetUpcomingContests()
        {
            try
            {
                IEnumerable<Contest> activeContest = await _dbContext.Contests
                    .Where(contest => contest.StartTime.Date > DateTime.Now.Date).ToListAsync();
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
                    if (contest.StartTime < DateTime.Now && contest.StartTime.AddMinutes(20) <= DateTime.Now)
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
    }
}

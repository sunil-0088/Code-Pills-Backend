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
                Contest contest = await _dbContext.Contests.FirstOrDefaultAsync(contest => contest.Id == contestId);
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
                    .Where(contest => contest.StartTime > DateTime.Now).ToListAsync();
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
                List<Guid> registerdContestIds = await _dbContext.ContestUserMappings.Where(user => user.UserId == Id)
                    .Select(contest => contest.ContestId).ToListAsync();
                IEnumerable<Contest> registerdContests = new List<Contest>();
                if (registerdContestIds.Count > 0)
                {
                    List<Contest> registerdContest = new List<Contest>();
                    foreach (Guid contestId in registerdContestIds)
                    {
                        registerdContest.Add(await _dbContext.Contests
                           .Where(contest => contest.Id == contestId)
                           .FirstAsync());
                    }
                    registerdContests = registerdContest;
                }
                return registerdContests;
            }catch(Exception ex)
            {
                return null;
            }
        }
        public async Task<IEnumerable<Contest>> GetActiveContests(string Id)
        {
            try
            {
                IEnumerable<Guid> registeredContestIds = await _dbContext.ContestUserMappings
                .Where(applicants => applicants.UserId == Id).Select(application => application.ContestId).ToListAsync();

                IEnumerable<Contest>? activeContests = null;
                if(registeredContestIds == null)
                {
                    return activeContests;
                }
                else
                {
                    List<Contest> contestList = new List<Contest>();
                    foreach (Guid contestId in registeredContestIds)
                    {
                        Contest? contest = await _dbContext.Contests.Where(contest => contest.Id == contestId && contest.StartTime < DateTime.Now && contest.EndTime > DateTime.Now).FirstOrDefaultAsync();
                        if (contest != null)
                        {
                            contestList.Add(contest);
                        }
                    }
                    activeContests = contestList;
                    return activeContests;
                }
            }
            catch(Exception ex)
            {
                return null;

            }
        }
    }
}

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
        public async Task<IEnumerable<Contest>> GetContest()
        {
            IEnumerable<Contest> activeContest = await _dbContext.Contests
                .Where(contest => contest.StartTime > DateTime.Now).ToListAsync();
            return activeContest;
        }
        public async Task<IEnumerable<Contest>> GetRegisteredContest(string Id)
        {
            IEnumerable<Guid> registeredContestIds = await _dbContext.ContestUserMappings
                .Where(applicants => applicants.PersonalInfoId == Id).Select(application => application.ContestId).ToListAsync();

            IEnumerable<Contest>? registeredContests = null;
            if(registeredContestIds == null)
            {
                return registeredContests;
            }
            try
            {
                List<Contest> contestList = new List<Contest>();
                foreach (Guid id in registeredContestIds)
                {
                    contestList.Add(await _dbContext.Contests.Where(contest => contest.Id == id).FirstOrDefaultAsync());
                }
                registeredContests = contestList;
                return registeredContests;
            }
            catch(Exception ex)
            {
                return registeredContests;

            }
        }
    }
}

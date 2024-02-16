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
                PersonalInfo? user = await _dbContext.PersonalInformation.FirstOrDefaultAsync(u => u.Id == applicant.PersonalInfo.Id);
                user.ContestUserMapping.Add(applicant);
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
    }
}

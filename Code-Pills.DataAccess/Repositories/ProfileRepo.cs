using Code_Pills.DataAccess.Context;
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Interface;
using Code_Pills.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Code_Pills.DataAccess.Repositories
{
    public class ProfileRepo: IProfileRepo
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProfileRepo(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> SaveProfile(PersonalInfo profile)
        {
            try
            {
                PersonalInfo? user=await _dbContext.PersonalInformation
                                   .FirstOrDefaultAsync(user=>user.Id==profile.Id);

                if (user!=null)
                {
                    user.Name = profile.Name;
                    user.Skills = profile.Skills;
                    user.About=profile.About;
                    user.DOB = profile.DOB;
                    user.Email = profile.Email;
                    user.Profession = profile.Profession;
                    user.Gender = profile.Gender;
                    user.UserName = profile.UserName;
                    await _dbContext.SaveChangesAsync();
                    return "Profile Update Successfully";
                }
                else
                {
                    await _dbContext.PersonalInformation.AddAsync(profile);
                    await _dbContext.SaveChangesAsync();
                    return "Profile Saved Successfully";
                }
               
            }
            catch(Exception Ex)
            {
                return Ex.Message;
            }
        }
        public async Task<PersonalInfo?> GetProfile(string userId)
        {
            return await _dbContext.PersonalInformation.FirstOrDefaultAsync(user => user.Id == userId);
        }
        public async Task<string> SavePerformance(PerformanceMapping performance)
        {
            try
            {
                await _dbContext.PerformanceMappings.AddAsync(performance);
                await _dbContext.SaveChangesAsync();
                return "Performance Saved Successfully";
            }
            catch (Exception Ex)
            {
                return "";
            }
        }
        public async Task<string> EditPerformance(PerformanceMapping performance)
        {
            try
            {
                PerformanceMapping previousPerformance = await _dbContext.PerformanceMappings.FirstOrDefaultAsync(user => user.UserId == performance.UserId);
                previousPerformance = performance;
                await _dbContext.SaveChangesAsync();
                return "Performance Edited Succesfully";
            }
            catch(Exception Ex)
            {
                return "";
            }
        }

        public async Task<bool> IsUserNameUnique(string userName)
        {
            var userIdClaim = httpContextAccessor.HttpContext?.User.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userIdClaim != null)
            {
                bool isTaken = await _dbContext.PersonalInformation.AnyAsync(user => user.UserName == userName && user.Id != userIdClaim.ToString());
                return isTaken;
            }
            else
            {
                return false;
            }
            
        }

        public async Task<IEnumerable<GlobalRank>> GetGlobalRanks()
        {
            try
            {
                List<GlobalRank> ranks = new List<GlobalRank>();
                var query = from personalInfo in _dbContext.PersonalInformation
                             join performace in _dbContext.PerformanceMappings
                             on personalInfo.Id equals performace.UserId
                             select new GlobalRank
                             {
                                 UserId = personalInfo.Id,
                                 UserName = personalInfo.UserName,
                                 Credits = performace.TotalCredits,
                                 Rating = performace.Rating,
                                 Accuracy = (performace.Solved / performace.Attempts) * 100,
                             };
                query = query.OrderByDescending(x => x.Credits)
                 .ThenByDescending(x => x.Rating)
                 .ThenByDescending(x => x.Accuracy);

                ranks.AddRange(query);

                return ranks;
            }
            catch(Exception ex)
            {
                return new List<GlobalRank>();
            }
        }

        public async Task<PerformanceMapping> GetProfileStats(string userId)
        {
            try
            {
                PerformanceMapping? profile = await _dbContext.PerformanceMappings.Where(p => p.UserId == userId).FirstOrDefaultAsync();
                return profile;
            }
            catch (Exception ex)
            {
                return new PerformanceMapping();
            }
        }

        public async Task<UserReport> GetUserReport(string userId)
        {
            try
            {
                UserReport report = new UserReport
                {
                    EasyCount = new List<int>(Enumerable.Repeat(0, 12)),
                    MediumCount = new List<int>(Enumerable.Repeat(0, 12)),
                    HardCount = new List<int>(Enumerable.Repeat(0, 12))
                };

                List<UserQuestionMapping> mappings = await _dbContext.UserQuestionMappings
                    .Where(map => map.UserId == userId)
                    .Include(map => map.Question)
                    .ToListAsync();

                foreach (var mapping in mappings)
                {
                    int month = mapping.Date.Month;

                    string difficulty = mapping.Question.Difficulty;

                    switch (difficulty)
                    {
                        case "easy":
                            report.EasyCount[month - 1]++;
                            break;
                        case "medium":
                            report.MediumCount[month - 1]++;
                            break;
                        case "hard":
                            report.HardCount[month - 1]++;
                            break;
                        default:
                            break;
                    }
                    if (mapping.IsSolved)
                    {
                        int combinedKey = (mapping.Date.Month * 100) + mapping.Date.Day;
                        if (report.DayCount.ContainsKey(combinedKey))
                        {
                            report.DayCount[combinedKey]++;
                        }
                        else
                        {
                            report.DayCount[combinedKey] = 1;
                        }
                    }
                }

                return report;

            }
            catch(Exception ex)
            {
                return null;
            }
        }

    }
}

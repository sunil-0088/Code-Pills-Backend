using Code_Pills.DataAccess.Context;
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Code_Pills.DataAccess.Repositories
{
    public class ProfileRepo: IProfileRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public ProfileRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> SaveProfile(PersonalInfo profile)
        {
            try
            {
                await _dbContext.PersonalInformation.AddAsync(profile);
                await _dbContext.SaveChangesAsync();
                return "Profile Saved Successfully";
            }
            catch(Exception Ex)
            {
                return "";
            }
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
                PerformanceMapping previousPerformance = await _dbContext.PerformanceMappings.FirstOrDefaultAsync(user => user.PersonalInfoId == performance.PersonalInfoId);
                previousPerformance = performance;
                await _dbContext.SaveChangesAsync();
                return "Performance Edited Succesfully";
            }
            catch(Exception Ex)
            {
                return "";
            }
        }
    }
}

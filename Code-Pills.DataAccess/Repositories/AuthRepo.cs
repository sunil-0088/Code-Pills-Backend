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
    public class AuthRepo : IAuthRepo
    {
        private readonly ApplicationDbContext dbContext;

        public AuthRepo(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> AddPersonalInformation(string userId, string email, string username)
        {
            var dataRow = new PersonalInfo()
            {
                Id = userId,
                UserName = username,
                Email = email,
                DOB=DateTime.Now
            };
            await dbContext.PersonalInformation.AddAsync(dataRow);
            await dbContext.SaveChangesAsync();
            return true;
            
        }

      

    }
}

using Code_Pills.DataAccess.Context;
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

namespace Code_Pills.DataAccess.Repositories
{
    public class UserInfoRepo:IUserInfo
    {
        private readonly ApplicationDbContext _dbContext;

        public UserInfoRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PersonalInfo> GetPersonalInfo(string id)
        {
            return await _dbContext.PersonalInformation.FirstOrDefaultAsync(user => user.Id == id);

            
        }
    }
}

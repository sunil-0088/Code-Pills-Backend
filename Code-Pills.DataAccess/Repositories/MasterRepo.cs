using Code_Pills.DataAccess.Context;
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;

namespace Code_Pills.DataAccess.Repositories
{
    public class MasterRepo : IMasterRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public MasterRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Language>> GetLanguages()
        {
            try
            {
              return await  _dbContext.Languages.ToListAsync();
            }
            catch
            {
                return new List<Language>();
            }
        }

        public async Task<List<Tag>> GetTags()
        {
            try
            {
                return await _dbContext.Tags.ToListAsync();
            }
            catch
            {
                return new List<Tag>();
            }
        }
    }
}

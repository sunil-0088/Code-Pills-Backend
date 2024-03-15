using Code_Pills.DataAccess.Context;
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.DataAccess.Repositories
{
    public class HomeRepo: IHomeRepo
    {
        private readonly ApplicationDbContext _dbContext;

        public HomeRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Feature>> GetAllFeatures()
        {
            try
            {
                IEnumerable<Feature> features = await _dbContext.Featured.ToListAsync();
                return features;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

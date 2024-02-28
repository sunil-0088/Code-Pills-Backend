using Code_Pills.DataAccess.Context;
using Code_Pills.DataAccess.Interface;
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
    }
}

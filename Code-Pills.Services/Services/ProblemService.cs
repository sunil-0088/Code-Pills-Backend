using Code_Pills.DataAccess.Interface;
using Code_Pills.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.Services
{
    public class ProblemService: IProblemService
    {
        private readonly IProblemRepo _problemRepo;

        public ProblemService(IProblemRepo problemRepo)
        {
            _problemRepo = problemRepo;
        }
    }
}

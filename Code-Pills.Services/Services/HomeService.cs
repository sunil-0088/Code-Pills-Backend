using Code_Pills.DataAccess.Interface;
using Code_Pills.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.Services
{
    public class HomeService: IHomeService
    {
        private readonly IHomeRepo _homeRepo;

        public HomeService(IHomeRepo homeRepo)
        {
            _homeRepo = homeRepo;
        }
    }
}

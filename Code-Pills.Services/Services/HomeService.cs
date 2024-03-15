using AutoMapper;
using Code_Pills.DataAccess.Interface;
using Code_Pills.Services.DTOs;
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
        private readonly IMapper _mapper;
        public HomeService(IHomeRepo homeRepo, IMapper mapper)
        {
            _homeRepo = homeRepo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FeatureDTO>> GetAllFeatures()
        {
            IEnumerable<FeatureDTO> features = _mapper.Map<IEnumerable<FeatureDTO>>(await _homeRepo.GetAllFeatures());
            return features;
        }
    }
}

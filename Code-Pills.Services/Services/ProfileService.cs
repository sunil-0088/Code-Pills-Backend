using AutoMapper;
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Interface;
using Code_Pills.Services.DTOs;
using Code_Pills.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.Services
{
    public class ProfileService: IProfileService
    {
        private readonly IProfileRepo _profileRepo;
        private readonly IMapper _mapper;
        private readonly IJwtToken _tokenService;

        public ProfileService(IProfileRepo profileRepo, IMapper mapper, IJwtToken tokenService)
        {
            _profileRepo = profileRepo;
            _mapper = mapper;
            _tokenService = tokenService;
            _tokenService = tokenService;
        }
        public async Task<string> SaveProfile(ProfileDTO profile)
        {
            PersonalInfo newProfile = _mapper.Map<PersonalInfo>(profile);
            return await _profileRepo.SaveProfile(newProfile);
        }
        public async Task<ProfileDTO?> GetProfile()
        {
            string userId = _tokenService.GetUserId();
            PersonalInfo personalInfo= await _profileRepo.GetProfile(userId);
            ProfileDTO userInfo = _mapper.Map < ProfileDTO >(personalInfo);
            return userInfo;
        }
        public async Task<string> SavePerformance(PerformanceDTO performance)
        {
            PerformanceMapping userPerformance = _mapper.Map<PerformanceMapping>(performance);
            return await _profileRepo.SavePerformance(userPerformance);
        }
        public async Task<string> EditPerformance(PerformanceDTO performance)
        {
            PerformanceMapping userPerformance = _mapper.Map<PerformanceMapping>(performance);
            return await _profileRepo.EditPerformance(userPerformance);
        }

        public async Task<bool> IsUserNameTaken(string userName)
        {
            return await _profileRepo.IsUserNameUnique(userName);
        }

    }
}

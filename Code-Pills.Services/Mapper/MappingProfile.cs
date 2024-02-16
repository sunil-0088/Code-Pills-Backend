using AutoMapper;
using Code_Pills.DataAccess.EntityModels;
using Code_Pills.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<ContestDTO, Contest>();
            CreateMap<ProfileDTO, PersonalInfo>();
            CreateMap<PerformanceDTO, PerformanceMapping>()
                .ForMember(dest => dest.PersonalInfoId, opt => opt.MapFrom(src => src.UserID));
            CreateMap<ContestApplicantDTO, ContestUserMapping>()
                .ForPath(dest => dest.PersonalInfo.Id, opt => opt.MapFrom(src => src.UserId));
        }
    }
}

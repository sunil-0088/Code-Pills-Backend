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
            CreateMap<Contest, ContestDTO>();
            CreateMap<ProfileDTO, PersonalInfo>();
            CreateMap<PersonalInfo, ProfileDTO>();
            CreateMap<PerformanceDTO, PerformanceMapping>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserID));
            CreateMap<ContestApplicantDTO, ContestUserMapping>()
                .ForPath(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
            CreateMap<QuestionDTO, Question>();
            CreateMap<QuestionAttemptDTO, UserQuestionMapping>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId));
        }
    }
}

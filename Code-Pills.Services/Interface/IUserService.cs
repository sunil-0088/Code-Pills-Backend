using Code_Pills.DataAccess.EntityModels;
using Code_Pills.DataAccess.Models;
using Code_Pills.Services.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Pills.Services.Interface
{
    public interface IUserService
    {
        Task<bool> AddPersonalInformation(string userId, string email);
        Task<Object> VerifyEmailAsync(string userId, string token);
        Task<bool> MarkEmailConfirm(IdentityUser user);
        Task<LoginResponseDto> VerifyOtp(VerifyOtpDto req);
        Task<string> GenerateUniqueUserName(string email);
    }
}
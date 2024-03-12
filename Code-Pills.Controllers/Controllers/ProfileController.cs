using Code_Pills.Services.DTOs;
using Code_Pills.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Code_Pills.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProfileController(IProfileService profileService,IHttpContextAccessor httpContextAccessor) 
        {
            _profileService = profileService;
            _httpContextAccessor = httpContextAccessor;
            //Console.WriteLine(HttpContext.User.Identity.IsAuthenticated);
           
        }

        [HttpPost("PersonalInfo")]
        public async Task<IActionResult> SaveProfile(ProfileDTO profile)
        {
            try {
                string msg = await _profileService.SaveProfile(profile);

                return Ok(new
                {
                    message = msg
                });
            }
            catch(Exception ex) {
                return BadRequest(ex.Message);
            }

        }
       
        [HttpGet("PersonalInfo")]
        [Authorize]
        public async Task<IActionResult> GetProfile(string userId)
        {
            try
            {
                ProfileDTO? user = await _profileService.GetProfile(userId);
                if(user == null)
                {
                    return BadRequest("User not Found");
                }
                else
                {
                     return Ok(user);
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("UserPerformance")]
        public async Task<IActionResult> SavePerformance(PerformanceDTO performance)
        {
            return Ok(await _profileService.SavePerformance(performance));
        }
        [HttpPut("UserPerformance")]
        public async Task<IActionResult> EditPerformance(PerformanceDTO performance)
        {
            return Ok(await _profileService.EditPerformance(performance));
        }

        // Check for unique userName

        [HttpGet("check-username")]
        public async Task<IActionResult> CheckUsername(string username)
        {
            // Check if the username is taken in your database or any other storage
            bool isTaken =await _profileService.IsUserNameTaken(username);
            return Ok(isTaken);
        }

    }
}

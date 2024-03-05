using Code_Pills.Services.DTOs;
using Code_Pills.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Code_Pills.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService) 
        {
            _profileService = profileService;
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
    }
}

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
            return Ok(await _profileService.SaveProfile(profile));
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

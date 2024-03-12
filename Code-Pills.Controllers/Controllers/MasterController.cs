using Code_Pills.Services.DTOs;
using Code_Pills.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Code_Pills.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterService _masterService;

        public MasterController(IMasterService masterService)
        {
            _masterService = masterService;
        }
        [HttpGet("GetLanguages")]
        public async Task<IActionResult> getLanguages()
        {
            try
            {
                List<LanguageDTO> languages= await _masterService.GetLanguages();

                return Ok(languages);

            }
            catch
            {
                return BadRequest("Languages Not Found");
            }
        }

        [HttpGet("GetTags")]
        public async Task<IActionResult> getTags()
        {
            try
            {
                List<TagDTO> tags = await _masterService.GetTags();

                return Ok(tags);

            }
            catch
            {
                return BadRequest("Tags Not Found");
            }
        }

    }
}

using Code_Pills.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Code_Pills.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController: ControllerBase
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        [HttpGet("GetAllFeatures")]
        public async Task<IActionResult> GetAllFeatures()
        {
            return Ok(new
            {
                features = await _homeService.GetAllFeatures()
            });
        }
    }
}

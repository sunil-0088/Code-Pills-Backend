
using Code_Pills.Services.DTOs;
using Code_Pills.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Code_Pills.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemsController: ControllerBase
    {
        private readonly IProblemService _problemService;
        public ProblemsController(IProblemService problemService) 
        { 
            _problemService = problemService;
        }
        [HttpPost("Question")]
        public async Task<IActionResult> SaveQuestion(QuestionDTO question)
        {
            return Ok(await _problemService.SaveQuestion(question));
        }
        //[HttpPut("Question")]
        //public async Task<IActionResult> EditQuestion(QuestionDTO question)
        //{

        //}
        [HttpPost("AddUserAttempt")]
        public async Task<IActionResult> SaveUserAttempt(QuestionAttemptDTO question)
        {
            return Ok(await _problemService.SaveUserAttempt(question));
        }
        [HttpPut("EditUserAttempt")]
        public async Task<IActionResult> EditUserAttempt(QuestionAttemptDTO question)
        {
            return Ok(await _problemService.EditUserAttempt(question));
        }
    }
}

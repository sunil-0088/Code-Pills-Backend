using Code_Pills.Services.DTOs;
using Code_Pills.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Code_Pills.Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContestController: ControllerBase
    {
        private readonly IContestService _contestSerivce;
        public ContestController(IContestService contestSerivce) 
        {
            _contestSerivce = contestSerivce;
        }

        [HttpPost("Contest")]
        public async Task<IActionResult> SaveContest(ContestDTO contest)
        {
            return Ok(await _contestSerivce.SaveContest(contest));
        }

        [HttpPost("AddToContest")]
        public async Task<IActionResult> SaveParticipation(ContestApplicantDTO applicant)
        {
            return Ok(await _contestSerivce.SaveParticipation(applicant));
        }

        [HttpPut("ContestResult")]
        public async Task<IActionResult> SaveContestResult(ContestDTO results)
        {
            return Ok(await _contestSerivce.SaveContestResult(results));
        }

        [HttpGet("UpcomingContests")]
        public async Task<IActionResult> GetUpcomingContests()
        {
            return Ok(await _contestSerivce.GetUpcomingContests());
        }

        [HttpGet("RegisteredContests")]
        public async Task<IActionResult> GetRegisteredContests(string userId)
        {
            return Ok(await _contestSerivce.GetRegisteredContests(userId));
        }

        [HttpGet("ActiveContests")]
        public async Task<IActionResult> GetActiveContesst(string userId)
        {
            return Ok(await _contestSerivce.GetActiveContests(userId));
        }

    }
}

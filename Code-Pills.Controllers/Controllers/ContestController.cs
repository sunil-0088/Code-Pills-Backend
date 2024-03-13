using Code_Pills.DataAccess.Models;
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

        [HttpPost("AddContest")]
        public async Task<IActionResult> SaveContest(ContestDTO contest)
        {
            return Ok( new {
                id = await _contestSerivce.SaveContest(contest)
                });
        }

        [HttpPost("AddToContest")]
        public async Task<IActionResult> SaveParticipation(Guid contestId)
        {
            return Ok(await _contestSerivce.SaveParticipation(contestId));
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
        public async Task<IActionResult> GetRegisteredContests()
        {
            return Ok(await _contestSerivce.GetRegisteredContests());
        }

        [HttpGet("ActiveContests")]
        public async Task<IActionResult> GetActiveContests()
        {
            return Ok(await _contestSerivce.GetActiveContests());
        }

        [HttpGet("CompletedContests")]
        public async Task<IActionResult> GetCompletedContests()
        {
            return Ok(await _contestSerivce.GetCompletedContests());
        }
        [HttpGet("ContestById")]
        public async Task<IActionResult> GetContestById(Guid contestId)
        {

            return Ok(await _contestSerivce.GetContestById(contestId));
        }

    }
}

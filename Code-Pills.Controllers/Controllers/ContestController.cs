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
        /*        [HttpPut("UserResult")]
                public async Task<IActionResult> SaveUserResult(ContestApplicantDTO applicant)
                {
                    return Ok(_contestSerivce.SaveUserResults(applicant));
                }*/
        [HttpGet("Contest")]
        public async Task<IActionResult> GetContest()
        {
            return Ok(await _contestSerivce.GetContest());
        }
        [HttpGet("RegisteredContest")]
        public async Task<IActionResult> GetRegisteredContest(string userId)
        {
            return Ok(await _contestSerivce.GetRegisteredContest(userId));
        }

    }
}

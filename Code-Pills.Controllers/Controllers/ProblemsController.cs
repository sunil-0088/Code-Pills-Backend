
using Code_Pills.DataAccess.EntityModels;
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
        private readonly IHttpContextAccessor httpContextAccessor;

        public ProblemsController(IProblemService problemService, IHttpContextAccessor httpContextAccessor) 
        { 
            _problemService = problemService;
            this.httpContextAccessor = httpContextAccessor;
            var userClaims = httpContextAccessor.HttpContext?.User.Claims;
        }
        [HttpPost("Question")]
        public async Task<IActionResult> SaveQuestion(QuestionDTO question)
        {
            try
            {
                var msg = await _problemService.SaveQuestion(question);
                 bool isMapped=await _problemService.QuestionTagMapping(question.Tags,question.Id);

                if (!isMapped)
                {
                   return  BadRequest("Upable to map Question with Tags");
                }
                    return Ok( new
                    {
                        message = msg
                    });

            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
        [HttpGet("SearchQuestions")]
        public async Task<IActionResult> SearchQuestions(string title)
        {
            if(title == null)
            {
                return Ok();
            }
            return Ok(await  _problemService.SearchQuestions(title));
        }
        [HttpGet("AttemptedQuestions")]
        public async Task<IActionResult> GetAttemptedQuestions()
        {
            return Ok(await _problemService.GetAttemptedQuestions());
        }
        [HttpGet("SolvedQuestions")]
        public async Task<IActionResult> GetSolvedQuestions()
        {
            return Ok(await _problemService.GetSolvedQuestions());
        }
        [HttpGet("IncompleteQuestions")]
        public async Task<IActionResult> GetIncompleteQuestions()
        {
            return Ok(await _problemService.GetIncompleteQuestions());
        }
        [HttpGet("QuestionsByTags")]
        public async Task<IActionResult> GetQuestionsByTags([FromQuery] List<int> Tags)
        {
            return Ok(await _problemService.GetQuestionsByTags(Tags));
        }
        [HttpGet("QuestionsById")]
        public async Task<IActionResult> GetQuestionsById(string questionId)
        {
            return Ok(await _problemService.GetQuestionsById(questionId));
        }

        [HttpPost("CreateFeatureList")]
        public async Task<IActionResult> PostFeature(FeatureDTO feature)
        {
            return Ok( new
            {
                id = await _problemService.PostFeature(feature)
            });
        }

        [HttpPost("AddUserToFeature")]
        public async Task<IActionResult> AddUserToFeature(Guid featureId)
        {
            return Ok(await _problemService.AddUserToFeature(featureId));
        }
    }
}

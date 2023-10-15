using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.AnswerDtos;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : Controller
    {
        private readonly IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all answers")]
        public async Task<IActionResult> GetAllAnswers()
        {
            var answers = await _answerService.GetAllAnswers();
            return Ok(answers);
        }

        [HttpGet("{answerId}")]
        [SwaggerOperation(Summary = "Get an answer by ID")]
        public async Task<IActionResult> GetAnswerById(int answerId)
        {
            var answer = await _answerService.GetAnswerById(answerId);
            if (answer == null)
            {
                return NotFound();
            }

            return Ok(answer);
        }

        [HttpGet("question/{questionId}")]
        [SwaggerOperation(Summary = "Get answers by question ID")]
        public async Task<IActionResult> GetAnswersByQuestion(int questionId)
        {
            var answers = await _answerService.GetAnswersByQuestion(questionId);
            return Ok(answers);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new answer")]
        public async Task<IActionResult> CreateAnswer([FromBody] AnswerToAddDto dto)
        {
            var answer = await _answerService.CreateAnswer(dto);
            if (answer != null)
            {
                return Ok(answer);
            }
            else
            {
                return BadRequest("Failed to create answer");
            }
        }

        [HttpPut("{answerId}")]
        [SwaggerOperation(Summary = "Update an answer")]
        public async Task<IActionResult> UpdateAnswer(int answerId, [FromBody] AnswerToUpdateDto dto)
        {
            var updatedAnswer = await _answerService.UpdateAnswer(answerId, dto);
            if (updatedAnswer == null)
            {
                return NotFound();
            }

            return Ok(updatedAnswer);
        }

        [HttpDelete("{answerId}")]
        [SwaggerOperation(Summary = "Delete an answer by ID")]
        public async Task<IActionResult> DeleteAnswerById(int answerId)
        {
            await _answerService.DeleteAnswerById(answerId);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.QuestionDtos;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all questions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _questionService.GetAllQuestions();
            return Ok(questions);
        }

        [HttpGet("{questionId}")]
        [SwaggerOperation(Summary = "Get a question by ID")]
        public async Task<IActionResult> GetQuestionById(int questionId)
        {
            var question = await _questionService.GetQuestionById(questionId);
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new question")]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionToAddDto dto)
        {
            var question = await _questionService.CreateQuestion(dto);
            if (question != null)
            {
                return Ok(question);
            }
            else
            {
                return BadRequest("Failed to create question");
            }
        }

        [HttpPut("{questionId}")]
        [SwaggerOperation(Summary = "Update a question")]
        public async Task<IActionResult> UpdateQuestion(int questionId, [FromBody] QuestionToUpdateDto dto)
        {
            var updatedQuestion = await _questionService.UpdateQuestion(questionId, dto);
            if (updatedQuestion == null)
            {
                return NotFound();
            }

            return Ok(updatedQuestion);
        }

        [HttpDelete("{questionId}")]
        [SwaggerOperation(Summary = "Delete a question by ID")]
        public async Task<IActionResult> DeleteQuestionById(int questionId)
        {
            await _questionService.DeleteQuestionById(questionId);
            return NoContent();
        }

        [HttpGet("{questionId}/answers")]
        [SwaggerOperation(Summary = "Get answers for a question")]
        public async Task<IActionResult> GetQuestionAnswers(int questionId)
        {
            var answers = await _questionService.GetQuestionAnswers(questionId);
            return Ok(answers);
        }

        [HttpGet("{questionId}/correct-answers")]
        [SwaggerOperation(Summary = "Get correct answers for a question")]
        public async Task<IActionResult> GetCorrectAnswersForQuestion(int questionId)
        {
            var correctAnswers = await _questionService.GetCorrectAnswersForQuestion(questionId);
            return Ok(correctAnswers);
        }
    }
}

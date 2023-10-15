using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.ExamDtos;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : Controller
    {
        private readonly IExamService _examService;

        public ExamController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all exams")]
        public async Task<IActionResult> GetAllExams()
        {
            var exams = await _examService.GetAllExams();
            return Ok(exams);
        }

        [HttpGet("{examId}")]
        [SwaggerOperation(Summary = "Get an exam by ID")]
        public async Task<IActionResult> GetExamById(int examId)
        {
            var exam = await _examService.GetExamById(examId);
            if (exam == null)
            {
                return NotFound();
            }

            return Ok(exam);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new exam")]
        public async Task<IActionResult> CreateExam([FromBody] ExamToAddDto dto)
        {
            var exam = await _examService.CreateExam(dto);
            if (exam != null)
            {
                return Ok(exam);
            }
            else
            {
                return BadRequest("Failed to create exam");
            }
        }

        [HttpPut("{examId}")]
        [SwaggerOperation(Summary = "Update an exam")]
        public async Task<IActionResult> UpdateExam(int examId, [FromBody] ExamToUpdateDto dto)
        {
            var updatedExam = await _examService.UpdateExam(examId, dto);
            if (updatedExam == null)
            {
                return NotFound();
            }

            return Ok(updatedExam);
        }

        [HttpDelete("{examId}")]
        [SwaggerOperation(Summary = "Delete an exam by ID")]
        public async Task<IActionResult> DeleteExam(int examId)
        {
            await _examService.DeleteExamById(examId);
            return NoContent();
        }

        [HttpGet("course/{courseId}")]
        [SwaggerOperation(Summary = "Get exams by course")]
        public async Task<IActionResult> GetExamsByCourseId(int courseId)
        {
            var exams = await _examService.GetExamsByCourseId(courseId);
            return Ok(exams);
        }
    }
}

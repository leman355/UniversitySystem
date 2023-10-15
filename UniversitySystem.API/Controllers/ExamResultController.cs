using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.ExamResultDtos;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultController : Controller
    {
        private readonly IExamResultService _examResultService;

        public ExamResultController(IExamResultService examResultService)
        {
            _examResultService = examResultService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all exam results")]
        public async Task<IActionResult> GetAllExamResults()
        {
            var examResults = await _examResultService.GetAllExamResults();
            return Ok(examResults);
        }

        [HttpGet("{examResultId}")]
        [SwaggerOperation(Summary = "Get an exam result by ID")]
        public async Task<IActionResult> GetExamResultById(int examResultId)
        {
            var examResult = await _examResultService.GetExamResultById(examResultId);
            if (examResult == null)
            {
                return NotFound();
            }

            return Ok(examResult);
        }

        [HttpGet("student/{studentId}")]
        [SwaggerOperation(Summary = "Get exam results by student")]
        public async Task<IActionResult> GetExamResultsByStudentId(int studentId)
        {
            var examResults = await _examResultService.GetExamResultsByStudentId(studentId);
            return Ok(examResults);
        }

        [HttpGet("teacher/{teacherId}")]
        [SwaggerOperation(Summary = "Get exam results by teacher")]
        public async Task<IActionResult> GetExamResultsByTeacherId(int teacherId)
        {
            var examResults = await _examResultService.GetExamResultsByTeacherId(teacherId);
            return Ok(examResults);
        }

        [HttpGet("exam/{examId}")]
        [SwaggerOperation(Summary = "Get exam results by exam")]
        public async Task<IActionResult> GetExamResultsByExamId(int examId)
        {
            var examResults = await _examResultService.GetExamResultsByExamId(examId);
            return Ok(examResults);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new exam result")]
        public async Task<IActionResult> CreateExamResult([FromBody] ExamResultToAddDto dto)
        {
            var examResult = await _examResultService.CreateExamResult(dto);
            if (examResult != null)
            {
                return Ok(examResult);
            }
            else
            {
                return BadRequest("Failed to create exam result");
            }
        }

        [HttpPut("{examResultId}")]
        [SwaggerOperation(Summary = "Update an exam result")]
        public async Task<IActionResult> UpdateExamResult(int examResultId, [FromBody] ExamResultToUpdateDto dto)
        {
            var updatedExamResult = await _examResultService.UpdateExamResult(examResultId, dto);
            if (updatedExamResult == null)
            {
                return NotFound();
            }

            return Ok(updatedExamResult);
        }

        [HttpDelete("{examResultId}")]
        [SwaggerOperation(Summary = "Delete an exam result by ID")]
        public async Task<IActionResult> DeleteExamResult(int examResultId)
        {
            await _examResultService.DeleteExamResultById(examResultId);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.StudentDtos;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all students")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{studentId}")]
        [SwaggerOperation(Summary = "Get a student by ID")]
        public async Task<IActionResult> GetStudentById(int studentId)
        {
            var student = await _studentService.GetStudentById(studentId);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new student")]
        public async Task<IActionResult> CreateStudent([FromBody] StudentToAddDto dto)
        {
            var student = await _studentService.CreateStudent(dto);
            if (student != null)
            {
                return Ok(student);
            }
            else
            {
                return BadRequest("Failed to create student");
            }
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update a student")]
        public async Task<IActionResult> UpdateStudent(int studentId, [FromBody] StudentToUpdateDto dto)
        {
            var updatedStudent = await _studentService.UpdateStudent(studentId, dto);
            if (updatedStudent == null)
            {
                return NotFound();
            }

            return Ok(updatedStudent);
        }

        [HttpDelete("{studentId}")]
        [SwaggerOperation(Summary = "Delete a student by ID")]
        public async Task<IActionResult> DeleteStudentById(int studentId)
        {
            await _studentService.DeleteStudentById(studentId);
            return NoContent();
        }

        [HttpGet("{studentId}/examResults")]
        [SwaggerOperation(Summary = "Get exam results for a student")]
        public async Task<IActionResult> GetStudentExamResults(int studentId)
        {
            var examResults = await _studentService.GetStudentExamResults(studentId);
            return Ok(examResults);
        }
    }
}

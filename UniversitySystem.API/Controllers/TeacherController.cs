using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.TeacherDtos;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all teachers")]
        public async Task<IActionResult> GetAllTeachers()
        {
            var teachers = await _teacherService.GetAllTeachers();
            return Ok(teachers);
        }

        [HttpGet("{teacherId}")]
        [SwaggerOperation(Summary = "Get a teacher by ID")]
        public async Task<IActionResult> GetTeacherById(int teacherId)
        {
            var teacher = await _teacherService.GetTeacherById(teacherId);
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new teacher")]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherToAddDto dto)
        {
            var teacher = await _teacherService.CreateTeacher(dto);
            if (teacher != null)
            {
                return Ok(teacher);
            }
            else
            {
                return BadRequest("Failed to create user");
            }
        }

        [HttpPut("{teacherId}")]
        [SwaggerOperation(Summary = "Update a teacher")]
        public async Task<IActionResult> UpdateTeacher(int teacherId, [FromBody] TeacherToUpdateDto dto)
        {
            var updatedTeacher = await _teacherService.UpdateTeacher(teacherId, dto);
            if (updatedTeacher == null)
            {
                return NotFound();
            }

            return Ok(updatedTeacher);
        }

        [HttpDelete("{teacherId}")]
        [SwaggerOperation(Summary = "Delete a teacher by ID")]
        public async Task<IActionResult> DeleteTeacherById(int teacherId)
        {
            await _teacherService.DeleteTeacherById(teacherId);
            return NoContent();
        }

        [HttpGet("{teacherId}/groups")]
        [SwaggerOperation(Summary = "Get groups associated with a teacher")]
        public async Task<IActionResult> GetTeacherGroups(int teacherId)
        {
            var groups = await _teacherService.GetTeacherGroups(teacherId);
            return Ok(groups);
        }
    }
}

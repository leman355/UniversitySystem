using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.CourseDtos;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all courses")]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet("{courseId}")]
        [SwaggerOperation(Summary = "Get a course by ID")]
        public async Task<IActionResult> GetCourseById(int courseId)
        {
            var course = await _courseService.GetCourseById(courseId);
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new course")]
        public async Task<IActionResult> CreateCourse([FromBody] CourseToAddDto dto)
        {
            var course = await _courseService.CreateCourse(dto);
            if (course != null)
            {
                return Ok(course);
            }
            else
            {
                return BadRequest("Failed to create course");
            }
        }

        [HttpPut("{courseId}")]
        [SwaggerOperation(Summary = "Update a course")]
        public async Task<IActionResult> UpdateCourse(int courseId, [FromBody] CourseToUpdateDto dto)
        {
            var updatedCourse = await _courseService.UpdateCourse(courseId, dto);
            if (updatedCourse == null)
            {
                return NotFound();
            }

            return Ok(updatedCourse);
        }

        [HttpDelete("{courseId}")]
        [SwaggerOperation(Summary = "Delete a course by ID")]
        public async Task<IActionResult> DeleteCourseById(int courseId)
        {
            await _courseService.DeleteCourseById(courseId);
            return NoContent();
        }
    }
}

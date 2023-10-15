using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.ClassDtos;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassController : Controller
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all classes")]
        public async Task<IActionResult> GetAllClasses()
        {
            var classes = await _classService.GetAllClasses();
            return Ok(classes);
        }

        [HttpGet("{classId}")]
        [SwaggerOperation(Summary = "Get a class by ID")]
        public async Task<IActionResult> GetClassById(int classId)
        {
            var classEntity = await _classService.GetClassById(classId);
            if (classEntity == null)
            {
                return NotFound();
            }

            return Ok(classEntity);
        }

        [HttpGet("course/{courseId}")]
        [SwaggerOperation(Summary = "Get classes by course ID")]
        public async Task<IActionResult> GetClassesByCourse(int courseId)
        {
            var classes = await _classService.GetClassesByCourse(courseId);
            return Ok(classes);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new class")]
        public async Task<IActionResult> CreateClass([FromBody] ClassToAddDto dto)
        {
            var classEntity = await _classService.CreateClass(dto);
            if (classEntity != null)
            {
                return Ok(classEntity);
            }
            else
            {
                return BadRequest("Failed to create class");
            }
        }

        [HttpPut("{classId}")]
        [SwaggerOperation(Summary = "Update a class")]
        public async Task<IActionResult> UpdateClass(int classId, [FromBody] ClassToUpdateDto dto)
        {
            var updatedClass = await _classService.UpdateClass(classId, dto);
            if (updatedClass == null)
            {
                return NotFound();
            }

            return Ok(updatedClass);
        }

        [HttpDelete("{classId}")]
        [SwaggerOperation(Summary = "Delete a class by ID")]
        public async Task<IActionResult> DeleteClassById(int classId)
        {
            await _classService.DeleteClassById(classId);
            return NoContent();
        }
    }
}

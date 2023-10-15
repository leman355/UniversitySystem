using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.MajorDtos;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MajorController : Controller
    {
        private readonly IMajorService _majorService;

        public MajorController(IMajorService majorService)
        {
            _majorService = majorService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all majors")]
        public async Task<IActionResult> GetAllMajors()
        {
            var majors = await _majorService.GetAllMajors();
            return Ok(majors);
        }

        [HttpGet("{majorId}")]
        [SwaggerOperation(Summary = "Get a major by ID")]
        public async Task<IActionResult> GetMajorById(int majorId)
        {
            var major = await _majorService.GetMajorById(majorId);
            if (major == null)
            {
                return NotFound();
            }

            return Ok(major);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new major")]
        public async Task<IActionResult> CreateMajor([FromBody] MajorToAddDto dto)
        {
            var major = await _majorService.CreateMajor(dto);
            if (major != null)
            {
                return Ok(major);
            }
            else
            {
                return BadRequest("Failed to create major");
            }
        }

        [HttpPut("{majorId}")]
        [SwaggerOperation(Summary = "Update a major")]
        public async Task<IActionResult> UpdateMajor(int majorId, [FromBody] MajorToUpdateDto dto)
        {
            var updatedMajor = await _majorService.UpdateMajor(majorId, dto);
            if (updatedMajor == null)
            {
                return NotFound();
            }

            return Ok(updatedMajor);
        }

        [HttpDelete("{majorId}")]
        [SwaggerOperation(Summary = "Delete a major by ID")]
        public async Task<IActionResult> DeleteMajorById(int majorId)
        {
            await _majorService.DeleteMajorById(majorId);
            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.DepartmentDtos;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all departments")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _departmentService.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("{departmentId}")]
        [SwaggerOperation(Summary = "Get a department by ID")]
        public async Task<IActionResult> GetDepartmentById(int departmentId)
        {
            var department = await _departmentService.GetDepartmentById(departmentId);
            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new department")]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentToAddDto dto)
        {
            var department = await _departmentService.CreateDepartment(dto);
            if (department != null)
            {
                return Ok(department);
            }
            else
            {
                return BadRequest("Failed to create department");
            }
        }

        [HttpPut("{departmentId}")]
        [SwaggerOperation(Summary = "Update a department")]
        public async Task<IActionResult> UpdateDepartment(int departmentId, [FromBody] DepartmentToUpdateDto dto)
        {
            var updatedDepartment = await _departmentService.UpdateDepartment(departmentId, dto);
            if (updatedDepartment == null)
            {
                return NotFound();
            }

            return Ok(updatedDepartment);
        }

        [HttpDelete("{departmentId}")]
        [SwaggerOperation(Summary = "Delete a department by ID")]
        public async Task<IActionResult> DeleteDepartmentById(int departmentId)
        {
            await _departmentService.DeleteDepartmentById(departmentId);
            return NoContent();
        }
    }
}

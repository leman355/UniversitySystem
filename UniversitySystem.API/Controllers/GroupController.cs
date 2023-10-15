using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.GroupDtos;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all groups")]
        public async Task<IActionResult> GetAllGroups()
        {
            var groups = await _groupService.GetAllGroups();
            return Ok(groups);
        }

        [HttpGet("{groupId}")]
        [SwaggerOperation(Summary = "Get a group by ID")]
        public async Task<IActionResult> GetGroupById(int groupId)
        {
            var group = await _groupService.GetGroupById(groupId);
            if (group == null)
            {
                return NotFound();
            }

            return Ok(group);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new group")]
        public async Task<IActionResult> CreateGroup([FromBody] GroupToAddDto dto)
        {
            var group = await _groupService.CreateGroup(dto);
            if (group != null)
            {
                return Ok(group);
            }
            else
            {
                return BadRequest("Failed to create group");
            }
        }

        [HttpPut("{groupId}")]
        [SwaggerOperation(Summary = "Update a group")]
        public async Task<IActionResult> UpdateGroup(int groupId, [FromBody] GroupToUpdateDto dto)
        {
            var updatedGroup = await _groupService.UpdateGroup(groupId, dto);
            if (updatedGroup == null)
            {
                return NotFound();
            }

            return Ok(updatedGroup);
        }

        [HttpDelete("{groupId}")]
        [SwaggerOperation(Summary = "Delete a group by ID")]
        public async Task<IActionResult> DeleteGroupById(int groupId)
        {
            await _groupService.DeleteGroupById(groupId);
            return NoContent();
        }

        [HttpGet("{groupId}/students")]
        [SwaggerOperation(Summary = "Get students in a group")]
        public async Task<IActionResult> GetGroupStudents(int groupId)
        {
            var students = await _groupService.GetGroupStudents(groupId);
            return Ok(students);
        }

        [HttpGet("{groupId}/courses")]
        [SwaggerOperation(Summary = "Get courses offered by a group")]
        public async Task<IActionResult> GetGroupCourses(int groupId)
        {
            var courses = await _groupService.GetGroupCourses(groupId);
            return Ok(courses);
        }
    }
}

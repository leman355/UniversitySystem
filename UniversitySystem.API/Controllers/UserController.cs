using Microsoft.AspNetCore.Mvc;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.UserDtos;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [SwaggerOperation(Summary = "user list")]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
        
        [Authorize(Policy = "AdminRole")]
        [HttpGet("{userId}")]
        [SwaggerOperation(Summary = "Get a user by ID")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var user = await _userService.GetUserById(userId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [Authorize(Policy = "UserRoles")]
        [HttpGet("byRole/{roleId}")]
        [SwaggerOperation(Summary = "Get users by role")]
        public async Task<IActionResult> GetUsersByRoleId(int roleId)
        {
            var users = await _userService.GetUsersByRoleId(roleId);
            return Ok(users);
        }
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new user")]
        public async Task<IActionResult> CreateUser([FromBody] UserToAddDto dto)
        {
            var createdUser = await _userService.CreateUser(dto);

            if (createdUser != null)
            {
                return Ok(createdUser);
            }
            else
            {
                return BadRequest("Failed to create user");
            }
        }
        [HttpPut("{userId}")]
        [SwaggerOperation(Summary = "Update a user")]
        public async Task<IActionResult> UpdateUser([FromRoute] int userId, UserToUpdateDto userToUpdateDto)
        {
            if (userId <= 0)
            {
                return BadRequest();
            }

            var updatedUser = await _userService.UpdateUser(userId, userToUpdateDto);

            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }
        [HttpDelete("{userId}")]
        [SwaggerOperation(Summary = "Delete a user by ID")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            await _userService.DeleteUserById(userId);
            return NoContent();
        }

        [HttpGet("{userId}/groups")]
        [SwaggerOperation(Summary = "Get groups of a user by ID")]
        public async Task<IActionResult> GetUserGroups(int userId)
        {
            var groups = await _userService.GetUserGroups(userId);
            return Ok(groups);
        }

        [HttpGet("roleByEmail")]
        [SwaggerOperation(Summary = "Get user role by email")]
        public async Task<IActionResult> GetUserRoleByEmail([FromQuery] string email)
        {
            var role = await _userService.GetUserRoleByEmail(email);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }
    }
}
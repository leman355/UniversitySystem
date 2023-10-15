using UniversitySystem.Business.DTO.GroupDtos;
using UniversitySystem.Business.DTO.UserDtos;

namespace UniversitySystem.Business.Abstract
{
    public interface IUserService
    {
        Task<List<UserToListDto>> GetAllUsers();
        Task<UserToListDto> GetUserById(int userId);
        Task<List<UserToListDto>> GetUsersByRoleId(int roleId);
        Task<UserToAddDto> CreateUser(UserToAddDto dto);
        Task<UserToUpdateDto> UpdateUser(int id, UserToUpdateDto user);
        Task DeleteUserById(int userId);
        Task<List<ShortGroupToListDto>> GetUserGroups(int userId);
    }
}

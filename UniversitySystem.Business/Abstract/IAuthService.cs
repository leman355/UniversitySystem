using UniversitySystem.Business.DTO.UserDtos;

namespace UniversitySystem.Business.Abstract
{
    public interface IAuthService
    {
        Task<UserLoginDto> Login(UserLoginDto dto);
        Task<UserToAddDto> Register(UserToAddDto dto);
        Task<UserToListDto> GetUserByEmail(string email);
        Task<string> GetUserRoleByEmail(string email);
    }
}

using UniversitySystem.Business.DTO.RoleDtos;

namespace UniversitySystem.Business.Abstract
{
    public interface IRoleService
    {
        Task<List<RoleToListDto>> GetAllRoles();
        Task<RoleToListDto> GetRoleById(int roleId);
        Task<RoleToAddDto> CreateRole(RoleToAddDto dto);
        Task<RoleToUpdateDto> UpdateRole(int roleId, RoleToUpdateDto role);
        Task DeleteRoleById(int roleId);
    }
}

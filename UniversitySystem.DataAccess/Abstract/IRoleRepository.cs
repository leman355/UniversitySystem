using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Abstract
{
    public interface IRoleRepository
    {
        Task<List<Role>> GetAllRoles();
        Task<Role> GetRoleById(int roleId);
        Task<Role> CreateRole(Role role);
        Task<Role> UpdateRole(Role role);
        Task DeleteRoleById(int roleId);
    }
}
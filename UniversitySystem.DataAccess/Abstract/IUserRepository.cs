using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Abstract
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int userId);
        Task<List<User>> GetUsersByRoleId(int roleId);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUserById(int id);
        Task<List<Group>> GetUserGroups(int userId);
        Task<List<Group>> GetGroups(List<int> ids);
    }
}

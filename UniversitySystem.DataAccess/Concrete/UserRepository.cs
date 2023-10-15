using Microsoft.EntityFrameworkCore;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.Include(x => x.Role).Include(g=>g.Groups).ToListAsync();
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _context.Users.Include(x => x.Role).Include(g => g.Groups)
                .Where(u => u.UserId == userId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<User>> GetUsersByRoleId(int roleId)
        {
            return await _context.Users.Include(x => x.Role).Include(g => g.Groups)
                .Where(u => u.RoleId == roleId)
                .ToListAsync();
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserById(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user != null)
            {
                user.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Group>> GetUserGroups(int userId)
        {
            return await _context.Groups
                .Where(g => g.Users.Any(u => u.UserId == userId))
                .ToListAsync();
        }

        public async Task<List<Group>> GetGroups(List<int> ids)
        {
            var groups = _context.Groups.Where(g => ids.Contains(g.GroupId)).ToList();
            return groups;
        }
    }
}

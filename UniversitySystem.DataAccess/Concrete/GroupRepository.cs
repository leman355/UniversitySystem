using Microsoft.EntityFrameworkCore;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Concrete
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDbContext _context;

        public GroupRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Group>> GetAllGroups()
        {
            return await _context.Groups
                .Include(t=>t.Teachers)
                .Include(c=>c.Courses)
                .Include(s=>s.Students)
                .Include(u=>u.Users)
                .ThenInclude(r => r.Role)
                .Include(e=>e.Exams)
                .ToListAsync();
        }

        public async Task<Group> GetGroupById(int groupId)
        {
            return await _context.Groups
                .Include(t => t.Teachers)
                .Include(c => c.Courses)
                .Include(s => s.Students)
                .Include(u => u.Users)
                .ThenInclude(r=>r.Role)
                .Include(e => e.Exams)
                .Where(g => g.GroupId == groupId)
                .FirstOrDefaultAsync();
        }

        public async Task<Group> CreateGroup(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task<Group> UpdateGroup(Group group)
        {
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
            return group;
        }

        public async Task DeleteGroupById(int groupId)
        {
            var group = await _context.Groups.FindAsync(groupId);
            if (group != null)
            {
                group.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Student>> GetGroupStudents(int groupId)
        {
            return await _context.Students
                .Where(s => s.GroupId == groupId)
                .ToListAsync();
        }

        public async Task<List<Course>> GetGroupCourses(int groupId)
        {
            return await _context.Groups
                .Where(g => g.GroupId == groupId)
                .SelectMany(g => g.Courses)
                .ToListAsync();
        }
    }
}

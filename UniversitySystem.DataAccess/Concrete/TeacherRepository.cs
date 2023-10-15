using Microsoft.EntityFrameworkCore;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Concrete
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> GetAllTeachers()
        {
            return await _context.Teachers
                .Include(x => x.Groups)
                .Include(x => x.ExamResults)
                .ThenInclude(x=>x.Exam)
                .IgnoreQueryFilters()
                .ToListAsync();
        }

        public async Task<Teacher> GetTeacherById(int teacherId)
        {
            return await _context.Teachers
                .Include(x => x.Groups)
                .Include(x => x.ExamResults)
                .Where(t => t.TeacherId == teacherId)
                .FirstOrDefaultAsync();
        }
        public async Task<Teacher> CreateTeacher(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task<Teacher> UpdateTeacher(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }

        public async Task DeleteTeacherById(int teacherId)
        {
            var teacher = await _context.Teachers.FindAsync(teacherId);
            if (teacher != null)
            {
                teacher.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Group>> GetTeacherGroups(int teacherId)
        {
            return await _context.Teachers
                    .Where(t => t.TeacherId == teacherId)
                    .Include(t => t.Groups)
                    .SelectMany(t => t.Groups)
                    .ToListAsync();
        }

        public async Task<List<Group>> GetGroups(List<int> ids)
        {
            var groups = _context.Groups.Where(g => ids.Contains(g.GroupId)).ToList();
            return groups;
        }
    }
}

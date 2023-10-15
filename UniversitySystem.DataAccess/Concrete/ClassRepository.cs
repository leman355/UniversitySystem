using Microsoft.EntityFrameworkCore;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Concrete
{
    public class ClassRepository : IClassRepository
    {
        private readonly AppDbContext _context;

        public ClassRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Class>> GetAllClasses()
        {
            return await _context.Classes.Include(c=>c.Course).ToListAsync();
        }

        public async Task<Class> GetClassById(int classId)
        {
            return await _context.Classes
                .Include(c => c.Course)
                .Where(c => c.ClassId == classId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Class>> GetClassesByCourse(int courseId)
        {
            return await _context.Classes
                .Include(c => c.Course)
                .Where(c => c.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<Class> CreateClass(Class classEntity)
        {
            _context.Classes.Add(classEntity);
            await _context.SaveChangesAsync();
            return classEntity;
        }

        public async Task<Class> UpdateClass(Class classEntity)
        {
            _context.Classes.Update(classEntity);
            await _context.SaveChangesAsync();
            return classEntity;
        }

        public async Task DeleteClassById(int classId)
        {
            var classEntity = await _context.Classes.FindAsync(classId);
            if (classEntity != null)
            {
                _context.Classes.Remove(classEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}

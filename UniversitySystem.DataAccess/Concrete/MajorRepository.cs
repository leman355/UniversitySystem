using Microsoft.EntityFrameworkCore;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Concrete
{
    public class MajorRepository : IMajorRepository
    {
        private readonly AppDbContext _context;

        public MajorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Major>> GetAllMajors()
        {
            return await _context.Majors
                .Include(s=>s.Students)
                .Include(d=>d.Department)
                .ToListAsync();
        }

        public async Task<Major> GetMajorById(int majorId)
        {
            return await _context.Majors
                .Include(s => s.Students)
                .Include(d => d.Department)
                .Where(m => m.MajorId == majorId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Major>> GetMajorsByDepartment(int departmentId)
        {
            return await _context.Majors
                .Where(m => m.DepartmentId == departmentId)
                .ToListAsync();
        }

        public async Task<Major> CreateMajor(Major major)
        {
            _context.Majors.Add(major);
            await _context.SaveChangesAsync();
            return major;
        }

        public async Task<Major> UpdateMajor(Major major)
        {
            _context.Majors.Update(major);
            await _context.SaveChangesAsync();
            return major;
        }

        public async Task DeleteMajorById(int majorId)
        {
            var major = await _context.Majors.FindAsync(majorId);
            if (major != null)
            {
                _context.Majors.Remove(major);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using Microsoft.EntityFrameworkCore;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Concrete
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllCourses()
        {
            return await _context.Courses
                .Include(g => g.Groups)
                .Include(c => c.Classes)
                .Include(e => e.Exam)
                .Include(p => p.Payments)
                .ToListAsync();
        }

        public async Task<Course> GetCourseById(int courseId)
        {
            return await _context.Courses
                .Include(g => g.Groups)
                .Include(c => c.Classes)
                .Include(e => e.Exam)
                .Include(p => p.Payments)
                .Where(c => c.CourseId == courseId)
                .FirstOrDefaultAsync();
        }

        public async Task<Course> CreateCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course> UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task DeleteCourseById(int courseId)
        {
            var course = await _context.Courses.FindAsync(courseId);
            if (course != null)
            {
                course.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
using Microsoft.EntityFrameworkCore;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Concrete
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _context.Students
                .Include(t => t.Group)
                .Include(t => t.Payments)
                .Include(t => t.Major)
                .Include(t => t.ExamResults)
                .ThenInclude(e => e.Exam)
                .ToListAsync();
        }

        public async Task<Student> GetStudentById(int studentId)
        {
            return await _context.Students
                .Include(t => t.Group)
                .Include(t => t.Payments)
                .Include(t => t.Major)
                .Include(t => t.ExamResults)
                .Where(s => s.StudentId == studentId)
                .FirstOrDefaultAsync();
        }

        public async Task<Student> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task DeleteStudentById(int studentId)
        {
            var student = await _context.Students.FindAsync(studentId);
            if (student != null)
            {
                student.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ExamResult>> GetStudentExamResults(int studentId)
        {
            return await _context.ExamResults.Include(e => e.Exam)
                .Where(e => e.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<List<ExamResult>> GetExamResults(List<int> examResultIds)
        {
            var exRes = _context.ExamResults.Where(e => examResultIds.Contains(e.ExamResultId)).ToList();
            return exRes;
        }
    }
}
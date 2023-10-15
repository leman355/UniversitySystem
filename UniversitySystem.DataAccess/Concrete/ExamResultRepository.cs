using Microsoft.EntityFrameworkCore;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Concrete
{
    public class ExamResultRepository : IExamResultRepository
    {
        private readonly AppDbContext _context;

        public ExamResultRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ExamResult>> GetAllExamResults()
        {
            return await _context.ExamResults
                .Include(e=>e.Exam)
                .Include(s=>s.Student)
                .Include(t=>t.Teacher)
                .ToListAsync();
        }

        public async Task<ExamResult> GetExamResultById(int examResultId)
        {
            return await _context.ExamResults
                .Include(e => e.Exam)
                .Include(s => s.Student)
                .Include(t => t.Teacher)
                .Where(er => er.ExamResultId == examResultId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<ExamResult>> GetExamResultsByStudentId(int studentId)
        {
            return await _context.ExamResults
                .Include(e => e.Exam)
                .Where(er => er.StudentId == studentId)
                .ToListAsync();
        }
        public async Task<List<ExamResult>> GetExamResultsByTeacherId(int teacherId)
        {
            return await _context.ExamResults
               .Include(e => e.Exam)
               .Where(er => er.TeacherId == teacherId)
               .ToListAsync();
        }

        public async Task<List<ExamResult>> GetExamResultsByExamId(int examId)
        {
            return await _context.ExamResults
                .Include(e => e.Exam)
                .Where(er => er.ExamId == examId)
                .ToListAsync();
        }

        public async Task<ExamResult> CreateExamResult(ExamResult examResult)
        {
            _context.ExamResults.Add(examResult);
            await _context.SaveChangesAsync();
            return examResult;
        }

        public async Task<ExamResult> UpdateExamResult(ExamResult examResult)
        {
            _context.ExamResults.Update(examResult);
            await _context.SaveChangesAsync();
            return examResult;
        }

        public async Task DeleteExamResultById(int examResultId)
        {
            var examResult = await _context.ExamResults.FindAsync(examResultId);
            if (examResult != null)
            {
                _context.ExamResults.Remove(examResult);
                await _context.SaveChangesAsync();
            }
        }
    }
}

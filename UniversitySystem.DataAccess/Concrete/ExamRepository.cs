using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Concrete
{
    public class ExamRepository : IExamRepository
    {
        private readonly AppDbContext _context;

        public ExamRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Exam>> GetAllExams()
        {
            return await _context.Exams
                .Include(с => с.Course)
                .Include(g => g.Groups)
                .Include(q => q.Questions)
                .Include(e => e.ExamResults)
                .ToListAsync();
        }

        public async Task<Exam> GetExamById(int examId)
        {
            return await _context.Exams
                .Include(с => с.Course)
                .Include(g => g.Groups)
                .Include(q => q.Questions)
                .Include(e => e.ExamResults)
                .Where(exam => exam.ExamId == examId)
                .FirstOrDefaultAsync();
        }

        public async Task<Exam> CreateExam(Exam exam)
        {
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
            return exam;
        }

        public async Task<Exam> UpdateExam(Exam exam)
        {
            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
            return exam;
        }

        public async Task DeleteExamById(int examId)
        {
            var exam = await _context.Exams.FindAsync(examId);
            if (exam != null)
            {
                _context.Exams.Remove(exam);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Exam>> GetExamsByCourseId(int courseId)
        {
            return await _context.Exams
                .Where(exam => exam.CourseId == courseId)
                .Include(e => e.Course)
                .Include(e => e.ExamResults)
                .ToListAsync();
        }
    }
}

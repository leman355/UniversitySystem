using Microsoft.EntityFrameworkCore;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Concrete
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _context;

        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetAllQuestions()
        {
            return await _context.Questions
                .Include(e => e.Exam)
                .Include(a => a.Answers)
                .ToListAsync();
        }

        public async Task<Question> GetQuestionById(int questionId)
        {
            return await _context.Questions
                .Include(e => e.Exam)
                .Include(a => a.Answers)
                .Where(q => q.QuestionId == questionId)
                .FirstOrDefaultAsync();
        }

        public async Task<Question> CreateQuestion(Question question)
        {
            _context.Questions.Add(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task<Question> UpdateQuestion(Question question)
        {
            _context.Questions.Update(question);
            await _context.SaveChangesAsync();
            return question;
        }

        public async Task DeleteQuestionById(int questionId)
        {
            var question = await _context.Questions.FindAsync(questionId);
            if (question != null)
            {
                question.IsDeleted = true;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Answer>> GetQuestionAnswers(int questionId)
        {
            return await _context.Answers
                .Where(a => a.QuestionId == questionId)
                .ToListAsync();
        }

        public async Task<List<Answer>> GetCorrectAnswersForQuestion(int questionId)
        {
            return await _context.Answers
                .Where(a => a.QuestionId == questionId && a.Status)
                .ToListAsync();
        }
    }
}

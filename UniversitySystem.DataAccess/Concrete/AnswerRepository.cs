using Microsoft.EntityFrameworkCore;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Concrete
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly AppDbContext _context;

        public AnswerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Answer>> GetAllAnswers()
        {
            return await _context.Answers.Include(q=>q.Question).ToListAsync();
        }

        public async Task<Answer> GetAnswerById(int answerId)
        {
            return await _context.Answers
                .Include(q => q.Question)
                .Where(a => a.AnswerId == answerId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Answer>> GetAnswersByQuestion(int questionId)
        {
            return await _context.Answers
                .Include(q => q.Question)
                .Where(a => a.QuestionId == questionId)
                .ToListAsync();
        }

        public async Task<Answer> CreateAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();
            return answer;
        }

        public async Task<Answer> UpdateAnswer(Answer answer)
        {
            _context.Answers.Update(answer);
            await _context.SaveChangesAsync();
            return answer;
        }

        public async Task DeleteAnswerById(int answerId)
        {
            var answer = await _context.Answers.FindAsync(answerId);
            if (answer != null)
            {
                _context.Answers.Remove(answer);
                await _context.SaveChangesAsync();
            }
        }
    }
}

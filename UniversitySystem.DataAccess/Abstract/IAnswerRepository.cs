using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Abstract
{
    public interface IAnswerRepository
    {
        Task<List<Answer>> GetAllAnswers();
        Task<Answer> GetAnswerById(int answerId);
        Task<List<Answer>> GetAnswersByQuestion(int questionId);
        Task<Answer> CreateAnswer(Answer answer);
        Task<Answer> UpdateAnswer(Answer answer);
        Task DeleteAnswerById(int answerId);
    }
}

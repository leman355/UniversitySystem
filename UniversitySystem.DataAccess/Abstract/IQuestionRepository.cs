using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Abstract
{
    public interface IQuestionRepository
    {
        Task<List<Question>> GetAllQuestions();
        Task<Question> GetQuestionById(int questionId);
        Task<Question> CreateQuestion(Question question);
        Task<Question> UpdateQuestion(Question question);
        Task DeleteQuestionById(int questionId);
        Task<List<Answer>> GetQuestionAnswers(int questionId);
        Task<List<Answer>> GetCorrectAnswersForQuestion(int questionId);
    }
}

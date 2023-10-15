using UniversitySystem.Business.DTO.AnswerDtos;
using UniversitySystem.Business.DTO.QuestionDtos;

namespace UniversitySystem.Business.Abstract
{    public interface IQuestionService
    {
        Task<List<QuestionToListDto>> GetAllQuestions();
        Task<QuestionToListDto> GetQuestionById(int questionId);
        Task<QuestionToAddDto> CreateQuestion(QuestionToAddDto dto);
        Task<QuestionToUpdateDto> UpdateQuestion(int questionId, QuestionToUpdateDto dto);
        Task DeleteQuestionById(int questionId);
        Task<List<ShortAnswerToListDto>> GetQuestionAnswers(int questionId);
        Task<List<ShortAnswerToListDto>> GetCorrectAnswersForQuestion(int questionId);
    }
}
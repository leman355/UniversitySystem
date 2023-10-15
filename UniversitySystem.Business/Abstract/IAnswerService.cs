using UniversitySystem.Business.DTO.AnswerDtos;

namespace UniversitySystem.Business.Abstract
{
    public interface IAnswerService
    {
        Task<List<AnswerToListDto>> GetAllAnswers();
        Task<AnswerToListDto> GetAnswerById(int answerId);
        Task<List<AnswerToListDto>> GetAnswersByQuestion(int questionId);
        Task<AnswerToAddDto> CreateAnswer(AnswerToAddDto dto);
        Task<AnswerToUpdateDto> UpdateAnswer(int answerId, AnswerToUpdateDto dto);
        Task DeleteAnswerById(int answerId);
    }
}

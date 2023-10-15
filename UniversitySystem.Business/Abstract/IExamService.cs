using UniversitySystem.Business.DTO.ExamDtos;

namespace UniversitySystem.Business.Abstract
{
    public interface IExamService
    {
        Task<List<ExamToListDto>> GetAllExams();
        Task<ExamToListDto> GetExamById(int examId);
        Task<ExamToAddDto> CreateExam(ExamToAddDto dto);
        Task<ExamToUpdateDto> UpdateExam(int examId, ExamToUpdateDto dto);
        Task DeleteExamById(int examId);
        Task<List<ShortExamToListDto>> GetExamsByCourseId(int courseId);
    }
}
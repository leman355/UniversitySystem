using UniversitySystem.Business.DTO.ExamResultDtos;

namespace UniversitySystem.Business.Abstract
{
    public interface IExamResultService
    {
        Task<List<ExamResultToListDto>> GetAllExamResults();
        Task<ExamResultToListDto> GetExamResultById(int examResultId);
        Task<List<ShortExamResultToListDto>> GetExamResultsByStudentId(int studentId);
        Task<List<ShortExamResultToListDto>> GetExamResultsByTeacherId(int teacherId);
        Task<List<ShortExamResultToListDto>> GetExamResultsByExamId(int examId);
        Task<ExamResultToAddDto> CreateExamResult(ExamResultToAddDto dto);
        Task<ExamResultToUpdateDto> UpdateExamResult(int examResultId, ExamResultToUpdateDto dto);
        Task DeleteExamResultById(int examResultId);
    }
}
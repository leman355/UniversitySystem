using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Abstract
{
    public interface IExamResultRepository
    {
        Task<List<ExamResult>> GetAllExamResults();
        Task<ExamResult> GetExamResultById(int examResultId);
        Task<List<ExamResult>> GetExamResultsByStudentId(int studentId);
        Task<List<ExamResult>> GetExamResultsByTeacherId(int teacherId);
        Task<List<ExamResult>> GetExamResultsByExamId(int examId);
        Task<ExamResult> CreateExamResult(ExamResult examResult);
        Task<ExamResult> UpdateExamResult(ExamResult examResult);
        Task DeleteExamResultById(int examResultId);
    }
}

using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Abstract
{
    public interface IExamRepository
    {
        Task<List<Exam>> GetAllExams();
        Task<Exam> GetExamById(int examId);
        Task<Exam> CreateExam(Exam exam);
        Task<Exam> UpdateExam(Exam exam);
        Task DeleteExamById(int examId);
        Task<List<Exam>> GetExamsByCourseId(int courseId);
    }
}
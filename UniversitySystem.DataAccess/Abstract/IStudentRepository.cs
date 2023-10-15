using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Abstract
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudents();
        Task<Student> GetStudentById(int studentId);
        Task<Student> CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task DeleteStudentById(int studentId);
        Task<List<ExamResult>> GetStudentExamResults(int studentId);
        Task<List<ExamResult>> GetExamResults(List<int> examResultIds);
    }
}
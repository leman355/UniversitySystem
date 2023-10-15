using UniversitySystem.Business.DTO.ExamResultDtos;
using UniversitySystem.Business.DTO.StudentDtos;

namespace UniversitySystem.Business.Abstract
{
    public interface IStudentService
    {
        Task<List<StudentToListDto>> GetAllStudents();
        Task<StudentToListDto> GetStudentById(int studentId);
        Task<StudentToAddDto> CreateStudent(StudentToAddDto dto);
        Task<StudentToUpdateDto> UpdateStudent(int id, StudentToUpdateDto dto);
        Task DeleteStudentById(int studentId);
        Task<List<ShortExamResultToListDto>> GetStudentExamResults(int studentId);
    }
}

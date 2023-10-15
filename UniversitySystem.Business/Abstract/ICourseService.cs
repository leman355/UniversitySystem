using UniversitySystem.Business.DTO.CourseDtos;

namespace UniversitySystem.Business.Abstract
{
    public interface ICourseService
    {
        Task<List<CourseToListDto>> GetAllCourses();
        Task<CourseToListDto> GetCourseById(int courseId);
        Task<CourseToAddDto> CreateCourse(CourseToAddDto dto);
        Task<CourseToUpdateDto> UpdateCourse(int courseId, CourseToUpdateDto dto);
        Task DeleteCourseById(int courseId);
    }
}

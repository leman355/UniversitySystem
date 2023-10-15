using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Abstract
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCourses();
        Task<Course> GetCourseById(int courseId);
        Task<Course> CreateCourse(Course course);
        Task<Course> UpdateCourse(Course course);
        Task DeleteCourseById(int courseId);
    }
}

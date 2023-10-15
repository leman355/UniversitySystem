using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Abstract
{
    public interface IClassRepository
    {
        Task<List<Class>> GetAllClasses();
        Task<Class> GetClassById(int classId);
        Task<List<Class>> GetClassesByCourse(int courseId);
        Task<Class> CreateClass(Class classEntity);
        Task<Class> UpdateClass(Class classEntity);
        Task DeleteClassById(int classId);
    }
}

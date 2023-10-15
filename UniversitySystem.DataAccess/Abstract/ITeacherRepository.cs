using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Abstract
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllTeachers();
        Task<Teacher> GetTeacherById(int teacherId);
        Task<Teacher> CreateTeacher(Teacher teacher);
        Task<Teacher> UpdateTeacher(Teacher teacher);
        Task DeleteTeacherById(int teacherId);
        Task<List<Group>> GetTeacherGroups(int teacherId);
        Task<List<Group>> GetGroups(List<int> ids);
    }
}
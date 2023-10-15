using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Abstract
{
    public interface IGroupRepository
    {
        Task<List<Group>> GetAllGroups();
        Task<Group> GetGroupById(int groupId);
        Task<Group> CreateGroup(Group group);
        Task<Group> UpdateGroup(Group group);
        Task DeleteGroupById(int groupId);
        Task<List<Student>> GetGroupStudents(int groupId);
        Task<List<Course>> GetGroupCourses(int groupId);
    }
}
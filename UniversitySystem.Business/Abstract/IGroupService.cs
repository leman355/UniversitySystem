using UniversitySystem.Business.DTO.CourseDtos;
using UniversitySystem.Business.DTO.GroupDtos;
using UniversitySystem.Business.DTO.StudentDtos;

namespace UniversitySystem.Business.Abstract
{
    public interface IGroupService
    {
        Task<List<GroupToListDto>> GetAllGroups();
        Task<GroupToListDto> GetGroupById(int groupId);
        Task<GroupToAddDto> CreateGroup(GroupToAddDto dto);
        Task<GroupToUpdateDto> UpdateGroup(int groupId, GroupToUpdateDto dto);
        Task DeleteGroupById(int groupId);
        Task<List<ShortStudentToListDto>> GetGroupStudents(int groupId);
        Task<List<ShortCourseToListDto>> GetGroupCourses(int groupId);
    }
}
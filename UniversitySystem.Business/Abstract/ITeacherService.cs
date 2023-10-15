using UniversitySystem.Business.DTO.GroupDtos;
using UniversitySystem.Business.DTO.TeacherDtos;

namespace UniversitySystem.Business.Abstract
{
    public interface ITeacherService
    {
        Task<List<TeacherToListDto>> GetAllTeachers();
        Task<TeacherToListDto> GetTeacherById(int teacherId);
        Task<TeacherToAddDto> CreateTeacher(TeacherToAddDto dto);
        Task<TeacherToUpdateDto> UpdateTeacher(int id, TeacherToUpdateDto dto);
        Task DeleteTeacherById(int teacherId);
        Task<List<ShortGroupToListDto>> GetTeacherGroups(int teacherId);
    }
}

using UniversitySystem.Business.DTO.ClassDtos;

namespace UniversitySystem.Business.Abstract
{
    public interface IClassService
    {
        Task<List<ClassToListDto>> GetAllClasses();
        Task<ClassToListDto> GetClassById(int classId);
        Task<List<ClassToListDto>> GetClassesByCourse(int courseId);
        Task<ClassToAddDto> CreateClass(ClassToAddDto dto);
        Task<ClassToUpdateDto> UpdateClass(int classId, ClassToUpdateDto dto);
        Task DeleteClassById(int classId);
    }
}

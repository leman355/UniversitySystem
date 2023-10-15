using UniversitySystem.Business.DTO.DepartmentDtos;

namespace UniversitySystem.Business.Abstract
{
    public interface IDepartmentService
    {
        Task<List<DepartmentToListDto>> GetAllDepartments();
        Task<DepartmentToListDto> GetDepartmentById(int departmentId);
        Task<DepartmentToAddDto> CreateDepartment(DepartmentToAddDto dto);
        Task<DepartmentToUpdateDto> UpdateDepartment(int departmentId, DepartmentToUpdateDto dto);
        Task DeleteDepartmentById(int departmentId);
    }
}

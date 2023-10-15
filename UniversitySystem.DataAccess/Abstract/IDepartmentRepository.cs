using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Abstract
{
    public interface IDepartmentRepository
    {
        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int departmentId);
        Task<Department> CreateDepartment(Department department);
        Task<Department> UpdateDepartment(Department department);
        Task DeleteDepartmentById(int departmentId);
    }
}

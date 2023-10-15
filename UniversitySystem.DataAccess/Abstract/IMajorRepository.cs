using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Abstract
{
    public interface IMajorRepository
    {
        Task<List<Major>> GetAllMajors();
        Task<Major> GetMajorById(int majorId);
        Task<List<Major>> GetMajorsByDepartment(int departmentId);
        Task<Major> CreateMajor(Major major);
        Task<Major> UpdateMajor(Major major);
        Task DeleteMajorById(int majorId);
    }
}
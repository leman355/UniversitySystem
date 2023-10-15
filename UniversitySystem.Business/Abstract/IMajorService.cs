using UniversitySystem.Business.DTO.MajorDtos;

namespace UniversitySystem.Business.Abstract
{    public interface IMajorService
    {
        Task<List<MajorToListDto>> GetAllMajors();
        Task<MajorToListDto> GetMajorById(int majorId);
        Task<MajorToAddDto> CreateMajor(MajorToAddDto dto);
        Task<MajorToUpdateDto> UpdateMajor(int majorId, MajorToUpdateDto dto);
        Task DeleteMajorById(int majorId);
    }
}
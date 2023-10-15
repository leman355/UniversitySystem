using UniversitySystem.Business.DTO.DepartmentDtos;
using UniversitySystem.Business.DTO.StudentDtos;

namespace UniversitySystem.Business.DTO.MajorDtos
{
    public record MajorToListDto
    {
        public int MajorId { get; set; }
        public string MajorName { get; set; }
        public string Description { get; set; }
        public int DepartmentId { get; set; }
        public ShortDepartmentToListDto Department { get; set; }
        public List<ShortStudentToListDto> Students { get; set; }
    }
}

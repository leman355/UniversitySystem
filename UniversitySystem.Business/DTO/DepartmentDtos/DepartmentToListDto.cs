using UniversitySystem.Business.DTO.MajorDtos;

namespace UniversitySystem.Business.DTO.DepartmentDtos
{
    public record DepartmentToListDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string HeadOfDepartment { get; set; }
        public List<ShortMajorToListDto> Majors { get; set; }
    }
}

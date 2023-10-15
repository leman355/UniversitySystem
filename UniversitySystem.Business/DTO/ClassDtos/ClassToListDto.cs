using UniversitySystem.Business.DTO.CourseDtos;

namespace UniversitySystem.Business.DTO.ClassDtos
{
    public record ClassToListDto
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public DateTime DateTime { get; set; }
        public string? Location { get; set; }
        public ShortCourseToListDto Course { get; set; }
    }
}

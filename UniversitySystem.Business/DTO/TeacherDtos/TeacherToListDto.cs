using UniversitySystem.Business.DTO.ExamResultDtos;
using UniversitySystem.Business.DTO.GroupDtos;

namespace UniversitySystem.Business.DTO.TeacherDtos
{
    public record TeacherToListDto
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsDeleted { get; set; }
        public List<ShortGroupToListDto> Groups { get; set; }
        public List<ShortExamResultToListDto> ExamResults { get; set; }
    }
}
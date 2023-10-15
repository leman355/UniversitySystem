using UniversitySystem.Business.DTO.CourseDtos;
using UniversitySystem.Business.DTO.ExamResultDtos;
using UniversitySystem.Business.DTO.GroupDtos;
using UniversitySystem.Business.DTO.QuestionDtos;

namespace UniversitySystem.Business.DTO.ExamDtos
{
    public record ExamToListDto
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public List<ShortGroupToListDto> Groups { get; set; }
        public ShortCourseToListDto Course { get; set; }
        public DateTime ExamDate { get; set; }
        public List<ExamResultForExamToListDto> ExamResults { get; set; }
        public List<ShortQuestionToListDto> Questions { get; set; }
    }
}

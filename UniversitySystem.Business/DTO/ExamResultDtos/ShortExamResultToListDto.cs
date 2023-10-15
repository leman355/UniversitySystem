using UniversitySystem.Business.DTO.ExamDtos;
using UniversitySystem.Entities;

namespace UniversitySystem.Business.DTO.ExamResultDtos
{
    public record ShortExamResultToListDto
    {
        public int ExamResultId { get; set; }
        public double Grade { get; set; }
        public ShortExamToListDto Exam { get; set; }
    }
}

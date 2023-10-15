using UniversitySystem.Business.DTO.ExamDtos;
using UniversitySystem.Business.DTO.StudentDtos;
using UniversitySystem.Business.DTO.TeacherDtos;

namespace UniversitySystem.Business.DTO.ExamResultDtos
{
    public record ExamResultToListDto
    {
        public int ExamResultId { get; set; }
        public double Grade { get; set; }
        public ShortExamToListDto Exam { get; set; }
        public ShortStudentToListDto Student { get; set; }
        public ShortTeacherToListDto Teacher { get; set; }
    }
}

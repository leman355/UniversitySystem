using UniversitySystem.Business.DTO.CourseDtos;
using UniversitySystem.Business.DTO.StudentDtos;
using UniversitySystem.Entities;

namespace UniversitySystem.Business.DTO.PaymentDtos
{
    public record PaymentToListDto
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public ShortStudentToListDto Student { get; set; }
        public ShortCourseToListDto Course { get; set; }
    }
}

using UniversitySystem.Business.DTO.ClassDtos;
using UniversitySystem.Business.DTO.ExamDtos;
using UniversitySystem.Business.DTO.GroupDtos;
using UniversitySystem.Business.DTO.PaymentDtos;

namespace UniversitySystem.Business.DTO.CourseDtos
{
    public record CourseToListDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string? Description { get; set; }
        public List<ShortGroupToListDto> Groups { get; set; }
        public List<ShortClassToListDto> Classes { get; set; }
        public bool IsDeleted { get; set; }
        public ShortExamToListDto Exam { get; set; }
        public List<ShortPaymentToListDto> Payments { get; set; }
    }
}

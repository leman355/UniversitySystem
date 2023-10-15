using UniversitySystem.Business.DTO.ExamResultDtos;
using UniversitySystem.Business.DTO.GroupDtos;
using UniversitySystem.Business.DTO.MajorDtos;
using UniversitySystem.Business.DTO.PaymentDtos;

namespace UniversitySystem.Business.DTO.StudentDtos
{
    public record StudentToListDto
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public bool IsPayingStudent { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime AdmissionDate { get; set; }
        public bool IsGraduated { get; set; }
        public double? AverageGrade { get; set; }
        public ShortMajorToListDto Major { get; set; }
        public List<ShortPaymentToListDto> Payments { get; set; }
        public ShortGroupToListDto Group { get; set; }
        public List<ShortExamResultToListDto> ExamResults { get; set; }
    }
}

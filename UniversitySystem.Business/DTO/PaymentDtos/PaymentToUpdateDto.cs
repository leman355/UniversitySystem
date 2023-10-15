namespace UniversitySystem.Business.DTO.PaymentDtos
{
    public record PaymentToUpdateDto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}

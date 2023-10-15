namespace UniversitySystem.Business.DTO.PaymentDtos
{
    public record ShortPaymentToListDto
    {
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}

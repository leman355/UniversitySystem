using UniversitySystem.Business.DTO.PaymentDtos;

namespace UniversitySystem.Business.Abstract
{
    public interface IPaymentService
    {
        Task<List<PaymentToListDto>> GetAllPayments();
        Task<PaymentToListDto> GetPaymentById(int paymentId);
        Task<PaymentToAddDto> CreatePayment(PaymentToAddDto dto);
        Task<PaymentToUpdateDto> UpdatePayment(int paymentId, PaymentToUpdateDto dto);
        Task DeletePaymentById(int paymentId);
    }
}
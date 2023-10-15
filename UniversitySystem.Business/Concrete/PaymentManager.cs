using AutoMapper;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.PaymentDtos;
using UniversitySystem.Entities;
using UniversitySystem.DataAccess.Abstract;

namespace UniversitySystem.Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentManager(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
        }

        public async Task<List<PaymentToListDto>> GetAllPayments()
        {
            var payments = await _paymentRepository.GetAllPayments();
            return _mapper.Map<List<PaymentToListDto>>(payments);
        }

        public async Task<PaymentToListDto> GetPaymentById(int paymentId)
        {
            var payment = await _paymentRepository.GetPaymentById(paymentId);
            return _mapper.Map<PaymentToListDto>(payment);
        }

        public async Task<PaymentToAddDto> CreatePayment(PaymentToAddDto dto)
        {
            var payment = _mapper.Map<Payment>(dto);
            var createdPayment = await _paymentRepository.CreatePayment(payment);
            return _mapper.Map<PaymentToAddDto>(createdPayment);
        }

        public async Task<PaymentToUpdateDto> UpdatePayment(int paymentId, PaymentToUpdateDto dto)
        {
            var existingPayment = await _paymentRepository.GetPaymentById(paymentId);

            if (existingPayment == null)
            {
                return null;
            }

            _mapper.Map(dto, existingPayment);

            var updatedPayment = await _paymentRepository.UpdatePayment(existingPayment);
            return _mapper.Map<PaymentToUpdateDto>(updatedPayment);
        }

        public async Task DeletePaymentById(int paymentId)
        {
            await _paymentRepository.DeletePaymentById(paymentId);
        }
    }
}

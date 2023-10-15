using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Abstract
{
    public interface IPaymentRepository
    {
        Task<List<Payment>> GetAllPayments();
        Task<Payment> GetPaymentById(int paymentId);
        Task<List<Payment>> GetPaymentsByStudent(int studentId);
        Task<List<Payment>> GetPaymentsByCourse(int courseId);
        Task<Payment> CreatePayment(Payment payment);
        Task<Payment> UpdatePayment(Payment payment);
        Task DeletePaymentById(int paymentId);
    }
}
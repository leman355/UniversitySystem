using Microsoft.EntityFrameworkCore;
using UniversitySystem.DataAccess.Abstract;
using UniversitySystem.Entities;

namespace UniversitySystem.DataAccess.Concrete
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Payment>> GetAllPayments()
        {
            return await _context.Payments
                .Include(s => s.Student)
                .Include(c => c.Course)
                .ToListAsync();
        }

        public async Task<Payment> GetPaymentById(int paymentId)
        {
            return await _context.Payments
                 .Include(s => s.Student)
                .Include(c => c.Course)
                .Where(p => p.PaymentId == paymentId)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Payment>> GetPaymentsByStudent(int studentId)
        {
            return await _context.Payments
                .Where(p => p.StudentId == studentId)
                .ToListAsync();
        }

        public async Task<List<Payment>> GetPaymentsByCourse(int courseId)
        {
            return await _context.Payments
                .Where(p => p.CourseId == courseId)
                .ToListAsync();
        }

        public async Task<Payment> CreatePayment(Payment payment)
        {
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> UpdatePayment(Payment payment)
        {
            _context.Payments.Update(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task DeletePaymentById(int paymentId)
        {
            var payment = await _context.Payments.FindAsync(paymentId);
            if (payment != null)
            {
                _context.Payments.Remove(payment);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversitySystem.Business.Abstract;
using UniversitySystem.Business.DTO.PaymentDtos;

namespace UniversitySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all payments")]
        public async Task<IActionResult> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPayments();
            return Ok(payments);
        }

        [HttpGet("{paymentId}")]
        [SwaggerOperation(Summary = "Get a payment by ID")]
        public async Task<IActionResult> GetPaymentById(int paymentId)
        {
            var payment = await _paymentService.GetPaymentById(paymentId);
            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new payment")]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentToAddDto dto)
        {
            var payment = await _paymentService.CreatePayment(dto);
            if (payment != null)
            {
                return Ok(payment);
            }
            else
            {
                return BadRequest("Failed to create payment");
            }
        }

        [HttpPut("{paymentId}")]
        [SwaggerOperation(Summary = "Update a payment")]
        public async Task<IActionResult> UpdatePayment(int paymentId, [FromBody] PaymentToUpdateDto dto)
        {
            var updatedPayment = await _paymentService.UpdatePayment(paymentId, dto);
            if (updatedPayment == null)
            {
                return NotFound();
            }

            return Ok(updatedPayment);
        }

        [HttpDelete("{paymentId}")]
        [SwaggerOperation(Summary = "Delete a payment by ID")]
        public async Task<IActionResult> DeletePaymentById(int paymentId)
        {
            await _paymentService.DeletePaymentById(paymentId);
            return NoContent();
        }
    }
}

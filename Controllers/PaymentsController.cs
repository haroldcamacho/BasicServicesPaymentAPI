using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BasicBilling.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("process")]
        public IActionResult ProcessPayment([FromBody] PaymentRequestModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _paymentService.ProcessPayment(model.ClientId, model.TypeOfService, model.MonthYear, model.Amount);

            return Ok();
        }

        [HttpGet("pending/{clientId}")]
        public IActionResult GetPendingBills(int clientId)
        {
            var pendingBills = _paymentService.GetPendingBills(clientId);

            return Ok(pendingBills);
        }

        [HttpGet("history/{clientId}")]
        public IActionResult GetPaymentHistory(int clientId)
        {
            var paymentHistory = _paymentService.GetPaymentHistory(clientId);

            return Ok(paymentHistory);
        }
    }
}
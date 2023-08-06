[ApiController]
[Route("api/payments")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet("{clientId}/pending")]
    public IActionResult GetPendingBills(int clientId)
    {
        var pendingBills = _paymentService.GetPendingBills(clientId);
        return Ok(pendingBills);
    }

    [HttpGet("{clientId}/payment-history")]
    public IActionResult GetPaymentHistory(int clientId)
    {
        var paymentHistory = _paymentService.GetPaymentHistory(clientId);
        return Ok(paymentHistory);
    }

    [HttpPost("pay")]
    public IActionResult PayBill([FromBody] PaymentRequest paymentRequest)
    {
        // Implement the logic to validate the payment data and process the payment.
        // In a real application, you should add error handling and proper data storage.

        _paymentService.ProcessPayment(paymentRequest.ClientId, paymentRequest.TypeOfService, paymentRequest.MonthYear, paymentRequest.Amount);

        return Ok();
    }
}

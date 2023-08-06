public class Payment
{
    public int PaymentId { get; set; }
    public int BillId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
}
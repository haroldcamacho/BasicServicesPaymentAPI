public class Bill
{
    public int BillId { get; set; }
    public int ClientId { get; set; }
    public string TypeOfService { get; set; }
    public DateTime MonthYear { get; set; }
    public bool IsPaid { get; set; }
}
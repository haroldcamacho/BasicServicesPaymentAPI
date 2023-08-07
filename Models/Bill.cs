public class Bill
{
    public Bill(int clientId, string typeOfService, DateTime monthYear, bool isPaid)
    {
        ClientId = clientId;
        TypeOfService = typeOfService; 
        MonthYear = monthYear;
        IsPaid = isPaid;
    }

    public int BillId { get; set; }
    public int ClientId { get; set; }
    public string TypeOfService { get; set; }
    public DateTime MonthYear { get; set; }
    public bool IsPaid { get; set; }
}
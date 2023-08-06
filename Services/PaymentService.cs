public class PaymentService : IPaymentService
{
    private readonly List<Client> _clients; // In a real application, this should be replaced with a database or data access layer
    private readonly List<Bill> _bills;
    private readonly List<Payment> _payments;

    public PaymentService()
    {
        // Initialize data with some test values. In a real application, data will be fetched from the database.
        _clients = new List<Client>
        {
            new Client { ClientId = 1, Name = "Client A" },
            new Client { ClientId = 2, Name = "Client B" },
            // Add more clients here
        };

        _bills = new List<Bill>
        {
            new Bill { BillId = 1, ClientId = 1, TypeOfService = "Service1", MonthYear = new DateTime(2023, 8, 1), IsPaid = false },
            new Bill { BillId = 2, ClientId = 1, TypeOfService = "Service2", MonthYear = new DateTime(2023, 7, 1), IsPaid = false },
            // Add more bills here
        };

        _payments = new List<Payment>();
    }

    public IEnumerable<Bill> GetPendingBills(int clientId)
    {
        return _bills.Where(b => b.ClientId == clientId && !b.IsPaid);
    }

    public IEnumerable<Payment> GetPaymentHistory(int clientId)
    {
        return _payments.Where(p => _bills.Any(b => b.BillId == p.BillId && b.ClientId == clientId));
    }

    public void ProcessPayment(int clientId, string typeOfService, DateTime monthYear, decimal amount)
    {
        // Implement the logic to validate the payment data and update the bill's state to paid.
        // You should also check if the bill exists and belongs to the specified client.
        // If successful, update the payment history accordingly.
        // In a real application, you should add error handling and proper data storage.
        var bill = _bills.FirstOrDefault(b =>
            b.ClientId == clientId &&
            b.TypeOfService == typeOfService &&
            b.MonthYear == monthYear &&
            !b.IsPaid);

        if (bill != null)
        {
            bill.IsPaid = true;
            _payments.Add(new Payment
            {
                PaymentId = _payments.Count + 1,
                BillId = bill.BillId,
                Amount = amount,
                PaymentDate = DateTime.Now
            });
        }
    }
}
using System;
using System.Linq;
using BasicBilling.API.Data;

namespace BasicBilling.API.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly DataContext _context;

        public PaymentService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Bill> GetPendingBills(int clientId)
        {
            return _context.Bills.Where(b => b.ClientId == clientId && !b.IsPaid);
        }

        public IEnumerable<Payment> GetPaymentHistory(int clientId)
        {
            return _context.Payments
                .Join(_context.Bills,
                    payment => payment.BillId,
                    bill => bill.BillId,
                    (payment, bill) => new { Payment = payment, Bill = bill })
                .Where(x => x.Bill.ClientId == clientId)
                .Select(x => x.Payment);
        }

        public void ProcessPayment(int clientId, string typeOfService, DateTime monthYear, decimal amount)
        {
            var bill = _context.Bills.FirstOrDefault(b =>
                b.ClientId == clientId &&
                b.TypeOfService == typeOfService &&
                b.MonthYear == monthYear &&
                !b.IsPaid);

            if (bill != null)
            {
                bill.IsPaid = true;
                _context.Payments.Add(new Payment
                {
                    BillId = bill.BillId,
                    Amount = amount,
                    PaymentDate = DateTime.Now
                });

                _context.SaveChanges();
            }
        }
    }
}

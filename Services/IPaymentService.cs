using System;
using System.Collections.Generic;

public interface IPaymentService
{
    IEnumerable<Bill> GetPendingBills(int clientId);
    IEnumerable<Payment> GetPaymentHistory(int clientId);
    void ProcessPayment(int clientId, string typeOfService, DateTime monthYear, decimal amount);
}

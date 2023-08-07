using System;
using System.ComponentModel.DataAnnotations;

public class PaymentRequestModel
{
    [Required]
    public int ClientId { get; set; }

    [Required]
    public string TypeOfService { get; set; }

    [Required]
    public DateTime MonthYear { get; set; }

    [Required]
    public decimal Amount { get; set; }

    // Constructor to initialize non-nullable properties
    public PaymentRequestModel(int clientId, string typeOfService, DateTime monthYear, decimal amount)
    {
        ClientId = clientId;
        TypeOfService = typeOfService; // Initialize non-nullable property 'TypeOfService'
        MonthYear = monthYear;
        Amount = amount;
    }
}

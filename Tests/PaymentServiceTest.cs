// using System;
// using NUnit.Framework;
// using BasicBilling.API.Services;

// namespace BasicBilling.API.Tests
// {
//     public class PaymentServiceTests
//     {
//         [Test]
//         public void ProcessPayment_ShouldMarkBillAsPaid()
//         {
//             // Arrange
//             var paymentService = new PaymentService(/* Your mock DataContext or DbContext */);

//             // Mock input data for the test
//             int clientId = 100;
//             string typeOfService = "Electricity";
//             DateTime monthYear = new DateTime(2023, 8, 1);
//             decimal amount = 100.00m;

//             // Act
//             paymentService.ProcessPayment(clientId, typeOfService, monthYear, amount);

//             // Assert
//             // Add assertions here to verify that the bill was marked as paid.
//             // For example, you can check the DataContext/DbContext to see if the bill's IsPaid property was set to true.
//         }
//     }
// }

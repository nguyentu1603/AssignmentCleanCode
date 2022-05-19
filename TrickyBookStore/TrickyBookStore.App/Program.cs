using Microsoft.Extensions.DependencyInjection;
using System;
using TrickyBookStore.Services;
using TrickyBookStore.Services.Payment;

namespace TrickyBookStore.App
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddServices()
                .BuildServiceProvider();

            DateTimeOffset startDate = new DateTimeOffset(new DateTime(2018, 2, 1));
            DateTimeOffset endDate = new DateTimeOffset(new DateTime(2018, 2, 28));

            var paymentService = serviceProvider.GetService<IPaymentService>();
            double paymentAmount = paymentService.GetPaymentAmount(1, startDate, endDate);
            Console.WriteLine("Payment Amount: " + paymentAmount);
        }
    }
}

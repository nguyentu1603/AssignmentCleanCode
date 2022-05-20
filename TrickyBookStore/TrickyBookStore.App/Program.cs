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

            Console.WriteLine("TrickBookStore");
            Console.Write("Input Customer Id: ");
            int customerId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Month: ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input Year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            DateTimeOffset startDate = new DateTimeOffset(new DateTime(year, month, 1));
            DateTimeOffset endDate = new DateTimeOffset(new DateTime(year, month, 28));

            var paymentService = serviceProvider.GetService<IPaymentService>();
            double paymentAmount = paymentService.GetPaymentAmount(customerId, startDate, endDate);
            Console.WriteLine("Payment Amount: " + paymentAmount);
        }
    }
}


using System;
using TrickyBookStore.Repositories.Customers;
using TrickyBookStore.Repositories.PurchaseTransactions;

namespace TrickyBookStore.Repositories.Payment
{
    public class PaymentRepository : IPaymentRepository
    {
        ICustomerRepository CustomerRepository { get; }
        IPurchaseTransactionRepository PurchaseTransactionRepository { get; }

        public PaymentRepository(ICustomerRepository customerRepository,
            IPurchaseTransactionRepository purchaseTransactionRepository)
        {
            CustomerRepository = customerRepository;
            PurchaseTransactionRepository = purchaseTransactionRepository;
        }

        public double GetPaymentAmount(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            throw new NotImplementedException();
        }
    }
}

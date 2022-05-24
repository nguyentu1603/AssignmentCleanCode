using System;
using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Books;
using TrickyBookStore.Services.Customers;
using TrickyBookStore.Services.Helpers;
using TrickyBookStore.Services.PurchaseTransactions;
using TrickyBookStore.Services.Subscriptions;

namespace TrickyBookStore.Services.Payment
{
    internal class PaymentService : IPaymentService
    {
        ICustomerService CustomerService { get; }
        IPurchaseTransactionService PurchaseTransactionService { get; }

        public PaymentService(ICustomerService customerService,
            IPurchaseTransactionService purchaseTransactionService)
        {
            CustomerService = customerService;
            PurchaseTransactionService = purchaseTransactionService;
        }

        public double GetPaymentAmount(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            Customer customer = CustomerService.GetCustomerById(customerId);

            IList<PurchaseTransaction> listPurchase = PurchaseTransactionService.GetPurchaseTransactions(customerId, fromDate, toDate);
            IList<Subscription> listSubcription = customer.Subscriptions.ToList();
            IList<Book> listBook = listPurchase.Select(x => x.Book).ToArray();
             
            double receiptPrice = PurchaseTransactionService.GetTotalReceipt(listBook.ToList(), listSubcription.ToList());
            double subscriptionPrice = customer.Subscriptions.Select(x => x.PriceDetails[Constants.PriceDetailKeys.FixPrice]).Sum();
            double totalPrice = subscriptionPrice + receiptPrice;
            return totalPrice;
        }
    }
}

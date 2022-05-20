using System;
using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Books;
using TrickyBookStore.Services.Customers;
using TrickyBookStore.Services.PurchaseTransactions;
using TrickyBookStore.Services.Subscriptions;

namespace TrickyBookStore.Services.Payment
{
    internal class PaymentService : IPaymentService
    {
        ICustomerService CustomerService { get; }
        IPurchaseTransactionService PurchaseTransactionService { get; }
        ISubscriptionService SubscriptionService { get; }
        IBookService BookService { get; }

        public PaymentService(ICustomerService customerService,
            IPurchaseTransactionService purchaseTransactionService,
            ISubscriptionService subscriptionService,
            IBookService bookService
            )
        {
            CustomerService = customerService;
            PurchaseTransactionService = purchaseTransactionService;
            SubscriptionService = subscriptionService;
            BookService = bookService;
        }

        public double GetPaymentAmount(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            Customer customer = CustomerService.GetCustomerById(customerId);

            IList<PurchaseTransaction> listPurchase = PurchaseTransactionService.GetPurchaseTransactions(customerId, fromDate, toDate);
            IList<Subscription> listSubcription = SubscriptionService.GetSubscriptions(customer.SubscriptionIds.ToArray());
            IList<Book> listBook = BookService.GetBooks(listPurchase.ToList());

            double receiptPrice = PurchaseTransactionService.GetTotalReceipt(listBook.ToList(), listSubcription.ToList());
            double subscriptionPrice = SubscriptionService.GetTotalSubcriptionPrice(listSubcription.ToList());
            double totalPrice = subscriptionPrice + receiptPrice;
            return totalPrice;
        }
    }
}

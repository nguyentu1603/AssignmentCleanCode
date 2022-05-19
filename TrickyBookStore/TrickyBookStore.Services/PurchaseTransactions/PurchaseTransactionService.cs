using System;
using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Books;

namespace TrickyBookStore.Services.PurchaseTransactions
{
    internal class PurchaseTransactionService : IPurchaseTransactionService
    {
        IBookService BookService { get; }

        public PurchaseTransactionService(IBookService bookService)
        {
            BookService = bookService;
        }

        public IList<PurchaseTransaction> GetPurchaseTransactions(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            List<PurchaseTransaction> purchaseTransactions = new List<PurchaseTransaction>();
            purchaseTransactions = Store.PurchaseTransactions.Data.Where(x => x.CustomerId == customerId && x.CreatedDate >= fromDate && x.CreatedDate <= toDate).ToList();
            return purchaseTransactions;
        }

        public double GetTotalReceipt(List<Book> books, List<Subscription> subscriptions)
        {
            double totalReceiptPrice = 0;
            if (subscriptions == null)
            {
                foreach (var book in books)
                {
                    totalReceiptPrice += book.Price;
                }
                return totalReceiptPrice;
            }
            List<Book> oldBooks = new List<Book>();
            List<Book> newBooks = new List<Book>();

            foreach (var book in books)
            {
                if (book.IsOld)
                {
                    oldBooks.Add(book);
                }
                else
                {
                    newBooks.Add(book);
                }
            }
            double totalNewBookPrice = GetTotalPriceOfNewBooks(newBooks, subscriptions);
            double totalOldBookPrice = GetTotalPriceOfOldBooks(oldBooks, subscriptions);
            totalReceiptPrice = totalOldBookPrice + totalNewBookPrice;
            return totalReceiptPrice;
        }


        public double GetTotalPriceOfOldBooks(List<Book> books, List<Subscription> subscriptions)
        {
            double totalPrice = 0;
            bool isCalculated;
            foreach (var book in books)
            {
                isCalculated = false;
                foreach (var subscription in subscriptions)
                {
                    var subscriptionAddicted = subscriptions.FirstOrDefault(x => x.BookCategoryId == book.CategoryId);
                    if (subscriptionAddicted != null)
                    {
                        totalPrice += 0;
                        isCalculated = true;
                    }
                    if (subscription.BookCategoryId == null)
                    {
                        totalPrice += book.Price - (book.Price * subscription.PriceDetails["OldBookDiscountPercent"] / 100);
                        isCalculated = true;
                    }
                    if (isCalculated)
                    {
                        break;
                    }
                }
                if (!isCalculated)
                {
                    totalPrice += book.Price;
                }
            }
            return totalPrice;
        }

        public double GetTotalPriceOfNewBooks(List<Book> books, List<Subscription> subscriptions)
        {
            double totalPrice = 0;
            bool isCalculated;
            foreach (var book in books)
            {
                isCalculated = false;
                foreach (var subscription in subscriptions)
                {
                    if (subscription.BookCategoryId == book.CategoryId)
                    {
                        if (subscription.PriceDetails["DiscountedBooks"] > 0)
                        {
                            totalPrice += book.Price - (book.Price * subscription.PriceDetails["NewBookDiscountPercent"] / 100);
                            subscription.PriceDetails["DiscountedBooks"]--;
                            isCalculated = true;
                        }
                    }
                    if (subscription.BookCategoryId == null)
                    {
                        if (subscription.PriceDetails["DiscountedBooks"] > 0)
                        {
                            totalPrice += book.Price - (book.Price * subscription.PriceDetails["NewBookDiscountPercent"] / 100);
                            subscription.PriceDetails["DiscountedBooks"]--;
                            isCalculated = true;
                        }
                    }
                    if (isCalculated)
                    {
                        break;
                    }
                }
                if (!isCalculated)
                {
                    totalPrice += book.Price;
                }
            }
            return totalPrice;
        }
    }
}

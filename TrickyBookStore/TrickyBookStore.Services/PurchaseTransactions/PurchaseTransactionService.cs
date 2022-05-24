using System;
using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;
using TrickyBookStore.Services.Books;
using TrickyBookStore.Services.Helpers;

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
            if(purchaseTransactions != null)
            {
                foreach (var purchaseTransaction in purchaseTransactions)
                {
                    purchaseTransaction.Book = BookService.GetBooks(purchaseTransaction.BookId).FirstOrDefault();
                }
            }
            return purchaseTransactions;
        }

        public double GetTotalReceipt(List<Book> books, List<Subscription> subscriptions)
        {
            double totalReceiptPrice = 0, totalOldBookPrice = 0, totalNewBookPrice = 0;
            if (subscriptions == null)
            {
                totalReceiptPrice = books.Select(x => x.Price).Sum();
                return totalReceiptPrice;
            }
            else
            {
                totalOldBookPrice = GetTotalPriceOfOldBooks(books.Where(x => x.IsOld).ToList(), subscriptions);
                totalNewBookPrice = GetTotalPriceOfNewBooks(books.Where(x => !x.IsOld).ToList(), subscriptions);
            }
            totalReceiptPrice = totalOldBookPrice + totalNewBookPrice;
            return totalReceiptPrice;
        }


        public double GetTotalPriceOfOldBooks(List<Book> books, List<Subscription> subscriptions)
        {
            double totalPrice = 0;
            foreach (var book in books)
            {
                bool isCalculated = false;
                foreach (var subscription in subscriptions)
                {
                    if (subscription.BookCategoryId == book.CategoryId)
                    {
                        totalPrice += 0;
                        isCalculated = true;
                    }
                    if (subscription.BookCategoryId == null)
                    {
                        totalPrice += book.Price - (book.Price * subscription.PriceDetails[Constants.PriceDetailKeys.OldBookDiscountPercent] / 100);
                        isCalculated = true;
                    }
                    if (isCalculated)
                    {
                        break;
                    }
                }
                if (!isCalculated)
                {
                    totalPrice += book.Price - (book.Price * 10 / 100);
                }
            }
            return totalPrice;
        }

        public double GetTotalPriceOfNewBooks(List<Book> books, List<Subscription> subscriptions)
        {
            double totalPrice = 0;
            foreach (var book in books)
            {
                bool isCalculated = false;
                foreach (var subscription in subscriptions)
                {
                    if (subscription.BookCategoryId == book.CategoryId)
                    {
                        if (subscription.PriceDetails[Constants.PriceDetailKeys.DiscountedNewBooks] > 0)
                        {
                            totalPrice += book.Price - (book.Price * subscription.PriceDetails[Constants.PriceDetailKeys.NewBookDiscountPercent] / 100);
                            subscription.PriceDetails[Constants.PriceDetailKeys.DiscountedNewBooks]--;
                            isCalculated = true;
                        }
                    }
                    if (subscription.BookCategoryId == null)
                    {
                        if (subscription.PriceDetails[Constants.PriceDetailKeys.DiscountedNewBooks] > 0)
                        {
                            totalPrice += book.Price - (book.Price * subscription.PriceDetails[Constants.PriceDetailKeys.NewBookDiscountPercent] / 100);
                            subscription.PriceDetails[Constants.PriceDetailKeys.DiscountedNewBooks]--;
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

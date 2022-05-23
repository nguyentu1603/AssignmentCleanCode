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
            double totalReceiptPrice = 0, totalOldBookPrice = 0, totalNewBookPrice = 0;
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
            if (subscriptions == null)
            {
                foreach (var book in books)
                {
                    totalReceiptPrice += book.Price;
                }
                return totalReceiptPrice;
            }
            else
            {
                totalOldBookPrice = GetTotalPriceOfOldBooks(oldBooks, subscriptions);
                totalNewBookPrice = GetTotalPriceOfNewBooks(newBooks, subscriptions);
            }
            totalReceiptPrice = totalOldBookPrice + totalNewBookPrice;
            Console.WriteLine($"Total Receipt: {totalReceiptPrice}");
            return totalReceiptPrice;
        }


        public double GetTotalPriceOfOldBooks(List<Book> books, List<Subscription> subscriptions)
        {
            double totalPrice = 0, discountedPrice = 0;
            Console.WriteLine("Calculate Total Price of Old Books");
            foreach (var book in books)
            {
                bool isCalculated = false;
                foreach (var subscription in subscriptions)
                {
                    if (subscription.BookCategoryId == book.CategoryId)
                    {
                        discountedPrice = (book.Price * subscription.PriceDetails["OldBookDiscountPercent"] / 100);
                        totalPrice += 0;
                        isCalculated = true;
                        Console.WriteLine($"Book: {book.Title} - Discount: {discountedPrice} => Price: {book.Price - discountedPrice}");
                    }
                    if (subscription.BookCategoryId == null)
                    {
                        discountedPrice = (book.Price * subscription.PriceDetails["OldBookDiscountPercent"] / 100);
                        totalPrice += book.Price - discountedPrice;
                        isCalculated = true;
                        Console.WriteLine($"Book: {book.Title} - Discount: {discountedPrice} => Price: {book.Price - discountedPrice}");
                    }
                    if (isCalculated)
                    {
                        break;
                    }
                }
                if (!isCalculated)
                {
                    discountedPrice = (book.Price * 10 / 100);
                    totalPrice += book.Price - discountedPrice;
                    Console.WriteLine($"Book: {book.Title} - Discount: {discountedPrice} => Price: {book.Price - discountedPrice}");
                }
            }
            return totalPrice;
        }

        public double GetTotalPriceOfNewBooks(List<Book> books, List<Subscription> subscriptions)
        {
            double totalPrice = 0, discountedPrice = 0;
            Console.WriteLine("Calculate Total Price of New Books");
            foreach (var book in books)
            {
                bool isCalculated = false;
                foreach (var subscription in subscriptions)
                {
                    if (subscription.BookCategoryId == book.CategoryId)
                    {
                        if (subscription.PriceDetails["DiscountedBooks"] > 0)
                        {
                            discountedPrice = book.Price * subscription.PriceDetails["NewBookDiscountPercent"] / 100;
                            totalPrice += book.Price - discountedPrice;
                            subscription.PriceDetails["DiscountedBooks"]--;
                            isCalculated = true;
                            Console.WriteLine($"Book: {book.Title} - Discount: {discountedPrice} => Price: {book.Price - discountedPrice}");
                        }
                    }
                    if (subscription.BookCategoryId == null)
                    {
                        if (subscription.PriceDetails["DiscountedBooks"] > 0)
                        {
                            discountedPrice = book.Price * subscription.PriceDetails["NewBookDiscountPercent"] / 100;
                            totalPrice += book.Price - discountedPrice;
                            subscription.PriceDetails["DiscountedBooks"]--;
                            isCalculated = true;
                            Console.WriteLine($"Book: {book.Title} - Discount: {discountedPrice} => Price: {book.Price - discountedPrice}");
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
                    Console.WriteLine($"Book: {book.Title} - Price: {book.Price}");
                }
            }
            return totalPrice;
        }
    }
}

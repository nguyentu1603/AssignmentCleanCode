using System;
using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Books
{
    internal class BookService : IBookService
    {
        public IList<Book> GetBooks(List<PurchaseTransaction> purchaseTransactions)
        {
            List<Book> books = new List<Book>();
            foreach (var purchaseTransaction in purchaseTransactions)
            {
                var book = Store.Books.Data.FirstOrDefault(x => x.Id == purchaseTransaction.BookId);
                if (book != null)
                {
                    books.Add(book);
                }
            }
            Console.WriteLine("List of Books in Purchase Transaction");
            int i = 1;
            foreach (var book in books)
            {
                var status = book.IsOld ? "Old" : "New";
                Console.WriteLine($" #{i} Book Id:{book.Id} - Title: {book.Title} [{status}] - $Price: {book.Price} - Category: {book.CategoryId}");
                i++;
            }
            return books;
        }
    }
}

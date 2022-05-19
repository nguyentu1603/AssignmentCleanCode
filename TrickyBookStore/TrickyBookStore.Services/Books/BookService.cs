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
                var book = Store.Books.Data.FirstOrDefault(x => x.Id == purchaseTransaction.Id);
                if (book != null)
                {
                    books.Add(book);
                }
            }
            return books;
        }
    }
}

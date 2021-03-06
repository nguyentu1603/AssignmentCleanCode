using System;
using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Books
{
    internal class BookService : IBookService
    {
        public IList<Book> GetBooks(long[] ids)
        {
            List<Book> books = new List<Book>();
            foreach (var id in ids)
            {
                var book = Store.Books.Data.FirstOrDefault(x => x.Id == id);
                if (book != null)
                {
                    books.Add(book);
                }
            }      
            return books;
        }
    }
}

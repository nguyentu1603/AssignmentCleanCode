using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrickyBookStore.Models;

namespace TrickyBookStore.Repositories.Books
{
    public class BookRepository : IBookRepository
    {
        public IList<Book> GetBooks(long[] ids)
        {
            var books = Store.Books.Data.Where(x => ids.Contains(x.Id));
            return books.ToList();
        }
    }
}

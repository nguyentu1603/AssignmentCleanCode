using System.Collections.Generic;
using TrickyBookStore.Models;

namespace TrickyBookStore.Repositories.Books
{
    public interface IBookRepository
    {
        IList<Book> GetBooks(params long[] ids);
    }
}

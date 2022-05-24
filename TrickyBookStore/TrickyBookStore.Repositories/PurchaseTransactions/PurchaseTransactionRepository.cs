using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrickyBookStore.Models;
using TrickyBookStore.Repositories.Books;

namespace TrickyBookStore.Repositories.PurchaseTransactions
{
    public class PurchaseTransactionRepository : IPurchaseTransactionRepository
    {
        IBookRepository BookRepository { get; }
        public PurchaseTransactionRepository(IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }

        public IList<PurchaseTransaction> GetPurchaseTransactions(long customerId, DateTimeOffset fromDate, DateTimeOffset toDate)
        {
            var purchaseTransactions = Store.PurchaseTransactions.Data.Where(x => x.CustomerId == customerId && x.CreatedDate >= fromDate && x.CreatedDate <= fromDate).ToList();
            if(purchaseTransactions != null)
            {
                foreach (var purchaseTransaction in purchaseTransactions)
                {
                    purchaseTransaction.Book = BookRepository.GetBooks(purchaseTransaction.BookId).FirstOrDefault();

                }
            }
        }
    }
}

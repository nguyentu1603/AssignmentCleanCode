using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrickyBookStore.Models;

namespace TrickyBookStore.Repositories.Customers
{
    public interface ICustomerRepository
    {
        Customer GetCustomerById(long id);
    }
}

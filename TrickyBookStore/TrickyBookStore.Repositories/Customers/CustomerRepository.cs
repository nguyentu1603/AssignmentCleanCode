using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrickyBookStore.Models;
using TrickyBookStore.Repositories.Subscriptions;

namespace TrickyBookStore.Repositories.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        ISubscriptionRepository SubscriptionRepository { get; }

        public CustomerRepository(ISubscriptionRepository subscriptionRepository)
        {
            SubscriptionRepository = subscriptionRepository;
        }

        public Customer GetCustomerById(long id)
        {
            var customer = Store.Customers.Data.FirstOrDefault(x => x.Id == id);
            if(customer != null)
            {
                customer.Subscriptions = SubscriptionRepository.GetSubscriptions(customer.SubscriptionIds.ToArray());
            }
            return customer;
        }
    }
}

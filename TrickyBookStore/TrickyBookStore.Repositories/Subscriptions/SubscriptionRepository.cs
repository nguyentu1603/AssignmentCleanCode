using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrickyBookStore.Models;

namespace TrickyBookStore.Repositories.Subscriptions
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        public IList<Subscription> GetSubscriptions(params int[] ids)
        {
            var subscriptions = Store.Subscriptions.Data.Where(x => ids.Contains(x.Id));
            return subscriptions.ToList();
        }
    }
}

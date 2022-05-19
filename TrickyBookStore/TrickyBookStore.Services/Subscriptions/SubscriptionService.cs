using System.Collections.Generic;
using System.Linq;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Subscriptions
{
    internal class SubscriptionService : ISubscriptionService
    {
        public IList<Subscription> GetSubscriptions(params int[] ids)
        {
            var subscriptions = new List<Subscription>();
            foreach (var id in ids)
            {
                Subscription subscription = Store.Subscriptions.Data.FirstOrDefault(x => x.Id == id);
                if (subscription != null)
                {
                    subscriptions.Add(subscription);
                }
            }
            return subscriptions.OrderByDescending(x => x.Priority).ToList();
        }

        public double GetTotalSubcriptionPrice(List<Subscription> subscriptions)
        {
            double total = 0;
            foreach (var subscription in subscriptions)
            {
                total += subscription.PriceDetails["FixPrice"];
            }
            return total;
        }
    }
}

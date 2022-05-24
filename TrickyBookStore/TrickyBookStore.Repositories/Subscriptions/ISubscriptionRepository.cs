using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrickyBookStore.Models;

namespace TrickyBookStore.Repositories.Subscriptions
{
    public interface ISubscriptionRepository
    {
        IList<Subscription> GetSubscriptions(params int[] ids);
    }
}

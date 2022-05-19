using System.Collections.Generic;
using TrickyBookStore.Models;

namespace TrickyBookStore.Services.Store
{
    public static class Subscriptions
    {
        public static readonly IEnumerable<Subscription> Data = new List<Subscription>
        {
             new Subscription { Id = 2, SubscriptionType = SubscriptionTypes.Free, Priority = 1,
                PriceDetails = new Dictionary<string, double>
                {
                    {"FixPrice", 0 },
                    {"OldBookDiscountPercent", 10 },
                    {"NewBookDiscountPercent", 0 },
                    {"DiscountedBooks", 0 }
                }
            },
            new Subscription { Id = 1, SubscriptionType = SubscriptionTypes.Paid, Priority = 2,
                PriceDetails = new Dictionary<string, double>
                {
                    {"FixPrice", 50 },
                    {"OldBookDiscountPercent", 95 },
                    {"NewBookDiscountPercent", 5 },
                    {"DiscountedBooks", 3 }
                }
            },
            new Subscription { Id = 4, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = 3,
                PriceDetails = new Dictionary<string, double>
                {
                    {"FixPrice", 75 },
                    {"OldBookDiscountPercent", 100 },
                    {"NewBookDiscountPercent", 15 },
                    {"DiscountedBooks", 3 }
                },
                BookCategoryId = 1
            },
            new Subscription { Id = 5, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = 3,
                PriceDetails = new Dictionary<string, double>
                {
                    {"FixPrice", 75 },
                    {"OldBookDiscountPercent", 100 },
                    {"NewBookDiscountPercent", 15 },
                    {"DiscountedBooks", 3 }         
                },
                BookCategoryId = 2
            },
            new Subscription { Id = 6, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = 3,
                PriceDetails = new Dictionary<string, double>
                {
                    {"FixPrice", 75 },
                    {"OldBookDiscountPercent", 100 },
                    {"NewBookDiscountPercent", 15 },
                    {"DiscountedBooks", 3 }
                },
                BookCategoryId = 3
            },
            new Subscription { Id = 3, SubscriptionType = SubscriptionTypes.Premium, Priority = 4,
                PriceDetails = new Dictionary<string, double>
                {
                    {"FixPrice", 200 },
                    {"OldBookDiscountPercent", 100 },
                    {"NewBookDiscountPercent", 15 },
                    {"DiscountedBooks", 3 }
                }
            }
        };
    }
}

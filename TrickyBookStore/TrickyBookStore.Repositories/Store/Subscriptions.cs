using System.Collections.Generic;
using TrickyBookStore.Models;
using TrickyBookStore.Repositories.Helpers;

namespace TrickyBookStore.Repositories.Store
{
    public static class Subscriptions
    {
        public static readonly IEnumerable<Subscription> Data = new List<Subscription>
        {
            new Subscription { Id = 2, SubscriptionType = SubscriptionTypes.Free, Priority = 1,
                PriceDetails = new Dictionary<string, double>
                {
                    {Constants.PriceDetailKeys.FixPrice, Constants.SubcriptionPrice.Free },
                    {Constants.PriceDetailKeys.OldBookDiscountPercent, Constants.OldBooksDiscount.Free },
                    {Constants.PriceDetailKeys.NewBookDiscountPercent, Constants.NewBooksDiscount.Free },
                    {Constants.PriceDetailKeys.DiscountedNewBooks, Constants.LimitDiscount.Free }
                }
            },
            new Subscription { Id = 1, SubscriptionType = SubscriptionTypes.Paid, Priority = 2,
                PriceDetails = new Dictionary<string, double>
                {
                    {Constants.PriceDetailKeys.FixPrice, Constants.SubcriptionPrice.Paid },
                    {Constants.PriceDetailKeys.OldBookDiscountPercent, Constants.OldBooksDiscount.Paid },
                    {Constants.PriceDetailKeys.NewBookDiscountPercent, Constants.NewBooksDiscount.Paid },
                    {Constants.PriceDetailKeys.DiscountedNewBooks, Constants.LimitDiscount.Paid }
                }
            },
            new Subscription { Id = 4, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = 3,
                PriceDetails = new Dictionary<string, double>
                {
                    {Constants.PriceDetailKeys.FixPrice, Constants.SubcriptionPrice.CategoryAddicted },
                    {Constants.PriceDetailKeys.OldBookDiscountPercent, Constants.OldBooksDiscount.CategoryAddicted },
                    {Constants.PriceDetailKeys.NewBookDiscountPercent, Constants.NewBooksDiscount.CategoryAddicted },
                    {Constants.PriceDetailKeys.DiscountedNewBooks, Constants.LimitDiscount.CategoryAddicted }
                },
                BookCategoryId = 1
            },
            new Subscription { Id = 5, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = 3,
                PriceDetails = new Dictionary<string, double>
                {
                    {Constants.PriceDetailKeys.FixPrice, Constants.SubcriptionPrice.CategoryAddicted },
                    {Constants.PriceDetailKeys.OldBookDiscountPercent, Constants.OldBooksDiscount.CategoryAddicted },
                    {Constants.PriceDetailKeys.NewBookDiscountPercent, Constants.NewBooksDiscount.CategoryAddicted },
                    {Constants.PriceDetailKeys.DiscountedNewBooks, Constants.LimitDiscount.CategoryAddicted }
                },
                BookCategoryId = 2
            },
            new Subscription { Id = 6, SubscriptionType = SubscriptionTypes.CategoryAddicted, Priority = 3,
                PriceDetails = new Dictionary<string, double>
                {
                    {Constants.PriceDetailKeys.FixPrice, Constants.SubcriptionPrice.CategoryAddicted },
                    {Constants.PriceDetailKeys.OldBookDiscountPercent, Constants.OldBooksDiscount.CategoryAddicted },
                    {Constants.PriceDetailKeys.NewBookDiscountPercent, Constants.NewBooksDiscount.CategoryAddicted },
                    {Constants.PriceDetailKeys.DiscountedNewBooks, Constants.LimitDiscount.CategoryAddicted }
                },
                BookCategoryId = 3
            },
            new Subscription { Id = 3, SubscriptionType = SubscriptionTypes.Premium, Priority = 4,
                PriceDetails = new Dictionary<string, double>
                {
                    {Constants.PriceDetailKeys.FixPrice, Constants.SubcriptionPrice.Premium },
                    {Constants.PriceDetailKeys.OldBookDiscountPercent, Constants.OldBooksDiscount.Premium },
                    {Constants.PriceDetailKeys.NewBookDiscountPercent, Constants.NewBooksDiscount.Premium },
                    {Constants.PriceDetailKeys.DiscountedNewBooks, Constants.LimitDiscount.Premium }
                }
            }
        };
    }
}

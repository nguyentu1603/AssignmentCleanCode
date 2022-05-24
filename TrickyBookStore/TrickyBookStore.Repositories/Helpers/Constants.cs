using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyBookStore.Services.Helpers
{
    public class Constants
    {
        public static class PriceDetailKeys
        {
            public const string FixPrice = "FixPrice";
            public const string OldBookDiscountPercent = "OldBookDiscountPercent";
            public const string NewBookDiscountPercent = "NewBookDiscountPercent";
            public const string DiscountedNewBooks = "DiscountedBooks";
        }

        public static class SubcriptionPrice
        {
            public const double Free = 0;
            public const double Paid = 50;
            public const double CategoryAddicted = 75;
            public const double Premium = 200;
        }

        public static class OldBooksDiscount
        {
            public const double Free = 10;
            public const double Paid = 95;
            public const double CategoryAddicted = 100;
            public const double Premium = 100;
        }

        public static class NewBooksDiscount
        {
            public const double Free = 0;
            public const double Paid = 5;
            public const double CategoryAddicted = 15;
            public const double Premium = 15;
        }
        public static class LimitDiscount
        {
            public const double Free = 0;
            public const double Paid = 3;
            public const double CategoryAddicted = 3;
            public const double Premium = 3;
        }
    }
}

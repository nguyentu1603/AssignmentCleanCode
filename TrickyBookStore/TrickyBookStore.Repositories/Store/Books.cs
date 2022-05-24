using System.Collections.Generic;
using TrickyBookStore.Models;

namespace TrickyBookStore.Repositories.Store
{
    public static class Books
    {
        public static readonly IEnumerable<Book> Data = new List<Book>
        {
            new Book { Id = 1,Title = "Traitor With Honor", CategoryId = 1, IsOld = true, Price = 34 },
            new Book { Id = 2,Title = "Assassin Of The Prison", CategoryId = 2, IsOld = true, Price = 25 },
            new Book { Id = 3,Title = "Slaves Of The End", CategoryId = 3, IsOld = true, Price = 20 },
            new Book { Id = 4,Title = "Driving Into The Stars", CategoryId = 4, IsOld = true, Price = 16 },
            new Book { Id = 5,Title ="Emperor Of The Lost Ones", CategoryId = 3, IsOld = true, Price = 9.99 },
            new Book { Id = 6,Title ="Vanish In The Apocalypse", CategoryId = 1, IsOld = false, Price = 70 },
            new Book { Id = 7,Title ="Humans Of Darkness", CategoryId = 2, IsOld = false, Price = 69 },
            new Book { Id = 8,Title ="Phantom Of Rainbows", CategoryId = 3, IsOld = false, Price = 55 },
            new Book { Id = 9,Title ="Bandits Of Wood", CategoryId = 4, IsOld = false, Price = 88 },
            new Book { Id = 10,Title ="Spire Of The Eternal", CategoryId = 2, IsOld = false, Price = 76 },
            new Book { Id = 11,Title ="Rebels Of Fire", CategoryId = 2, IsOld = false, Price = 85 },
            new Book { Id = 12,Title ="Robots And Creators", CategoryId = 1, IsOld = false, Price = 74 },
            new Book { Id = 13,Title ="Life At My Destiny", CategoryId = 2, IsOld = false, Price = 65 },
            new Book { Id = 14,Title ="Amusing The Fog", CategoryId = 3, IsOld = false, Price = 45 },
            new Book { Id = 15,Title ="Effect With Money", CategoryId = 1, IsOld = false, Price = 33 },
            new Book { Id = 16,Title ="Hunters And Girls", CategoryId = 1, IsOld = false, Price = 81 },
            new Book { Id = 17,Title ="Dogs Of Gold", CategoryId = 4, IsOld = false, Price = 42 },
            new Book { Id = 18,Title ="Guarding The Night", CategoryId = 2, IsOld = false, Price = 82 },
        };
    }
}

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ACWS_Data.Models
{
    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Participants.Any())
            {
                return;
            }

            context.Participants.AddRange(
                new Participant
                {
                    FirstName = "Johnny",
                    LastName = "Dough",
                    Email = "johnny.dough@example.com",
                    DateOfBirth = new DateTime(1983, 3, 19),
                    ToSPP = true
                }
            );
            context.SaveChanges();

            context.SerialNumbers.AddRange(
                new SerialNumber
                {
                    ParticipantID = context.Participants.FirstOrDefault(p => p.Email == "johnny.dough@example.com").ParticipantID,
                    SerialKey = "ASDFGHJK"
                },
                new SerialNumber
                {
                    ParticipantID = context.Participants.FirstOrDefault(p => p.Email == "johnny.dough@example.com").ParticipantID,
                    SerialKey = "QWERTYUI"
                },
                new SerialNumber
                {
                    ParticipantID = context.Participants.FirstOrDefault(p => p.Email == "johnny.dough@example.com").ParticipantID,
                    SerialKey = "12345678"
                }
            );
            context.SaveChanges();

            context.Products.AddRange(
                new Product
                {
                    ProductName = "Nvidia GTX 2080Ti",
                    AvailableQuantity = 3
                },
                new Product
                {
                    ProductName = "Intel i9-10900X",
                    AvailableQuantity = 4
                },
                new Product
                {
                    ProductName = "AMD Ryzen 9 3950X",
                    AvailableQuantity = 5
                },
                new Product
                {
                    ProductName = "G.SKILL Trident Z 16GB DDR4 3600MHz",
                    AvailableQuantity = 8
                },
                new Product
                {
                    ProductName = "WD Red 10TB NAS HDD",
                    AvailableQuantity = 7
                },
                new Product
                {
                    ProductName = "Samsung 970 PRO SSD 1TB",
                    AvailableQuantity = 7
                }
            );
            context.SaveChanges();

            context.PrizePools.AddRange(
                new PrizePool
                {
                    PrizePoolName = "The Biggest and Badest",
                    PrizePoolDescription = "The best computer you can get!",
                    PrizePoolQuantity = 1
                },
                new PrizePool
                {
                    PrizePoolName = "RTX Luver",
                    PrizePoolDescription = "The perfect card for the perfect machine!",
                    PrizePoolQuantity = 2
                },
                new PrizePool
                {
                    PrizePoolName = "Intel Fan Boi",
                    PrizePoolDescription = "The newest from team blue!",
                    PrizePoolQuantity = 4
                },
                new PrizePool
                {
                    PrizePoolName = "AMD Fan Boi",
                    PrizePoolDescription = "The newest from team red!",
                    PrizePoolQuantity = 4
                },
                new PrizePool
                {
                    PrizePoolName = "MASS Storage",
                    PrizePoolDescription = "Enough to archive the world!",
                    PrizePoolQuantity = 6
                },
                new PrizePool
                {
                    PrizePoolName = "Big But Speedy",
                    PrizePoolDescription = "Alot of fast storage in a small place!",
                    PrizePoolQuantity = 6
                },
                new PrizePool
                {
                    PrizePoolName = "Battering Ram",
                    PrizePoolDescription = "Enough ram for the whole Middle Ages!",
                    PrizePoolQuantity = 3
                }
            );
            context.SaveChanges();

            context.Prizes.AddRange(
                new Prize
                {
                    PrizePoolID = context.PrizePools.FirstOrDefault(p => p.PrizePoolName == "RTX Luver").PrizePoolID,
                    ProductID = context.Products.FirstOrDefault(p => p.ProductName == "Nvidia GTX 2080Ti").ProductID,
                    ProductQuantity = 1
                },
                new Prize
                {
                    PrizePoolID = context.PrizePools.FirstOrDefault(p => p.PrizePoolName == "Intel Fan Boi").PrizePoolID,
                    ProductID = context.Products.FirstOrDefault(p => p.ProductName == "Intel i9-10900X").ProductID,
                    ProductQuantity = 1
                },
                new Prize
                {
                    PrizePoolID = context.PrizePools.FirstOrDefault(p => p.PrizePoolName == "AMD Fan Boi").PrizePoolID,
                    ProductID = context.Products.FirstOrDefault(p => p.ProductName == "AMD Ryzen 9 3950X").ProductID,
                    ProductQuantity = 1
                },
                new Prize
                {
                    PrizePoolID = context.PrizePools.FirstOrDefault(p => p.PrizePoolName == "MASS Storage").PrizePoolID,
                    ProductID = context.Products.FirstOrDefault(p => p.ProductName == "WD Red 10TB NAS HDD").ProductID,
                    ProductQuantity = 1
                },
                new Prize
                {
                    PrizePoolID = context.PrizePools.FirstOrDefault(p => p.PrizePoolName == "Big But Speedy").PrizePoolID,
                    ProductID = context.Products.FirstOrDefault(p => p.ProductName == "Samsung 970 PRO SSD 1TB").ProductID,
                    ProductQuantity = 1
                },
                new Prize
                {
                    PrizePoolID = context.PrizePools.FirstOrDefault(p => p.PrizePoolName == "Battering Ram").PrizePoolID,
                    ProductID = context.Products.FirstOrDefault(p => p.ProductName == "G.SKILL Trident Z 16GB DDR4 3600MHz").ProductID,
                    ProductQuantity = 2
                },
                new Prize
                {
                    PrizePoolID = context.PrizePools.FirstOrDefault(p => p.PrizePoolName == "The Biggest and Badest").PrizePoolID,
                    ProductID = context.Products.FirstOrDefault(p => p.ProductName == "Nvidia GTX 2080Ti").ProductID,
                    ProductQuantity = 1
                },
                new Prize
                {
                    PrizePoolID = context.PrizePools.FirstOrDefault(p => p.PrizePoolName == "The Biggest and Badest").PrizePoolID,
                    ProductID = context.Products.FirstOrDefault(p => p.ProductName == "AMD Ryzen 9 3950X").ProductID,
                    ProductQuantity = 1
                },
                new Prize
                {
                    PrizePoolID = context.PrizePools.FirstOrDefault(p => p.PrizePoolName == "The Biggest and Badest").PrizePoolID,
                    ProductID = context.Products.FirstOrDefault(p => p.ProductName == "WD Red 10TB NAS HDD").ProductID,
                    ProductQuantity = 1
                },
                new Prize
                {
                    PrizePoolID = context.PrizePools.FirstOrDefault(p => p.PrizePoolName == "The Biggest and Badest").PrizePoolID,
                    ProductID = context.Products.FirstOrDefault(p => p.ProductName == "Samsung 970 PRO SSD 1TB").ProductID,
                    ProductQuantity = 1
                },
                new Prize
                {
                    PrizePoolID = context.PrizePools.FirstOrDefault(p => p.PrizePoolName == "The Biggest and Badest").PrizePoolID,
                    ProductID = context.Products.FirstOrDefault(p => p.ProductName == "G.SKILL Trident Z 16GB DDR4 3600MHz").ProductID,
                    ProductQuantity = 2
                }
            );
            context.SaveChanges();

            context.PoolEntries.AddRange(
                new PoolEntry
                {
                    PrizePoolID = context.PrizePools.FirstOrDefault(p => p.PrizePoolName == "RTX Luver").PrizePoolID,
                    SerialNumberID = context.SerialNumbers.FirstOrDefault(s => s.SerialKey == "ASDFGHJK").SerialNumberID
                },
                new PoolEntry
                {
                    PrizePoolID = context.PrizePools.FirstOrDefault(p => p.PrizePoolName == "The Biggest and Badest").PrizePoolID,
                    SerialNumberID = context.SerialNumbers.FirstOrDefault(s => s.SerialKey == "ASDFGHJK").SerialNumberID
                },
                new PoolEntry
                {
                    PrizePoolID = context.PrizePools.FirstOrDefault(p => p.PrizePoolName == "The Biggest and Badest").PrizePoolID,
                    SerialNumberID = context.SerialNumbers.FirstOrDefault(s => s.SerialKey == "QWERTYUI").SerialNumberID
                }
            );
            context.SaveChanges();
        }
    }
}
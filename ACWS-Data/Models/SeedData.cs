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
                }
            );
            context.SaveChanges();

            context.Products.AddRange(
                new Product
                {
                    ProductName = "Nvidia GTX 2080Ti",
                    AvailableQuantity = 3
                }
            );
            context.SaveChanges();

            context.PrizePools.AddRange(
                new PrizePool
                {
                    PrizePoolName = "RTX Luver",
                    PrizePoolDescription = "The perfect card for the perfect machine.",
                    PrizePoolQuantity = 2
                }
            );
            context.SaveChanges();

            context.Prizes.AddRange(
                new Prize
                {
                    PrizePoolID = context.PrizePools.FirstOrDefault(p => p.PrizePoolName == "RTX Luver").PrizePoolID,
                    ProductID = context.Products.FirstOrDefault(p => p.ProductName == "Nvidia GTX 2080Ti").ProductID,
                    ProductQuantity = 2
                }
            );
            context.SaveChanges();

            context.PoolEntries.AddRange(
                new PoolEntry
                {
                    PrizePoolID = context.PrizePools.FirstOrDefault(p => p.PrizePoolName == "RTX Luver").PrizePoolID,
                    SerialNumberID = context.SerialNumbers.FirstOrDefault(s => s.SerialKey == "ASDFGHJK").SerialNumberID
                }
            );
            context.SaveChanges();
        }
    }
}
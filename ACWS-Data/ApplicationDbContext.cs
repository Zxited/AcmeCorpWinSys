using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ACWS_Data.Models;

namespace ACWS_Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Participant> Participants { get; set; }
        public DbSet<SerialNumber> SerialNumbers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PrizePool> PrizePools { get; set; }
        public DbSet<PoolEntry> PoolEntries { get; set; }
        public DbSet<Prize> Prizes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Participant>().ToTable("Participant");
            builder.Entity<SerialNumber>().ToTable("SerialNumber");
            builder.Entity<Product>().ToTable("Product");
            builder.Entity<PrizePool>().ToTable("PrizePool");
            builder.Entity<PoolEntry>().ToTable("PoolEntry");
            builder.Entity<Prize>().ToTable("Prize");

            builder.Entity<Prize>()
                .HasKey(c => new {c.PrizePoolID, c.ProductID});

            base.OnModelCreating(builder);
        }
    }
}

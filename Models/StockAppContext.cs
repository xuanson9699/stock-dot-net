using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace StockAppWebApi.Models
{
    public class StockAppContext : DbContext
    {
        public StockAppContext(DbContextOptions<StockAppContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<UserDevice> UserDevices { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<Etf> Etfs { get; set; }
        public DbSet<EducationalResource> EducationalResources { get; set; }
        public DbSet<LinkedBankAccount> LinkedBankAccounts { get; set; }
        public DbSet<EtfHolding> EtfHoldings { get; set; }
        public DbSet<CoveredWarrant> CoveredWarrants { get; set; }
        public DbSet<Derivative> Derivatives { get; set; }
        public DbSet<MarketIndex> MarketIndexs { get; set; }
        public DbSet<IndexConstituent> IndexConstituents { get; set; }
        public DbSet<EtfQuote> EtfQuotes { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        public DbSet<Order> Orders { get; set; }
        //public DbSet<RealtimeQuote> RealtimeQuotes { get; set; }
        //public DbSet<Quote> Quotes { get; set; }

        //public DbSet<Order> Orders { get; set; }
        //public DbSet<CoveredWarrant> CoveredWarrants { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<WatchList>()
        //        .HasKey(w => new { w.UserId, w.StockId });
        //    modelBuilder.Entity<Order>()
        //        .ToTable(table => table.HasTrigger("trigger_orders"));
        //}
    }
}

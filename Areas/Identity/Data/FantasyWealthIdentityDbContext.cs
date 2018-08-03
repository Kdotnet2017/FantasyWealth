using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FantasyWealth.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FantasyWealth.Models;

namespace FantasyWealth.Areas.Identity.Data
{
    public class FantasyWealthIdentityDbContext : IdentityDbContext<FantasyWealthUser>
    {
        public FantasyWealthIdentityDbContext(DbContextOptions<FantasyWealthIdentityDbContext> options)
            : base(options)
        {
        }
        public DbSet<Wealth> Wealths { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<TickerSymbol> TickerSymbols { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<FantasyWealthUser>().Property(FantasyWealthUser => FantasyWealthUser.CashBalanceAmount)
            .HasColumnType("decimal(18,2)");
            builder.Entity<Trade>().Property(Trade => Trade.Price)
           .HasColumnType("decimal(18,2)");
            builder.Entity<Transaction>().Property(Transaction => Transaction.TotalAmount)
           .HasColumnType("decimal(18,2)");
            builder.Entity<Trade>().Property(Trade => Trade.UserId)
            .IsRequired(true);
            builder.Entity<Transaction>().Property(Transaction => Transaction.UserId)
            .IsRequired(true);
            builder.Entity<Wealth>().Property(Wealth => Wealth.UserId)
            .IsRequired(true);

        }
    }
}

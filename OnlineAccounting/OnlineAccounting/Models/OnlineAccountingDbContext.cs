using OnlineAccounting.Models.Accounting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineAccounting.Models;
using OnlineAccounting.Models.Sales;
using OnlineAccounting.Models.Purchase;
using OnlineAccounting.Models.ViewModels;
using OnlineAccounting.Models.User;

namespace OnlineAccounting.Models
{
    public class OnlineAccountingDbContext:IdentityDbContext<ApplicationUser>
    {
        public OnlineAccountingDbContext(DbContextOptions<OnlineAccountingDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //modelBuilder.Entity<JournalEntry>().HasOne(a => a.CreditAccount).WithMany(a => a.JournalEntries).OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<JournalEntry>().HasOne(a => a.DebitAccount).WithMany(a => a.JournalEntries).OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<FinancialAccount>().HasMany(fa => fa.DebitJournalEntries).WithOne(je => je.DebitAccount).HasForeignKey(a => a.CreditAccountId).OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<FinancialAccount>().HasMany(fa => fa.CreditJournalEntries).WithOne(je => je.CreditAccount).HasForeignKey(a => a.DebitAccountId).OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<JournalEntry>().HasOne<FinancialAccount>(je => je.CreditAccount).WithMany(a=>a.CreditJournalEntries).HasForeignKey(a => a.CreditAccountId).OnDelete(DeleteBehavior.Restrict);
            //modelBuilder.Entity<JournalEntry>().HasOne<FinancialAccount>(je => je.DebitAccount).WithMany(a=>a.DebitJournalEntries).HasForeignKey(a => a.DebitAccountId).OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<FinancialAccount> FinancialAccounts { get; set; }
        //public DbSet<FinancialAccountType> AccountTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<LedgerEntry> LedgerEntries { get; set; }

        public DbSet<Customer> customers { get; set; }
        public DbSet<SalesOrder> salesOrders { get; set; }
        public DbSet<DeliveryChallan> deliveryChallans { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<ItemDetail> itemDetails { get; set; }
        public DbSet<PaymentReceived> paymentReceiveds { get; set; }
        
        public DbSet<Bill> bills { get; set; }
        public DbSet<BillItemDetail> billItemDetails { get; set; }
        public DbSet<Expense> expenses { get; set; }
        public DbSet<PaymentsMade> paymentsMades { get; set; }
        public DbSet<PurchaseOrder> purchaseOrders { get; set; }
        public DbSet<POrderItemDetail> POrderItemDetails { get; set; }
        public DbSet<Vendor> vendors { get; set; }
        public DbSet<OnlineAccounting.Models.ViewModels.RegisterViewModel> RegisterViewModel { get; set; }
        public DbSet<OnlineAccounting.Models.ViewModels.LoginViewModel> LoginViewModel { get; set; }
    }
}

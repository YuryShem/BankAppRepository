using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BankApp.Infrastructure
{
    public class BankDbConnection : DbContext
    {
        public DbSet<AccountsTable> Accounts { get; set; }
        public DbSet<AccountTypeTable> AccountTypes { get; set; }
        public DbSet<PersonsTable> Persons { get; set; }
        public DbSet<AccountBalanceTable> AccountBalance { get; set; }
        public DbSet<LoginTable> LoginsAndPasswords { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string path = @"F:\STUDY\JUNISWAT\BANKAPP\BANKAPP.INFRASTRUCTURE\BANKDB.MDF";
            optionsBuilder.UseSqlServer($"Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = {path}; Integrated Security = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountsTable>()
                .HasOne(a => a.AccountTypeTable)
                .WithMany()
                .HasForeignKey(a => a.AccountTypeId);

            modelBuilder.Entity<AccountsTable>()
                .HasOne(p => p.PersonsTable)
                .WithMany()
                .HasForeignKey(p => p.PersonId);

            modelBuilder.Entity<AccountBalanceTable>()
                .HasOne(a => a.AccountsTable)
                .WithMany()
                .HasForeignKey(a => a.AccountId);

            modelBuilder.Entity<LoginTable>()
                .HasOne(a => a.AccountsTable)
                .WithMany()
                .HasForeignKey(a => a.AccountId);
        }
    }
}

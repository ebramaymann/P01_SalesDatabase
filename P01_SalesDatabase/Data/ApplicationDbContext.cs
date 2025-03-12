using Microsoft.EntityFrameworkCore;
using P01_SalesDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace P01_SalesDatabase.Data
{


    internal class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Store> Stores { get; set; }    

        override protected void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-JUIUM6J\\SQLEXPRESS;Initial Catalog=SalesTB;Integrated Security=True;TrustServerCertificate=True");
        }

       
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ////////constraints////////
            
            //product
            modelBuilder.Entity<Product>()
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode(true)
                .IsRequired(true);

            modelBuilder.Entity<Product>()
                .Property(P=> P.Quantity)
                .IsRequired(true);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .IsRequired(true);

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(500)
                .IsUnicode();



            //customer
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerId);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Name)
                .HasMaxLength(100)
                .IsUnicode(true);

            modelBuilder.Entity<Customer>()
                .Property(c => c.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(c => c.CreditCardNumber)
                .IsRequired();


            //store
            modelBuilder.Entity<Store>()
                .HasKey(s => s.StoreId);

            modelBuilder.Entity<Store>()
                .Property(s => s.Name)
                .HasMaxLength(80)
                .IsUnicode();


            //sale
            modelBuilder.Entity<Sale>()
                .HasKey(s => s.SaleId);

            modelBuilder.Entity<Sale>()
               .Property(s => s.Date)
               .HasDefaultValueSql("GETDATE()");






        }

    }
}

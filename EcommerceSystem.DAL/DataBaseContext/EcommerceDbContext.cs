using EcommerceSystem.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
namespace EcommerceSystem.DAL.DataBaseContext
{
    public class EcommerceSystemdb : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public EcommerceSystemdb() { }
        public EcommerceSystemdb(DbContextOptions<EcommerceSystemdb> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Hardcoded connection string
                string connectionString = "Server=NAQASH-ASIF-128\\SQLEXPRESS;Database=EcommerceDataBase;Trusted_Connection=True;TrustServerCertificate=True;";

                // Configure DbContext to use SQL Server with the connection string
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
        }
    }

}



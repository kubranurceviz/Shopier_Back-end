using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Concreate
{
    public class Context : DbContext
    {
        private readonly IConfiguration _configuration;

        public Context(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seller - Order (One-to-Many)
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Seller)  // Order'ın bir Seller'ı var
                .WithMany(s => s.Orders) // Seller'ın birden fazla Order'ı olabilir
                .HasForeignKey(o => o.SellerId);

            // Seller - Product (One-to-Many)
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Seller)  // Product'ın bir Seller'ı var
                .WithMany(s => s.Products) // Seller'ın birden fazla Product'ı olabilir
                .HasForeignKey(p => p.SellerId);

            // Order - Product (Many-to-Many)
            modelBuilder.Entity<OrderProduct>()
                .HasKey(op => new { op.OrderId, op.ProductId }); // Composite Key

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)  // OrderProduct'ın bir Order'ı var
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product) // OrderProduct'ın bir Product'ı var
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.ProductId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = _configuration.GetConnectionString("Shopier");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        
    }

}

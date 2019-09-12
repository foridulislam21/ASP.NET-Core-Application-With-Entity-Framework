using Ecommerce.DatabaseContext.FluentConfiguration;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DatabaseContext
{
    public class EcommerceDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies(false)
                .UseSqlServer("Server=(local);Database=EcommarceDB4; Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductFluentConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryFluentConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerFluentConfiguration());
            modelBuilder.ApplyConfiguration(new OrderFluentConfiguration());

            modelBuilder.Entity<ProductOrder>().HasKey(c => new { c.ProductId, c.OrderId });

            modelBuilder.Entity<ProductOrder>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.Orders)
                .HasForeignKey(pt => pt.ProductId);

            modelBuilder.Entity<ProductOrder>()
                .HasOne(pt => pt.Order)
                .WithMany(t => t.Products)
                .HasForeignKey(pt => pt.OrderId);
        }
    }
}
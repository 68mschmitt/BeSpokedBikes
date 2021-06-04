using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class BeSpokedDataContext : DbContext
    {
        public BeSpokedDataContext(DbContextOptions<BeSpokedDataContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SalesPerson> SalesPeople { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discount>().Property(d => d.DiscountPercentage).HasPrecision(18, 4);
            modelBuilder.Entity<Product>().Property(p => p.CommissionPercentage).HasPrecision(18, 4);

            base.OnModelCreating(modelBuilder);
        }
    }
}
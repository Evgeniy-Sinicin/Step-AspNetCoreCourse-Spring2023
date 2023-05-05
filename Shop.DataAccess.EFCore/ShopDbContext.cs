using Microsoft.EntityFrameworkCore;
using Shop.BusinessLogic.Models;

namespace Shop.DataAccess.EFCore
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Link> Links { get; set; }

        public DbSet<Order> Orders { get; set; }

        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(product => product.Id);
                entity.Property(product => product.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<Link>(entity =>
            {
                entity.HasKey(link => new { link.CategoryId, link.ProductId });
                entity.Property(link => link.ProductId).ValueGeneratedNever();
                entity.Property(link => link.CategoryId).ValueGeneratedNever();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}

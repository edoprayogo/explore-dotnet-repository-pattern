using explore_pattern.Api.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace explore_pattern.Api.Databases
{
    public class DemoStoreDbContext : DbContext
    {
        public DemoStoreDbContext(DbContextOptions<DemoStoreDbContext> options)
            : base(options) { }

        public DbSet<Store> Stores => Set<Store>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).HasMaxLength(100).IsRequired();
                entity.Property(x => x.CreatedAt)
                      .HasDefaultValueSql("SYSDATETIME()");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).HasMaxLength(100).IsRequired();

                entity.HasOne(x => x.Store)
                      .WithMany(x => x.Categories)
                      .HasForeignKey(x => x.StoreId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).HasMaxLength(150).IsRequired();
                entity.Property(x => x.Price)
                      .HasColumnType("decimal(18,2)");

                entity.HasOne(x => x.Category)
                      .WithMany(x => x.Products)
                      .HasForeignKey(x => x.CategoryId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.OrderDate)
                      .HasDefaultValueSql("SYSDATETIME()");

                entity.HasOne(x => x.Product)
                      .WithMany(x => x.Orders)
                      .HasForeignKey(x => x.ProductId);
            });
        }
    }
}

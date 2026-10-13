using CircloPos.Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CircloPos.Catalog.Insfrastructure.Persistence
{
    public sealed class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var product = modelBuilder.Entity<Product>();

            product.ToTable("Products");
            product.HasKey(x => x.Id);

            product.Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();

            product.Property(x => x.Price)
                .HasPrecision(12, 2)
                .IsRequired();

            product.Property(x => x.CreatedAt)
                .IsRequired();
        }
    }
}

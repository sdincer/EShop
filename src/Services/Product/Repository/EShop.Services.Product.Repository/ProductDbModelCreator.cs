using EShop.Services.Product.Repository.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Product.Repository
{
    internal partial class ProductDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BrandConfiguration());
            modelBuilder.ApplyConfiguration(new UnitConfiguration());
            modelBuilder.ApplyConfiguration(new VariantConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ListingConfiguration());
            modelBuilder.ApplyConfiguration(new ListingVariantConfiguration());
        }
    }
}

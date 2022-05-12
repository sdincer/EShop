using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Product.Repository
{
    internal partial class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Entity.Brand> Brands { get; set; }
        public DbSet<Entity.Category> Categories { get; set; }
        public DbSet<Entity.Unit> Units { get; set; }
        public DbSet<Entity.Variant> Variants { get; set; }
        public DbSet<Entity.Product> Products { get; set; }
        public DbSet<Entity.ProductCategory> ProductCategories { get; set; }
        public DbSet<Entity.Listing> Listings { get; set; }
        public DbSet<Entity.ListingVariant> ListingVariants { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Product.Repository
{
    public partial class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public virtual DbSet<Entity.Brand> Brands { get; set; }
        public virtual DbSet<Entity.Category> Categories { get; set; }
        public virtual DbSet<Entity.Unit> Units { get; set; }
        public virtual DbSet<Entity.Variant> Variants { get; set; }
        public virtual DbSet<Entity.Product> Products { get; set; }
        public virtual DbSet<Entity.ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<Entity.Listing> Listings { get; set; }
        public virtual DbSet<Entity.ListingVariant> ListingVariants { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Services.Product.Repository.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Entity.Product>
    {
        public void Configure(EntityTypeBuilder<Entity.Product> builder)
        {
            builder.ToTable(nameof(Entity.Product));

            //Id
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            //BrandId
            builder.Property(m => m.BrandId).IsRequired();

            //UnitId
            builder.Property(m => m.UnitId).IsRequired();

            //Name
            builder.Property(m => m.Name).IsRequired().HasMaxLength(250);

            //Code
            builder.Property(m => m.Code).IsRequired().HasMaxLength(15);
            builder.HasIndex(m => m.Code).IsUnique();

            //Brand
            builder.HasOne(m => m.Brand).WithMany().HasForeignKey(m => m.BrandId);

            //Unit
            builder.HasOne(m => m.Unit).WithMany().HasForeignKey(m => m.UnitId);

            //Categories
            builder.HasMany(m => m.Categories).WithMany(m => m.Products)
                .UsingEntity<Entity.ProductCategory>(
                    m => m.HasOne(m => m.Category).WithMany().HasForeignKey(m => m.CategoryId),
                    m => m.HasOne(m => m.Product).WithMany().HasForeignKey(m => m.ProductId)
                );

            //Listings
            builder.HasMany(m => m.Listings).WithOne(m => m.Product).HasForeignKey(m => m.ProductId);
        }
    }
}

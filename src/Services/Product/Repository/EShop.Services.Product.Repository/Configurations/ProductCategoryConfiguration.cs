using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Services.Product.Repository.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<Entity.ProductCategory>
    {
        public void Configure(EntityTypeBuilder<Entity.ProductCategory> builder)
        {
            builder.ToTable(nameof(Entity.ProductCategory));

            //Key
            builder.HasKey(m => new { m.CategoryId, m.ProductId });

            //CategoryId
            builder.Property(m => m.CategoryId).IsRequired();

            //ProductId
            builder.Property(m => m.ProductId).IsRequired();

            //Category
            builder.HasOne(m => m.Category).WithMany().HasForeignKey(m => m.CategoryId);

            //Product
            builder.HasOne(m => m.Product).WithMany().HasForeignKey(m => m.ProductId);
        }
    }
}

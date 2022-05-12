using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Services.Product.Repository.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Entity.Category>
    {
        public void Configure(EntityTypeBuilder<Entity.Category> builder)
        {
            builder.ToTable(nameof(Entity.Category));

            //Id
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            //Name
            builder.Property(m => m.Name).IsRequired().HasMaxLength(250);

            builder.Property(m => m.ParentCategoryId).IsRequired(false);

            //ParentCategory
            builder.HasOne(m => m.ParentCategory).WithMany(m => m.ChildCategories)
                .HasForeignKey(m => m.ParentCategoryId).OnDelete(DeleteBehavior.Restrict);

            //Products
            builder.HasMany(m => m.Products).WithMany(m => m.Categories)
                .UsingEntity<Entity.ProductCategory>(
                    m => m.HasOne(m => m.Product).WithMany().HasForeignKey(m => m.ProductId),
                    m => m.HasOne(m => m.Category).WithMany().HasForeignKey(m => m.CategoryId)
                );
        }
    }
}

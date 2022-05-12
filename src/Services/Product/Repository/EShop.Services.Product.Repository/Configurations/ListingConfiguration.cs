using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Services.Product.Repository.Configurations
{
    public class ListingConfiguration : IEntityTypeConfiguration<Entity.Listing>
    {
        public void Configure(EntityTypeBuilder<Entity.Listing> builder)
        {
            builder.ToTable(nameof(Entity.Listing));

            //Id
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            //Key
            builder.HasIndex(m => m.Sku).IsUnique();
            builder.Property(m => m.Sku).IsRequired();
            builder.Property(m => m.Sku).HasMaxLength(10);

            //Unit Price
            builder.Property(m => m.UnitPrice).IsRequired();

            //Stock
            builder.Property(m => m.Stock).IsRequired();

            //Product
            builder.HasOne(m => m.Product).WithMany(m => m.Listings).HasForeignKey(m => m.ProductId);

            //ListingVariants
            builder.HasMany(m => m.Variants).WithOne(m => m.Listing).HasForeignKey(m => m.ListingId);
        }
    }
}

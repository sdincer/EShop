using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Services.Product.Repository.Configurations
{
    public class ListingVariantConfiguration : IEntityTypeConfiguration<Entity.ListingVariant>
    {
        public void Configure(EntityTypeBuilder<Entity.ListingVariant> builder)
        {
            builder.ToTable(nameof(Entity.ListingVariant));

            //Key
            builder.HasKey(m => new { m.VariantId, m.ListingId });

            //VariantId
            builder.Property(m => m.VariantId).IsRequired();

            //ProductVariantId
            builder.HasIndex(m => m.ListingId);
            builder.Property(m => m.ListingId).IsRequired();

            //Value
            builder.Property(m => m.Value).IsRequired();

            //Variant
            builder.HasOne(m => m.Variant).WithMany().HasForeignKey(m => m.VariantId);

            //Listing
            builder.HasOne(m => m.Listing).WithMany(m => m.Variants).HasForeignKey(m => m.ListingId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Services.Product.Repository.Configurations
{
    public class VariantConfiguration : IEntityTypeConfiguration<Entity.Variant>
    {
        public void Configure(EntityTypeBuilder<Entity.Variant> builder)
        {
            builder.ToTable(nameof(Entity.Variant));

            //Id
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            //Name
            builder.Property(m => m.Name).IsRequired().HasMaxLength(150);
        }
    }
}

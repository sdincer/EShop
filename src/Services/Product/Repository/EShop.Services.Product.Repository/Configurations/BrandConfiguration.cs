using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Services.Product.Repository.Configurations
{
    public class BrandConfiguration : IEntityTypeConfiguration<Entity.Brand>
    {
        public void Configure(EntityTypeBuilder<Entity.Brand> builder)
        {
            builder.ToTable(nameof(Entity.Brand));

            //Id
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            //Name
            builder.Property(m => m.Name).IsRequired().HasMaxLength(20);
        }
    }
}

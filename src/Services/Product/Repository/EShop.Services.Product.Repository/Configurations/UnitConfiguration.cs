using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Services.Product.Repository.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Entity.Unit>
    {
        public void Configure(EntityTypeBuilder<Entity.Unit> builder)
        {
            builder.ToTable(nameof(Entity.Unit));

            //Id
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            //Name
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);

            //ShortName
            builder.Property(m => m.ShortName).IsRequired().HasMaxLength(20);
        }
    }
}

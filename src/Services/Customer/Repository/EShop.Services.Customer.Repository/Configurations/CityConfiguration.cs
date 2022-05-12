using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Services.Customer.Repository.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<Entity.City>
    {
        public void Configure(EntityTypeBuilder<Entity.City> builder)
        {
            builder.ToTable(nameof(Entity.City));

            //Id
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            //Code
            builder.HasIndex(m => m.Code).IsUnique();
            builder.Property(m => m.Code).IsRequired().HasMaxLength(2);

            //Name
            builder.Property(m => m.Name).IsRequired().HasMaxLength(20);

            //Districts
            builder.HasMany(m => m.Districts).WithOne(m => m.City).HasForeignKey(m => m.CityId);

        }
    }
}
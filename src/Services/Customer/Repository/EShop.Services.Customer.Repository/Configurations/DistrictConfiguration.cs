using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Services.Customer.Repository.Configurations
{
    public class DistrictConfiguration : IEntityTypeConfiguration<Entity.District>
    {
        public void Configure(EntityTypeBuilder<Entity.District> builder)
        {
            builder.ToTable(nameof(Entity.District));

            //Id
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            //Name
            builder.Property(m => m.Name).IsRequired().HasMaxLength(20);

            //Districts
            builder.HasMany(m => m.Neighbourhoods).WithOne(m => m.District).HasForeignKey(m => m.DistrictId);
        }
    }
}

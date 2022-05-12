using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Services.Customer.Repository.Configurations
{
    public class NeighbourhoodConfiguration : IEntityTypeConfiguration<Entity.Neighbourhood>
    {
        public void Configure(EntityTypeBuilder<Entity.Neighbourhood> builder)
        {
            builder.ToTable(nameof(Entity.Neighbourhood));

            //Id
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            //Name
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);
        }
    }
}

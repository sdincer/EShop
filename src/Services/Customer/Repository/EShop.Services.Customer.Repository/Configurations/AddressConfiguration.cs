using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Services.Customer.Repository.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Entity.Address>
    {
        public void Configure(EntityTypeBuilder<Entity.Address> builder)
        {
            builder.ToTable(nameof(Entity.Address));

            //Id
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            //CustomerId
            builder.HasIndex(m => m.CustomerId);
            builder.Property(m => m.CustomerId).IsRequired();

            //Type
            builder.Property(m => m.Type).IsRequired();

            //Name
            builder.Property(m => m.Name).IsRequired().HasMaxLength(100);

            //PostalCode
            builder.Property(m => m.PostalCode).IsRequired();

            //Type
            builder.Property(m => m.NeighbourhoodId).IsRequired();

            //AddressLine
            builder.Property(m => m.AddressLine).IsRequired().HasMaxLength(500);

            //Customer
            builder.HasOne(m => m.Customer).WithMany(m => m.Addresses).HasForeignKey(m => m.CustomerId);

            //Neighbourhood
            builder.HasOne(m => m.Neighbourhood).WithMany().HasForeignKey(m => m.NeighbourhoodId);
        }
    }
}

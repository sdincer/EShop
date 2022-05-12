using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Services.Customer.Repository.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Entity.Customer>
    {
        public void Configure(EntityTypeBuilder<Entity.Customer> builder)
        {
            builder.ToTable(nameof(Entity.Customer));

            //Id
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            //Key
            builder.HasIndex(m => m.Email).IsUnique();
            builder.Property(m => m.Email).IsRequired();
            builder.Property(m => m.Email).HasMaxLength(350);

            //First Name
            builder.Property(m => m.FirstName).IsRequired().HasMaxLength(255);

            //Last Name
            builder.Property(m => m.LastName).IsRequired().HasMaxLength(255);

            //Phone Number
            builder.Property(m => m.PhoneNumber).IsRequired().HasMaxLength(11);

            //Addresses
            builder.HasMany(m => m.Addresses).WithOne(m => m.Customer).HasForeignKey(m => m.CustomerId);
        }
    }
}

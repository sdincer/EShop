using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Order.Repository.Sql.Configurations
{
    internal class OrderAddressConfiguration : IEntityTypeConfiguration<Entity.OrderAddress>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entity.OrderAddress> builder)
        {
            //Id
            builder.HasKey(m => m.OrderId);

            //BillingAddressId
            builder.Property(m => m.BillingAddressId).IsRequired();

            //ShippingAddressId
            builder.Property(m => m.ShippingAddressId).IsRequired();

            //Order
            builder.HasOne(m => m.Order).WithOne();
        }
    }
}

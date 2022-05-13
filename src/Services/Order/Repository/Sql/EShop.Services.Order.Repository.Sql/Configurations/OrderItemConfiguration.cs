using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Order.Repository.Sql.Configurations
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<Entity.OrderItem>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entity.OrderItem> builder)
        {
            //Id
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            //OrderId
            builder.Property(m => m.OrderId).IsRequired();

            //Sku
            builder.Property(m => m.Sku).IsRequired();

            //Quantity
            builder.Property(m => m.Quantity).IsRequired();

            //Price
            builder.Property(m => m.Amount).IsRequired();

            //Order
            builder.HasOne(m => m.Order).WithMany().HasForeignKey(m => m.OrderId);
        }
    }
}

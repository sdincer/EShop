using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Order.Repository.Sql.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Entity.Order>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Entity.Order> builder)
        {
            //Id
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd();

            //CustomerEmail
            builder.Property(m => m.CustomerEmail).IsRequired();

            //Amount
            builder.Property(m => m.TotalAmount).IsRequired();

            //Status
            builder.Property(m => m.Status).IsRequired();

            //CreatedAt
            builder.Property(m => m.CreatedAt).IsRequired();

            //Address
            builder.HasOne(m => m.Address).WithOne();

            //Items
            builder.HasMany(m => m.Items).WithOne(m => m.Order).HasForeignKey(m => m.OrderId);
        }
    }
}

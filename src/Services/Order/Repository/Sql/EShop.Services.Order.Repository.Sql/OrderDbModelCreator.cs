using EShop.Services.Order.Repository.Sql.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Order.Repository.Sql
{
    internal partial class OrderDbModelCreator : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderAddressConfiguration());
        }
    }
}
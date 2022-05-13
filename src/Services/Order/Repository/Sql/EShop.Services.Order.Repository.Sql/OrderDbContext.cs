using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Order.Repository.Sql
{
    internal partial class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }

        public DbSet<Entity.Order> Orders { get; set; }
        public DbSet<Entity.OrderItem> OrderItems { get; set; }
        public DbSet<Entity.OrderAddress> OrderAddresses { get; set; }
    }
}

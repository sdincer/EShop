using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Customer.Repository
{
    internal partial class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        public DbSet<Entity.Customer> Customers { get; set; }
        public DbSet<Entity.Address> Addresses { get; set; }
        public DbSet<Entity.City> Cities { get; set; }
        public DbSet<Entity.District> Districts { get; set; }
        public DbSet<Entity.Neighbourhood> Neighbourhoods { get; set; }
    }
}

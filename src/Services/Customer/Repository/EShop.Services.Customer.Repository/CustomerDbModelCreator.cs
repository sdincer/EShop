using EShop.Services.Customer.Repository.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EShop.Services.Customer.Repository
{
    internal partial class CustomerDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new DistrictConfiguration());
            modelBuilder.ApplyConfiguration(new NeighbourhoodConfiguration());
        }
    }
}

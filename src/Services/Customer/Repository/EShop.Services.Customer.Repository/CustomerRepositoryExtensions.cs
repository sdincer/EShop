using EShop.Services.Customer.Application.Abstraction.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace EShop.Services.Customer.Repository
{
    public static class CustomerRepositoryExtensions
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerDbContext>(options => options
                //.UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("SqlServer")));

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddTransient<CustomerTestDataSeeder>();

            var testDataSeeder = services.BuildServiceProvider().GetRequiredService<CustomerTestDataSeeder>();
            testDataSeeder.SeedTestData();

            return services;
        }
    }
}

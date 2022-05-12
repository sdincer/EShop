using EShop.Services.Product.Application.Abstraction.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Services.Product.Repository
{
    public static class ProductRepositoryExtensions
    {
        public static IServiceCollection RegisterRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options => options
                //.UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("SqlServer")));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddTransient<ProductTestDataSeeder>();

            var testDataSeeder = services.BuildServiceProvider().GetRequiredService<ProductTestDataSeeder>();
            testDataSeeder.SeedTestData();

            return services;
        }
    }
}

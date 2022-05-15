using EShop.Services.Order.Application.Abstraction.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Services.Order.Repository.Sql
{
    public static class OrderRepositoryExtensions
    {
        public static IServiceCollection RegisterSqlRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("SqlServer")));

            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}

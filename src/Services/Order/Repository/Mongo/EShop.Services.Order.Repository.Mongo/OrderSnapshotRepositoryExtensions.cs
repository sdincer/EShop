using EShop.Services.Order.Application.Abstraction.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Services.Order.Repository.Mongo
{
    public static class OrderSnapshotRepositoryExtensions
    {
        public static IServiceCollection RegisterMongoRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IOrderSnapshotRepository>(new OrderSnapshotRepository(configuration.GetConnectionString("Mongo")));

            return services;
        }
    }
}

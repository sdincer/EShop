using EShop.Services.Order.Repository.Mongo;
using EShop.Services.Order.Repository.Sql;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EShop.Services.Order.Application.Abstraction.ExternalServices;
using EShop.Services.Order.External.ServiceClient;

namespace EShop.Services.Order.Application.Bootstrapper
{
    public static class ServiceExtensions
    {
        public static IServiceCollection BootstrapApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterSqlRepository(configuration);
            services.RegisterMongoRepository(configuration);

            var commands = AppDomain.CurrentDomain.Load("EShop.Services.Order.Application.Command");
            var queries = AppDomain.CurrentDomain.Load("EShop.Services.Order.Application.Query");

            services.AddMediatR(commands, queries);

            services.AddHttpClient("ApiGateway", httpClient => {
                httpClient.BaseAddress = new Uri(configuration["ApiGatewayUrl"]);
            });

            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IProductService, ProductService>();

            return services;
        }
    }
}
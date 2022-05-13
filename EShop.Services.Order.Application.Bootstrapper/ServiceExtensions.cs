using EShop.Services.Order.Repository.Mongo;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Services.Order.Application.Bootstrapper
{
    public static class ServiceExtensions
    {
        public static IServiceCollection BootstrapApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterMongoRepository(configuration);

            var commands = AppDomain.CurrentDomain.Load("EShop.Services.Order.Application.Command");
            var queries = AppDomain.CurrentDomain.Load("EShop.Services.Order.Application.Query");

            services.AddMediatR(commands, queries);

            return services;
        }
    }
}
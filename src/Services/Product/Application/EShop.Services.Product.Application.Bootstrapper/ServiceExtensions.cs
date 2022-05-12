using EShop.Services.Product.Repository;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Services.Product.Application.Bootstrapper
{
    public static class ServiceExtensions
    {
        public static IServiceCollection BootstrapApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepository(configuration);

            var commands = AppDomain.CurrentDomain.Load("EShop.Services.Product.Application.Command");
            var queries = AppDomain.CurrentDomain.Load("EShop.Services.Product.Application.Query");

            services.AddMediatR(commands, queries);

            return services;
        }
    }
}
using EShop.Services.Customer.Repository;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EShop.Services.Customer.Application.Bootstrapper
{
    public static class ServiceExtensions
    {
        public static IServiceCollection BootstrapApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepository(configuration);

            var queries = AppDomain.CurrentDomain.Load("EShop.Services.Customer.Application.Query");

            services.AddMediatR(queries);

            return services;
        }
    }
}
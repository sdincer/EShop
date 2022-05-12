using EShop.Services.Customer.Application.Bootstrapper;

namespace EShop.Services.Customer.Api
{
    public static class ServiceExtensions
    {
        public static IServiceCollection Bootstrap(this IServiceCollection services, IConfiguration configuration)
        {
            services.BootstrapApplication(configuration);

            return services;
        }
    }
}

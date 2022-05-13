using EShop.Services.Order.Application.Bootstrapper;

namespace EShop.Services.Order.Api
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

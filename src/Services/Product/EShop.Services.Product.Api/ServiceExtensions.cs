using EShop.Services.Product.Application.Bootstrapper;

namespace EShop.Services.Product.Api
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

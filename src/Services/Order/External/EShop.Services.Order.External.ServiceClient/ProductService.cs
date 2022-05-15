using EShop.Services.Order.Application.Abstraction.ExternalServices;

namespace EShop.Services.Order.External.ServiceClient
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiGateway");
        }
    }
}
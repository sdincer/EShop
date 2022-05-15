using EShop.Services.Order.Application.Abstraction.ExternalServices;
using System.Net.Http;

namespace EShop.Services.Order.External.ServiceClient
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiGateway");
        }
    }
}

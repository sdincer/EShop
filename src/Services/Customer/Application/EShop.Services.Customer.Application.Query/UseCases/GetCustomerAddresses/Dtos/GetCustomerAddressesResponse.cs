using EShop.Services.Customer.Application.Abstraction.DataAccess.Models;

namespace EShop.Services.Customer.Application.Query.UseCases.GetCustomerAddresses.Dtos
{
    public class GetCustomerAddressesResponse
    {
        public IEnumerable<Address> Addresses { get; set; }
    }
}

using MediatR;

namespace EShop.Services.Customer.Application.Query.UseCases.GetCustomerAddresses.Dtos
{
    public class GetCustomerAddressesRequest : IRequest<GetCustomerAddressesResponse>
    {
        public string Email { get; set; }
    }
}

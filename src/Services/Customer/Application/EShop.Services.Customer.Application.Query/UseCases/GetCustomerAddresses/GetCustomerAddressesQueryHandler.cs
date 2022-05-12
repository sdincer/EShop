using EShop.Services.Customer.Application.Abstraction.DataAccess;
using EShop.Services.Customer.Application.Query.UseCases.GetCustomerAddresses.Dtos;
using MediatR;

namespace EShop.Services.Customer.Application.Query.UseCases.GetCustomerAddresses
{
    public class GetCustomerAddressesQueryHandler : IRequestHandler<GetCustomerAddressesRequest, GetCustomerAddressesResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerAddressesQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<GetCustomerAddressesResponse> Handle(GetCustomerAddressesRequest request, CancellationToken cancellationToken)
        {
            var response = new GetCustomerAddressesResponse
            {
                Addresses = _customerRepository.GetCustomerAddressesByEmail(request.Email)
            };

            return response;
        }
    }
}

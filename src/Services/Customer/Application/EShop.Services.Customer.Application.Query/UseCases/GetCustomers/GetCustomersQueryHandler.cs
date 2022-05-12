using EShop.Services.Customer.Application.Abstraction.DataAccess;
using EShop.Services.Customer.Application.Query.UseCases.GetCustomers.Dtos;
using MediatR;

namespace EShop.Services.Customer.Application.Query.UseCases.GetCustomers
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersRequest, GetCustomersResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<GetCustomersResponse> Handle(GetCustomersRequest request, CancellationToken cancellationToken)
        {
            var response = new GetCustomersResponse
            {
                Customers = _customerRepository.GetCustomers()
            };

            return response;
        }
    }
}

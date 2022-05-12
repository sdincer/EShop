using EShop.Services.Customer.Application.Abstraction.DataAccess;
using EShop.Services.Customer.Application.Query.UseCases.GetCustomerByEmail.Dtos;
using MediatR;

namespace EShop.Services.Customer.Application.Query.UseCases.GetCustomerByEmail
{
    public class GetCustomerByEmailQueryHandler : IRequestHandler<GetCustomerByEmailRequest, GetCustomerByEmailResponse>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByEmailQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<GetCustomerByEmailResponse> Handle(GetCustomerByEmailRequest request, CancellationToken cancellationToken)
        {
            var response = new GetCustomerByEmailResponse();

            var customer = _customerRepository.GetCustomerByEmail(request.Email);

            if(customer == null)
            {
                throw new Exception("Customer not found!");
            }

            response.Customer = customer;

            return response;
        }
    }
}

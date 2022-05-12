using EShop.Services.Customer.Application.Query.UseCases.GetCustomerAddresses.Dtos;
using EShop.Services.Customer.Application.Query.UseCases.GetCustomerByEmail.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Services.Customer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetCustomerByEmail")]
        public async Task<GetCustomerByEmailResponse> Get([FromQuery] string email)
        {
            return await _mediator.Send(new GetCustomerByEmailRequest { Email = email });
        }

        [HttpGet("adresses", Name = "GetCustomerAddresses")]
        public async Task<GetCustomerAddressesResponse> GetAddresses([FromQuery] string email)
        {
            return await _mediator.Send(new GetCustomerAddressesRequest { Email = email });
        }
    }
}
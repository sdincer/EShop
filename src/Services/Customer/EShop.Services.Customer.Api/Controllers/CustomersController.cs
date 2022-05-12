using EShop.Services.Customer.Application.Query.UseCases.GetCustomers.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Services.Customer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetCustomers")]
        public async Task<GetCustomersResponse> Get()
        {
            return await _mediator.Send(new GetCustomersRequest());
        }
    }
}
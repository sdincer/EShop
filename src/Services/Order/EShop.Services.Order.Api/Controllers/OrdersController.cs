using EShop.Services.Order.Application.Query.UseCases.GetOrders.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Services.Order.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetOrders")]
        public async Task<GetOrdersResponse> Get([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate)
        {
            return await _mediator.Send(new GetOrdersRequest
            {
                StartDate = startDate,
                EndDate = endDate
            });
        }
    }
}
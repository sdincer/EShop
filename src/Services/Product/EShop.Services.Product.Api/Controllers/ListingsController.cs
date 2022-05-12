using EShop.Services.Product.Application.Command.UseCases.DecreaseListingStock.Dtos;
using EShop.Services.Product.Application.Query.UseCases.GetListingBySku.Dtos;
using EShop.Services.Product.Application.Query.UseCases.GetProducts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Services.Product.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ListingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{sku}", Name = "GetListingBySku")]
        public async Task<GetListingBySkuResponse> GetListingBySku([FromRoute] string sku)
        {
            return await _mediator.Send(new GetListingBySkuRequest { Sku = sku});
        }

        [HttpPost("{sku}/descrease-stock", Name = "DescreaseListingStock")]
        public async Task<IActionResult> DescreaseListingStock([FromRoute] string sku, [FromBody] DecreaseStockRequest request)
        {
            await _mediator.Send(new DecreaseListingStockRequest {  Sku = sku, Quantity = request.Quantity });
            return NoContent();
        }
    }
}
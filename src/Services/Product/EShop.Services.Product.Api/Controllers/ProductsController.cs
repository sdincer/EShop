using EShop.Services.Product.Application.Query.UseCases.GetListingsByProductCode.Dtos;
using EShop.Services.Product.Application.Query.UseCases.GetProducts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Services.Product.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<GetProductResponse> Get()
        {
            return await _mediator.Send(new GetProductRequest());
        }

        [HttpGet("{productCode}/listings", Name = "GetListingsByProductCode")]
        public async Task<GetListingsByProductCodeResponse> GetProductListings([FromRoute] string productCode)
        {
            return await _mediator.Send(new GetListingsByProductCodeRequest { ProductCode = productCode });
        }
    }
}
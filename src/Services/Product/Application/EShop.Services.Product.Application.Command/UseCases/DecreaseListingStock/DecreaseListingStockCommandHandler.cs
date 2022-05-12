using EShop.Services.Product.Application.Abstraction.DataAccess;
using EShop.Services.Product.Application.Abstraction.DataAccess.Models;
using EShop.Services.Product.Application.Command.UseCases.DecreaseListingStock.Dtos;
using MediatR;

namespace EShop.Services.Product.Application.Command.UseCases.DecreaseListingStock
{
    public class DecreaseListingStockCommandHandler : IRequestHandler<DecreaseListingStockRequest, DecreaseListingStockResponse>
    {
        private readonly IProductRepository _productRepository;

        public DecreaseListingStockCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DecreaseListingStockResponse> Handle(DecreaseListingStockRequest request, CancellationToken cancellationToken)
        {
            var result = _productRepository.DecreaseListingStock(request.Sku, request.Quantity);

            if (result == DescreaseStockOpResult.ListingNotFound)
            {
                throw new Exception("Listing not found!");
            }
            if (result == DescreaseStockOpResult.InsufficientStock)
            {
                throw new Exception("Insufficient stock!");
            }

            return new DecreaseListingStockResponse();
        }
    }
}

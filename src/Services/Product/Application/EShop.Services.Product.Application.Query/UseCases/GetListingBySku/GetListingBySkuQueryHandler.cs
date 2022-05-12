using EShop.Services.Product.Application.Abstraction.DataAccess;
using EShop.Services.Product.Application.Query.UseCases.GetListingBySku.Dtos;
using MediatR;

namespace EShop.Services.Product.Application.Query.UseCases.GetListingBySku
{
    public class GetListingBySkuQueryHandler : IRequestHandler<GetListingBySkuRequest, GetListingBySkuResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetListingBySkuQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetListingBySkuResponse> Handle(GetListingBySkuRequest request, CancellationToken cancellationToken)
        {
            var response = new GetListingBySkuResponse
            {
                Listing = _productRepository.GetListingBySku(request.Sku)
            };

            return response;
        }
    }
}

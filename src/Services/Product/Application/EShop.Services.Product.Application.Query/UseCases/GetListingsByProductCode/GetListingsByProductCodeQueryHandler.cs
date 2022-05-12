using EShop.Services.Product.Application.Abstraction.DataAccess;
using EShop.Services.Product.Application.Query.UseCases.GetListingsByProductCode.Dtos;
using MediatR;

namespace EShop.Services.Product.Application.Query.UseCases.GetListingsByProductCode
{
    public class GetListingsByProductCodeQueryHandler : IRequestHandler<GetListingsByProductCodeRequest, GetListingsByProductCodeResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetListingsByProductCodeQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetListingsByProductCodeResponse> Handle(GetListingsByProductCodeRequest request, CancellationToken cancellationToken)
        {
            var response = new GetListingsByProductCodeResponse
            {
                Listings = _productRepository.GetListingsByProductCode(request.ProductCode)
            };

            return response;
        }
    }
}

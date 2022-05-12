using EShop.Services.Product.Application.Abstraction.DataAccess;
using EShop.Services.Product.Application.Query.UseCases.GetProducts.Dtos;
using MediatR;

namespace EShop.Services.Product.Application.Query.UseCases.GetProducts
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductRequest, GetProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var response = new GetProductResponse
            {
                Products = _productRepository.GetAll()
            };

            return response;
        }
    }
}

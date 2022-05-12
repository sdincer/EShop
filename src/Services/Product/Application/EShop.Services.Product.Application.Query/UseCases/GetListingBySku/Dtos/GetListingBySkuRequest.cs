using MediatR;

namespace EShop.Services.Product.Application.Query.UseCases.GetListingBySku.Dtos
{
    public class GetListingBySkuRequest : IRequest<GetListingBySkuResponse>
    {
        public string Sku { get; set; }
    }
}

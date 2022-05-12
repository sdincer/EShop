using MediatR;

namespace EShop.Services.Product.Application.Command.UseCases.DecreaseListingStock.Dtos
{
    public class DecreaseListingStockRequest : DecreaseStockRequest, IRequest<DecreaseListingStockResponse>
    {
        public string Sku { get; set; }
    }
}
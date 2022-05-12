using EShop.Services.Product.Application.Abstraction.DataAccess.Models;

namespace EShop.Services.Product.Application.Query.UseCases.GetListingBySku.Dtos
{
    public class GetListingBySkuResponse
    {
        public Listing Listing { get; set; }
    }
}

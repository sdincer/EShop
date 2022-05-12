using EShop.Services.Product.Application.Abstraction.DataAccess.Models;

namespace EShop.Services.Product.Application.Query.UseCases.GetListingsByProductCode.Dtos
{
    public class GetListingsByProductCodeResponse
    {
        public IEnumerable<Listing> Listings { get; set; }
    }
}

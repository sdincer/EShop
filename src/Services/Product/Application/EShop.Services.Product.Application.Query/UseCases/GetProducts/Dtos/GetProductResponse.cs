namespace EShop.Services.Product.Application.Query.UseCases.GetProducts.Dtos
{
    public class GetProductResponse
    {
        public IEnumerable<Abstraction.DataAccess.Models.Product> Products { get; set; }
    }
}

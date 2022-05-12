namespace EShop.Services.Product.Application.Abstraction.DataAccess
{
    public interface IProductRepository
    {
        IEnumerable<Models.Product> GetAll();
        IEnumerable<Models.Listing> GetListingsByProductCode(string productCode);
        Models.Listing GetListingBySku(string sku);
        Models.DescreaseStockOpResult DecreaseListingStock(string sku, int quantity);
    }
}

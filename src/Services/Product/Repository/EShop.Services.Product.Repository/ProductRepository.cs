using EShop.Services.Product.Application.Abstraction.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace EShop.Services.Product.Repository
{
    internal class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _dbContext;

        public ProductRepository(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Application.Abstraction.DataAccess.Models.Product> GetAll()
        {
            var result = new List<Application.Abstraction.DataAccess.Models.Product>();
            var allProductEntities = _dbContext.Products
                .Include(m => m.Unit)
                .Include(m => m.Brand)
                .Include(m => m.Categories).ThenInclude(c => c.ParentCategory);

            foreach (var productEntity in allProductEntities)
            {
                var productModel = new Application.Abstraction.DataAccess.Models.Product
                {
                    Code = productEntity.Code,
                    Name = productEntity.Name,
                    Unit = productEntity.Unit.Name,
                    Brand = productEntity.Brand.Name,
                    Categories = new List<string>()
                };

                FillCategories(productModel, productEntity.Categories);

                result.Add(productModel);
            }

            return result;
        }

        public IEnumerable<Application.Abstraction.DataAccess.Models.Listing> GetListingsByProductCode(string productCode)
        {
            var product = _dbContext.Products
                .Include(m => m.Unit)
                .Include(m => m.Listings).ThenInclude(l => l.Variants).ThenInclude(v => v.Variant)
                .FirstOrDefault(m => m.Code == productCode);

            if (product == null)
            {
                return Enumerable.Empty<Application.Abstraction.DataAccess.Models.Listing>();
            }

            return product.Listings.Where(m => m.Variants.Any()).Select(CreateListingModel).ToList();
        }

        public Application.Abstraction.DataAccess.Models.Listing GetListingBySku(string sku)
        {
            var listing = _dbContext.Listings
                .Include(l => l.Product).ThenInclude(p => p.Unit)
                .Include(l => l.Variants).ThenInclude(v => v.Variant)
                .FirstOrDefault(m => m.Sku == sku);

            if (listing == null)
            {
                return default;
            }

            return CreateListingModel(listing);
        }

        public Application.Abstraction.DataAccess.Models.DescreaseStockOpResult DecreaseListingStock(string sku, int quantity)
        {
            var listing = _dbContext.Listings.FirstOrDefault(m => m.Sku == sku);

            if(listing == null)
            {
                return Application.Abstraction.DataAccess.Models.DescreaseStockOpResult.ListingNotFound;
            }

            if(listing.Stock < quantity)
            {
                return Application.Abstraction.DataAccess.Models.DescreaseStockOpResult.InsufficientStock;
            }

            listing.Stock -= quantity;

            _dbContext.SaveChanges();

            return Application.Abstraction.DataAccess.Models.DescreaseStockOpResult.Success;
        }

        private static void FillCategories(Application.Abstraction.DataAccess.Models.Product productModel, ICollection<Entity.Category> categories)
        {
            foreach (var categoryEntity in categories)
            {
                var cetegoryNames = new List<string>();

                var parent = categoryEntity.ParentCategory;

                cetegoryNames.Add(categoryEntity.Name);

                while (parent != null)
                {
                    cetegoryNames.Add(parent.Name);
                    parent = parent.ParentCategory;
                }

                cetegoryNames.Reverse();
                productModel.Categories.Add(string.Join('/', cetegoryNames));
            }
        }

        private static Application.Abstraction.DataAccess.Models.Listing CreateListingModel(Entity.Listing listing)
        {
            return new Application.Abstraction.DataAccess.Models.Listing
            {
                Sku = listing.Sku,
                ProductName = listing.Product.Name,
                ProductUnit = listing.Product.Unit.Name,
                UnitPrice = listing.UnitPrice,
                Thumbnail = listing.Thumbnail,
                InStock = listing.Stock > default(int),
                Properties = listing.Variants.ToDictionary(m => m.Variant.Name, m => m.Value)
            };
        }
    }
}

using EShop.Services.Product.Repository;
using Moq;
using Xunit;
using Moq.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using EShop.Services.Product.Application.Abstraction.DataAccess.Models;

namespace EShop.Tests.Product.Repository
{
    public class ProductRepositoryTest
    {
        private readonly ProductRepository _productRepository;

        public ProductRepositoryTest()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                .UseInMemoryDatabase(databaseName: "Product")
                .Options;

            var productDbContext = new ProductDbContext(options);
            var productTestDataSeeder = new ProductTestDataSeeder(productDbContext);
            productTestDataSeeder.SeedTestData();

            _productRepository = new ProductRepository(productDbContext);
        }

        [Fact]
        public void GetAll_ReturnsAllProductEntities()
        {
            // Act
            var entities = _productRepository.GetAll();

            // Assert
            Assert.Equal(3, entities.Count());
            Assert.All(entities,  item => Assert.NotNull(item.Unit));
            Assert.All(entities,  item => Assert.NotNull(item.Brand));
            Assert.All(entities,  item => Assert.NotNull(item.Categories));
            Assert.All(entities,  item => Assert.NotEmpty(item.Categories));
        }

        [Fact]
        public void WhenProductCodeIsNotFound_GetListingsByProductCode_ReturnsEmptyList()
        {
            // Arrange
            var productCode = "DUMMY_PRODUCT_CODE";
            var entities = Enumerable.Empty<Listing>();

            // Act
            var exception = Record.Exception(() => { entities = _productRepository.GetListingsByProductCode(productCode); });

            // Assert
            Assert.Null(exception);
            Assert.NotNull(entities);
            Assert.Equal(Enumerable.Empty<Listing>().Count(), entities.Count());
        }

        [Fact]
        public void WhenProductCodeIsFound_GetListingsByProductCode_ReturnsListingInfoListHasVariant()
        {
            // Arrange
            var productCode = "H67027";
            var entities = Enumerable.Empty<Listing>();

            // Act
            var exception = Record.Exception(() => { entities = _productRepository.GetListingsByProductCode(productCode); });

            // Assert
            Assert.Null(exception);
            Assert.NotNull(entities);
            Assert.Equal(2, entities.Count());
            Assert.All(entities, item => Assert.NotEmpty(item.Properties));
        }

        [Fact]
        public void WhenSkuCodeIsNotFound_GetListingBySku_ReturnsNull()
        {
            // Arrange
            var sku = "DUMMY_SKU";
            Listing entity = default;

            // Act
            var exception = Record.Exception(() => { entity = _productRepository.GetListingBySku(sku); });

            // Assert
            Assert.Null(exception);
            Assert.Null(entity);
        }

        [Fact]
        public void WhenSkuCodeIsFound_GetListingBySku_ReturnsListingInfo()
        {
            // Arrange
            var sku = "H6702701";
            Listing entity = default;

            // Act
            var exception = Record.Exception(() => { entity = _productRepository.GetListingBySku(sku); });

            // Assert
            Assert.Null(exception);
            Assert.NotNull(entity);
            Assert.Equal(sku, entity.Sku);
            Assert.Equal(string.Empty, entity.Thumbnail);
            Assert.Equal(999, entity.UnitPrice);
            Assert.NotEmpty(entity.Properties);
            Assert.Equal(2, entity.Properties.Count);
            Assert.True(entity.InStock);
        }

        [Fact]
        public void WhenSkuCodeIsNotFound_DecreaseListingStock_ReturnsListingNotFound()
        {
            // Arrange
            var sku = "DUMMY_SKU";
            var quantity = 2;
            var result = DescreaseStockOpResult.Success;

            // Act
            var exception = Record.Exception(() => { result = _productRepository.DecreaseListingStock(sku, quantity); });

            // Assert
            Assert.Null(exception);
            Assert.Equal(DescreaseStockOpResult.ListingNotFound, result);
        }

        [Fact]
        public void WhenStockIsInsufficient_DecreaseListingStock_ReturnsInsufficientStock()
        {
            // Arrange
            var sku = "H6702702";
            var quantity = 15;
            var result = DescreaseStockOpResult.Success;

            // Act
            var exception = Record.Exception(() => { result = _productRepository.DecreaseListingStock(sku, quantity); });

            // Assert
            Assert.Null(exception);
            Assert.Equal(DescreaseStockOpResult.InsufficientStock, result);
        }

        [Fact]
        public void WhenSkuIsExistAndStockIsSsufficient_DecreaseListingStock_ReturnsSuccess()
        {
            // Arrange
            var sku = "H6702702";
            var quantity = 5;
            var result = DescreaseStockOpResult.Success;

            // Act
            var exception = Record.Exception(() => { result = _productRepository.DecreaseListingStock(sku, quantity); });

            // Assert
            Assert.Null(exception);
            Assert.Equal(DescreaseStockOpResult.Success, result);
        }
    }
}
using EShop.Services.Product.Api.Controllers;
using EShop.Services.Product.Application.Abstraction.DataAccess.Models;
using EShop.Services.Product.Application.Query.UseCases.GetListingsByProductCode.Dtos;
using EShop.Services.Product.Application.Query.UseCases.GetProducts.Dtos;
using MediatR;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EShop.Tests.Product.Api
{
    public class ProductsControllerTest
    {
        private readonly Mock<IMediator> _meditorMock;
        private readonly ProductsController _productsController;

        public ProductsControllerTest()
        {
            _meditorMock = new Mock<IMediator>();
            _productsController = new ProductsController(_meditorMock.Object);
        }

        [Fact]
        public void GetProducts_ReturnsProductInfoList()
        {
            // Arrange
            var response = new GetProductResponse
            {
                Products = new List<Services.Product.Application.Abstraction.DataAccess.Models.Product>
                {
                    new Services.Product.Application.Abstraction.DataAccess.Models.Product
                    {
                        Code = "Code1",
                        Name = "Product1",
                        Brand = "Brand1",
                        Unit = "Unit1",
                        Categories = new List<string> { "Category1", "Cetagory2" }
                    },
                    new Services.Product.Application.Abstraction.DataAccess.Models.Product
                    {
                        Code = "Code2",
                        Name = "Product2",
                        Brand = "Brand2",
                        Unit = "Unit2",
                        Categories = new List<string> { "Category3", "Cetagory4" }
                    }
                }
            };

            _meditorMock.Setup(m => m
                .Send(It.IsAny<GetProductRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response));

            // Act
            var apiResponse = _productsController.Get().ConfigureAwait(false).GetAwaiter().GetResult();

            // Assert
            _meditorMock.Verify(m => m.Send(It.IsAny<GetProductRequest>(), It.IsAny<CancellationToken>()), times: Times.Once);

            Assert.Equal(response.GetHashCode(), apiResponse.GetHashCode());
        }

        [Fact]
        public void GetListingsByProductCode_ReturnsListingInfoList()
        {
            // Arrange
            var productCode = "00000";
            var request = new GetListingsByProductCodeRequest { ProductCode = productCode };
            var response = new GetListingsByProductCodeResponse
            {
                Listings = new List<Listing>
                {
                    new Listing
                    {
                        InStock = true,
                        ProductName = "ProductName1",
                        ProductUnit = "ProductUnit1",
                        Sku = "Sku1",
                        Thumbnail = "Thumbnail1",
                        UnitPrice = 10.00M,
                        Properties = new Dictionary<string, string>
                        {
                            { "PropertyKey1", "PropertyValue1" }
                        }
                    }
                }
            };

            _meditorMock.Setup(m => m
                .Send(It.IsAny<GetListingsByProductCodeRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response));

            // Act
            var apiResponse = _productsController.GetProductListings(productCode).ConfigureAwait(false).GetAwaiter().GetResult();

            // Assert
            _meditorMock.Verify(m => m.Send(It.IsAny<GetListingsByProductCodeRequest>(), It.IsAny<CancellationToken>()), times: Times.Once);

            Assert.Equal(response.GetHashCode(), apiResponse.GetHashCode());
        }
    }
}

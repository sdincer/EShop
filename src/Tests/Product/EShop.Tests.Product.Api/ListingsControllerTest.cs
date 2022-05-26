using EShop.Services.Product.Api.Controllers;
using EShop.Services.Product.Application.Abstraction.DataAccess.Models;
using EShop.Services.Product.Application.Command.UseCases.DecreaseListingStock.Dtos;
using EShop.Services.Product.Application.Query.UseCases.GetListingBySku.Dtos;
using EShop.Services.Product.Application.Query.UseCases.GetListingsByProductCode.Dtos;
using EShop.Services.Product.Application.Query.UseCases.GetProducts.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace EShop.Tests.Product.Api
{
    public class ListingsControllerTest
    {
        private readonly Mock<IMediator> _meditorMock;
        private readonly ListingsController _listingsController;

        public ListingsControllerTest()
        {
            _meditorMock = new Mock<IMediator>();
            _listingsController = new ListingsController(_meditorMock.Object);
        }

        [Fact]
        public void GetListingBySku_ReturnsListingInfo()
        {
            // Arrange
            var sku = "00000";
            var response = new GetListingBySkuResponse
            {
                Listing = new Listing
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
            };

            _meditorMock.Setup(m => m
                .Send(It.IsAny<GetListingBySkuRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response));

            // Act
            var apiResponse = _listingsController.GetListingBySku(sku).ConfigureAwait(false).GetAwaiter().GetResult();

            // Assert
            _meditorMock.Verify(m => m.Send(It.IsAny<GetListingBySkuRequest>(), It.IsAny<CancellationToken>()), times: Times.Once);

            Assert.Equal(response.GetHashCode(), apiResponse.GetHashCode());
        }

        [Fact]
        public void DescreaseListingStock_ReturnsNoContent()
        {
            // Arrange
            var sku = "00000";
            var quantity = 10;
            var request = new DecreaseStockRequest { Quantity = quantity };

            _meditorMock.Setup(m => m
                .Send(It.IsAny<DecreaseListingStockRequest>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(It.IsAny<DecreaseListingStockResponse>()));

            // Act
            var apiResponse = _listingsController.DescreaseListingStock(sku, request).ConfigureAwait(false).GetAwaiter().GetResult();

            // Assert
            _meditorMock.Verify(m => m.Send(It.IsAny<DecreaseListingStockRequest>(), It.IsAny<CancellationToken>()), times: Times.Once);

            Assert.Equal(typeof(NoContentResult), apiResponse.GetType());
        }
    }
}

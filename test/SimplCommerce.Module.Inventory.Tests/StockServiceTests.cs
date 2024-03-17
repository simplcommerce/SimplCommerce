using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MockQueryable.Moq;
using Moq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Inventory.Event;
using SimplCommerce.Module.Inventory.Models;
using SimplCommerce.Module.Inventory.Services;
using Xunit;

namespace SimplCommerce.Module.Inventory.Tests
{
    public class StockServiceTests
    {
        private Mock<IRepository<Stock>> _stockRepoMock;
        private Mock<IRepository<Product>> _productRepoMock;

        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IRepository<StockHistory>> _stockHistoryRepoMock;
        private readonly Warehouse _testWarehouse = new(100) { VendorId = 123 };

        public StockServiceTests()
        {
            _stockHistoryRepoMock = new Mock<IRepository<StockHistory>>();
            _mediatorMock = new Mock<IMediator>();
        }

        //[Theory]
        //[InlineData(100, 50)]
        //[InlineData(1000, 560)]
        //[InlineData(13, 5)]
        //[InlineData(143, 0)]
        //public async Task AddAllProductsTest(int productsCount, int stocksCount)
        //{
        //    InitializeMocks(productsCount, stocksCount);
            
        //    var service = new StockService(_stockRepoMock.Object, _productRepoMock.Object,
        //        _stockHistoryRepoMock.Object, _mediatorMock.Object);
        //    await service.AddAllProduct(_testWarehouse);

        //    _stockRepoMock.Verify(m =>
        //        m.AddRange(It.Is<IEnumerable<Stock>>(arg => arg.Count() == productsCount - stocksCount)));
        //}

        [Theory]
        [InlineData(1, 1, -5)]
        [InlineData(1, 1, -10)]
        [InlineData(1, 1, 7)]
        [InlineData(1, 1, 0)]
        [InlineData(1, 1, -2)]
        public async Task UpdateStockTest(int productsCount, int stocksCount, int adjustedQuantity)
        {
            // Arrange
            InitializeMocks(productsCount, stocksCount);

            var service = new StockService(
                _stockRepoMock.Object,
                _productRepoMock.Object,
               _stockHistoryRepoMock.Object,
               _mediatorMock.Object);

            var product = _productRepoMock.Object
                .Query()
                .FirstOrDefault();
            var stock = _stockRepoMock.Object
              .Query()
              .FirstOrDefault(o => o.ProductId == product.Id && o.WarehouseId == _testWarehouse.Id);
            var prevStockQuantity = stock.Quantity;
            var request = new StockUpdateRequest
            {
                AdjustedQuantity = adjustedQuantity,
                ProductId = product.Id,
                WarehouseId = _testWarehouse.Id,
            };

            // Act
            await service.UpdateStock(request);


            // Assert
            var newStockQuantity = stock.Quantity;
            Assert.Equal(Math.Max(0, prevStockQuantity + adjustedQuantity), newStockQuantity);
        }

        private void InitializeMocks(int productsCount, int stocksCount)
        {
            _stockRepoMock = new Mock<IRepository<Stock>>();
            var stocks = new Stock[stocksCount];
            for (int i = 1; i <= stocks.Length; i++)
            {
                stocks[i - 1] = new Stock
                {
                    ProductId = i,
                    Quantity = 5,
                    WarehouseId = _testWarehouse.Id
                };
            }

            var stocksMock = stocks.BuildMock();
            _stockRepoMock.Setup(x => x.Query())
                .Returns(stocksMock);
            _stockRepoMock.Setup(x => x.AddRange(It.IsAny<IEnumerable<Stock>>()));

            _productRepoMock = new Mock<IRepository<Product>>();
            var products = new Product[productsCount];
            for (int i = 1; i <= products.Length; i++)
            {
                products[i - 1] = new Product { HasOptions = false, VendorId = _testWarehouse.VendorId };
                typeof(Product).GetProperty("Id").SetValue(products[i - 1], i);
            }

            var productsMock = products.BuildMock();
            _productRepoMock
                .Setup(x => x.Query())
                .Returns(productsMock);

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<ProductBackInStock>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(Task.CompletedTask);
        }
    }
}

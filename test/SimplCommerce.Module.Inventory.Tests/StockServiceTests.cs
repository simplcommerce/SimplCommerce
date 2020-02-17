using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Inventory.Models;
using SimplCommerce.Module.Inventory.Services;
using Xunit;

namespace SimplCommerce.Module.Inventory.Tests
{
    public class StockServiceTests
    {
        private  Mock<IRepository<Stock>> _stockRepoMock;
        private  Mock<IRepository<Product>> _productRepoMock;
        private readonly Mock<IRepository<StockHistory>> _stockHistoryRepoMock;
        private readonly Warehouse _testWarehouse = new Warehouse(100) {VendorId = 123};

        public StockServiceTests()
        {
            _stockHistoryRepoMock = new Mock<IRepository<StockHistory>>();
        }

        //[Theory]
        //[InlineData(100,50)]
        //[InlineData(1000,560)]
        //[InlineData(13, 5)]
        //[InlineData(143, 0)]
        //public async Task AddAllProductsTest(int productsCount, int  stocksCount)
        //{
        //    InitializeMocks(productsCount, stocksCount);
        //    var service = new StockService(_stockRepoMock.Object, _productRepoMock.Object,
        //        _stockHistoryRepoMock.Object);
        //    await service.AddAllProduct(_testWarehouse);

        //    _stockRepoMock.Verify(m =>
        //        m.AddRange(It.Is<IEnumerable<Stock>>(arg => arg.Count() == productsCount - stocksCount)));
        //}

        private void InitializeMocks(int productsCount, int stocksCount)
        {
            _stockRepoMock = new Mock<IRepository<Stock>>();
            var stocks = new Stock[stocksCount];
            for (int i = 1; i <= stocks.Length; i++)
            {
                stocks[i - 1] = new Stock
                    { ProductId = i, Quantity = 5, WarehouseId = _testWarehouse.Id };
            }

            _stockRepoMock.Setup(x => x.Query()).Returns(() => new TestAsyncEnumerable<Stock>(stocks.AsQueryable()));
            _stockRepoMock.Setup(x => x.AddRange(It.IsAny<IEnumerable<Stock>>()));
            _productRepoMock = new Mock<IRepository<Product>>();
            var products = new Product[productsCount];

            for (int i = 1; i <= products.Length; i++)
            {
                products[i - 1] = new Product { HasOptions = false, VendorId = _testWarehouse.VendorId };
                typeof(Product).GetProperty("Id").SetValue(products[i - 1], i);
            }

            _productRepoMock.Setup(x => x.Query()).Returns(new TestAsyncEnumerable<Product>(products.AsQueryable()));
        }
    }
}

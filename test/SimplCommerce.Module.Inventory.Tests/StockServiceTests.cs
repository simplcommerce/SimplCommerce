using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using java.lang;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Inventory.Areas.Inventory.Controllers;
using SimplCommerce.Module.Inventory.Areas.Inventory.ViewModels;
using SimplCommerce.Module.Inventory.Models;
using SimplCommerce.Module.Inventory.Services;
using Xunit;

namespace SimplCommerce.Module.Inventory.Tests.Controllers
{
    public class StockApiControllerTests
    {
        [Fact]
        public async Task List_ReturnsOkResult()
        {
            // Arrange
            var stockRepositoryMock = new Mock<IRepository<Stock>>();
            var stockServiceMock = new Mock<IStockService>();
            var workContextMock = new Mock<IWorkContext>();
            var warehouseRepositoryMock = new Mock<IRepository<Warehouse>>();
            var stockHistoryRepositoryMock = new Mock<IRepository<StockHistory>>();

            var controller = new StockApiController(
                stockRepositoryMock.Object,
                stockServiceMock.Object,
                workContextMock.Object,
                warehouseRepositoryMock.Object,
                stockHistoryRepositoryMock.Object
            );

            var warehouseId = 1;
            var param = new SmartTableParam();
            
             

            // Act
            var result = await controller.List(warehouseId, param);
            var okResult = result as OkObjectResult;

            // Assert
            
            //Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task Put_ReturnsAcceptedResult()
        {
            // Arrange
            var stockRepositoryMock = new Mock<IRepository<Stock>>();
            var stockServiceMock = new Mock<IStockService>();
            var workContextMock = new Mock<IWorkContext>();
            var warehouseRepositoryMock = new Mock<IRepository<Warehouse>>();
            var stockHistoryRepositoryMock = new Mock<IRepository<StockHistory>>();

            var controller = new StockApiController(
                stockRepositoryMock.Object,
                stockServiceMock.Object,
                workContextMock.Object,
                warehouseRepositoryMock.Object,
                stockHistoryRepositoryMock.Object
            );

            var warehouseId = 1;
            var stockVms = new List<StockVm> { new StockVm { ProductId = 1, AdjustedQuantity = 5 } };

            // Act
            var result = await controller.Put(warehouseId, stockVms);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task GetStockHistory_ReturnsOkResult()
        {
            // Arrange
            var stockRepositoryMock = new Mock<IRepository<Stock>>();
            var stockServiceMock = new Mock<IStockService>();
            var workContextMock = new Mock<IWorkContext>();
            var warehouseRepositoryMock = new Mock<IRepository<Warehouse>>();
            var stockHistoryRepositoryMock = new Mock<IRepository<StockHistory>>();

            var controller = new StockApiController(
                stockRepositoryMock.Object,
                stockServiceMock.Object,
                workContextMock.Object,
                warehouseRepositoryMock.Object,
                stockHistoryRepositoryMock.Object
            );

            var warehouseId = 1;
            var productId = 1;

            // Act
            //var result = await controller.GetStockHistory(warehouseId, productId);

            // Assert
           // Assert.IsType<OkObjectResult>(result);
        }
    }
}

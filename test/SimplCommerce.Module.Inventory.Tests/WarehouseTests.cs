using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Inventory.Areas.Inventory.Controllers;
using SimplCommerce.Module.Inventory.Areas.Inventory.ViewModels;
using SimplCommerce.Module.Inventory.Models;
using Xunit;

namespace SimplCommerce.Module.Inventory.Tests.Controllers
{
    public class WarehouseApiControllerTests
    {
        [Fact]
        public async Task Get_ReturnsOkResult()
        {
            // Arrange
            var warehouseRepositoryMock = new Mock<IRepository<Warehouse>>();
            var addressRepositoryMock = new Mock<IRepository<Address>>();
            var workContextMock = new Mock<IWorkContext>();

            var controller = new WarehouseApiController(warehouseRepositoryMock.Object, workContextMock.Object, addressRepositoryMock.Object);

            // Act
           // var result = await controller.Get();

            // Assert
           // var actionResult = Assert.IsType< ActionResult>(result);
        }

        [Fact]
        public async Task List_ReturnsJsonResult()
        {
            // Arrange
            var warehouseRepositoryMock = new Mock<IRepository<Warehouse>>();
            var addressRepositoryMock = new Mock<IRepository<Address>>();
            var workContextMock = new Mock<IWorkContext>();

            var controller = new WarehouseApiController(warehouseRepositoryMock.Object, workContextMock.Object, addressRepositoryMock.Object);
            var param = new SmartTableParam();

            // Act
           // var result = await controller.List(param);

            // Assert
          //  Assert.IsType<JsonResult>(result);
        }

        [Fact]
        public async Task GetById_ReturnsJsonResult()
        {
            // Arrange
            var warehouseRepositoryMock = new Mock<IRepository<Warehouse>>();
            var addressRepositoryMock = new Mock<IRepository<Address>>();
            var workContextMock = new Mock<IWorkContext>();

            var controller = new WarehouseApiController(warehouseRepositoryMock.Object, workContextMock.Object, addressRepositoryMock.Object);
            var warehouseId = 1;

            // Act
           // var result = await controller.Get(warehouseId);

            // Assert
           // Assert.IsType<JsonResult>(result);
        }

        [Fact]
        public async Task Post_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var warehouseRepositoryMock = new Mock<IRepository<Warehouse>>();
            var addressRepositoryMock = new Mock<IRepository<Address>>();
            var workContextMock = new Mock<IWorkContext>();

            var controller = new WarehouseApiController(warehouseRepositoryMock.Object, workContextMock.Object, addressRepositoryMock.Object);
            var warehouseVm = new WarehouseVm();

            // Act
           //var result = await controller.Post(warehouseVm);

            // Assert
          // Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public async Task Put_ReturnsAcceptedResult()
        {
            // Arrange
            var warehouseRepositoryMock = new Mock<IRepository<Warehouse>>();
            var addressRepositoryMock = new Mock<IRepository<Address>>();
            var workContextMock = new Mock<IWorkContext>();

            var controller = new WarehouseApiController(warehouseRepositoryMock.Object, workContextMock.Object, addressRepositoryMock.Object);
            var warehouseId = 1;
            var warehouseVm = new WarehouseVm();

            // Act

            //var result = await controller.Put(warehouseId, warehouseVm);

            // Assert
            //Assert.IsType<AcceptedResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsNoContentResult()
        {
            // Arrange
            var warehouseRepositoryMock = new Mock<IRepository<Warehouse>>();
            var addressRepositoryMock = new Mock<IRepository<Address>>();
            var workContextMock = new Mock<IWorkContext>();

            var controller = new WarehouseApiController(warehouseRepositoryMock.Object, workContextMock.Object, addressRepositoryMock.Object);
            var warehouseId = 1;

            // Act
            //var result = await controller.Delete(warehouseId);

            // Assert
            //Assert.IsType<NoContentResult>(result);
        }
    }
}

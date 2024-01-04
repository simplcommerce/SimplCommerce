using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Payments.Areas.Payments.Controllers;
using SimplCommerce.Module.Payments.Models;
using Xunit;

namespace SimplCommerce.Module.Payments.Tests.Controllers
{
    public class PaymentApiControllerTests
    {

        [Fact]
        public async Task GetByOrder_ValidOrderId_ReturnsOkResult()
        {
            // Arrange
            long validOrderId = 1;
            var paymentRepositoryMock = new Mock<IRepository<Payment>>();
            var currencyServiceMock = new Mock<ICurrencyService>();
            var controller = new PaymentApiController(paymentRepositoryMock.Object, currencyServiceMock.Object);

            var paymentsData = new List<Payment>
        {
            new Payment { OrderId = 1234557, Amount = 50.0m, PaymentFee = 2.0m, Status = PaymentStatus.Pending, CreatedOn = DateTime.Now },
            new Payment { OrderId = validOrderId, Amount = 30.0m, PaymentFee = 1.0m, Status = PaymentStatus.Completed, CreatedOn = DateTime.Now }
            // Add more sample payments if needed
        };

            paymentRepositoryMock.Setup(repo => repo.Query().Where(x => x.OrderId == OrderId)
                .Select(x => new
                {
                    x.Id,
                    x.Amount,
                    
                    x.PaymentFee,
                    
                    x.OrderId,
                    x.GatewayTransactionId,
                    Status = x.Status.ToString(),
                    x.CreatedOn
                })).ReturnsAsync(paymentsData);

            // Act
            var result = await controller.GetByOrder(validOrderId);

            // Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var payments = Assert.IsType<List<object>>(okObjectResult.Value);
            Assert.Equal(2, payments.Count); // Assuming we have 2 payments for the validOrderId
        }

        //[Fact]
        //public async Task GetByOrder_InvalidOrderId_ReturnsNotFoundResult()
        //{
        //    // Arrange
        //    long invalidOrderId = 999; // Assuming 999 is an invalid order ID
        //    var paymentRepositoryMock = new Mock<IRepository<Payment>>();
        //    var currencyServiceMock = new Mock<ICurrencyService>();
        //    var controller = new PaymentApiController(paymentRepositoryMock.Object, currencyServiceMock.Object);

        //    paymentRepositoryMock.Setup(repo => repo.Query().Where(It.IsAny<System.Linq.Expressions.Expression<Func<Payment, bool>>>()).ToListAsync())
        //        .ReturnsAsync(new List<Payment>());

        //    // Act
        //    var result = await controller.GetByOrder(invalidOrderId);

        //    // Assert
        //    Assert.IsType<NotFoundResult>(result);
        //}

    }
}


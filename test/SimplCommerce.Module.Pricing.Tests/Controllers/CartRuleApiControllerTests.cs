using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Pricing.Areas.Pricing.Controllers;
using SimplCommerce.Module.Pricing.Areas.Pricing.ViewModels;
using SimplCommerce.Module.Pricing.Models;
using Xunit;

namespace SimplCommerce.Module.Pricing.Tests.Controllers
{
    public class CartRuleApiControllerTests
    {
        [Fact]
        public void List_ReturnsJsonResult()
        {
            // Arrange
            var cartRuleRepositoryMock = new Mock<IRepository<CartRule>>();
            var controller = new CartRuleApiController(cartRuleRepositoryMock.Object);
            var smartTableParam = new SmartTableParam()
            {
                Pagination = new Pagination() { Start = 1, TotalItemCount = 1, Number = 1, NumberOfPages = 1 },
                Search = new Search() { },
                Sort = new Sort() { }
            };
            
            // Act
            var result = controller.List(smartTableParam);
            
            // Assert
            Assert.IsType<JsonResult>(result);
        }

        [Fact]
        public async Task Post_CreatesNewCartRule_WhenModelStateIsValid()
        {
            // Arrange
            var cartRuleRepositoryMock = new Mock<IRepository<CartRule>>();
            var controller = new CartRuleApiController(cartRuleRepositoryMock.Object);
            var model = new CartRuleForm
            {
                Id = 1,
                Name = "Test Cart Rule",
                IsActive = true,
                StartOn = DateTime.Now,
                EndOn = DateTime.Now.AddDays(7),
                IsCouponRequired = true,
                RuleToApply = "Coupon",
                DiscountAmount = 10,
                DiscountStep = 2,
                MaxDiscountAmount = 50,
                UsageLimitPerCoupon = 100,
                UsageLimitPerCustomer = 1
            };
            
            // Act
            var result = await controller.Post(model);
            
            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(CartRuleApiController.Get), createdAtActionResult.ActionName);
            Assert.NotNull(createdAtActionResult.RouteValues["id"]);
            cartRuleRepositoryMock.Verify(repo => repo.Add(It.IsAny<CartRule>()), Times.Once);
            cartRuleRepositoryMock.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }
    }
}

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
               Pagination=new Pagination() {Start=1,TotalItemCount=1,Number=1,NumberOfPages=1 },
               Search=new Search() { },
               Sort=new Sort() { }
            };
            // Act
            var result = controller.List(smartTableParam);
            // Assert
            Assert.IsType<JsonResult>(result);
        }
        //[Fact]
        //public async Task Get_Returns_JsonResult_With_CartRuleForm()
        //{
        //    // Arrange
        //    var cartRuleRepositoryMock = new Mock<IRepository<CartRule>>();
        //    var controller = new CartRuleApiController(cartRuleRepositoryMock.Object);
        //    var cartRuleId = 1;

        //    var mockCartRule = new CartRule
        //    {
               
        //        Name = "Test Cart Rule",
        //        IsActive = true,
        //        StartOn = DateTime.Now,
        //        EndOn = DateTime.Now.AddDays(7),
        //        IsCouponRequired = true,
        //        RuleToApply = "Coupon",
        //        DiscountAmount = 10,
        //        DiscountStep = 2,
        //        MaxDiscountAmount = 50,
        //        UsageLimitPerCoupon = 100,
        //        UsageLimitPerCustomer = 1,
        //        Products = new List<CartRuleProduct>
        //                {
        //                    new CartRuleProduct { ProductId = 1, Product = new Product {  Name = "Product 1", IsPublished = true } },
        //                    new CartRuleProduct { ProductId = 2, Product = new Product {  Name = "Product 2", IsPublished = true } }
        //                },
        //        Coupons = new List<Coupon>
        //                {
        //                    new Coupon { Code = "TESTCODE123" }
        //                }
        //    };
        //    var mock = new Mock<IRepository<CartRule>>();
        //    mock.Setup(x => x.Query()).Returns(new List<CartRule>() {mockCartRule }.AsQueryable());

        //    // Act
        //    var result = await controller.Get(cartRuleId);

        //    // Assert
        //    var jsonResult = Assert.IsType<JsonResult>(result);
        //    var model = Assert.IsType<CartRuleForm>(jsonResult.Value);

        //    // Add additional assertions based on your mock data
        //    Assert.Equal(cartRuleId, model.Id);
        //    Assert.Equal("Test Cart Rule", model.Name);
        //    Assert.True(model.IsActive);
        //}

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

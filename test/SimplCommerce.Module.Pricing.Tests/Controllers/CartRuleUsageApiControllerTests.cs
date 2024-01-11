using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Pricing.Areas.Pricing.Controllers;
using SimplCommerce.Module.Pricing.Models;
using Xunit;

namespace SimplCommerce.Module.Pricing.Tests.Controllers
{
    public class CartRuleUsageApiControllerTests
    {
        [Fact]
        public void List_ReturnsJsonResult()
        {
            // Arrange
            var cartRuleUsageRepositoryMock = new Mock<IRepository<CartRuleUsage>>();
            var controller = new CartRuleUsageApiController(cartRuleUsageRepositoryMock.Object);
            var smartTableParam = new SmartTableParam() { Pagination = new Pagination() { }, Search = new Search() { }, Sort = new Sort() };

            // Act
            var result = controller.List(smartTableParam);

            // Assert
            Assert.IsType<JsonResult>(result);
        }

        [Fact]
        public void List_ShouldReturnCorrectData()
        {
            // Arrange
            var cartRuleUsageRepositoryMock = new Mock<IRepository<CartRuleUsage>>();
            var controller = new CartRuleUsageApiController(cartRuleUsageRepositoryMock.Object);

            var smartTableParam = new SmartTableParam()
            {
                Pagination = new Pagination() { },
                Search = new Search
                {

                    PredicateObject = new JObject()
                },
                Sort = new Sort() { }
            };
            smartTableParam.Search.PredicateObject.Add("RuleName", "TestRule");
            smartTableParam.Search.PredicateObject.Add("CouponCode", "TestCoupon");
            smartTableParam.Search.PredicateObject.Add("FullName", "TestUser");
            smartTableParam.Search.PredicateObject.Add("CreatedOn", new JObject
            {
                { "after" , DateTimeOffset.Now.AddDays(-7)},
                { "before" , DateTimeOffset.Now}
            });

            // Mocking the IQueryable<CartRuleUsage>
            var cartRuleUsageData = new List<CartRuleUsage>
            {
                new CartRuleUsage
                {
                    CartRuleId = 101,
                    CartRule = new CartRule { Name = "TestRule" },
                    UserId = 201,
                    User = new User { FullName = "TestUser" },
                    Coupon = new Coupon { Code = "TestCoupon" },
                    OrderId = 301,
                    CreatedOn = DateTimeOffset.Now.AddDays(-5)
                },
                // Add more data as needed for testing different scenarios
            }.AsQueryable();

            cartRuleUsageRepositoryMock.Setup(r => r.Query()).Returns(cartRuleUsageData);

            // Act
            var result = controller.List(smartTableParam);

            // Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            //var cartRuleUsages = Assert.IsType<SmartTableResult<searchobject>>(jsonResult.Value);

            // Add more assertions based on your expectations for the result
            Assert.NotNull(jsonResult.Value);
            var serializeobj = JsonConvert.SerializeObject(jsonResult.Value);
            var deserializeobj = JsonConvert.DeserializeObject<searchObject>(serializeobj);
            Assert.Equal("TestRule", deserializeobj.Items[0].CartRuleName);
            Assert.Equal("TestUser", deserializeobj.Items[0].FullName);
            Assert.Equal("TestCoupon", deserializeobj.Items[0].CouponCode);
            Assert.Equal(101, deserializeobj.Items[0].CartRuleId);
            Assert.Equal(201, deserializeobj.Items[0].UserId);
            Assert.Equal(301, deserializeobj.Items[0].OrderId);

        }

        public class Itemsobject
        {
            public long Id { get; set; }
            public long CartRuleId { get; set; }
            public string CartRuleName { get; set; }
            public long UserId { get; set; }
            public string FullName { get; set; }
            public string CouponCode { get; set; }
            public long OrderId { get; set; }
            public DateTimeOffset CreatedOn { get; set; }
        }

        public class searchObject
        {
            public List<Itemsobject> Items { get; set; }

            public int NumberOfPages { get; set; }

            public int TotalRecord { get; set; }
        }
    }
}


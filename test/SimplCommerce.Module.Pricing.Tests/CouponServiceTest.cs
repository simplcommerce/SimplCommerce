using Microsoft.EntityFrameworkCore;
using Moq;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Pricing.Models;
using SimplCommerce.Module.Pricing.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SimplCommerce.Module.Pricing.Tests
{
    public class CouponServiceTest
    {
        [Fact]
        public async Task CouponService_WhithNoCoupon_ShouldReturns_CouponNotExistMessage()
        {
            var user = MakeMockUser();

            var coupon = MakeMockCoupon("test");

            var couponService = MakeMockCouponService(user, coupon);

            var cartInfo = MakeMockCartInfoForCoupon();

            string couponToApply = null;

            var result = await couponService.Validate(couponToApply, cartInfo);

            Assert.Equal($"The coupon {couponToApply} is not exist.", result.ErrorMessage);
        }

        [Fact]
        public async Task CouponService_WhithInactiveCoupon_ShouldReturns_CouponNotExistMessage()
        {
            var user = MakeMockUser();

            var coupon = MakeMockCoupon("test", isActive: false);

            var couponService = MakeMockCouponService(user, coupon);

            var cartInfo = MakeMockCartInfoForCoupon();

            string couponToApply = "test";

            var result = await couponService.Validate(couponToApply, cartInfo);

            Assert.Equal($"The coupon {couponToApply} is not exist.", result.ErrorMessage);
        }

        [Fact]
        public async Task CouponService_WhithStartsOnInTheFuture_ShouldReturns_CouponCanBeUsedAfterStartOnDate()
        {
            var user = MakeMockUser();

            var coupon = MakeMockCoupon("test");
            coupon.CartRule.StartOn = DateTime.Now.AddDays(1);

            var couponService = MakeMockCouponService(user, coupon);

            var cartInfo = MakeMockCartInfoForCoupon();

            string couponToApply = "test";

            var result = await couponService.Validate(couponToApply, cartInfo);

            Assert.Equal($"The coupon {couponToApply} should be used after {coupon.CartRule.StartOn}.", result.ErrorMessage);
        }

        private static CartInfoForCoupon MakeMockCartInfoForCoupon()
        {
            var cartInfoForCoupon = new CartInfoForCoupon
            {
                Items = new List<CartItemForCoupon>
                {
                    new CartItemForCoupon
                    {
                        ProductId = 1,
                        Quantity = 1
                    }
                }
            };

            return cartInfoForCoupon;
        }

        private static User MakeMockUser()
        {
            var user = new User { Id = 1, FullName = "Jane Smith" };

            return user;
        }

        private static Coupon MakeMockCoupon(string code, bool isActive = true)
        {
            var coupon = new Coupon
            {
                Code = code,
                CartRule = new CartRule
                {
                    IsActive = isActive,
                    Products = new List<CartRuleProduct> { },
                    Categories = new List<CartRuleCategory> { }
                }
            };

            return coupon;
        }

        private static CouponService MakeMockCouponService(User user, Coupon coupon)
        {
            var coupons = new List<Coupon> { coupon }.AsQueryable();

            var mockSet = new Mock<DbSet<Coupon>>();
            mockSet.As<IAsyncEnumerable<Coupon>>()
                .Setup(m => m.GetEnumerator())
                .Returns(new TestAsyncEnumerator<Coupon>(coupons.GetEnumerator()));

            mockSet.As<IQueryable<Coupon>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<Coupon>(coupons.Provider));

            mockSet.As<IQueryable<Coupon>>().Setup(m => m.Expression).Returns(coupons.Expression);
            mockSet.As<IQueryable<Coupon>>().Setup(m => m.ElementType).Returns(coupons.ElementType);
            mockSet.As<IQueryable<Coupon>>().Setup(m => m.GetEnumerator()).Returns(() => coupons.GetEnumerator());

            var contextOptions = new DbContextOptions<SimplDbContext>();
            var mockContext = new Mock<SimplDbContext>(contextOptions);
            mockContext.Setup(c => c.Set<Coupon>()).Returns(mockSet.Object);

            var mockWorkContext = new Mock<IWorkContext>();
            mockWorkContext.Setup(x => x.GetCurrentUser()).Returns(Task.FromResult(user));

            var couponRepository = new Repository<Coupon>(mockContext.Object);
            var cartRuleUsageRepository = new Repository<CartRuleUsage>(mockContext.Object);
            var productRepository = new Repository<Product>(mockContext.Object);

            var couponService = new CouponService(couponRepository, cartRuleUsageRepository, productRepository, mockWorkContext.Object);
            return couponService;
        }
    }
}

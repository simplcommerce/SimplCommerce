using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Moq;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Pricing.Models;
using SimplCommerce.Module.Pricing.Services;

namespace SimplCommerce.Module.Pricing.Tests
{
    public class CouponServiceTest
    {
        [Fact(DisplayName = "WithNoCoupon_ShouldReturns_CouponNotExistMessage")]
        public async Task CouponService_WithNoCoupon_ShouldReturns_CouponNotExistMessage()
        {
            var user = MakeMockUser();

            var coupon = MakeMockCoupon("test");

            var cartRuleUsage = MakeMockCartRuleUsage(user, coupon);

            var couponService = MakeMockCouponService(user, coupon, cartRuleUsage);

            var cartInfo = MakeMockCartInfoForCoupon();

            string couponToApply = null;

            var result = await couponService.Validate(user.Id, couponToApply, cartInfo);

            Assert.Equal($"The coupon {couponToApply} is not exist.", result.ErrorMessage);
        }

        [Fact(DisplayName = "WithInactiveCoupon_ShouldReturns_CouponNotExistMessage")]
        public async Task CouponService_WithInactiveCoupon_ShouldReturns_CouponNotExistMessage()
        {
            var user = MakeMockUser();

            var coupon = MakeMockCoupon("test", isActive: false);

            var cartRuleUsage = MakeMockCartRuleUsage(user, coupon);

            var couponService = MakeMockCouponService(user, coupon, cartRuleUsage);

            var cartInfo = MakeMockCartInfoForCoupon();

            string couponToApply = "test";

            var result = await couponService.Validate(user.Id, couponToApply, cartInfo);

            Assert.Equal($"The coupon {couponToApply} is not exist.", result.ErrorMessage);
        }

        [Fact(DisplayName = "WithStartsOnInTheFuture_ShouldReturns_CouponCanBeUsedAfterStartOnDateMessage")]
        public async Task CouponService_WithStartsOnInTheFuture_ShouldReturns_CouponCanBeUsedAfterStartOnDateMessage()
        {
            var user = MakeMockUser();

            var coupon = MakeMockCoupon("test");
            coupon.CartRule.StartOn = DateTime.Now.AddDays(1);

            var cartRuleUsage = MakeMockCartRuleUsage(user, coupon);

            var couponService = MakeMockCouponService(user, coupon, cartRuleUsage);

            var cartInfo = MakeMockCartInfoForCoupon();

            string couponToApply = "test";

            var result = await couponService.Validate(user.Id, couponToApply, cartInfo);

            Assert.Equal($"The coupon {couponToApply} should be used after {coupon.CartRule.StartOn}.", result.ErrorMessage);
        }

        [Fact(DisplayName = "WithExpiredCoupon_ShouldReturns_CouponExpiredMessage")]
        public async Task CouponService_WithExpiredCoupon_ShouldReturns_CouponExpiredMessage()
        {
            var user = MakeMockUser();

            var coupon = MakeMockCoupon("test");
            coupon.CartRule.StartOn = DateTime.Now.AddDays(-2);
            coupon.CartRule.EndOn = DateTime.Now.AddDays(-1);

            var cartRuleUsage = MakeMockCartRuleUsage(user, coupon);

            var couponService = MakeMockCouponService(user, coupon, cartRuleUsage);

            var cartInfo = MakeMockCartInfoForCoupon();

            string couponToApply = "test";

            var result = await couponService.Validate(user.Id, couponToApply, cartInfo);

            Assert.Equal($"The coupon {couponToApply} is expired.", result.ErrorMessage);
        }

        [Fact(DisplayName = "WithFullyConsumedCoupon_ShouldReturns_CouponAllUsedMessage")]
        public async Task CouponService_WithFullyConsumedCoupon_ShouldReturns_CouponAllUsedMessage()
        {
            var user = MakeMockUser();

            var coupon = MakeMockCoupon("test", usageLimitForCoupon: 1);
            coupon.CartRule.StartOn = DateTime.Now.AddDays(-2);
            coupon.CartRule.EndOn = DateTime.Now.AddDays(1);

            var cartRuleUsage = MakeMockCartRuleUsage(user, coupon);

            var couponService = MakeMockCouponService(user, coupon, cartRuleUsage);

            var cartInfo = MakeMockCartInfoForCoupon();

            string couponToApply = "test";

            var result = await couponService.Validate(user.Id, couponToApply, cartInfo);

            Assert.Equal($"The coupon {couponToApply} is all used.", result.ErrorMessage);
        }

        [Fact(DisplayName = "WithFullyConsumedCouponForUser_ShouldReturns_CouponAllUsedMessage")]
        public async Task CouponService_WithFullyConsumedCouponForUser_ShouldReturns_CouponAllUsedMessage()
        {
            var user = MakeMockUser();

            var coupon = MakeMockCoupon("test", usageLimitForCoupon: 2, usageLimitForUser: 1);
            coupon.CartRule.StartOn = DateTime.Now.AddDays(-2);
            coupon.CartRule.EndOn = DateTime.Now.AddDays(1);

            var cartRuleUsage = MakeMockCartRuleUsage(user, coupon);

            var couponService = MakeMockCouponService(user, coupon, cartRuleUsage);

            var cartInfo = MakeMockCartInfoForCoupon();

            string couponToApply = "test";

            var result = await couponService.Validate(user.Id, couponToApply, cartInfo);

            Assert.Equal($"You can use the coupon {couponToApply} only {coupon.CartRule.UsageLimitPerCustomer} times", result.ErrorMessage);
        }

        [Fact(DisplayName = "WithNoCouponCartRuleToApplySpecified_ShouldThrow_InvalidOperationException")]
        public void CouponService_WithoutCouponCartRuleToApplySpecified_ShouldThrow_InvalidOperationException()
        {
            var user = MakeMockUser();

            var coupon = MakeMockCoupon("test", usageLimitForCoupon: 2, usageLimitForUser: 2);
            coupon.CartRule.StartOn = DateTime.Now.AddDays(-2);
            coupon.CartRule.EndOn = DateTime.Now.AddDays(1);

            var cartRuleUsage = MakeMockCartRuleUsage(user, coupon);

            var couponService = MakeMockCouponService(user, coupon, cartRuleUsage);

            var cartInfo = MakeMockCartInfoForCoupon();

            string couponToApply = "test";

            Assert.ThrowsAsync<InvalidOperationException>(async () => await couponService.Validate(user.Id, couponToApply, cartInfo));
        }

        [Fact(DisplayName = "WithDiscountAndFixedCartRule_ShouldReturns_SameDiscountAmount")]
        public async Task CouponService_WithDiscountAndFixedCartRule_ShouldReturns_SameDiscountAmount()
        {
            var user = MakeMockUser();

            var coupon = MakeMockCoupon("test", usageLimitForCoupon: 2, usageLimitForUser: 2);
            coupon.CartRule.StartOn = DateTime.Now.AddDays(-2);
            coupon.CartRule.EndOn = DateTime.Now.AddDays(1);
            coupon.CartRule.DiscountAmount = 1M;
            coupon.CartRule.RuleToApply = "cart_fixed";

            var cartRuleUsage = MakeMockCartRuleUsage(user, coupon);

            var couponService = MakeMockCouponService(user, coupon, cartRuleUsage);

            var cartInfo = MakeMockCartInfoForCoupon();

            string couponToApply = "test";

            var result = await couponService.Validate(user.Id, couponToApply, cartInfo);

            Assert.True(result.Succeeded);
            Assert.Equal(coupon.CartRule.DiscountAmount, result.DiscountAmount);
        }

        [Fact(DisplayName = "WithDiscountAndByPercentCartRule_ShouldReturns_DiscountedAmount")]
        public async Task CouponService_WithDiscountAndByPercentCartRule_ShouldReturns_DiscountedAmount()
        {
            var user = MakeMockUser();

            var coupon = MakeMockCoupon("test", usageLimitForCoupon: 2, usageLimitForUser: 2);
            coupon.CartRule.StartOn = DateTime.Now.AddDays(-2);
            coupon.CartRule.EndOn = DateTime.Now.AddDays(1);
            coupon.CartRule.DiscountAmount = 10M;
            coupon.CartRule.RuleToApply = "by_percent";
            coupon.CartRule.Products.Add(new CartRuleProduct { ProductId = 1 });
            coupon.CartRule.Products.Add(new CartRuleProduct { ProductId = 2 });

            var cartRuleUsage = MakeMockCartRuleUsage(user, coupon);

            var couponService = MakeMockCouponService(user, coupon, cartRuleUsage);

            var cartInfo = MakeMockCartInfoForCoupon();

            string couponToApply = "test";

            var result = await couponService.Validate(user.Id, couponToApply, cartInfo);

            Assert.True(result.Succeeded);
            Assert.Equal(1M, result.DiscountAmount);
        }

        #region MockDataHelpers

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
                    },
                    new CartItemForCoupon
                    {
                        ProductId = 2,
                        Quantity = 2
                    }
                }
            };

            return cartInfoForCoupon;
        }

        private static CartRuleUsage MakeMockCartRuleUsage(User user, Coupon coupon)
        {
            var cartRule = new CartRuleUsage
            {
                UserId = user.Id,
                CouponId = coupon.Id
            };

            return cartRule;
        }

        private static User MakeMockUser()
        {
            var user = new User { Id = 1, FullName = "Jane Smith" };

            return user;
        }

        private static Coupon MakeMockCoupon(string code, bool isActive = true, int usageLimitForCoupon = 1, int usageLimitForUser = 1)
        {
            var coupon = new Coupon
            {
                Code = code,
                CartRule = new CartRule
                {
                    IsActive = isActive,
                    UsageLimitPerCoupon = usageLimitForCoupon,
                    UsageLimitPerCustomer = usageLimitForUser,
                    Products = new List<CartRuleProduct> {},
                    Categories = new List<CartRuleCategory> { }
                }
            };

            return coupon;
        }

        private static IList<Product> MakeMockProducts()
        {
            var mockProduct1 = new Mock<Product>();
            mockProduct1.SetupGet(p => p.Id).Returns(1);
            mockProduct1.Object.Price = 10M;

            var mockProduct2 = new Mock<Product>();
            mockProduct2.SetupGet(p => p.Id).Returns(2);
            mockProduct2.Object.Price = 20M;


            return new List<Product>
            {
                mockProduct1.Object,
                mockProduct2.Object
            };
        }

        private static CouponService MakeMockCouponService(User user, Coupon coupon, CartRuleUsage cartRuleUsage)
        {
            var coupons = new List<Coupon> { coupon }.AsQueryable();

            var cartRules = new List<CartRuleUsage> { cartRuleUsage }.AsQueryable();

            Mock<DbSet<Coupon>> couponMockSet = BuildMockSetForCoupon(coupons);
            Mock<DbSet<CartRuleUsage>> cartRuleUsageMockSet = BuildMockSetForCartRuleUsage(cartRules);
            Mock<DbSet<Product>> productsMockSet = BuildMockSetForProduct(MakeMockProducts().AsQueryable());

            var contextOptions = new DbContextOptions<SimplDbContext>();
            var mockContext = new Mock<SimplDbContext>(contextOptions);
            mockContext.Setup(c => c.Set<Coupon>()).Returns(couponMockSet.Object);
            mockContext.Setup(c => c.Set<CartRuleUsage>()).Returns(cartRuleUsageMockSet.Object);
            mockContext.Setup(c => c.Set<Product>()).Returns(productsMockSet.Object);

            var mockWorkContext = new Mock<IWorkContext>();
            mockWorkContext.Setup(x => x.GetCurrentUser()).Returns(Task.FromResult(user));

            var couponRepository = new Repository<Coupon>(mockContext.Object);
            var cartUsageRepository = new Repository<CartRuleUsage>(mockContext.Object);
            var productRepository = new Repository<Product>(mockContext.Object);


            var couponService = new CouponService(couponRepository, cartUsageRepository, productRepository, mockWorkContext.Object);

            return couponService;
        }

        private static Mock<DbSet<Coupon>> BuildMockSetForCoupon(IQueryable<Coupon> coupons)
        {
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

            return mockSet;
        }

        private static Mock<DbSet<CartRuleUsage>> BuildMockSetForCartRuleUsage(IQueryable<CartRuleUsage> cartRules)
        {
            var mockSet = new Mock<DbSet<CartRuleUsage>>();
            mockSet.As<IAsyncEnumerable<CartRuleUsage>>()
                .Setup(m => m.GetEnumerator())
                .Returns(new TestAsyncEnumerator<CartRuleUsage>(cartRules.GetEnumerator()));

            mockSet.As<IQueryable<CartRuleUsage>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<CartRuleUsage>(cartRules.Provider));

            mockSet.As<IQueryable<CartRuleUsage>>().Setup(m => m.Expression).Returns(cartRules.Expression);
            mockSet.As<IQueryable<CartRuleUsage>>().Setup(m => m.ElementType).Returns(cartRules.ElementType);
            mockSet.As<IQueryable<CartRuleUsage>>().Setup(m => m.GetEnumerator()).Returns(() => cartRules.GetEnumerator());

            return mockSet;
        }

        private static Mock<DbSet<Product>> BuildMockSetForProduct(IQueryable<Product> products)
        {
            var mockSet = new Mock<DbSet<Product>>();
            mockSet.As<IAsyncEnumerable<Product>>()
                .Setup(m => m.GetEnumerator())
                .Returns(new TestAsyncEnumerator<Product>(products.GetEnumerator()));

            mockSet.As<IQueryable<Product>>()
                .Setup(m => m.Provider)
                .Returns(new TestAsyncQueryProvider<Product>(products.Provider));

            mockSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            mockSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            mockSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => products.GetEnumerator());


            return mockSet;
        }

        #endregion
    }
}

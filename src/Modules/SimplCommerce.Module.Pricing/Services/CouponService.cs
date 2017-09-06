using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Pricing.Models;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Pricing.Services
{
    public class CouponService : ICouponService
    {
        private readonly IRepository<Coupon> _couponRepository;
        private readonly IRepository<CouponUsage> _couponUsageRepository;
        private readonly IRepository<Product> _productRepository;
        private readonly IWorkContext _workContext;

        public CouponService(IRepository<Coupon> couponRepository, IRepository<CouponUsage> couponUsageRepository, IRepository<Product> productRespository, IWorkContext workContext)
        {
            _couponRepository = couponRepository;
            _couponUsageRepository = couponUsageRepository;
            _productRepository = productRespository;
            _workContext = workContext;
        }

        public async Task<CouponValidationResult> Validate(string couponCode, CartInfoForCoupon cart)
        {
            var coupon = _couponRepository.Query()
                .Include(x => x.CartRule).ThenInclude(c => c.Products)
                .Include(x => x.CartRule).ThenInclude(c => c.Categories)
                .FirstOrDefault(x => x.Code == couponCode);
            var validationResult = new CouponValidationResult { Succeeded = false };

            if(coupon == null || !coupon.CartRule.IsActive)
            {
                validationResult.ErrorMessage = $"The coupon {couponCode} is not exist.";
                return validationResult;
            }

            if (coupon.CartRule.StartOn.HasValue && coupon.CartRule.StartOn > DateTimeOffset.Now)
            {
                validationResult.ErrorMessage = $"The coupon {couponCode} should be used after {coupon.CartRule.StartOn}.";
                return validationResult;
            }

            if (coupon.CartRule.EndOn.HasValue && coupon.CartRule.EndOn <= DateTimeOffset.Now)
            {
                validationResult.ErrorMessage = $"The coupon {couponCode} is expired.";
                return validationResult;
            }

            var couponUsageCount = _couponUsageRepository.Query().Count(x => x.CouponId == coupon.Id);
            if(coupon.CartRule.UsageLimitPerCoupon.HasValue && couponUsageCount >= coupon.CartRule.UsageLimitPerCoupon)
            {
                validationResult.ErrorMessage = $"The coupon {couponCode} is all used.";
                return validationResult;
            }

            var currentCustomer = await _workContext.GetCurrentUser();
            var couponUsageByCustomerCount = _couponUsageRepository.Query().Count(x => x.CouponId == coupon.Id && x.UserId == currentCustomer.Id);
            if (coupon.CartRule.UsageLimitPerCustomer.HasValue && couponUsageCount >= coupon.CartRule.UsageLimitPerCustomer)
            {
                validationResult.ErrorMessage = $"You can use the coupon {couponCode} only {coupon.CartRule.UsageLimitPerCustomer} times";
                return validationResult;
            }

            IList<DiscountedProduct> discountedProducts = new List<DiscountedProduct>();
            if(coupon.CartRule.Products.Any() || coupon.CartRule.Categories.Any())
            {
                var discounttableProducts = GetDiscountableProduct(coupon.CartRule.Products, coupon.CartRule.Categories);
                foreach(var item in cart.Items)
                {
                    var discounttableProduct = discounttableProducts.FirstOrDefault(x => x.Id == item.ProductId);

                    if (discounttableProduct != null)
                    {
                        discountedProducts.Add(new DiscountedProduct { Id = discounttableProduct.Id, Name = discounttableProduct.Name, Price = discounttableProduct.Price, Quantity = item.Quantity });
                    }
                }

                if (!discountedProducts.Any())
                {
                    validationResult.ErrorMessage = $"The coupon {couponCode} doesn't apply to any products in your cart";
                    return validationResult;
                }
            }

            switch (coupon.CartRule.RuleToApply)
            {
                case "cart_fixed":
                    validationResult.Succeeded = true;
                    validationResult.CouponId = coupon.Id;
                    validationResult.CouponRuleName = coupon.CartRule.Name;
                    validationResult.DiscountAmount = coupon.CartRule.DiscountAmount;
                    return validationResult;
                case "by_percent":
                    validationResult.Succeeded = true;
                    validationResult.CouponId = coupon.Id;
                    validationResult.CouponRuleName = coupon.CartRule.Name;
                    validationResult.DiscountAmount = discountedProducts.Sum(x => (x.Price * coupon.CartRule.DiscountAmount / 100) * x.Quantity);
                    return validationResult;
                default:
                    throw new InvalidOperationException($"{coupon.CartRule.RuleToApply} is not supported");
            }
        }

        private IList<DiscountableProduct> GetDiscountableProduct(IList<CartRuleProduct> cartRuleProducts, IList<CartRuleCategory> cartRuleCategorys)
        {
            IList<DiscountableProduct> discountedProducts = new List<DiscountableProduct>();
            if (cartRuleProducts.Any())
            {
                var productIds = cartRuleProducts.Select(x => x.ProductId);
                discountedProducts = _productRepository.Query()
                    .Where(x => productIds.Contains(x.Id))
                    .Select(x => new DiscountableProduct { Id = x.Id, Name = x.Name, Price = x.Price }).ToList();
            }

            if (cartRuleCategorys.Any())
            {
                var categoryIds = cartRuleCategorys.Select(x => x.CategoryId);
                var discountedProductByCategories = _productRepository.Query()
                    .Where(x => x.Categories.Any(c => categoryIds.Contains(c.Id)))
                    .Select(x => new DiscountableProduct { Id = x.Id, Name = x.Name, Price = x.Price }).ToList();
                discountedProducts = discountedProducts.Concat(discountedProductByCategories).ToList();
            }

            return discountedProducts;
        }

        public void AddCouponUsage(long userId, long couponId)
        {
            var couponUsage = new CouponUsage
            {
                CouponId = couponId,
                UserId = userId
            };

            _couponUsageRepository.Add(couponUsage);
        }
    }
}

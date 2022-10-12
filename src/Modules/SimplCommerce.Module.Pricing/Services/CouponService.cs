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
        private readonly IRepository<CartRuleUsage> _cartRuleUsageRepository;
        private readonly IRepository<Product> _productRepository;

        public CouponService(IRepository<Coupon> couponRepository, IRepository<CartRuleUsage> cartRuleUsageRepository, IRepository<Product> productRespository, IWorkContext workContext)
        {
            _couponRepository = couponRepository;
            _cartRuleUsageRepository = cartRuleUsageRepository;
            _productRepository = productRespository;
        }

        public async Task<CouponValidationResult> Validate(long customerId, string couponCode, CartInfoForCoupon cart)
        {
            var coupon = await _couponRepository.Query()
                .Include(x => x.CartRule).ThenInclude(c => c.Products)
                .Include(x => x.CartRule).ThenInclude(c => c.Categories)
                .FirstOrDefaultAsync(x => x.Code == couponCode);
            var validationResult = new CouponValidationResult { Succeeded = false };

            if (coupon == null || !coupon.CartRule.IsActive)
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

            var couponUsageCount = _cartRuleUsageRepository.Query().Count(x => x.CouponId == coupon.Id);
            if (coupon.CartRule.UsageLimitPerCoupon.HasValue && couponUsageCount >= coupon.CartRule.UsageLimitPerCoupon)
            {
                validationResult.ErrorMessage = $"The coupon {couponCode} is all used.";
                return validationResult;
            }

            var couponUsageByCustomerCount = _cartRuleUsageRepository.Query().Count(x => x.CouponId == coupon.Id && x.UserId == customerId);
            if (coupon.CartRule.UsageLimitPerCustomer.HasValue && couponUsageByCustomerCount >= coupon.CartRule.UsageLimitPerCustomer)
            {
                validationResult.ErrorMessage = $"You can use the coupon {couponCode} only {coupon.CartRule.UsageLimitPerCustomer} times";
                return validationResult;
            }

            IList<DiscountableProduct> discountableProducts = new List<DiscountableProduct>();
            if (!coupon.CartRule.Products.Any() && !coupon.CartRule.Categories.Any())
            {
                var productIds = cart.Items.Select(x => x.ProductId);
                discountableProducts = _productRepository.Query()
                   .Where(x => productIds.Contains(x.Id))
                   .Select(x => new DiscountableProduct { Id = x.Id, Name = x.Name, Price = x.Price }).ToList();
            }
            else
            {
                discountableProducts = GetDiscountableProduct(coupon.CartRule.Products, coupon.CartRule.Categories);
            }

            foreach (var item in cart.Items)
            {
                if ((coupon.CartRule.UsageLimitPerCoupon.HasValue && couponUsageCount >= coupon.CartRule.UsageLimitPerCoupon) ||
                    (coupon.CartRule.UsageLimitPerCustomer.HasValue && couponUsageByCustomerCount >= coupon.CartRule.UsageLimitPerCustomer))
                {
                    break;
                }

                var discountableProduct = discountableProducts.FirstOrDefault(x => x.Id == item.ProductId);
                if (discountableProduct != null)
                {
                    var discountedProduct = new DiscountedProduct { Id = discountableProduct.Id, Name = discountableProduct.Name, Price = discountableProduct.Price, Quantity = item.Quantity };
                    validationResult.DiscountedProducts.Add(discountedProduct);
                }
            }

            if (!validationResult.DiscountedProducts.Any())
            {
                validationResult.ErrorMessage = $"The coupon {couponCode} doesn't apply to any products in your cart";
                return validationResult;
            }

            validationResult.Succeeded = true;
            validationResult.CouponId = coupon.Id;
            validationResult.CouponCode = coupon.Code;
            validationResult.CouponRuleName = coupon.CartRule.Name;
            validationResult.CartRule = coupon.CartRule;

            switch (coupon.CartRule.RuleToApply)
            {
                case "cart_fixed":
                    validationResult.DiscountAmount = Math.Min(coupon.CartRule.DiscountAmount, coupon.CartRule.MaxDiscountAmount.GetValueOrDefault(decimal.MaxValue));
                    return validationResult;

                case "by_percent":
                    var maxDiscountAmount = coupon.CartRule.MaxDiscountAmount.GetValueOrDefault(decimal.MaxValue);
                    foreach (var item in validationResult.DiscountedProducts)
                    {
                        item.DiscountAmount = Math.Min((item.Price * coupon.CartRule.DiscountAmount / 100) * item.Quantity, maxDiscountAmount);
                        maxDiscountAmount -= item.DiscountAmount;
                    }

                    validationResult.DiscountAmount = validationResult.DiscountedProducts.Sum(x => x.DiscountAmount);
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

        public void AddCouponUsage(long customerId, long orderId, CouponValidationResult couponValidationResult)
        {
            if (!couponValidationResult.Succeeded || couponValidationResult.CartRule == null)
            {
                return;
            }

            CartRuleUsage couponUsage;
            switch (couponValidationResult.CartRule.RuleToApply)
            {
                case "cart_fixed":
                    couponUsage = new CartRuleUsage
                    {
                        UserId = customerId,
                        OrderId = orderId,
                        CouponId = couponValidationResult.CouponId,
                        CartRuleId = couponValidationResult.CartRule.Id
                    };

                    _cartRuleUsageRepository.Add(couponUsage);
                    break;

                case "by_percent":
                    foreach (var item in couponValidationResult.DiscountedProducts)
                    {
                        for (var i = 0; i < item.Quantity; i++)
                        {
                            couponUsage = new CartRuleUsage
                            {
                                UserId = customerId,
                                OrderId = orderId,
                                CouponId = couponValidationResult.CouponId,
                                CartRuleId = couponValidationResult.CartRule.Id
                            };

                            _cartRuleUsageRepository.Add(couponUsage);
                        }
                    }

                    break;

                default:
                    throw new InvalidOperationException($"{couponValidationResult.CartRule.RuleToApply} is not supported");
            }
        }
    }
}

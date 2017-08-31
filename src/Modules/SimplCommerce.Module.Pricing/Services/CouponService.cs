using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Pricing.Models;

namespace SimplCommerce.Module.Pricing.Services
{
    public class CouponService : ICouponService
    {
        private readonly IRepository<Coupon> _couponRepository;
        private readonly IRepository<CouponUsage> _couponUsageRepository;
        private readonly IWorkContext _workContext;

        public CouponService(IRepository<Coupon> couponRepository, IRepository<CouponUsage> couponUsageRepository, IWorkContext workContext)
        {
            _couponRepository = couponRepository;
            _couponUsageRepository = couponUsageRepository;
            _workContext = workContext;
        }

        public async Task<CouponValidationResult> Validate(string couponCode)
        {
            var coupon = _couponRepository.Query().Include(x => x.CartRule).FirstOrDefault(x => x.Code == couponCode);
            var validationResult = new CouponValidationResult { Succeeded = false };

            if(coupon == null || !coupon.CartRule.IsActive)
            {
                validationResult.ErrorMessage = $"The coupon {couponCode} is not exist.";
                return validationResult;
            }

            if (coupon.ExpirationOn.HasValue && coupon.ExpirationOn <= DateTimeOffset.Now)
            {
                validationResult.ErrorMessage = $"The coupon {couponCode} is expired.";
                return validationResult;
            }

            var couponUsageCount = _couponUsageRepository.Query().Count(x => x.CouponId == coupon.Id);
            if(couponUsageCount >= coupon.UsageLimit)
            {
                validationResult.ErrorMessage = $"The coupon {couponCode} is all used.";
                return validationResult;
            }

            var currentCustomer = await _workContext.GetCurrentUser();
            var couponUsageByCustomerCount = _couponUsageRepository.Query().Count(x => x.CouponId == coupon.Id && x.UserId == currentCustomer.Id);
            if (couponUsageCount >= coupon.UsageLimitPerCustomer)
            {
                validationResult.ErrorMessage = $"You can use the coupon {couponCode} only {coupon.UsageLimitPerCustomer} times";
                return validationResult;
            }

            switch (coupon.CartRule.RuleToApply)
            {
                case "cart_fixed":
                    validationResult.Succeeded = true;
                    validationResult.CouponRuleName = coupon.CartRule.Name;
                    validationResult.DiscountAmount = coupon.CartRule.DiscountAmount;
                    return validationResult;
                default:
                    throw new InvalidOperationException($"{coupon.CartRule.RuleToApply} is not supported");
            }
        }
    }
}

using SimplCommerce.Module.Pricing.Models;
using System.Collections.Generic;

namespace SimplCommerce.Module.Pricing.Services
{
    public class CouponValidationResult
    {
        public bool Succeeded { get; set; }

        public decimal DiscountAmount { get; set; }

        public string CouponCode { get; set; }

        public string CouponRuleName { get; set; }

        public string ErrorMessage { get; set; }

        public long CouponId { get; set; }

        public CartRule CartRule { get; set; }

        public IList<DiscountedProduct> DiscountedProducts { get; set; } = new List<DiscountedProduct>();
    }
}

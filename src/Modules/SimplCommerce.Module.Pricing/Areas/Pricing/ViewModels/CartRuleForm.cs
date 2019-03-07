using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Pricing.Areas.Pricing.ViewModels
{
    public class CartRuleForm
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset? StartOn { get; set; }

        public DateTimeOffset? EndOn { get; set; }

        public bool IsCouponRequired { get; set; }

        public string CouponCode { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string RuleToApply { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public decimal DiscountAmount { get; set; }

        public decimal? MaxDiscountAmount { get; set; }

        public int? DiscountStep { get; set; }

        public int? UsageLimitPerCoupon { get; set; }

        public int? UsageLimitPerCustomer { get; set; }

        public IList<CartRuleProductVm> Products { get; set; } = new List<CartRuleProductVm>();
    }
}

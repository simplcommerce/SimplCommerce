using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Pricing.Models
{
    public class CartRule : EntityBase
    {
        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }

        public DateTimeOffset? StartOn { get; set; }

        public DateTimeOffset? EndOn { get; set; }

        public bool IsCouponRequired { get; set; }

        public string RuleToApply { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal? MaxDiscountAmount { get; set; }

        public int? DiscountStep { get; set; }

        public int? UsageLimitPerCoupon { get; set; }

        public int? UsageLimitPerCustomer { get; set; }

        public IList<Coupon> Coupons { get; set; } = new List<Coupon>();

        public IList<CartRuleCustomerGroup> CustomerGroups { get; set; } = new List<CartRuleCustomerGroup>();

        public IList<CartRuleProduct> Products { get; set; } = new List<CartRuleProduct>();

        public IList<CartRuleCategory> Categories { get; set; } = new List<CartRuleCategory>();
    }
}

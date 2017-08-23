using System;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Pricing.Models
{
    public class Coupon : EntityBase
    {
        public Coupon ()
        {
            CreatedOn = DateTimeOffset.Now;
        }

        public long CartRuleId { get; set; }

        public CartRule CartRule { get; set; }

        public string Code { get; set; }

        public int UsageLimit { get; set; }

        public int UsageLimitPerCustomer { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? ExpirationOn { get; set; }
    }
}

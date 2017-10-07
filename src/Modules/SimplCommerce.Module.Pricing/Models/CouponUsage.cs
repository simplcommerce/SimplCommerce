using System;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Pricing.Models
{
    public class CouponUsage : EntityBase
    {
        public CouponUsage()
        {
            UsedOn = DateTimeOffset.Now;
        }

        public long CouponId { get; set; }

        public Coupon Coupon { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public DateTimeOffset UsedOn { get; set; }
    }
}

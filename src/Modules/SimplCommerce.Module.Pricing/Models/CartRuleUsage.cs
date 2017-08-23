using System;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Pricing.Models
{
    public class CartRuleUsage : EntityBase
    {
        public long CartRuleId { get; set; }

        public CartRule CartRule { get; set; }

        public long UserId { get; set; }

        public User User { get; set; }

        public long OrderId { get; set; }

        public DateTimeOffset UsedOn { get; set; }
    }
}

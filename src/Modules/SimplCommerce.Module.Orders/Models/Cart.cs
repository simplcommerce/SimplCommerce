using System;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;
using System.Collections.Generic;

namespace SimplCommerce.Module.Orders.Models
{
    public class Cart : EntityBase
    {
        public Cart()
        {
            CreatedOn = DateTimeOffset.Now;
            IsActive = true;
        }

        public long UserId { get; set; }

        public User User { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset? UpdatedOn { get; set; }

        public bool IsActive { get; set; }

        public string CouponCode { get; set; }

        public string CouponRuleName { get; set; }

        public IList<CartItem> Items { get; set; } = new List<CartItem>();
    }
}

using System;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Orders.Models
{
    public class OrderHistory : EntityBase
    {
        public long OrderId { get; set; }

        public Order Order { get; set; }

        public OrderStatus? OldStatus { get; set; }

        public OrderStatus NewStatus { get; set; }

        public string OrderSnapshot { get; set; }

        public string Note { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public long CreatedById { get; set; }

        public User CreatedBy { get; set; }
    }
}

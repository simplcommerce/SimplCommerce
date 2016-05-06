using System;
using System.Collections.Generic;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.Models;

namespace Shopcuatoi.Orders.Domain.Models
{
    public class Order : Entity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public virtual UserAddress ShippingAddress { get; set; }

        public virtual UserAddress BillingAddress { get; set; }

        public virtual IList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public void AddOrderItem(OrderItem item)
        {
            item.Order = this;
            OrderItems.Add(item);
        }
    }
}
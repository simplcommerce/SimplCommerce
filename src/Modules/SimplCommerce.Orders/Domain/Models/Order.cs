using System;
using System.Collections.Generic;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.Models;

namespace SimplCommerce.Orders.Domain.Models
{
    public class Order : Entity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public long CreatedById { get; set; }

        public virtual User CreatedBy { get; set; }

        public decimal SubTotal { get; set; }

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
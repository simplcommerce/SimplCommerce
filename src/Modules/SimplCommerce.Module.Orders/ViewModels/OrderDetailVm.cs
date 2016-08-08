using System;
using System.Collections.Generic;

namespace SimplCommerce.Module.Orders.ViewModels
{
    public class OrderDetailVm
    {
        public long Id { get; set; }

        public string CustomerName { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public decimal SubTotal { get; set; }

        public ShippingAddressVm ShippingAddress { get; set; }

        public IList<OrderItemVm> OrderItems { get; set; } = new List<OrderItemVm>();
    }
}

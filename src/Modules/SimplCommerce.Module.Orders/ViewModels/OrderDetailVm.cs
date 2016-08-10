using System;
using System.Collections.Generic;

namespace SimplCommerce.Module.Orders.ViewModels
{
    public class OrderDetailVm
    {
        public long Id { get; set; }

        public string CustomerName { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string OrderStatusString { get; set; }

        public int OrderStatus { get; set; }

        public decimal SubTotal { get; set; }

        public string SubTotalString { get { return SubTotal.ToString("C"); } }

        public ShippingAddressVm ShippingAddress { get; set; }

        public IList<OrderItemVm> OrderItems { get; set; } = new List<OrderItemVm>();
    }
}

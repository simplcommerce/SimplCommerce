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

        public decimal Subtotal { get; set; }

        public decimal Discount { get; set; }

        public decimal SubTotalWithDiscount { get; set; }

        public string SubtotalString { get { return Subtotal.ToString("C"); } }

        public string DiscountString { get { return Discount.ToString("C"); } }

        public string SubtotalWithDiscountString { get { return SubTotalWithDiscount.ToString("C"); } }

        public ShippingAddressVm ShippingAddress { get; set; }

        public IList<OrderItemVm> OrderItems { get; set; } = new List<OrderItemVm>();
    }
}

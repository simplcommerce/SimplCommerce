using System;
using System.Collections.Generic;

namespace SimplCommerce.Module.Orders.ViewModels
{
    public class OrderDetailVm
    {
        public long Id { get; set; }

        public long CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public DateTimeOffset CreatedOn { get; set; }

        public string OrderStatusString { get; set; }

        public int OrderStatus { get; set; }

        public decimal Subtotal { get; set; }

        public decimal DiscountAmount { get; set; }

        public decimal SubTotalWithDiscount { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal ShippingAmount { get; set; }

        public decimal OrderTotal { get; set; }

        public string ShippingMethod { get; set; }

        public string PaymentMethod { get; set; }

        public string SubtotalString { get { return Subtotal.ToString("C"); } }

        public string DiscountAmountString { get { return DiscountAmount.ToString("C"); } }

        public string SubtotalWithDiscountString { get { return SubTotalWithDiscount.ToString("C"); } }

        public string TaxAmountString { get { return TaxAmount.ToString("C"); } }

        public string ShippingAmountString { get { return ShippingAmount.ToString("C"); } }

        public string OrderTotalString { get { return OrderTotal.ToString("C"); } }

        public ShippingAddressVm ShippingAddress { get; set; }

        public IList<OrderItemVm> OrderItems { get; set; } = new List<OrderItemVm>();
    }
}

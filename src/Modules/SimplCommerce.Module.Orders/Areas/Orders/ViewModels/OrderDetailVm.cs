using System;
using System.Collections.Generic;
using SimplCommerce.Module.Checkouts.Areas.Checkouts.ViewModels;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Orders.Areas.Orders.ViewModels
{
    public class OrderDetailVm
    {
        private readonly ICurrencyService _currencyService;

        public OrderDetailVm(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

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

        public decimal PaymentFeeAmount { get; set; }

        public string SubtotalString { get { return _currencyService.FormatCurrency(Subtotal); } }

        public string DiscountAmountString { get { return _currencyService.FormatCurrency(DiscountAmount); } }

        public string SubtotalWithDiscountString { get { return _currencyService.FormatCurrency(SubTotalWithDiscount); } }

        public string TaxAmountString { get { return _currencyService.FormatCurrency(TaxAmount); } }

        public string ShippingAmountString { get { return _currencyService.FormatCurrency(ShippingAmount); } }

        public string PaymentFeeAmountString { get { return _currencyService.FormatCurrency(PaymentFeeAmount); } }

        public string OrderTotalString { get { return _currencyService.FormatCurrency(OrderTotal); } }

        public ShippingAddressVm ShippingAddress { get; set; }

        public IList<OrderItemVm> OrderItems { get; set; } = new List<OrderItemVm>();

        public IList<long> SubOrderIds { get; set; }

        public bool IsMasterOrder { get; set; }

        public string OrderNote { get; set; }
    }
}

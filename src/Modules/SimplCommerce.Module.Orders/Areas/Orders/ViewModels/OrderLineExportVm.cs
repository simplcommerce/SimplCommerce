using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Orders.Areas.Orders.ViewModels
{
    public  class OrderLineExportVm : OrderExportVm
    {
        private readonly ICurrencyService _currencyService;

        public OrderLineExportVm(ICurrencyService currencyService) : base (currencyService)
        {
            _currencyService = currencyService;
        }

        public long OrderLineId { get; set; }

        public long ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public decimal ProductPrice { get; set; }

        public int OrderLineQuantity { get; set; }

        public int OrderLineShippedQuantity { get; set; }

        public decimal OrderLineTaxAmount { get; set; }

        public decimal OrderLineTaxPercent { get; set; }

        public decimal OrderLineDiscountAmount { get; set; }

        public decimal OrderLineTotal => OrderLineQuantity * ProductPrice;

        public decimal OrderLineRowTotal => OrderLineTotal + OrderLineTaxAmount - OrderLineDiscountAmount;

        public string OrderLineTaxAmountString => _currencyService.FormatCurrency(OrderLineTaxAmount);

        public string OrderLineProductPriceString => _currencyService.FormatCurrency(ProductPrice);

        public string OrderLineDiscountAmountString => _currencyService.FormatCurrency(OrderLineDiscountAmount);

        public string OrderLineTotalString => _currencyService.FormatCurrency(OrderLineTotal);

        public string OrderLineRowTotalString => _currencyService.FormatCurrency(OrderLineRowTotal);
    }
}

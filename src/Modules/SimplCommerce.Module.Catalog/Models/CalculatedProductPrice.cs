using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Catalog.Models
{
    public class CalculatedProductPrice
    {
        private ICurrencyService _currencyService;

        public CalculatedProductPrice(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public decimal Price => PriceExcludingTax + TaxAmount;

        public decimal TaxAmount { get; set; }

        public decimal? OldPrice => OldPriceExcludingTax.HasValue && OldTaxAmount.HasValue ? OldPriceExcludingTax.Value + OldTaxAmount.Value : default(decimal?);

        public decimal? OldTaxAmount { get; set; }

        public int PercentOfSaving { get; set; }

        public string PriceString => _currencyService.FormatCurrency(Price);

        public string TaxAmountString => _currencyService.FormatCurrency(TaxAmount);

        public string OldPriceString => OldPrice.HasValue ? _currencyService.FormatCurrency(OldPrice.Value) : string.Empty;

        public string OldTaxAmountString => OldPrice.HasValue ? _currencyService.FormatCurrency(OldTaxAmount.Value) : string.Empty;

        public decimal PriceExcludingTax { get; set; }

        public string PriceExcludingTaxString => _currencyService.FormatCurrency(PriceExcludingTax);

        public decimal? OldPriceExcludingTax { get; set; }

        public string OldPriceExcludingTaxString => OldPriceExcludingTax.HasValue ? _currencyService.FormatCurrency(OldPriceExcludingTax) : string.Empty;
    }
}

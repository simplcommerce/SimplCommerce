using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.ShippingPrices.Services
{
    public class ShippingPrice
    {
        private readonly ICurrencyService _currencyService;

        public ShippingPrice(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string PriceText
        {
            get
            {
               return _currencyService.FormatCurrency(Price);
            }
        }
    }
}

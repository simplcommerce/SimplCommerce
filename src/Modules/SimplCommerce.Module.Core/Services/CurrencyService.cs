using System.Globalization;
using Microsoft.Extensions.Configuration;

namespace SimplCommerce.Module.Core.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IConfiguration _config;

        public CurrencyService(IConfiguration config)
        {
            _config = config;
            var currencyCulture = "tr-TR";// _config.GetValue<string>("Global.CurrencyCulture");
            CurrencyCulture = new CultureInfo(currencyCulture);
        }

        public CultureInfo CurrencyCulture { get; }

        public string FormatCurrency(decimal value)
        {
            var decimalPlace = 2;// _config.GetValue<int>("Global.CurrencyDecimalPlace");
            return value.ToString($"C{decimalPlace}", CurrencyCulture);
        }
    }
}

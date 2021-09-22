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
            //var currencyCulture = _config.GetValue<string>("Global.CurrencyCulture");
            //CurrencyCulture = new CultureInfo(currencyCulture);
            CurrencyCulture = new CultureInfo("HA-LATN-NG");
        }

        public CultureInfo CurrencyCulture { get; }

        public string FormatCurrency(decimal value)
        {
            //var decimalPlace = _config.GetValue<int>("Global.CurrencyDecimalPlace");
            var decimalPlace = _config.GetValue<int>("HA-LATN-NG");
            return value.ToString($"C{decimalPlace}", CurrencyCulture);
        }
    }
}

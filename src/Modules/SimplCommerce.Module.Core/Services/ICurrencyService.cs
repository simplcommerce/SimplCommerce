using System.Globalization;

namespace SimplCommerce.Module.Core.Services
{
    public interface ICurrencyService
    {
        CultureInfo CurrencyCulture { get; }

        string FormatCurrency(decimal value);
    }
}

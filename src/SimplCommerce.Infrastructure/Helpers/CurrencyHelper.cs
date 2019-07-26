using System.Collections.Generic;
using System.Globalization;

namespace SimplCommerce.Infrastructure.Helpers
{
    public static class CurrencyHelper
    {
        private static readonly List<string> _zeroDecimalCurrencies = new List<string> { "BIF", "DJF", "JPY", "KRW", "PYG", "VND", "XAF", "XPF", "CLP", "GNF", "KMF", "MGA", "RWF", "VUV", "XOF" };

        public static bool IsZeroDecimalCurrencies(CultureInfo cultureInfo)
        {
            var regionInfo = new RegionInfo(cultureInfo.LCID);
            return _zeroDecimalCurrencies.Contains(regionInfo.ISOCurrencySymbol);
        }
    }
}

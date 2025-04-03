using System.Collections.Generic;
using System.Globalization;

namespace SimplCommerce.Infrastructure.Helpers
{
    public static class CurrencyHelper
    {
        private static readonly List<string> _zeroDecimalCurrencies = new List<string> { "BIF", "DJF", "JPY", "KRW", "PYG", "VND", "XAF", "XPF", "CLP", "GNF", "KMF", "MGA", "RWF", "VUV", "XOF" };

        /// <summary>
        /// Determines whether the currency associated with the specified culture uses decimal places.
        /// </summary>
        /// <param name="cultureInfo">The culture to check for its associated currency format.</param>
        /// <returns> true if the currency is a known zero-decimal currency else false</returns>
        public static bool IsZeroDecimalCurrencies(CultureInfo cultureInfo)
        {
            var regionInfo = new RegionInfo(cultureInfo.LCID);
            return _zeroDecimalCurrencies.Contains(regionInfo.ISOCurrencySymbol);
        }
    }
}

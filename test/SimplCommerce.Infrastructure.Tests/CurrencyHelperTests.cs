using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Xunit;
using SimplCommerce.Infrastructure.Helpers;


namespace SimplCommerce.Infrastructure.Tests
{
    public class CurrencyHelperTests
    {
        [Fact]
        public void IsZeroDecimalCurrencies_WithZeroDecimalCurrency_ReturnsTrue()
        {
            var cultureInfo = new CultureInfo("ja-JP");

            var result = CurrencyHelper.IsZeroDecimalCurrencies(cultureInfo);

            Assert.True(result);
        }

        [Fact]
        public void IsZeroDecimalCurrencies_WithNonZeroDecimalCurrency_ReturnsFalse()
        {
            var cultureInfo = new CultureInfo("en-US");

            var result = CurrencyHelper.IsZeroDecimalCurrencies(cultureInfo);

            Assert.False(result);
        }

        [Fact]
        public void IsZeroDecimalCurrencies_WithUnknownCurrency_ReturnsFalse()
        {
            var cultureInfo = new CultureInfo("fr-FR"); 

            var result = CurrencyHelper.IsZeroDecimalCurrencies(cultureInfo);

            Assert.False(result);
        }
        [Fact]
        public void IsZeroDecimalCurrencies_WithUnknown2Currency_ReturnsFalse()
        {
            var cultureInfo = new CultureInfo("de-DE_phoneb");

            var result = CurrencyHelper.IsZeroDecimalCurrencies(cultureInfo);

            Assert.False(result);

        }
        


    }
}

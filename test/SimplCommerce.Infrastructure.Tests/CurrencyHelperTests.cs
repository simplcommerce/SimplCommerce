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
        [Theory]
        [InlineData("ja-JP", true)]    // Japanese Yen (JPY)
        [InlineData("ko-KR", true)]    // Korean Won (KRW)
        [InlineData("en-US", false)]   // US Dollar (USD)
        [InlineData("fr-FR", false)]   // Euro (EUR)
        public void IsZeroDecimalCurrencies_ReturnsExpectedResult(string cultureName, bool expectedResult)
        {
            // Arrange
            var cultureInfo = new CultureInfo(cultureName);

            // Act
            var result = CurrencyHelper.IsZeroDecimalCurrencies(cultureInfo);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void IsZeroDecimalCurrencies_InvalidCulture_ThrowsException()
        {
            // Arrange
            var invalidCulture = CultureInfo.InvariantCulture;

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
                CurrencyHelper.IsZeroDecimalCurrencies(invalidCulture));
        }
    }
}

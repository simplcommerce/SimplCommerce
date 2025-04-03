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
    /// <summary>
    /// Contains unit tests for <see cref="CurrencyHelper.IsZeroDecimalCurrencies"/> method.
    /// </summary>
    public class CurrencyHelperTests
    {
        /// <summary>
        /// Verifies that zero-decimal currencies are correctly identified.
        /// </summary>
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

        /// <summary>
        /// Verifies that an exception is thrown when an invalid culture is provided.
        /// </summary>
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

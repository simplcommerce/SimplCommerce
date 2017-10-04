using Xunit;

namespace SimplCommerce.Infrastructure.Tests
{
    public class StringHelperTests
    {
        [Theory]
        [InlineData("friendly url", "friendly-url")]
        [InlineData("friendly    url", "friendly-url")]
        [InlineData("friendly--url", "friendly-url")]
        [InlineData("friendly---url", "friendly-url")]
        public void EnglishUrlShouldBeReplacedCorrectly(string actual, string expected)
        {
            var foo = "friendly---url".ToUrlFriendly();
            Assert.Equal("friendly-url", foo);
        }

        [Theory]
        [InlineData("понятный адресс", "понятный-адресс")]
        [InlineData("понятный    адресс", "понятный-адресс")]
        [InlineData("понятный--адресс", "понятный-адресс")]
        [InlineData("понятный---адресс", "понятный-адресс")]
        public void RussianUrlShouldBeReplacedCorrectly(string actual, string expected)
        {
            var foo = actual.ToUrlFriendly();
            Assert.Equal(expected, foo);
        }

        [Theory]
        [InlineData("友好 的網址", "友好-的網址")]
        [InlineData("友好    的網址", "友好-的網址")]
        [InlineData("友好--的網址", "友好-的網址")]
        [InlineData("友好---的網址", "友好-的網址")]
        public void ChineseUrlShouldBeReplacedCorrectly(string actual, string expected)
        {
            var foo = actual.ToUrlFriendly();
            Assert.Equal(expected, foo);
        }

        [Theory]
        [InlineData("friendły url", "friendły-url")]
        [InlineData("frđendły url", "frđendły-url")]
        public void UrlWithEgdeCasesShouldBeReplacedCorrectly(string actual, string expected)
        {
            var foo = actual.ToUrlFriendly();
            Assert.Equal(expected, foo);
        }
    }
}

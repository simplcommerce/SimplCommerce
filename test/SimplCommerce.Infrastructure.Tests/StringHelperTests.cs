using Xunit;

namespace SimplCommerce.Infrastructure.Tests
{
    public class StringHelperTests
    {
        [Fact]
        public void UrlWithOneSpaceShouldBeReplacedWithOneDash()
        {
            var foo = "friendly url".ToUrlFriendly();
            Assert.Equal("friendly-url", foo);
        }

        [Fact]
        public void UrlWithManySpacesShouldBeReplacedWithOneDash()
        {
            var foo = "friendly    url".ToUrlFriendly();
            Assert.Equal("friendly-url", foo);
        }

        [Fact]
        public void UrlWithTwoDashesShouldBeReplacedWithOneDash()
        {
            var foo = "friendly--url".ToUrlFriendly();
            Assert.Equal("friendly-url", foo);
        }

        [Fact]
        public void UrlWithManyDashesShouldBeReplacedWithOneDash()
        {
            var foo = "friendly---url".ToUrlFriendly();
            Assert.Equal("friendly-url", foo);
        }
    }
}

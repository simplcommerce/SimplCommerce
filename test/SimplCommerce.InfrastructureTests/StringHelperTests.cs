using SimplCommerce.Infrastructure;
using Xunit;

namespace SimplCommerce.InfrastructureTests
{
    public class StringHelperTests
    {
        [Fact]
        public void UrlWithSpaceShouldBeReplacedWithDash()
        {
            var foo = "friendly url".ToUrlFriendly();
            Assert.Equal("friendly-url", foo);
        }
    }
}

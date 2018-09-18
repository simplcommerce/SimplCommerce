using SimplCommerce.Infrastructure.Helpers;
using Xunit;

namespace SimplCommerce.Infrastructure.Tests
{
    public class EnumHelperTests
    {
        enum Importance
        {
            None,
            Trivial,
            Regular,
            Important,
            Critical
        };

        [Fact]
        public void GetDisplayNameImportanceEnumCriticalShouldReturnsCritical()
        {
            var foo = Importance.Critical.GetDisplayName();
            Assert.Equal("Critical", foo);
        }

        [Fact]
        public void EnumToDictionaryShouldReturnsDictionary()
        {
            var dic = EnumHelper.ToDictionary(typeof(Importance));
            Assert.Equal(5, dic.Count);
        }
    }
}

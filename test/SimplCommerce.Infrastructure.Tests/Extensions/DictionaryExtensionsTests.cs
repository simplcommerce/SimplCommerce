using System.Collections.Generic;
using SimplCommerce.Infrastructure.Extensions;
using Xunit;

namespace SimplCommerce.Infrastructure.Tests
{
    public class DictionaryExtensionsTests
    {
        internal class MockClass
        {
        }

        [Fact]
        public void GetOrDefaultShouldReturnDefaultWithNullDictionary()
        {
            Dictionary<string, MockClass> dict = null;
            MockClass result = dict.GetOrDefault("key");
            Assert.Null(result);
        }

        [Fact]
        public void GetOrDefaultShouldReturnCorrectValue()
        {
            MockClass mockClass = new MockClass();
            Dictionary<string, MockClass> dict = new Dictionary<string, MockClass> { { "key", mockClass } };
            MockClass result = dict.GetOrDefault("key");
            Assert.NotNull(result);
            Assert.Equal(mockClass, result);
        }
    }
}

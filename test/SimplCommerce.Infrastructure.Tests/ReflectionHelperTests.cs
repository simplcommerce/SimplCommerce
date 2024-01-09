using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimplCommerce.Infrastructure.Helpers;
using Xunit;

namespace SimplCommerce.Infrastructure.Tests
{
    public class ReflectionHelperTests
    {
        [Fact]
        public void IsAssignableToGenericType_TypeIsAssignable_ReturnsTrue()
        {
            // Arrange
            var targetType = typeof(List<int>);
            var genericType = typeof(IEnumerable<>);

            // Act
            var result = ReflectionHelper.IsAssignableToGenericType(targetType, genericType);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsAssignableToGenericType_TypeIsNotAssignable_ReturnsFalse()
        {
            // Arrange
            var targetType = typeof(string);
            var genericType = typeof(IEnumerable<>);

            // Act
            var result = ReflectionHelper.IsAssignableToGenericType(targetType, genericType);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsAssignableToGenericType_TypeInheritsGenericInterface_ReturnsTrue()
        {
            // Arrange
            var targetType = typeof(MyClass);
            var genericType = typeof(IGenericInterface<>);

            // Act
            var result = ReflectionHelper.IsAssignableToGenericType(targetType, genericType);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsAssignableToGenericType_TypeDoesNotInheritGenericInterface_ReturnsFalse()
        {
            // Arrange
            var targetType = typeof(MyClass);
            var genericType = typeof(INonGenericInterface);

            // Act
            var result = ReflectionHelper.IsAssignableToGenericType(targetType, genericType);

            // Assert
            Assert.False(result);
        }

        // Example classes/interfaces for testing
        public class MyClass : IGenericInterface<int> { }

        public interface IGenericInterface<T> { }

        public interface INonGenericInterface { }
    }
}

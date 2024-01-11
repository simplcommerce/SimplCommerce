using System;
using System.Linq;
using Moq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;
using Xunit;

namespace SimplCommerce.Module.Core.Tests.Services
{
    public class WidgetInstanceServiceTests
    {
        [Fact]
        public void GetPublished_ShouldReturnPublishedWidgetInstances()
        {
            // Arrange
            var widgetInstances = new[]
            {
                new WidgetInstance { PublishStart = DateTimeOffset.Now.AddDays(-1), PublishEnd = DateTimeOffset.Now.AddDays(1) },
                new WidgetInstance { PublishStart = DateTimeOffset.Now.AddDays(-2), PublishEnd = DateTimeOffset.Now.AddDays(2) }
            };

            var mockRepository = new Mock<IRepository<WidgetInstance>>();
            mockRepository.Setup(x => x.Query()).Returns(widgetInstances.AsQueryable());

            var widgetInstanceService = new WidgetInstanceService(mockRepository.Object);

            // Act
            var result = widgetInstanceService.GetPublished();

            // Assert
            Assert.Equal(widgetInstances.Length, result.Count());
        }

        [Fact]
        public void GetPublished_ShouldNotReturnUnpublishedWidgetInstances()
        {
            // Arrange
            var widgetInstances = new[]
            {
                new WidgetInstance { PublishStart = DateTimeOffset.Now.AddDays(1), PublishEnd = DateTimeOffset.Now.AddDays(2) },
                new WidgetInstance { PublishStart = null, PublishEnd = DateTimeOffset.Now.AddDays(-1) },
            };

            var mockRepository = new Mock<IRepository<WidgetInstance>>();
            mockRepository.Setup(x => x.Query()).Returns(widgetInstances.AsQueryable());

            var widgetInstanceService = new WidgetInstanceService(mockRepository.Object);

            // Act
            var result = widgetInstanceService.GetPublished();

            // Assert
            Assert.Empty(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.ProductComparison.Models;
using SimplCommerce.Module.ProductComparison.Services;
using Xunit;

namespace SimplCommerce.Module.ProductComparison.Tests.Services
{
    public class ComparingProductServiceTests
    {
        [Fact]
        public void AddToComparison_SuccessfullyAddsProduct()
        {
            // Arrange
            var userId = 1;
            var productId = 1001;
            var repositoryMock = new Mock<IRepository<ComparingProduct>>();
            var service = new ComparingProductService(repositoryMock.Object);

            // Act
            service.AddToComparison(userId, productId);

            // Assert
            repositoryMock.Verify(r => r.Add(It.IsAny<ComparingProduct>()), Times.Once);
            repositoryMock.Verify(r => r.SaveChanges(), Times.Once);
        }

        [Fact]
        public void MigrateComparingProduct_SuccessfullyMigratesProducts()
        {
            // Arrange
            var fromUserId = 1;
            var toUserId = 2;
            var repositoryMock = new Mock<IRepository<ComparingProduct>>();
            var comparingProducts = new List<ComparingProduct>()
            {
                new ComparingProduct { UserId = fromUserId, ProductId = 1001 },
                new ComparingProduct { UserId = fromUserId, ProductId = 1002 },
            };
            repositoryMock.Setup(r => r.Query()).Returns(comparingProducts.AsQueryable());
            var service = new ComparingProductService(repositoryMock.Object);

            // Act
            service.MigrateComparingProduct(fromUserId, toUserId);

            // Assert
            repositoryMock.Verify(r => r.SaveChanges(), Times.Once);
            Assert.All(comparingProducts, cp => Assert.Equal(toUserId, cp.UserId));
        }

        [Fact]
        public void AddToComparison_TooManyComparingProducts_ThrowsException()
        {
            // Arrange
            var userId = 1;
            var productId = 1001;
            var repositoryMock = new Mock<IRepository<ComparingProduct>>();
            var listComparingProducts = new List<ComparingProduct>()
            {
                new ComparingProduct()
                {
                    ProductId = 1001,
                    Product=new Product()
                    {
                        Name="TestProduct"
                    },
                    CreatedOn = DateTime.Now,
                    UserId=1
                },
                new ComparingProduct()
                {
                    ProductId = 1002,
                    Product=new Product()
                    {
                        Name="TestProduct1"
                    },
                    CreatedOn = DateTime.Now,
                    UserId=1
                },
                new ComparingProduct()
                {
                    ProductId = 1003,
                    Product=new Product()
                    {
                        Name="TestProduct2"
                    },
                    CreatedOn = DateTime.Now,
                    UserId=1
                },
                new ComparingProduct()
                {
                    ProductId = 1004,
                    Product=new Product()
                    {
                        Name="TestProduct3"
                    },
                    CreatedOn = DateTime.Now,
                    UserId=1
                },
            };
            repositoryMock.Setup(r => r.Query()).Returns(listComparingProducts.AsQueryable);
            var service = new ComparingProductService(repositoryMock.Object);

            // Act & Assert
            Assert.Throws<TooManyComparingProductException>(() => service.AddToComparison(userId, productId));
        }

        [Fact]
        public void AddToComparison_ProductAlreadyExists_DoesNotAddAgain()
        {
            // Arrange
            var comparingProduct = new ComparingProduct()
            {
                ProductId = 1001,
                Product = new Product()
                {
                    Name = "TestProduct"
                },
                CreatedOn = DateTime.Now,
                UserId = 1
            };
            var userId = 1;
            var productId = 1001;
            var repositoryMock = new Mock<IRepository<ComparingProduct>>();
            repositoryMock.Setup(r => r.Query()).Returns(new List<ComparingProduct> { comparingProduct }.AsQueryable);
            var service = new ComparingProductService(repositoryMock.Object);

            // Act
            service.AddToComparison(userId, productId);

            // Assert
            repositoryMock.Verify(r => r.Add(comparingProduct), Times.Never);
            repositoryMock.Verify(r => r.SaveChanges(), Times.Never);
        }
    }
}

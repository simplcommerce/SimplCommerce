using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.ProductComparison.Areas.ProductComparison.Controllers;
using SimplCommerce.Module.ProductComparison.Areas.ProductComparison.ViewModels;
using SimplCommerce.Module.ProductComparison.Models;
using SimplCommerce.Module.ProductComparison.Services;
using Xunit;

namespace SimplCommerce.Module.ProductComparison.Tests.Controllers
{
    public class ComparingProductControllerTests
    {
        [Fact]
        public async Task AddToComparison_SuccessfullyAddsProduct()
        {
            // Arrange
            var userId = 1; // Use a unique user id
            var productId = 1001;
            var model = new AddToComparisonModel { ProductId = productId };
            var repositoryMock = new Mock<IRepository<ComparingProduct>>();
            var comparingProductServiceMock = new Mock<IComparingProductService>();
            var productPricingServiceMock = new Mock<IProductPricingService>();
            var mediaServiceMock = new Mock<IMediaService>();
            var contentLocalizationServiceMock = new Mock<IContentLocalizationService>();
            var workContextMock = new Mock<IWorkContext>();
            var userManagerMock = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            var controller = new ComparingProductController(
                userManagerMock.Object,
                repositoryMock.Object,
                comparingProductServiceMock.Object,
                productPricingServiceMock.Object,
                mediaServiceMock.Object,
                contentLocalizationServiceMock.Object,
                workContextMock.Object
            );
            var user = new User()
            {
                Id = userId,
                UserName = "TestUser"
            };
            workContextMock.Setup(repo => repo.GetCurrentUser()).ReturnsAsync(user);
            
            // Act
            var result = await controller.AddToComparison(model);
            
            // Assert
            comparingProductServiceMock.Verify(s => s.AddToComparison(userId, productId), Times.Once);
            Assert.IsType<PartialViewResult>(result);
        }

        [Fact]
        public async Task Remove_ValidProduct_RemovesProduct()
        {
            // Arrange
            var userId = 1;
            var productId = 1001;
            var repositoryMock = new Mock<IRepository<ComparingProduct>>();
            repositoryMock.Setup(r => r.Query()).Returns(new[]
            {
                new ComparingProduct { UserId = userId, ProductId = productId }
            }.AsQueryable());
            var comparingProductServiceMock = new Mock<IComparingProductService>();
            var productPricingServiceMock = new Mock<IProductPricingService>();
            var mediaServiceMock = new Mock<IMediaService>();
            var contentLocalizationServiceMock = new Mock<IContentLocalizationService>();
            var workContextMock = new Mock<IWorkContext>();
            var userManagerMock = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            var controller = new ComparingProductController(
                userManagerMock.Object,
                repositoryMock.Object,
                comparingProductServiceMock.Object,
                productPricingServiceMock.Object,
                mediaServiceMock.Object,
                contentLocalizationServiceMock.Object,
                workContextMock.Object
            );
            var user = new User()
            {
                Id = userId,
                UserName = "TestUser"
            };
            workContextMock.Setup(repo => repo.GetCurrentUser()).ReturnsAsync(user);
            
            // Act
            var result = await controller.Remove(productId);
            
            // Assert
            repositoryMock.Verify(r => r.Remove(It.IsAny<ComparingProduct>()), Times.Once);
            repositoryMock.Verify(r => r.SaveChanges(), Times.Once);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Index_ReturnsValidViewModel()
        {
            // Arrange
            var userId = 1; // Use a unique user id
            var comparingProducts = new List<ComparingProduct>()
            {
                new ComparingProduct
                {
                    UserId = userId,
                    ProductId = 1001,
                    CreatedOn = DateTime.Now,
                    Product=new Product
                    {
                        AttributeValues={ new ProductAttributeValue()
                        {
                            AttributeId=1,
                            Attribute= new ProductAttribute(){Name="test1"}
                        },
                        new ProductAttributeValue()
                        {
                            AttributeId=2,
                            Attribute= new ProductAttribute(){Name="test2"}
                        },
                        new ProductAttributeValue()
                        {
                            AttributeId=3,
                            Attribute= new ProductAttribute(){Name="test3"}
                        },}
                    }
                },
                new ComparingProduct
                {
                    UserId = userId,
                    ProductId = 1002 ,
                    CreatedOn = DateTime.Now,
                    Product=new Product
                    {
                        AttributeValues={
                            new ProductAttributeValue()
                            {
                                AttributeId=1,
                                Attribute= new ProductAttribute(){Name="test1"}
                            },
                            new ProductAttributeValue()
                            {
                                AttributeId=2,
                                Attribute= new ProductAttribute(){Name="test2"}
                            },
                            new ProductAttributeValue()
                            {
                                AttributeId=3,
                                Attribute= new ProductAttribute(){Name="test3"}
                            },
                        }
                    }
                },
            };
            var repositoryMock = new Mock<IRepository<ComparingProduct>>();
            repositoryMock.Setup(r => r.Query()).Returns(comparingProducts.AsQueryable());
            var comparingProductServiceMock = new Mock<IComparingProductService>();
            var productPricingServiceMock = new Mock<IProductPricingService>();
            var mediaServiceMock = new Mock<IMediaService>();
            var contentLocalizationServiceMock = new Mock<IContentLocalizationService>();
            contentLocalizationServiceMock.Setup(s => s.GetLocalizedProperty(It.IsAny<ComparingProduct>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns<string, string, string>((obj, propertyName, defaultValue) => defaultValue);
            var workContextMock = new Mock<IWorkContext>();
            var userManagerMock = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            workContextMock.Setup(w => w.GetCurrentUser()).ReturnsAsync(new User { Id = userId });
            var controller = new ComparingProductController(
                userManagerMock.Object,
                repositoryMock.Object,
                comparingProductServiceMock.Object,
                productPricingServiceMock.Object,
                mediaServiceMock.Object,
                contentLocalizationServiceMock.Object,
                workContextMock.Object
            );
            
            // Act
            var result = await controller.Index();
            
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = Assert.IsType<ProductComparisonVm>(viewResult.Model);
            Assert.Equal(comparingProducts.Count, viewModel.Products.Count);
            Assert.NotEmpty(viewModel.Attributes);
        }

        [Fact]
        public async Task AddToComparison_TooManyComparingProducts_ReturnsErrorMessage()
        {
            // Arrange
            var userId = 1;
            var productId = 1001;
            var model = new AddToComparisonModel { ProductId = productId };
            var repositoryMock = new Mock<IRepository<ComparingProduct>>();
            var comparingProductServiceMock = new Mock<IComparingProductService>();
            comparingProductServiceMock.Setup(s => s.AddToComparison(userId, productId))
                .Throws(new TooManyComparingProductException(4));
            var productPricingServiceMock = new Mock<IProductPricingService>();
            var mediaServiceMock = new Mock<IMediaService>();
            var contentLocalizationServiceMock = new Mock<IContentLocalizationService>();
            var workContextMock = new Mock<IWorkContext>();
            var userManagerMock = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            var controller = new ComparingProductController(
                userManagerMock.Object,
                repositoryMock.Object,
                comparingProductServiceMock.Object,
                productPricingServiceMock.Object,
                mediaServiceMock.Object,
                contentLocalizationServiceMock.Object,
                workContextMock.Object
            );
            var user = new User()
            {
                Id = userId,
                UserName = "TestUser"
            };
            workContextMock.Setup(repo => repo.GetCurrentUser()).ReturnsAsync(user);
            
            // Act
            var result = await controller.AddToComparison(model);
            
            // Assert
            comparingProductServiceMock.Verify(s => s.AddToComparison(It.IsAny<long>(), It.IsAny<long>()), Times.Once);
            var viewResult = Assert.IsType<PartialViewResult>(result);
            var viewModel = Assert.IsType<AddToComparisonResult>(viewResult.Model);
            Assert.Contains("Can not add to comparison items", viewModel.Message);
        }

        [Fact]
        public async Task Remove_InvalidProduct_ReturnsNotFound()
        {
            // Arrange
            var userId = 1;
            var productId = 1001;
            var repositoryMock = new Mock<IRepository<ComparingProduct>>();
            repositoryMock.Setup(r => r.Query()).Returns(new[]
            {
                new ComparingProduct { UserId = userId, ProductId = 999 }
            }.AsQueryable());
            var comparingProductServiceMock = new Mock<IComparingProductService>();
            var productPricingServiceMock = new Mock<IProductPricingService>();
            var mediaServiceMock = new Mock<IMediaService>();
            var contentLocalizationServiceMock = new Mock<IContentLocalizationService>();
            var workContextMock = new Mock<IWorkContext>();
            var userManagerMock = new Mock<UserManager<User>>(
                Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
            var controller = new ComparingProductController(
                userManagerMock.Object,
                repositoryMock.Object,
                comparingProductServiceMock.Object,
                productPricingServiceMock.Object,
                mediaServiceMock.Object,
                contentLocalizationServiceMock.Object,
                workContextMock.Object
            );
            var user = new User()
            {
                Id = userId,
                UserName = "TestUser"
            };
            workContextMock.Setup(repo => repo.GetCurrentUser()).ReturnsAsync(user);
            
            // Act
            var result = await controller.Remove(productId);

            // Assert
            repositoryMock.Verify(r => r.Remove(It.IsAny<ComparingProduct>()), Times.Never);
            repositoryMock.Verify(r => r.SaveChanges(), Times.Never);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Checkouts.Areas.Checkouts.ViewModels;
using SimplCommerce.Module.Checkouts.Models;
using SimplCommerce.Module.Checkouts.Services;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Pricing.Services;
using SimplCommerce.Module.ShippingPrices.Services;
using SimplCommerce.Module.Tax.Services;
using Xunit;

namespace SimplCommerce.Module.Checkouts.Test.Service
{
    public class CheckoutServiceTest
    {

        [Fact]
        public async Task Create_ValidData_CheckoutCreatedSuccessfully()
        {
            // Arrange
            var checkoutRepositoryMock = new Mock<IRepositoryWithTypedId<Checkout, Guid>>();
            var userAddressRepositoryMock = new Mock<IRepository<UserAddress>>();
            var shippingPriceServiceMock = new Mock<IShippingPriceService>();
            var checkoutItemRepositoryMock = new Mock<IRepository<CheckoutItem>>();
            var taxServiceMock = new Mock<ITaxService>();
            var currencyServiceMock = new Mock<ICurrencyService>();
            var mediaServiceMock = new Mock<IMediaService>();
            var couponServiceMock = new Mock<ICouponService>();
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(config => config.GetValue<bool>("Catalog.IsProductPriceIncludeTax")).Returns(true);

            var checkoutService = new CheckoutService(
                checkoutRepositoryMock.Object,
                userAddressRepositoryMock.Object,
                shippingPriceServiceMock.Object,
                checkoutItemRepositoryMock.Object,
                taxServiceMock.Object,
                currencyServiceMock.Object,
                mediaServiceMock.Object,
                couponServiceMock.Object,
                configurationMock.Object
            );

            var customerId = 12;
            var createdById = 12;
            var cartItems = new List<CartItemToCheckoutVm>
            {
                new CartItemToCheckoutVm { ProductId = 23, Quantity = 1 }
            };
            var couponCode = "DISCOUNT123";

            // Act
            var result = await checkoutService.Create(customerId, createdById, cartItems, couponCode);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(customerId, result.CustomerId);
            Assert.Equal(createdById, result.CreatedById);
            Assert.True(result.IsProductPriceIncludeTax);
            Assert.Equal(couponCode, result.CouponCode);

            checkoutRepositoryMock.Verify(mock => mock.Add(It.IsAny<Checkout>()), Times.Once);
            checkoutRepositoryMock.Verify(mock => mock.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task Create_EmptyCartItems_CheckoutCreatedWithNoItems()
        {
            // Arrange
            var checkoutRepositoryMock = new Mock<IRepositoryWithTypedId<Checkout, Guid>>();
            var userAddressRepositoryMock = new Mock<IRepository<UserAddress>>();
            var shippingPriceServiceMock = new Mock<IShippingPriceService>();
            var checkoutItemRepositoryMock = new Mock<IRepository<CheckoutItem>>();
            var taxServiceMock = new Mock<ITaxService>();
            var currencyServiceMock = new Mock<ICurrencyService>();
            var mediaServiceMock = new Mock<IMediaService>();
            var couponServiceMock = new Mock<ICouponService>();
            var configurationMock = new Mock<IConfiguration>();
            configurationMock.Setup(config => config.GetValue<bool>("Catalog.IsProductPriceIncludeTax")).Returns(true);

            var checkoutService = new CheckoutService(
                checkoutRepositoryMock.Object,
                userAddressRepositoryMock.Object,
                shippingPriceServiceMock.Object,
                checkoutItemRepositoryMock.Object,
                taxServiceMock.Object,
                currencyServiceMock.Object,
                mediaServiceMock.Object,
                couponServiceMock.Object,
                configurationMock.Object
            );

            var customerId = 1;
            var createdById = 2;
            var cartItems = new List<CartItemToCheckoutVm>(); // Empty cart items
            var couponCode = "DISCOUNT123";

            // Act
            var result = await checkoutService.Create(customerId, createdById, cartItems, couponCode);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.CheckoutItems);

            checkoutRepositoryMock.Verify(mock => mock.Add(It.IsAny<Checkout>()), Times.Once);
            checkoutRepositoryMock.Verify(mock => mock.SaveChangesAsync(), Times.Once);
        }


    }
}

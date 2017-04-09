using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Components;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.ViewModels.Manage;
using Xunit;

namespace SimplCommerce.Module.Core.Tests.Components
{
    public class DefaultAddressViewComponentTest
    {

        [Fact]
        public async Task DefaultAddressViewComponent_Should_Returns_DefaultAddress()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Address>>();
            var country = new Country { Name = "France" };
            var sop = new StateOrProvince { Name = "IDF", Country = country, Type = "foo" };
            var district = new District { Location = "North", StateOrProvince = sop, Name = "Fresnes" };
            var address = new Address
            {
                CountryId = 1,
                AddressLine1 = "5 Rue Marcel",
                Country = country,
                StateOrProvince = sop,
                District = district
            };
            mockRepository.Setup(x => x.Add(address));
            var mockWorkContext = new Mock<IWorkContext>();
            var user = new User { DefaultBillingAddressId = 0, Id = 1, FullName = "Maher" };
            mockWorkContext.Setup(x => x.GetCurrentUser()).Returns(Task.FromResult(user));
            var component = new DefaultAddressViewComponent(mockRepository.Object, mockWorkContext.Object);

            // Act
            var result = await component.InvokeAsync();

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewViewComponentResult>(result);
            Assert.NotNull(viewResult.ViewName);
            var model = Assert.IsType< DefaultAddressViewComponentVm>(viewResult.ViewData.Model);
            Assert.Equal(address.AddressLine1, model.Address.AddressLine1);
            Assert.Equal("/Modules/SimplCommerce.Module.Core/Views/Components/DefaultAddress.cshtml", viewResult.ViewName);
        }

    }
}

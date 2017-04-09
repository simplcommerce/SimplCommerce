using System.Collections.Generic;
using System.Linq;
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
            var stateOrProvince = new StateOrProvince { Name = "IDF", Country = country, Type = "State" };
            var district = new District { Location = "Center", StateOrProvince = stateOrProvince, Name = "Paris" };

            var address = new Address
            {
                CountryId = 1,
                AddressLine1 = "115 Rue Marcel",
                Country = country,
                StateOrProvince = stateOrProvince,
                District = district
            };

            mockRepository.Setup(x => x.Query()).Returns(new List<Address> { address }.AsQueryable());
            var mockWorkContext = new Mock<IWorkContext>();
            var user = new User { Id = 1, FullName = "Maher", DefaultShippingAddressId = 0 };
            mockWorkContext.Setup(x => x.GetCurrentUser()).Returns(Task.FromResult(user));
            var component = new DefaultAddressViewComponent(mockRepository.Object, mockWorkContext.Object);

            // Act
            var result = await component.InvokeAsync();

            // Assert
            Assert.NotNull(result);
            var viewResult = Assert.IsType<ViewViewComponentResult>(result);
            Assert.NotNull(viewResult.ViewName);
            var model = Assert.IsType<DefaultAddressViewComponentVm>(viewResult.ViewData.Model);
            Assert.Equal(address.AddressLine1, model.Address.AddressLine1);
            Assert.Equal("/Modules/SimplCommerce.Module.Core/Views/Components/DefaultAddress.cshtml", viewResult.ViewName);
        }

    }
}

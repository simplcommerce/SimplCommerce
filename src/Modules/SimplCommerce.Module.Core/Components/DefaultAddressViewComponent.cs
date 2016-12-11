using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.ViewModels;
using SimplCommerce.Module.Core.ViewModels.Manage;

namespace SimplCommerce.Module.Core.Components
{
    public class DefaultAddressViewComponent : ViewComponent
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly IWorkContext _workContext;

        public DefaultAddressViewComponent(IRepository<Address> addressRepository, IWorkContext workContext)
        {
            _addressRepository = addressRepository;
            _workContext = workContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var curentUser = await _workContext.GetCurrentUser();

            var model = new DefaultAddressViewComponentVm();

            if (curentUser.CurrentShippingAddressId.HasValue)
            {
                var address = _addressRepository.Query()
                    .Include(x => x.District)
                    .Include(x => x.StateOrProvince)
                    .Include(x => x.Country)
                    .First(x => x.Id == curentUser.CurrentShippingAddressId.Value);
                model.Address = new UserAddressListItem
                {
                    UserAddressId = address.Id,
                    ContactName = address.ContactName,
                    Phone = address.Phone,
                    AddressLine1 = address.AddressLine1,
                    AddressLine2 = address.AddressLine1,
                    DistrictName = address.District.Name,
                    StateOrProvinceName = address.StateOrProvince.Name,
                    CountryName = address.Country.Name
                };
            }

            return View("/Modules/SimplCommerce.Module.Core/Views/Components/DefaultAddress.cshtml", model);
        }
    }
}
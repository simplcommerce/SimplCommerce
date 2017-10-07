using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.ViewModels;
using SimplCommerce.Module.Core.ViewModels.Manage;
using Microsoft.EntityFrameworkCore;

namespace SimplCommerce.Module.Core.Components
{
    public class DefaultShippingAddressViewComponent : ViewComponent
    {
        private readonly IRepository<UserAddress> _userAddressRepository;
        private readonly IWorkContext _workContext;

        public DefaultShippingAddressViewComponent(IRepository<UserAddress> userAddressRepository, IWorkContext workContext)
        {
            _userAddressRepository = userAddressRepository;
            _workContext = workContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var curentUser = await _workContext.GetCurrentUser();

            var model = new DefaultAddressViewComponentVm();

            if (curentUser.DefaultShippingAddressId.HasValue)
            {
                var userAddress = _userAddressRepository.Query().Include(a => a.Address)
                    .ThenInclude(x => x.District)
                    .ThenInclude(x => x.StateOrProvince)
                    .ThenInclude(x => x.Country)
                    .First(x => x.Id == curentUser.DefaultShippingAddressId.Value);
                if (userAddress != null)
                {
                    model.Address = new UserAddressListItem
                    {
                        UserAddressId = userAddress.Id,
                        ContactName = userAddress.Address.ContactName,
                        Phone = userAddress.Address.Phone,
                        AddressLine1 = userAddress.Address.AddressLine1,
                        AddressLine2 = userAddress.Address.AddressLine1,
                        DistrictName = userAddress.Address.District.Name,
                        StateOrProvinceName = userAddress.Address.StateOrProvince.Name,
                        CountryName = userAddress.Address.Country.Name
                    };
                }
            }

            return View("/Modules/SimplCommerce.Module.Core/Views/Components/DefaultShippingAddress.cshtml", model);
        }
    }
}
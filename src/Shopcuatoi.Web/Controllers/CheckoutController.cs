using System.Linq;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;
using Shopcuatoi.Web.ViewModels.Checkout;

namespace Shopcuatoi.Web.Controllers
{
    [Authorize]
    public class CheckoutController : BaseController
    {
        private IRepository<StateOrProvince> stateOrProvinceRepository;
        private IRepository<UserAddress> userAddressRepository; 

        public CheckoutController(UserManager<User> userManager, IRepository<StateOrProvince> stateOrProvinceRepository, IRepository<UserAddress> userAddressRepository) : base(userManager)
        {
            this.stateOrProvinceRepository = stateOrProvinceRepository;
            this.userAddressRepository = userAddressRepository;
        }

        public IActionResult Index()
        {
            return RedirectToAction("DeliveryInformation");
        }

        public IActionResult DeliveryInformation()
        {
            var model = new DeliveryInformationViewModel();

            model.ExistingShippingAddresses = userAddressRepository
                .Query()
                .Where(x => x.AddressType == AddressType.Shipping && x.UserId == CurrentUserId)
                .Select(x => new ShippingAddressViewModel
                {
                    UserAddressId = x.Id,
                    ContactName = x.Address.ContactName,
                    Phone = x.Address.Phone,
                    AddressLine1 = x.Address.AddressLine1,
                    AddressLine2 = x.Address.AddressLine1,
                    DistrictName = x.Address.District.Name,
                    StateOrProvinceName = x.Address.StateOrProvince.Name,
                    CountryName = x.Address.Country.Name
                }).ToList();

            model.NewAddressForm.StateOrProvinces = stateOrProvinceRepository
                .Query()
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

            return View(model);
        }
    }
}
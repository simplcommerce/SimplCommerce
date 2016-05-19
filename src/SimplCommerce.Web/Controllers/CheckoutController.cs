using System.Linq;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Orders.ApplicationServices;
using SimplCommerce.Web.ViewModels.Checkout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SimplCommerce.Web.Controllers
{
    [Authorize]
    public class CheckoutController : BaseController
    {
        private IRepository<StateOrProvince> stateOrProvinceRepository;
        private IRepository<District> districtRepository;
        private IRepository<UserAddress> userAddressRepository;
        private IRepository<User> userRepository;
        private IOrderService orderService;

        public CheckoutController(
            UserManager<User> userManager,
            IRepository<StateOrProvince> stateOrProvinceRepository,
            IRepository<District> districtRepository,
            IRepository<UserAddress> userAddressRepository,
            IRepository<User> userRepository,
            IOrderService orderService) : base(userManager)
        {
            this.stateOrProvinceRepository = stateOrProvinceRepository;
            this.districtRepository = districtRepository;
            this.userAddressRepository = userAddressRepository;
            this.userRepository = userRepository;
            this.orderService = orderService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("DeliveryInformation");
        }

        [HttpGet]
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
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

            var selectedStateOrProvince = long.Parse(model.NewAddressForm.StateOrProvinces.First().Value);

            model.NewAddressForm.Districts = districtRepository
                .Query()
                .Where(x => x.StateOrProvinceId == selectedStateOrProvince)
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem
                 {
                     Text = x.Name,
                     Value = x.Id.ToString()
                 }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult DeliveryInformation(DeliveryInformationViewModel model)
        {
            if (!ModelState.IsValid && model.ShippingAddressId == 0)
            {
                return View(model);
            }

            var user = userRepository.Query().FirstOrDefault(x => x.Id == CurrentUserId);

            if (model.ShippingAddressId == 0)
            {
                var address = new Address
                {
                    AddressLine1 = model.NewAddressForm.AddressLine1,
                    ContactName = model.NewAddressForm.ContactName,
                    CountryId = 1,
                    StateOrProvinceId = model.NewAddressForm.StateOrProvinceId,
                    DistrictId = model.NewAddressForm.DistrictId,
                    Phone = model.NewAddressForm.Phone
                };

                var userAddress = new UserAddress
                {
                    Address = address,
                    AddressType = AddressType.Shipping,
                    UserId = CurrentUserId
                };

                userAddressRepository.Add(userAddress);
                user.CurrentShippingAddress = userAddress;
            }
            else
            {
                user.CurrentShippingAddress = userAddressRepository.Query().FirstOrDefault(x => x.Id == model.ShippingAddressId);
            }
            orderService.CreateOrder(user);
            userAddressRepository.SaveChange();

            return RedirectToAction("OrderConfirmation");
        }

        [HttpGet]
        public IActionResult OrderConfirmation()
        {
            return View();
        }
    }
}
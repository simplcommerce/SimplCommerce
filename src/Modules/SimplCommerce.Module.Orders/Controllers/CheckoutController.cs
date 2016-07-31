using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.Orders.ViewModels;

namespace SimplCommerce.Module.Orders.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private IRepository<StateOrProvince> _stateOrProvinceRepository;
        private IRepository<District> _districtRepository;
        private IRepository<UserAddress> _userAddressRepository;
        private IRepository<User> _userRepository;
        private IOrderService _orderService;
        private IWorkContext _workContext;

        public CheckoutController(
            UserManager<User> userManager,
            IRepository<StateOrProvince> stateOrProvinceRepository,
            IRepository<District> districtRepository,
            IRepository<UserAddress> userAddressRepository,
            IRepository<User> userRepository,
            IOrderService orderService,
            IWorkContext workContext)
        {
            _stateOrProvinceRepository = stateOrProvinceRepository;
            _districtRepository = districtRepository;
            _userAddressRepository = userAddressRepository;
            _userRepository = userRepository;
            _orderService = orderService;
            _workContext = workContext;
        }

        public IActionResult Index()
        {
            return RedirectToAction("DeliveryInformation");
        }

        [HttpGet]
        public async Task<IActionResult> DeliveryInformation()
        {
            var model = new DeliveryInformationVm();

            var currentUser = await _workContext.GetCurrentUser();
            model.ExistingShippingAddresses = _userAddressRepository
                .Query()
                .Where(x => x.AddressType == AddressType.Shipping && x.UserId == currentUser.Id)
                .Select(x => new ShippingAddressVm
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

            model.ShippingAddressId = currentUser.CurrentShippingAddressId ?? 0;

            model.NewAddressForm.StateOrProvinces = _stateOrProvinceRepository
                .Query()
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

            var selectedStateOrProvince = long.Parse(model.NewAddressForm.StateOrProvinces.First().Value);

            model.NewAddressForm.Districts = _districtRepository
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
        public async Task<IActionResult> DeliveryInformation(DeliveryInformationVm model)
        {
            if (!ModelState.IsValid && model.ShippingAddressId == 0)
            {
                return View(model);
            }

            var currentUser = await _workContext.GetCurrentUser();

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
                    UserId = currentUser.Id
                };

                _userAddressRepository.Add(userAddress);
                currentUser.CurrentShippingAddress = userAddress;
            }
            else
            {
                currentUser.CurrentShippingAddress = _userAddressRepository.Query().FirstOrDefault(x => x.Id == model.ShippingAddressId);
            }
            _orderService.CreateOrder(currentUser);

            return RedirectToAction("OrderConfirmation");
        }

        [HttpGet]
        public IActionResult OrderConfirmation()
        {
            return View();
        }
    }
}

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.Orders.ViewModels;
using SimplCommerce.Module.Shipping.Models;
using SimplCommerce.Module.PaymentType.Models;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.PaymentType.Services;
using SimplCommerce.Module.Shipping.Services;

namespace SimplCommerce.Module.Orders.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly IRepository<District> _districtRepository;
        private readonly IOrderService _orderService;
        private readonly IRepository<StateOrProvince> _stateOrProvinceRepository;
        private readonly IRepository<UserAddress> _userAddressRepository;
        private readonly IWorkContext _workContext;
        private readonly IRepository<ShippingMethod> _shippingservice;
        private readonly IRepository<PaymentType.Models.PaymentType> _paymentTypeService;

        public CheckoutController(

            IRepository<StateOrProvince> stateOrProvinceRepository,
            IRepository<District> districtRepository,
            IRepository<UserAddress> userAddressRepository,
            IOrderService orderService,
            IWorkContext workContext,
             IRepository<PaymentType.Models.PaymentType> paymentRepository,
             IRepository<ShippingMethod> shippingRepository

            )
        {
            _stateOrProvinceRepository = stateOrProvinceRepository;
            _districtRepository = districtRepository;
            _userAddressRepository = userAddressRepository;
            _orderService = orderService;
            _workContext = workContext;
            _shippingservice = shippingRepository;
            _paymentTypeService = paymentRepository;
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
                .Where(x => (x.AddressType == AddressType.Shipping) && (x.UserId == currentUser.Id))
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

            model.ShippingAddressId = currentUser.DefaultShippingAddressId ?? 0;

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
            if (!ModelState.IsValid && (model.ShippingAddressId == 0) && (model.shippingmethodid == 0) && (model.paymentmethodid == 0))
            {
                return View(model);
            }

            var currentUser = await _workContext.GetCurrentUser();
            Address billingAddress;
            Address shippingAddress;

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

                billingAddress = shippingAddress = address;
            }
            else
            {
                billingAddress = shippingAddress = _userAddressRepository.Query().Where(x => x.Id == model.ShippingAddressId).Select(x => x.Address).First();
            }
            ShippingMethod shippingmethod = _shippingservice.Query().Where(x => x.Id == model.shippingmethodid).First();
            PaymentType.Models.PaymentType paymenttype = _paymentTypeService.Query().Where(x => x.Id == model.paymentmethodid).First();
           
            //have to add one field with orderpaymentmethodname and bool if it is successfully payed
            Order  createdorder  = await _orderService.CreateOrder(currentUser, billingAddress, shippingAddress, shippingmethod, paymenttype);
            //Go for payment call pay method with created order which is current order 
            if(paymenttype.Code == 0)
            {
                return RedirectToAction("Index", "payment", new { @Id = createdorder.Id });
            }
            
            return RedirectToAction("OrderConfirmation");
        }

        [HttpGet]
        public IActionResult OrderConfirmation()
        {
            return View();
        }
    }
}
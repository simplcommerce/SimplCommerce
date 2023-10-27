using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Checkouts.Areas.Checkouts.ViewModels;
using SimplCommerce.Module.Checkouts.Models;
using SimplCommerce.Module.Checkouts.Services;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.ShoppingCart.Models;
using SimplCommerce.Module.ShoppingCart.Services;

namespace SimplCommerce.Module.Checkouts.Areas.Checkouts.Controllers
{
    [Area("Checkouts")]
    [Route("checkout")]
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class CheckoutController : Controller
    {
        private readonly IRepositoryWithTypedId<Country, string> _countryRepository;
        private readonly IRepository<StateOrProvince> _stateOrProvinceRepository;
        private readonly IRepository<UserAddress> _userAddressRepository;
        private readonly ICheckoutService _checkoutService;
        private readonly IRepository<CartItem> _cartItemRepository;
        private readonly IWorkContext _workContext;
        private readonly IRepositoryWithTypedId<Checkout, Guid> _checkoutRepository;

        public CheckoutController(
            IRepository<StateOrProvince> stateOrProvinceRepository,
            IRepositoryWithTypedId<Country, string> countryRepository,
            IRepository<UserAddress> userAddressRepository,
            ICheckoutService checkout,
            IRepository<CartItem> cartItemRepository,
            IWorkContext workContext,
            IRepositoryWithTypedId<Checkout, Guid> checkoutRepository)
        {
            _stateOrProvinceRepository = stateOrProvinceRepository;
            _countryRepository = countryRepository;
            _userAddressRepository = userAddressRepository;
            _checkoutService = checkout;
            _cartItemRepository = cartItemRepository;
            _workContext = workContext;
            _checkoutRepository = checkoutRepository;
        }

        //TODO: Consider to allow customer select a subset of products in cart and pass to this endpoint
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CheckoutFormVm checkoutFormVm)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return Redirect("/login?ReturnUrl=%2Fcart");
            }
            var currentUser = await _workContext.GetCurrentUser();
            var cartItems = await _cartItemRepository.Query().Where(x => x.CustomerId == currentUser.Id).ToListAsync();
            if (!cartItems.Any())
            {
                return NotFound();
            }

            var cartItemToCheckouts = cartItems.Select(x => new CartItemToCheckoutVm
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToList();

            var checkout = await _checkoutService.Create(currentUser.Id, currentUser.Id, cartItemToCheckouts, checkoutFormVm.CouponCode);

            return Redirect($"~/checkout/{checkout.Id}/shipping");
        }

        [HttpGet("{checkoutId}/shipping")]
        public async Task<IActionResult> Shipping(Guid checkoutId)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var checkout = await _checkoutRepository.Query().FirstOrDefaultAsync(x => x.Id == checkoutId);
            if (checkout == null)
            {
                return NotFound();
            }

            if (checkout.CreatedBy != currentUser)
            {
                return Forbid();
            }

            var model = new DeliveryInformationVm();
            model.CheckoutId = checkoutId;

            PopulateShippingForm(model, currentUser);

            return View(model);
        }

        [HttpPost("{checkoutId}/shipping")]
        public async Task<IActionResult> Shipping(Guid checkoutId, DeliveryInformationVm model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var checkout = await _checkoutRepository.Query().FirstOrDefaultAsync(x => x.Id == checkoutId);
            if (checkout == null)
            {
                return NotFound();
            }

            if (checkout.CreatedBy != currentUser)
            {
                return Forbid();
            }

            if ((!model.NewAddressForm.IsValid() && model.ShippingAddressId == 0) ||
                (!model.NewBillingAddressForm.IsValid() && !model.UseShippingAddressAsBillingAddress && model.BillingAddressId == 0))
            {
                PopulateShippingForm(model, currentUser);
                return View(model);
            }

            checkout.ShippingData = JsonConvert.SerializeObject(model);
            await _checkoutRepository.SaveChangesAsync();
            return Redirect($"~/checkout/{checkoutId}/payment");
        }

        [HttpPost("{checkoutId}/update-tax-and-shipping-prices")]
        public async Task<IActionResult> UpdateTaxAndShippingPrices(Guid checkoutId, [FromBody] TaxAndShippingPriceRequestVm model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var checkout = await _checkoutRepository.Query().FirstOrDefaultAsync(x => x.Id == checkoutId);
            if(checkout == null)
            {
                return NotFound();
            }

            if (checkout.CreatedBy != currentUser)
            {
                return Forbid();
            }

            var orderTaxAndShippingPrice = await _checkoutService.UpdateTaxAndShippingPrices(checkoutId, model);

            return Ok(orderTaxAndShippingPrice);
        }

        [HttpGet("success")]
        public IActionResult Success(long orderId)
        {
            return View(orderId);
        }

        [HttpGet("error")]
        public IActionResult Error(long orderId)
        {
            return View(orderId);
        }

        private void PopulateShippingForm(DeliveryInformationVm model, User currentUser)
        {
            model.ExistingShippingAddresses = _userAddressRepository
                .Query()
                .Where(x => (x.AddressType == AddressType.Shipping) && (x.UserId == currentUser.Id))
                .Select(x => new ShippingAddressVm
                {
                    UserAddressId = x.Id,
                    ContactName = x.Address.ContactName,
                    Phone = x.Address.Phone,
                    AddressLine1 = x.Address.AddressLine1,
                    CityName = x.Address.City,
                    ZipCode = x.Address.ZipCode,
                    DistrictName = x.Address.District.Name,
                    StateOrProvinceName = x.Address.StateOrProvince.Name,
                    CountryName = x.Address.Country.Name,
                    IsCityEnabled = x.Address.Country.IsCityEnabled,
                    IsZipCodeEnabled = x.Address.Country.IsZipCodeEnabled,
                    IsDistrictEnabled = x.Address.Country.IsDistrictEnabled
                }).ToList();

            model.ShippingAddressId = currentUser.DefaultShippingAddressId ?? 0;

            model.UseShippingAddressAsBillingAddress = true;

            model.NewAddressForm.ShipableContries = _countryRepository.Query()
                .Where(x => x.IsShippingEnabled)
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

            if (model.NewAddressForm.ShipableContries.Count == 1)
            {
                var onlyShipableCountryId = model.NewAddressForm.ShipableContries.First().Value;

                model.NewAddressForm.StateOrProvinces = _stateOrProvinceRepository
                .Query()
                .Where(x => x.CountryId == onlyShipableCountryId)
                .OrderBy(x => x.Name)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();
            }
        }
    }
}

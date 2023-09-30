using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Checkouts.Areas.Checkouts.ViewModels;
using SimplCommerce.Module.Checkouts.Models;
using SimplCommerce.Module.Checkouts.Services;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Orders.Services;
using SimplCommerce.Module.ShoppingCart.Models;

namespace SimplCommerce.Module.Orders.Areas.Orders.Controllers
{
    [Area("ShoppingCart")]
    [Authorize(Roles = "admin")]
    public class CheckoutApiController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICheckoutService _checkoutService;
        private readonly IRepositoryWithTypedId<Checkout, Guid> _checkoutRepository;
        private readonly IWorkContext _workContext;

        public CheckoutApiController(
            IOrderService orderService,
            ICheckoutService checkoutService,
            IRepositoryWithTypedId<Checkout, Guid> checkoutRepository,
            IWorkContext workContext)
        {
            _orderService = orderService;
            _checkoutService = checkoutService;
            _checkoutRepository = checkoutRepository;
            _workContext = workContext;
        }

        [HttpPost("api/checkout/{checkoutId}/update-tax-and-shipping-prices")]
        public async Task<IActionResult> UpdateTaxAndShippingPrices(Guid checkoutId, [FromBody] TaxAndShippingPriceRequestVm model)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var checkout = await _checkoutRepository.Query().FirstOrDefaultAsync(x => x.Id == checkoutId);
            if (checkout == null)
            {
                return NotFound();
            }

            if (checkout.CreatedById != currentUser.Id)
            {
                return Forbid();
            }

            var orderTaxAndShippingPrice = await _checkoutService.UpdateTaxAndShippingPrices(checkout.Id, model);
            return Ok(orderTaxAndShippingPrice);
        }

        [HttpPost("api/checkout/{checkoutId}/order")]
        public async Task<IActionResult> CreateOrder(Guid checkoutId, [FromBody] DeliveryInformationVm deliveryInformationVm)
        {
            var currentUser = await _workContext.GetCurrentUser();
            var checkout = await _checkoutRepository.Query().FirstOrDefaultAsync(x => x.Id == checkoutId);
            if (checkout == null)
            {
                return NotFound();
            }

            if (checkout.CreatedById != currentUser.Id)
            {
                return Forbid();
            }

            checkout.ShippingData = JsonConvert.SerializeObject(deliveryInformationVm);
            checkout.OrderNote = deliveryInformationVm.OrderNote;
            _checkoutRepository.SaveChanges();
            var orderCreateResult = await _orderService.CreateOrder(checkout.Id, "CashOnDelivery", 0);

            if (!orderCreateResult.Success)
            {
                return BadRequest(orderCreateResult.Error);
            }

            return Created($"/api/orders/{orderCreateResult.Value.Id}", new { id = orderCreateResult.Value.Id });
        }

        // TODO might need to move to another place
        [HttpGet("api/users/{userId}/addresses")]
        public async Task<IActionResult> UserAddress(long userId, [FromServices] IRepository<UserAddress> userAddressRepository, [FromServices] IRepository<User> userRepository)
        {
            var user = await userRepository.Query().FirstOrDefaultAsync(x => x.Id == userId);
            if(user == null)
            {
                return NotFound();
            }

            var defaultAddressId = user.DefaultShippingAddressId.HasValue ? user.DefaultShippingAddressId : 0;
            var userAddress = await userAddressRepository
                .Query()
                .Where(x => (x.AddressType == AddressType.Shipping) && (x.UserId == userId))
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
                }).ToListAsync();

            return Ok(new { Addresses = userAddress, DefaultShippingAddressId = defaultAddressId });
        }
    }
}

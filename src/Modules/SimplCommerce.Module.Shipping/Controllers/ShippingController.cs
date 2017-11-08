using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Shipping.Services;
using SimplCommerce.Module.Shipping.ViewModels;

namespace SimplCommerce.Module.Shipping.Controllers
{
    public class ShippingController : Controller
    {
        private readonly IShippingService _shippingService;

        public ShippingController(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }

        [HttpPost]
        public async Task<IActionResult> GetShippingPrices([FromBody] ShippingPriceRequestVm model)
        {
            var request = new GetShippingPriceRequest
            {
                OrderAmount = model.OrderAmount,
                ShippingAddress = new Address
                {
                    CountryId = model.ShippingAddress.CountryId,
                    StateOrProvinceId = model.ShippingAddress.StateOrProvinceId,
                    AddressLine1 = model.ShippingAddress.AddressLine1
                }
            };
            var applicableShippingPrices = await _shippingService.GetApplicableShippingPrices(request);

            return Ok(applicableShippingPrices);
        }
    }
}

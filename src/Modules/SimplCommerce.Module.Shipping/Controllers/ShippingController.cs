using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Shipping.Services;
using SimplCommerce.Module.Shipping.ViewModels;
using SimplCommerce.Infrastructure.Data;

namespace SimplCommerce.Module.Shipping.Controllers
{
    public class ShippingController : Controller
    {
        private readonly IShippingService _shippingService;
        private readonly IRepository<UserAddress> _userAddressRepository;

        public ShippingController(IShippingService shippingService, IRepository<UserAddress> userAddressRepository)
        {
            _shippingService = shippingService;
            _userAddressRepository = userAddressRepository;
        }

        [HttpPost]
        public async Task<IActionResult> GetShippingPrices([FromBody] ShippingPriceRequestVm model)
        {
            Address address;
            if (model.ExistingShippingAddressId != 0)
            {
                address = await _userAddressRepository.Query().Where(x => x.Id == model.ExistingShippingAddressId).Select(x => x.Address).FirstOrDefaultAsync();
                if (address == null)
                {
                    return NotFound();
                }
            }
            else
            {
                address = new Address
                {
                    CountryId = model.NewShippingAddress.CountryId,
                    StateOrProvinceId = model.NewShippingAddress.StateOrProvinceId,
                    AddressLine1 = model.NewShippingAddress.AddressLine1
                };
            }

            var request = new GetShippingPriceRequest
            {
                OrderAmount = model.OrderAmount,
                ShippingAddress = address
            };
            var applicableShippingPrices = await _shippingService.GetApplicableShippingPrices(request);
            return Ok(applicableShippingPrices);
        }
    }
}

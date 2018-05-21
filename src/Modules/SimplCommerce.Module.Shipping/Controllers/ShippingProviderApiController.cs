using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Shipping.Models;

namespace SimplCommerce.Module.Shipping.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/shipping-providers")]
    public class ShippingProviderApiController : Controller
    {
        private readonly IRepositoryWithTypedId<ShippingProvider, string> _shippingProviderRepositor;

        public ShippingProviderApiController(IRepositoryWithTypedId<ShippingProvider, string> shippingProviderRepositor)
        {
            _shippingProviderRepositor = shippingProviderRepositor;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var providers = await _shippingProviderRepositor.Query()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.IsEnabled,
                    x.ConfigureUrl
                }).ToListAsync();

            return Json(providers);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Shipping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Shipping.Controllers
{
    [Route("api/shippingmethod")]
    public class ShippingMethodController :Controller
    {
        private readonly IRepository<ShippingMethod> _shippingRepository;


        public ShippingMethodController(
             IRepository<ShippingMethod> shippingRepository
            )
        {
            _shippingRepository = shippingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var query = _shippingRepository.Query().ToList();
            return Json(query);
        }

    }
}

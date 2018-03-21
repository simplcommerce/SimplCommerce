using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.PaymentCoD.Models;
using SimplCommerce.Module.Payments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentCoD.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/cod")]
    public class CoDApiController : Controller
    {
        private readonly IRepository<PaymentProvider> _paymentProviderRepository;

        public CoDApiController(IRepository<PaymentProvider> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }

        protected CoDApiController()
        {
        }

        [HttpGet("config")]
        public async Task<IActionResult> Config()
        {
            var codProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.CODProviderId);
            var model = JsonConvert.DeserializeObject<CODfee>(codProvider.AdditionalSettings);
            return Ok(model);
        }

        [HttpPut("config")]
        public async Task<IActionResult> Config([FromBody] CODfee model)
        {
            if (ModelState.IsValid)
            {
                var codProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.CODProviderId);
                codProvider.AdditionalSettings = JsonConvert.SerializeObject(model);
                await _paymentProviderRepository.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(ModelState);
        }
    }
}

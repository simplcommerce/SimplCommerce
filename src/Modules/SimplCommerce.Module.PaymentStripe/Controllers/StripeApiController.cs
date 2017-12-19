using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.PaymentStripe.Models;
using SimplCommerce.Module.PaymentStripe.ViewModels;

namespace SimplCommerce.Module.PaymentStripe.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/stripe")]
    public class StripeApiController : Controller
    {
        private readonly IRepository<PaymentProvider> _paymentProviderRepository;

        public StripeApiController(IRepository<PaymentProvider> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }

        [HttpGet("config")]
        public async Task<IActionResult> Config()
        {
            var stripeProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.StripeProviderId);
            var model = JsonConvert.DeserializeObject<StripeConfigForm>(stripeProvider.AdditionalSettings);
            return Ok(model);
        }

        [HttpPut("config")]
        public async Task<IActionResult> Config([FromBody] StripeConfigForm model)
        {
            if (ModelState.IsValid)
            {
                var stripeProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.StripeProviderId);
                stripeProvider.AdditionalSettings = JsonConvert.SerializeObject(model);
                await _paymentProviderRepository.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(ModelState);
        }
    }
}

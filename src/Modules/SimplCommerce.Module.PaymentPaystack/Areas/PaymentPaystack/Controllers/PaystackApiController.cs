using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.PaymentPaystack.Models;
using SimplCommerce.Module.PaymentPaystack.ViewModels;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentPaystack.Areas.PaymentPaystack.Controllers
{
    [Area("PaymentPaystack")]
    [Authorize(Roles = "admin")]
    [Route("api/paystack")]
    public class PaystackApiController : Controller
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public PaystackApiController(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }

        [HttpGet("config")]
        public async Task<IActionResult> Config()
        {
            var paystackProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.PaystackProviderId);
            var model = JsonConvert.DeserializeObject<PaystackConfigForm>(paystackProvider.AdditionalSettings);
            return Ok(model);
        }

        [HttpPut("config")]
        public async Task<IActionResult> Config([FromBody] PaystackConfigForm model)
        {
            if (ModelState.IsValid)
            {
                var paystackProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.PaystackProviderId);
                paystackProvider.AdditionalSettings = JsonConvert.SerializeObject(model);
                await _paymentProviderRepository.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(ModelState);
        }
    }
}

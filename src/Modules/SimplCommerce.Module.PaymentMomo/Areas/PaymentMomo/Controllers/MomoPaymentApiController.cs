using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.PaymentMomo.ViewModels;
using SimplCommerce.Module.PaymentMomo.Models;

namespace SimplCommerce.Module.PaymentMomo.Areas.PaymentMomo.Controllers
{
    [Area("PaymentMomo")]
    [Authorize(Roles = "admin")]
    [Route("api/momo")]
    public class MomoPaymentApiController : Controller
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public MomoPaymentApiController(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }

        [HttpGet("config")]
        public async Task<IActionResult> Config()
        {
            var momoProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.MomoPaymentProviderId);
            var model = JsonConvert.DeserializeObject<MomoPaymentConfigForm>(momoProvider.AdditionalSettings);
            return Ok(model);
        }

        [HttpPut("config")]
        public async Task<IActionResult> Config([FromBody] MomoPaymentConfigForm model)
        {
            if (ModelState.IsValid)
            {
                var momoProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.MomoPaymentProviderId);
                momoProvider.AdditionalSettings = JsonConvert.SerializeObject(model);
                await _paymentProviderRepository.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(ModelState);
        }
    }
}

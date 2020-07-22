using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Orders.Models;
using SimplCommerce.Module.Payments.Models;
using SimplCommerce.Module.PaymentStripeV2.Areas.PaymentStripeV2.ViewModels;
using SimplCommerce.Module.PaymentStripeV2.Models;
using SimplCommerce.Module.PaymentStripeV2.Services;

namespace SimplCommerce.Module.PaymentStripeV2.Areas.PaymentStripeV2.Controllers
{
    [Area("PaymentStripeV2")]
    [Authorize(Roles = "admin")]
    [Route("api/stripev2")]
    public class StripeV2ApiController : Controller
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly IPaymentStripeV2Service _paymentStripeService;

        public StripeV2ApiController(
            IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository,
            IPaymentStripeV2Service paymentStripeService)
        {
            _paymentProviderRepository = paymentProviderRepository;
            _paymentStripeService = paymentStripeService;
        }

        [HttpGet("config")]
        public async Task<IActionResult> Config()
        {
            var stripeProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.StripeProviderId);
            var model = JsonConvert.DeserializeObject<StripeV2ConfigForm>(stripeProvider.AdditionalSettings);
            return Ok(model);
        }

        [HttpPut("config")]
        public async Task<IActionResult> Config([FromBody] StripeV2ConfigForm model)
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

        private IActionResult HandleOrderCreationResult(object orderCreationResult)
        {
            if (orderCreationResult == null)
            {
                return Redirect("~/admin");
            }
            else if (orderCreationResult is Result<Order>)
            {
                var result = orderCreationResult as Result<Order>;
                TempData["Error"] = result?.Error;
                return Redirect("~/checkout/payment");
            }
            else if (orderCreationResult is Order)
            {
                var order = orderCreationResult as Order;
                return Redirect($"~/checkout/success?orderId={order.Id}");
            }

            TempData["Error"] = orderCreationResult;
            return Redirect($"~/checkout/error");
        }
    }
}

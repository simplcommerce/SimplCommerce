using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.PaymentStripe.ViewModels;

namespace SimplCommerce.Module.PaymentStripe.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/stripe")]
    public class StripeApiController : Controller
    {
        private readonly IRepository<AppSetting> _appSettingRepository;
        private readonly IConfigurationRoot _configurationRoot;

        public StripeApiController(IRepository<AppSetting> appSettingRepository, IConfiguration configuration)
        {
            _appSettingRepository = appSettingRepository;
            _configurationRoot = (IConfigurationRoot)configuration;
        }

        [HttpGet("config")]
        public async Task<IActionResult> Config()
        {
            var settings = await _appSettingRepository.Query().Where(x => x.Module == "PaymentStripe").ToListAsync();
            var model = new StripeConfigForm();
            var privateKey = settings.First(x => x.Key == "Stripe:SecretKey");
            model.PrivateKey = privateKey.Value;

            var publicKey = settings.First(x => x.Key == "Stripe:PublishableKey");
            model.PublicKey = publicKey.Value;

            return Ok(model);
        }

        [HttpPut("config")]
        public async Task<IActionResult> Config([FromBody] StripeConfigForm model)
        {
            if (ModelState.IsValid)
            {
                var settings = await _appSettingRepository.Query().Where(x => x.Module == "PaymentStripe").ToListAsync();
                var privateKey = settings.First(x => x.Key == "Stripe:SecretKey");
                privateKey.Value = model.PrivateKey;

                var publicKey = settings.First(x => x.Key == "Stripe:PublishableKey");
                publicKey.Value = model.PublicKey;

                await _appSettingRepository.SaveChangesAsync();
                _configurationRoot.Reload();

                return Accepted();
            }

            return BadRequest(ModelState);
        }
    }
}

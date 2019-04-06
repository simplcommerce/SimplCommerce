using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBitcoin;
using NBitpayClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.PaymentBtcPayServer.Models;
using SimplCommerce.Module.PaymentBtcPayServer.Services;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentBtcPayServer.Areas.PaymentBtcPayServer.Controllers
{
    [Area("PaymentBtcPayServer")]
    [Authorize(Roles = "admin")]
    [Route("api/btcpayserver")]
    public class BtcPayServerApiController : Controller
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;
        private readonly IBtcPayServerClientService _btcPayServerClientService;

        public BtcPayServerApiController(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository, IBtcPayServerClientService btcPayServerClientService)
        {
            _paymentProviderRepository = paymentProviderRepository;
            _btcPayServerClientService = btcPayServerClientService;
        }

        [HttpGet("config")]
        public async Task<IActionResult> Config()
        {
            var stripeProvider = await _paymentProviderRepository.Query()
                .FirstOrDefaultAsync(x => x.Id == PaymentProviderConstants.BtcPayServerProviderId);
            var model = JsonConvert.DeserializeObject<BtcPayServerConfig>(stripeProvider.AdditionalSettings);
            return Ok(new BtcPayServerConfigViewModel()
            {
                Seed = model.Seed ?? new Mnemonic(Wordlist.English).ToString(),
                Server = model.Server,
                Paired = await _btcPayServerClientService.CheckAccess(),
                PairingUrl = await _btcPayServerClientService.GetPairingUrl("SimplCommerce")
                
                
            });
        }

        [HttpPut("config")]
        public async Task<IActionResult> Config([FromBody] BtcPayServerConfigViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(model.PairingCode))
                {
                    var bitpayClient = new Bitpay(new Mnemonic(model.Seed).DeriveExtKey().PrivateKey, model.Server);
                    await bitpayClient.AuthorizeClient(new PairingCode(model.PairingCode));
                }              
                var paymentProvider = await _paymentProviderRepository.Query()
                    .FirstOrDefaultAsync(x => x.Id == PaymentProviderConstants.BtcPayServerProviderId);
                paymentProvider.AdditionalSettings = JObject.FromObject(model).ToString();
                await _paymentProviderRepository.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(ModelState);
        }
    }

    public class BtcPayServerConfigViewModel : BtcPayServerConfig
    {
        public string PairingUrl { get; set; }
        public string PairingCode { get; set; }
        public bool Paired { get; set; }
    }
}

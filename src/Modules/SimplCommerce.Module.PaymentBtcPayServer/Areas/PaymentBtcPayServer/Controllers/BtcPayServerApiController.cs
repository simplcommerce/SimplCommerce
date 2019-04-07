using System;
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
        public async Task<IActionResult> GetConfig()
        {
            var paymentProvider = await _paymentProviderRepository.Query()
                .FirstOrDefaultAsync(x => x.Id == PaymentProviderConstants.BtcPayServerProviderId);
            var model = JsonConvert.DeserializeObject<BtcPayServerConfig>(paymentProvider.AdditionalSettings);
            var client = await BtcPayServerClientService.ConstructClient(model);
            return Ok(new BtcPayServerConfigViewModel()
            {
                Seed = model.Seed ?? new Mnemonic(Wordlist.English).ToString(),
                Server = model.Server,
                Paired = await BtcPayServerClientService.CheckAccess(client),
                PairingUrl = await BtcPayServerClientService.GetPairingUrl(model, "SimplCommerce"),
                UseModal = model.UseModal,
                PaymentButtonLabel = model.PaymentButtonLabel
            });
        }
        
        
        [HttpGet("unpair")]
        public async Task<IActionResult> Unpair()
        {
            var paymentProvider = await _paymentProviderRepository.Query()
                .FirstOrDefaultAsync(x => x.Id == PaymentProviderConstants.BtcPayServerProviderId);
            var model = JsonConvert.DeserializeObject<BtcPayServerConfig>(paymentProvider.AdditionalSettings);

            model.Seed = new Mnemonic(Wordlist.English).ToString();

            await UpdatePaymentProviderConfig(model);
            
            return await GetConfig();
        }

        [HttpPut("config")]
        public async Task<IActionResult> SaveConfig([FromBody] BtcPayServerConfigViewModel model)
        {
            if (ModelState.IsValid )
            {
                if (!string.IsNullOrEmpty(model.PairingCode))
                {
                    try
                    {
                        var client = await BtcPayServerClientService.ConstructClient(model);
                        await client.AuthorizeClient(new PairingCode(model.PairingCode));
                        
                        return await GetConfig();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                     
                        ModelState.AddModelError(string.Empty, e.Message);
                    }
                }
                else
                {
                    await UpdatePaymentProviderConfig(model);
            
                    return await GetConfig();
                }

            }

            return BadRequest(ModelState);
        }

        private async Task UpdatePaymentProviderConfig(BtcPayServerConfig model)
        {
                      
            var paymentProvider = await _paymentProviderRepository.Query()
                .FirstOrDefaultAsync(x => x.Id == PaymentProviderConstants.BtcPayServerProviderId);
            paymentProvider.AdditionalSettings = JObject.FromObject(model).ToString();
            await _paymentProviderRepository.SaveChangesAsync();
        }
    }

    public class BtcPayServerConfigViewModel : BtcPayServerConfig
    {
        public string PairingUrl { get; set; }
        public string PairingCode { get; set; }
        public bool Paired { get; set; }
    }
}

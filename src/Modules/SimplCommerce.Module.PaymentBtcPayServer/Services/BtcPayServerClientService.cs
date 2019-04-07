using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NBitcoin;
using NBitpayClient;
using Newtonsoft.Json.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.PaymentBtcPayServer.Models;
using SimplCommerce.Module.Payments.Models;

namespace SimplCommerce.Module.PaymentBtcPayServer.Services
{
    public class BtcPayServerClientService : IBtcPayServerClientService
    {
        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public BtcPayServerClientService(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }


        public async Task<Bitpay> ConstructClient()
        {
            
            var paymentProvider = await _paymentProviderRepository.Query()
                .FirstOrDefaultAsync(x => x.Id == PaymentProviderConstants.BtcPayServerProviderId);
            if (paymentProvider == null)
            {
                return null;
            }

            var config = JObject.Parse(paymentProvider.AdditionalSettings).ToObject<BtcPayServerConfig>();
            return await ConstructClient(config);
        }

        public static async Task<Bitpay> ConstructClient(BtcPayServerConfig config)
        {
            try
            {
                var seed = new Mnemonic(config.Seed);

                return new Bitpay(seed.DeriveExtKey().PrivateKey, config.Server);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> CheckAccess()
        {
            var client = await ConstructClient();
            return await CheckAccess(client);
        }

        
        public static async Task<bool> CheckAccess(Bitpay client)
        {
            return client != null && await client.TestAccessAsync(Facade.Merchant);
        }
        
        public static async Task<string> GetPairingUrl(BtcPayServerConfig config, string label)
        {
            Bitpay client = null;
            try
            {
                client = await ConstructClient(config);

                if (client == null || await CheckAccess(client))
                {
                    return null;
                }

                return (await client.RequestClientAuthorizationAsync(label, Facade.Merchant))
                    .CreateLink(client.BaseUrl)
                    .ToString();
            }
            catch (Exception)
            {
                return client != null ? new Uri(client.BaseUrl, "api-tokens").ToString() : null;
            }
        }
    }
}

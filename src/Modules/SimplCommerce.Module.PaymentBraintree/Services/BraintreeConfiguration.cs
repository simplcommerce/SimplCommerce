using Braintree;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.PaymentBraintree.Areas.PaymentBraintree.ViewModels;
using SimplCommerce.Module.PaymentBraintree.Models;
using SimplCommerce.Module.Payments.Models;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentBraintree.Services
{
    public class BraintreeConfiguration : IBraintreeConfiguration
    {
        public string Environment { get; private set; }
        public string MerchantId { get; private set; }
        public string PublicKey { get; private set; }
        public string PrivateKey { get; private set; }

        public async Task<IBraintreeGateway> BraintreeGateway()
        {
            if (_braintreeGateway == null)
            {
                _braintreeGateway = await CreateGateway();
            }

            return _braintreeGateway;
        }

        private IBraintreeGateway _braintreeGateway { get; set; }

        private readonly IRepositoryWithTypedId<PaymentProvider, string> _paymentProviderRepository;

        public BraintreeConfiguration(IRepositoryWithTypedId<PaymentProvider, string> paymentProviderRepository)
        {
            _paymentProviderRepository = paymentProviderRepository;
        }
    

        private async Task<IBraintreeGateway> CreateGateway()
        {
            var stripeProvider = await _paymentProviderRepository.Query().FirstOrDefaultAsync(x => x.Id == PaymentProviderHelper.BraintreeProviderId);
            var stripeSetting = JsonConvert.DeserializeObject<BraintreeConfigForm>(stripeProvider.AdditionalSettings);

            Environment = stripeSetting.Environment;
            MerchantId = stripeSetting.MerchantId;
            PublicKey = stripeSetting.PublicKey;
            PrivateKey = stripeSetting.PrivateKey;

            return new BraintreeGateway(Environment, MerchantId, PublicKey, PrivateKey);
        }

        public async Task<string> GetClientToken()
        {
            var gateway = await BraintreeGateway();
            return await gateway.ClientToken.GenerateAsync();
        }
    }
}

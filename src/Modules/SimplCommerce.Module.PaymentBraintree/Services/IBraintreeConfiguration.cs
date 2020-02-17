using Braintree;
using System.Threading.Tasks;

namespace SimplCommerce.Module.PaymentBraintree.Services
{
    public interface IBraintreeConfiguration
    {
        string Environment { get; }

        string MerchantId { get; }

        string PublicKey { get; }

        string PrivateKey { get; }

        Task<IBraintreeGateway> BraintreeGateway();

        Task<string> GetClientToken();
    }
}

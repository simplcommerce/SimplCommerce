using System.Threading.Tasks;
using NBitpayClient;

namespace SimplCommerce.Module.PaymentBtcPayServer.Services
{
    public interface IBtcPayServerClientService
    {
   
        Task<Bitpay> ConstructClient();
        Task<bool> CheckAccess();
        Task<string> GetPairingUrl(string label);
    }
}

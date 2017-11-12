using SimplCommerce.Module.Shipping.Models;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Shipping.Services
{
    public interface IShippingRateService
    {
         Task<GetShippingRateResponse> GetShippingRates(GetShippingRateRequest request, ShippingProvider provider);
    }
}

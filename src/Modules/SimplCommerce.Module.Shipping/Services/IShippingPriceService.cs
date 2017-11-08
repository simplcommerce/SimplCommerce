using SimplCommerce.Module.Shipping.Models;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Shipping.Services
{
    public interface IShippingPriceService
    {
        Task<GetShippingPriceResponse> GetShippingPrices(GetShippingPriceRequest request, ShippingProvider provider);
    }
}

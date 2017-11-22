using System.Threading.Tasks;
using SimplCommerce.Module.Shipping.Models;

namespace SimplCommerce.Module.ShippingPrices.Services
{
    public interface IShippingPriceServiceProvider
    {
        Task<GetShippingPriceResponse> GetShippingPrices(GetShippingPriceRequest request, ShippingProvider provider);
    }
}

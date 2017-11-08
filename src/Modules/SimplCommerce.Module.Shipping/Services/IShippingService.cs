using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Shipping.Services
{
    public interface IShippingService
    {
        Task<IList<ShippingPrice>> GetApplicableShippingPrices(GetShippingPriceRequest request);
    }
}

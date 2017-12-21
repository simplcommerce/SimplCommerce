using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimplCommerce.Module.ShippingPrices.Services
{
    public interface IShippingPriceService
    {
        Task<IList<ShippingPrice>> GetApplicableShippingPrices(GetShippingPriceRequest request);
    }
}

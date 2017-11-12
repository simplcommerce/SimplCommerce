using System.Threading.Tasks;
using Newtonsoft.Json;
using SimplCommerce.Module.Shipping.Services;
using SimplCommerce.Module.ShippingFree.Models;
using SimplCommerce.Module.Shipping.Models;

namespace SimplCommerce.Module.ShippingFree.Services
{
    public class FreeShippingService : IShippingRateService
    {
        public Task<GetShippingRateResponse> GetShippingRates(GetShippingRateRequest request, ShippingProvider provider)
        {
            var response = new GetShippingRateResponse { IsSuccess = true };

            var freeShippingSetting = JsonConvert.DeserializeObject<FreeShippingSetting>(provider.AdditionalSettings);

            if (request.OrderAmount < freeShippingSetting.MinimumOrderAmount)
            {
                return Task.FromResult(response);
            }

            response.ApplicableRates.Add(new ShippingRate
            {
                Name = "Free",
                Rate = 0
            });

            return Task.FromResult(response);
        }
    }
}

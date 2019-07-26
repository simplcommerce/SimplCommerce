using System.Threading.Tasks;
using Newtonsoft.Json;
using SimplCommerce.Module.ShippingPrices.Services;
using SimplCommerce.Module.ShippingFree.Models;
using SimplCommerce.Module.Shipping.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.ShippingFree.Services
{
    public class FreeShippingServiceProvider : IShippingPriceServiceProvider
    {
        private readonly ICurrencyService _currencyService;

        public FreeShippingServiceProvider(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public Task<GetShippingPriceResponse> GetShippingPrices(GetShippingPriceRequest request, ShippingProvider provider)
        {
            var response = new GetShippingPriceResponse { IsSuccess = true };

            var freeShippingSetting = JsonConvert.DeserializeObject<FreeShippingSetting>(provider.AdditionalSettings);

            if (request.OrderAmount < freeShippingSetting.MinimumOrderAmount)
            {
                return Task.FromResult(response);
            }

            response.ApplicablePrices.Add(new ShippingPrice(_currencyService)
            {
                Name = "Free",
                Price = 0
            });

            return Task.FromResult(response);
        }
    }
}

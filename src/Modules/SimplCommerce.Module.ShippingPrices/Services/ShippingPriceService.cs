using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Shipping.Models;

namespace SimplCommerce.Module.ShippingPrices.Services
{
    public class ShippingPriceService : IShippingPriceService
    {
        private HttpContext _httpContext;
        private readonly IRepositoryWithTypedId<ShippingProvider, string> _shippingProviderRepository;

        public ShippingPriceService(IHttpContextAccessor contextAccessor, IRepositoryWithTypedId<ShippingProvider, string> shippingProviderRepository)
        {
            _httpContext = contextAccessor.HttpContext;
            _shippingProviderRepository = shippingProviderRepository;
        }

        public async Task<IList<ShippingPrice>> GetApplicableShippingPrices(GetShippingPriceRequest request)
        {
            var applicableShippingPrices = new List<ShippingPrice>();
            var providers = await _shippingProviderRepository.Query().ToListAsync();
            var shippingRateServices = _httpContext.RequestServices.GetServices<IShippingPriceServiceProvider>();

            foreach(var provider in providers)
            {
                if(!provider.IsEnabled)
                {
                    continue;
                }

                if (!provider.ToAllShippingEnabledCountries)
                {
                    if (!provider.OnlyCountryIds.Contains(request.ShippingAddress.CountryId))
                    {
                        continue;
                    }
                }

                if (!provider.ToAllShippingEnabledStatesOrProvinces)
                {
                    if (!provider.OnlyStateOrProvinceIds.Contains(request.ShippingAddress.StateOrProvinceId))
                    {
                        continue;
                    }
                }

                var priceServiceType = Type.GetType(provider.ShippingPriceServiceTypeName);
                var priceService = shippingRateServices.Where(x => x.GetType() == priceServiceType).FirstOrDefault();
                var response = await priceService.GetShippingPrices(request, provider);
                applicableShippingPrices.AddRange(response.ApplicablePrices);
            }

            return applicableShippingPrices;
        }
    }
}

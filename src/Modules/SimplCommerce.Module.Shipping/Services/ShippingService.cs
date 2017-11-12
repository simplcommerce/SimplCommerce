using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Shipping.Models;

namespace SimplCommerce.Module.Shipping.Services
{
    public class ShippingService : IShippingService
    {
        private readonly IRepository<ShippingProvider> _shippingProviderRepository;

        public ShippingService(IRepository<ShippingProvider> shippingProviderRepository)
        {
            _shippingProviderRepository = shippingProviderRepository;
        }

        public async Task<IList<ShippingRate>> GetApplicableShippingRates(GetShippingRateRequest request)
        {
            var applicableShippingRates = new List<ShippingRate>();
            var providers = await _shippingProviderRepository.Query().ToListAsync();

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

                var rateServiceType = Type.GetType(provider.RateServiceTypeName);
                var rateService = (IShippingRateService)Activator.CreateInstance(rateServiceType);
                var response = await rateService.GetShippingRates(request, provider);
                applicableShippingRates.AddRange(response.ApplicableRates);
            }

            return applicableShippingRates;
        }
    }
}

using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Module.Shipping.Models;
using SimplCommerce.Module.ShippingPrices.Services;
using SimplCommerce.Module.ShippingTableRate.Models;
using SimplCommerce.Infrastructure.Data;

namespace SimplCommerce.Module.ShippingTableRate.Services
{
    public class TableRateShippingServiceProvider : IShippingPriceServiceProvider
    {
        public readonly IRepository<PriceAndDestination> _priceAndDestinationRepository;

        public TableRateShippingServiceProvider(IRepository<PriceAndDestination> priceAndDestinationRepository)
        {
            _priceAndDestinationRepository = priceAndDestinationRepository;
        }

        public async Task<GetShippingPriceResponse> GetShippingPrices(GetShippingPriceRequest request, ShippingProvider provider)
        {
            var response = new GetShippingPriceResponse { IsSuccess = true };
            var priceAndDestinations = await _priceAndDestinationRepository.Query().ToListAsync();

            var query = priceAndDestinations.Where(x => (x.CountryId == null || x.CountryId == request.ShippingAddress.CountryId)
                && (x.StateOrProvinceId == null || x.StateOrProvinceId == request.ShippingAddress.StateOrProvinceId)
                && request.OrderAmount >= x.MinOrderSubtotal);

            if (request.ShippingAddress.DistrictId.HasValue)
            {
                query = query.Where(x => x.DistrictId == null || x.DistrictId == request.ShippingAddress.DistrictId.Value);
            }

            if(!string.IsNullOrWhiteSpace(request.ShippingAddress.ZipCode))
            {
                query = query.Where(x => x.ZipCode == null || x.ZipCode == request.ShippingAddress.ZipCode);
            }

            var cheapestApplicable = query.OrderBy(x => x.ShippingPrice).FirstOrDefault();

            if(cheapestApplicable != null)
            {
                response.ApplicablePrices.Add(new ShippingPrice
                {
                    Name = "Standard",
                    Price = cheapestApplicable.ShippingPrice
                });
            }

            return response;
        }
    }
}

using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SimplCommerce.Module.Shipping.Models;
using SimplCommerce.Module.Shipping.Services;
using SimplCommerce.Module.ShippingTableRate.Models;
using SimplCommerce.Infrastructure.Data;

namespace SimplCommerce.Module.ShippingTableRate.Services
{
    public class TableRateShippingService : IShippingRateService
    {
        public readonly IRepository<PriceAndDestination> _priceAndDestinationRepository;

        public TableRateShippingService(IRepository<PriceAndDestination> priceAndDestinationRepository)
        {
            _priceAndDestinationRepository = priceAndDestinationRepository;
        }

        public async Task<GetShippingRateResponse> GetShippingRates(GetShippingRateRequest request, ShippingProvider provider)
        {
            var response = new GetShippingRateResponse { IsSuccess = true };
            var priceAndDestinations = await _priceAndDestinationRepository.Query().ToListAsync();

            var cheapestApplicable = priceAndDestinations.Where(x => (x.Country == "*" || x.Country == request.ShippingAddress.CountryId.ToString())
                && (x.StateOrProvince == "*" || x.StateOrProvince == request.ShippingAddress.StateOrProvinceId.ToString())
                && request.OrderAmount >= x.MinOrderSubtotal).OrderBy(x => x.ShippingPrice).FirstOrDefault();

            if(cheapestApplicable != null)
            {
                response.ApplicableRates.Add(new ShippingRate
                {
                    Name = "Best Way",
                    Rate = cheapestApplicable.ShippingPrice
                });
            }

            return response;
        }
    }
}

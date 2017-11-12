using System.Collections.Generic;

namespace SimplCommerce.Module.Shipping.Services
{
    public class GetShippingRateResponse
    {
        public IList<ShippingRate> ApplicableRates = new List<ShippingRate>();

        public string CarrierName { get; set; }

        public bool IsSuccess { get; set; }

        public string Error { get; set; }
    }
}

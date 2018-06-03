namespace SimplCommerce.Module.ShippingTableRate.ViewModels
{
    public class PriceAndDestinationForm
    {
        public long Id { get; set; }

        public string CountryId { get; set; }

        public string CountryName { get; set; }

        public long? StateOrProvinceId { get; set; }

        public string StateOrProvinceName { get; set; }

        public long? DistrictId { get; set; }

        public string DistrictName { get; set; }

        public string ZipCode { get; set; }

        public string Note { get; set; }

        public decimal MinOrderSubtotal { get; set; }

        public decimal ShippingPrice { get; set; }
    }
}

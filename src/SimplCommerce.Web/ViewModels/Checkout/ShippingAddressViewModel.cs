namespace SimplCommerce.Web.ViewModels.Checkout
{
    public class ShippingAddressViewModel
    {
        public long UserAddressId { get; set; }

        public string ContactName { get; set; }

        public string Phone { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string DistrictName { get; set; }

        public string StateOrProvinceName { get; set; }

        public string CountryName { get; set; }
    }
}
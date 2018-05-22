namespace SimplCommerce.Module.Orders.ViewModels
{
    public class ShippingAddressVm
    {
        public long UserAddressId { get; set; }

        public string ContactName { get; set; }

        public string Phone { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string DistrictName { get; set; }

        public long StateOrProvinceId { get; set; }

        public string StateOrProvinceName { get; set; }

        public string CountryId { get; set; }

        public string CountryName { get; set; }

        public bool DisplayDistrict { get; set; }

        public bool DisplayZipCode { get; set; }

        public bool DisplayCity { get; set; }
    }
}

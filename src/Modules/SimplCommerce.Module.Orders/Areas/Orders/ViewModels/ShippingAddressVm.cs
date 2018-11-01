namespace SimplCommerce.Module.Orders.Areas.Orders.ViewModels
{
    public class ShippingAddressVm
    {
        public long UserAddressId { get; set; }

        public string ContactName { get; set; }

        public string Phone { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public long? DistrictId { get; set; }

        public string DistrictName { get; set; }

        public string ZipCode { get; set; }

        public long StateOrProvinceId { get; set; }

        public string StateOrProvinceName { get; set; }

        public string CountryId { get; set; }

        public string CountryName { get; set; }

        public bool IsDistrictEnabled { get; set; }

        public bool IsZipCodeEnabled { get; set; }

        public bool IsCityEnabled { get; set; }
    }
}

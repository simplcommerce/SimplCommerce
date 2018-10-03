namespace SimplCommerce.Module.Core.ViewModels
{
    public class UserAddressListItem
    {
        public long AddressId { get; set; }

        public long UserAddressId { get; set; }

        public string ContactName { get; set; }

        public string Phone { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string DistrictName { get; set; }

        public string StateOrProvinceName { get; set; }

        public string CountryName { get; set; }

        public bool IsDefaultShippingAddress { get; set; }

        public bool DisplayDistrict { get; set; }

        public bool DisplayZipCode { get; set; }

        public bool DisplayCity { get; set; }
    }
}

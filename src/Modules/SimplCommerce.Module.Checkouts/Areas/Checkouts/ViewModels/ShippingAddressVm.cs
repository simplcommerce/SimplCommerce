using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Checkouts.Areas.Checkouts.ViewModels
{
    public class ShippingAddressVm
    {
        public long UserAddressId { get; set; }

        public string ContactName { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Please enter a valid phone number")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Phone number must be between 10 and 20 characters")]
        public string Phone { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2
        {
            get
            {
                var parts = new[] { DistrictName, CityName, StateOrProvinceName, ZipCode, CountryName };
                return string.Join(", ", parts.Where(x => !string.IsNullOrEmpty(x)));
            }
        }

        public long? DistrictId { get; set; }

        public string DistrictName { get; set; }

        public string ZipCode { get; set; }

        public long StateOrProvinceId { get; set; }

        public string StateOrProvinceName { get; set; }

        public string CityName { get; set; }

        public string CountryId { get; set; }

        public string CountryName { get; set; }

        public bool IsDistrictEnabled { get; set; }

        public bool IsZipCodeEnabled { get; set; }

        public bool IsCityEnabled { get; set; }
    }
}

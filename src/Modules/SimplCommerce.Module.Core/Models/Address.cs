using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SimplCommerce.Infrastructure.Models;

namespace SimplCommerce.Module.Core.Models
{
    public class Address : EntityBase
    {
        public Address() { }

        public Address(long id)
        {
            Id = id;
        }

        public string ContactName { get; set; }

        public string Phone { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public long? DistrictId { get; set; }

        public District District { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public long StateOrProvinceId { get; set; }

        public StateOrProvince StateOrProvince { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string CountryId { get; set; }

        public Country Country { get; set; }

        public IList<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
    }
}

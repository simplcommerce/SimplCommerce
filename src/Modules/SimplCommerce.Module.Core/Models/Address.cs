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

        [StringLength(450)]
        public string ContactName { get; set; }

        [StringLength(450)]
        public string Phone { get; set; }

        [StringLength(450)]
        public string AddressLine1 { get; set; }

        [StringLength(450)]
        public string AddressLine2 { get; set; }

        [StringLength(450)]
        public string City { get; set; }

        [StringLength(450)]
        public string ZipCode { get; set; }

        public long? DistrictId { get; set; }

        public District District { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public long StateOrProvinceId { get; set; }

        public StateOrProvince StateOrProvince { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        [StringLength(450)]
        public string CountryId { get; set; }

        public Country Country { get; set; }

        public IList<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
    }
}

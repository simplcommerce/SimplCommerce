using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Inventory.ViewModels
{
    public class WarehouseVm
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public long AddressId { get; set; }

        public string ContactName { get; set; } 

        public string Phone { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public long? DistrictId { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "State or Province is required")]
        public long StateOrProvinceId { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Country is required")]
        public long CountryId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SimplCommerce.Module.Inventory.Areas.Inventory.ViewModels
{
    public class WarehouseVm
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string Name { get; set; }

        public long AddressId { get; set; }

        public string ContactName { get; set; } 

        public string Phone { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public long? DistrictId { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "State or Province is required")]
        public long StateOrProvinceId { get; set; }

        [Required(ErrorMessage = "The {0} field is required.")]
        public string CountryId { get; set; }
    }
}

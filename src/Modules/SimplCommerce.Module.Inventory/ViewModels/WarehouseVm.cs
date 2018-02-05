using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Required]
        public long StateOrProvinceId { get; set; }

        [Required]
        public long CountryId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Inventory.ViewModels
{
    public class WarehouseVm
    {
        public string Name { get; set; }

        public string ContactName { get; set; }

        public string Phone { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public long? DistrictId { get; set; }

        public long StateOrProvinceId { get; set; }

        public long CountryId { get; set; }

    }
}

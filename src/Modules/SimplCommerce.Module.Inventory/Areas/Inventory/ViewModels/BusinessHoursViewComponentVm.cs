using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.Inventory.Areas.Inventory.ViewModels
{
    public class BusinessHoursViewComponentVm
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public List<BusinessHourItemViewComponentVm> BusinessHourItems { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace SimplCommerce.Module.Inventory.Areas.Inventory.ViewModels
{
    public class BusinessHourItemViewComponentVm
    {
        public DayOfWeek Day { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

    }
}

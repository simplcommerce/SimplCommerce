using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplCommerce.Module.Catalog.ViewModels
{
    public class CategoryWidgetComponentVm
    {
        public long Id { get; set; }

        public string WidgetName { get; set; }

        public CategoryThumbnail Category { get; set; }
    }
}

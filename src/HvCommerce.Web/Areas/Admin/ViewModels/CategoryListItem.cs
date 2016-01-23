using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HvCommerce.Web.Areas.Admin.ViewModels
{
    public class CategoryListItem
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsPublished { get; set; }
    }
}

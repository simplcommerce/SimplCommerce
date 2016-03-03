using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HvCommerce.Web.ViewModels.Catalog
{
    public class BreadCrumbModel
    {
         public BreadCrumbCategory BreadCrumbCategory { get; set; }
         public BreadCrumbDetail BreadCrumbDetail { get; set; }
    }

    public class BreadCrumbCategory
    {
        public string CategoryName { get; set; }
        public string CategorySeoTitle { get; set; }
    }
    public class BreadCrumbDetail
    {
        public string Name { get; set; }
        public string SeoTitle { get; set; }
    }
}

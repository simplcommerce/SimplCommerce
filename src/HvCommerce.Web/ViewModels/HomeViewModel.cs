using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HvCommerce.Web.ViewModels.Catalog;

namespace HvCommerce.Web.ViewModels
{
    public class HomeViewModel
    {
        public IList<ProductListItem> FeaturedProducts { get; set; } = new List<ProductListItem>(); 
    }
}

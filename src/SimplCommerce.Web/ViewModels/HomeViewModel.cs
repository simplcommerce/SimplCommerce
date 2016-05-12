using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimplCommerce.Web.ViewModels.Catalog;

namespace SimplCommerce.Web.ViewModels
{
    public class HomeViewModel
    {
        public IList<ProductListItem> FeaturedProducts { get; set; } = new List<ProductListItem>(); 
    }
}

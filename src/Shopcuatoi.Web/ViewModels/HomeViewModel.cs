using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopcuatoi.Web.ViewModels.Catalog;

namespace Shopcuatoi.Web.ViewModels
{
    public class HomeViewModel
    {
        public IList<ProductListItem> FeaturedProducts { get; set; } = new List<ProductListItem>(); 
    }
}

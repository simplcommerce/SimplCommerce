using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopcuatoi.Web.ViewModels.Catalog
{
    public class ProductsByCategory
    {
        public string CategoryName { get; set; }

        public IList<ProductListItem> Products { get; set; } = new List<ProductListItem>();
    }
}

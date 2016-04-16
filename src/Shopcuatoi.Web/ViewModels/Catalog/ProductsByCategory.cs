using System.Collections.Generic;

namespace Shopcuatoi.Web.ViewModels.Catalog
{
    public class ProductsByCategory
    {
        public long CategoryId { get; set; }

        public long? ParentCategorId { get; set; }

        public string CategoryName { get; set; }

        public IList<ProductListItem> Products { get; set; } = new List<ProductListItem>();
    }
}

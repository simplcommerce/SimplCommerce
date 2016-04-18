using System.Collections.Generic;

namespace Shopcuatoi.Web.ViewModels.Catalog
{
    public class ProductsByCategory
    {
        public long CategoryId { get; set; }

        public long? ParentCategorId { get; set; }

        public string CategoryName { get; set; }

        public string CategorySeoTitle { get; set; }

        public IList<ProductListItem> Products { get; set; } = new List<ProductListItem>();

        public FilterOption FilterOption { get; set; }

        public SearchOption CurrentSearchOption { get; set; }
    }
}

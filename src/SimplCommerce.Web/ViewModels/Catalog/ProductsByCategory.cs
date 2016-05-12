using System.Collections.Generic;
using Microsoft.AspNet.Mvc.Rendering;

namespace SimplCommerce.Web.ViewModels.Catalog
{
    public class ProductsByCategory
    {
        public long CategoryId { get; set; }

        public long? ParentCategorId { get; set; }

        public string CategoryName { get; set; }

        public string CategorySeoTitle { get; set; }

        public int TotalProduct { get; set; }

        public IList<ProductListItem> Products { get; set; } = new List<ProductListItem>();

        public FilterOption FilterOption { get; set; }

        public SearchOption CurrentSearchOption { get; set; }

        public IList<SelectListItem> AvailableSortOptions => new List<SelectListItem>
        {
            new SelectListItem { Text = "Price: Low to High", Value = "price-asc" },
            new SelectListItem { Text = "Price: High to Low", Value = "price-desc" }
        };
    }
}

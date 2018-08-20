using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using SimplCommerce.Module.Catalog.ViewModels;

namespace SimplCommerce.Module.Search.ViewModels
{
    public class SearchResult
    {
        public long BrandId { get; set; }

        public string BrandName { get; set; }

        public string BrandSlug { get; set; }

        public int TotalProduct { get; set; }

        public IList<ProductThumbnail> Products { get; set; } = new List<ProductThumbnail>();

        public FilterOption FilterOption { get; set; }

        public SearchOption CurrentSearchOption { get; set; }

        public IList<SelectListItem> AvailableSortOptions => new List<SelectListItem>
        {
            new SelectListItem { Text = "Price: Low to High", Value = "price-asc" },
            new SelectListItem { Text = "Price: High to Low", Value = "price-desc" }
        };
    }
}

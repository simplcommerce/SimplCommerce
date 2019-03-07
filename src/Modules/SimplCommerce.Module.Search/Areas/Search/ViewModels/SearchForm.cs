using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SimplCommerce.Module.Search.Areas.Search.ViewModels
{
    public class SearchForm
    {
        public string Query { get; set; }

        public string Category { get; set; }

        public IList<SelectListItem> AvailableCategories { get; set; } = new List<SelectListItem>();
    }
}

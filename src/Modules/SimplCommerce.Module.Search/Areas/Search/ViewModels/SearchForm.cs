using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace SimplCommerce.Module.Search.ViewModels
{
    public class SearchForm
    {
        public string Query { get; set; }

        public string Category { get; set; }

        public IList<SelectListItem> AvailableCategories { get; set; } = new List<SelectListItem>();
    }
}

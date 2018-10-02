using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Module.Catalog.ViewModels;
using System.Collections.Generic;

namespace SimplCommerce.Module.Search.Components
{
    public class CategoriesTreeItemViewComponent : ViewComponent
    {
        public CategoriesTreeItemViewComponent()
        {
        }

        public IViewComponentResult Invoke(IList<CategoriesTree> categories, SearchOption currentSearchOption)
        {
            TempData["currentSearchOption"] = currentSearchOption;
            return View(categories);
        }
    }
}

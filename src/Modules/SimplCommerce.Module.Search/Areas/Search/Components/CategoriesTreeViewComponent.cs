using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Module.Search.ViewModels;

namespace SimplCommerce.Module.Search.Components
{
    public class CategoriesTreeViewComponent : ViewComponent
    {
        public CategoriesTreeViewComponent()
        {
        }

        public IViewComponentResult Invoke(SearchResult searchResult)
        {
            return View(searchResult);
        }
    }
}

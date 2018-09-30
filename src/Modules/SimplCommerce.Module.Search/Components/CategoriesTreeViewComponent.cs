using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Module.Search.ViewModels;

namespace SimplCommerce.Module.Search.Components
{
    public class CategoriesTreeViewComponent : ViewComponent
    {
        #region Ctor

        public CategoriesTreeViewComponent()
        {
        }

        #endregion Ctor

        #region Action

        public IViewComponentResult Invoke(SearchResult searchResult)
        {
            return View(searchResult);
        }

        #endregion Action
    }
}

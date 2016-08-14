using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Search.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SimplCommerce.Module.Search.Components
{
    public class SearchFormViewComponent : ViewComponent
    {
        private IRepository<Category> _categoryRepository;

        public SearchFormViewComponent(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var model = new SearchForm();
            model.AvailableCategories = _categoryRepository
                .Query()
                .Where(x => x.IsPublished && x.Parent == null)
                .Select(x => new SelectListItem
                {
                    Value = x.SeoTitle,
                    Text = x.Name
                }).ToList();

            model.Query = Request.Query["query"];
            model.Category = Request.Query["category"];

            return View("/Modules/SimplCommerce.Module.Search/Views/Components/SearchForm.cshtml", model);
        }
    }
}

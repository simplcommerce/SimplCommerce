using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryMenuViewComponent(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.Query().Where(x => !x.IsDeleted && x.IncludeInMenu).ToList();

            var categoryMenuItems = new List<CategoryMenuItem>();
            var topCategories = categories.Where(x => !x.ParentId.HasValue).OrderByDescending(x => x.DisplayOrder);
            foreach (var category in topCategories)
            {
                var categoryMenuItem = Map(category);
                categoryMenuItems.Add(categoryMenuItem);
            }

            return View(this.GetViewPath(), categoryMenuItems);
        }

        private CategoryMenuItem Map(Category category)
        {
            var categoryMenuItem = new CategoryMenuItem
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug
            };

            var childCategories = category.Children;
            foreach (var childCategory in childCategories.OrderByDescending(x => x.DisplayOrder))
            {
                var childCategoryMenuItem = Map(childCategory);
                categoryMenuItem.AddChildItem(childCategoryMenuItem);
            }

            return categoryMenuItem;
        }
    }
}

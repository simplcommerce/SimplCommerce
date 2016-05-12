using System.Collections.Generic;
using System.Linq;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.ViewModels.Catalog;
using Microsoft.AspNet.Mvc;

namespace SimplCommerce.Web.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryMenuViewComponent(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = categoryRepository.Query().Where(x => !x.IsDeleted).ToList();

            var categoryMenuItems = new List<CategoryMenuItem>();
            foreach (var category in categories.Where(x => !x.ParentId.HasValue))
            {
                var categoryMenuItem = Map(category);
                categoryMenuItems.Add(categoryMenuItem);
            }

            return View(categoryMenuItems);
        }

        private CategoryMenuItem Map(Category category)
        {
            var categoryMenuItem = new CategoryMenuItem
            {
                Id = category.Id,
                Name = category.Name,
                SeoTitle = category.SeoTitle
            };

            var childCategories = category.Child;
            foreach (var childCategory in childCategories)
            {
                var childCategoryMenuItem = Map(childCategory);
                categoryMenuItem.AddChildItem(childCategoryMenuItem);
            }

            return categoryMenuItem;
        }
    }
}
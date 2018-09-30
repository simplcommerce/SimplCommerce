using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Catalog.Components
{
    public class CategoryBreadcrumbViewComponent : ViewComponent
    {
        private readonly IRepository<Category> _categoryRepository;

        public CategoryBreadcrumbViewComponent(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke(long? categoryId, IEnumerable<long> categoryIds)
        {
            IList<BreadcrumbViewModel> breadcrumbs;
            if (categoryId.HasValue)
            {
                breadcrumbs = Create(categoryId.Value);
            }
            else
            {
                var breadcrumbList = categoryIds.Select(Create).ToList();
                breadcrumbs = breadcrumbList.OrderByDescending(x => x.Count).First();
            }

            return View(this.GetViewPath(), breadcrumbs);
        }

        private IList<BreadcrumbViewModel> Create(long categoryId)
        {
            var category = _categoryRepository
                .Query()
                .Include(x => x.Parent)
                .FirstOrDefault(x => x.Id == categoryId);
            var breadcrumbModels = new List<BreadcrumbViewModel>
            {
                new BreadcrumbViewModel
                {
                    Text = category.Name,
                    Url = category.Slug
                }
            };
            var parentCategory = category.Parent;
            while (parentCategory != null)
            {
                breadcrumbModels.Insert(0, new BreadcrumbViewModel
                {
                    Text = parentCategory.Name,
                    Url = parentCategory.Slug
                });
                parentCategory = parentCategory.Parent;
            }

            return breadcrumbModels;
        }
    }
}

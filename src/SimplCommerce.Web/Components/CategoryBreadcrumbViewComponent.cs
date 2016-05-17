using System.Collections.Generic;
using System.Linq;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace SimplCommerce.Web.Components
{
    public class CategoryBreadcrumbViewComponent : ViewComponent
    {
        private readonly IRepository<Category> categoryRepository;

        public CategoryBreadcrumbViewComponent(IRepository<Category> categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        //public IViewComponentResult Invoke(IEnumerable<long> categoryIds)
        //{
        //    var breadcrumbs = categoryIds.Select(Create).ToList();

        //    return View(breadcrumbs.OrderByDescending(x => x.Count).First());
        //}

        public IViewComponentResult Invoke(long categoryId)
        {
            var breadcrumbModels = Create(categoryId);

            return View(breadcrumbModels);
        }

        private IList<BreadcrumbViewModel> Create(long categoryId)
        {
            var category = categoryRepository.Query().FirstOrDefault(x => x.Id == categoryId);
            var breadcrumbModels = new List<BreadcrumbViewModel>
            {
                new BreadcrumbViewModel
                {
                    Text = category.Name,
                    Url = category.SeoTitle
                }
            };
            var parentCategory = category.Parent;
            while (parentCategory != null)
            {
                breadcrumbModels.Insert(0, new BreadcrumbViewModel
                {
                    Text = parentCategory.Name,
                    Url = parentCategory.SeoTitle
                });
                parentCategory = parentCategory.Parent;
            }

            return breadcrumbModels;
        }
    }
}
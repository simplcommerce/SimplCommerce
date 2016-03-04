using System.Linq;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure.Domain.IRepositories;
using HvCommerce.Web.ViewModels.Catalog;
using Microsoft.AspNet.Mvc;

namespace HvCommerce.Web.Components
{
    public class BreadcrumbViewComponent : ViewComponent
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Product> productRepository;

        public BreadcrumbViewComponent(IRepository<Category> categoryRepository, IRepository<Product> productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }

        public IViewComponentResult Invoke()
        {
            var breadcrumbModel = new BreadcrumbModel();

            // I don'nt want to add breadcrumb to some controllers like as Home, Account, Manage, Error. You can apply if be needed.
            if (ViewContext.RouteData.Values["controller"].ToString() == "Home" ||
                ViewContext.RouteData.Values["controller"].ToString() == "Account" ||
                ViewContext.RouteData.Values["controller"].ToString() == "Manage" ||
                ViewContext.RouteData.Values["controller"].ToString() == "Error")
            {
                breadcrumbModel = null;
            }
            // Applying breadcrumb to Product controller
            else if (ViewContext.RouteData.Values["controller"].ToString() == "Product")
            {
                if (ViewContext.RouteData.Values["seoTitle"] != null)
                {
                    var seoTitle = ViewContext.RouteData.Values["seoTitle"]?.ToString();
                    var product = productRepository.Query()
                        .SingleOrDefault(x => x.SeoTitle == seoTitle && x.IsPublished);

                    var proCats = product?.Categories?.FirstOrDefault(x => x.ProductId == product.Id);

                    breadcrumbModel.BreadcrumbCategory = new BreadcrumbCategory
                    {
                        CategoryName = proCats?.Category.Name,
                        CategorySeoTitle = proCats?.Category.SeoTitle
                    };

                    breadcrumbModel.BreadcrumbDetail = new BreadcrumbDetail
                    {
                        Name = product?.Name,
                        SeoTitle = product?.SeoTitle
                    };
                }
                if (ViewContext.RouteData.Values["catSeoTitle"] != null)
                {
                    var cateSeoTitle = ViewContext.RouteData.Values["catSeoTitle"]?.ToString();

                    var category = categoryRepository.Query().FirstOrDefault(x => x.SeoTitle == cateSeoTitle);
                    breadcrumbModel.BreadcrumbCategory = new BreadcrumbCategory
                    {
                        CategoryName = category?.Name,
                        CategorySeoTitle = category?.SeoTitle
                    };
                }
            }

            return View(breadcrumbModel);
        }
    }
}
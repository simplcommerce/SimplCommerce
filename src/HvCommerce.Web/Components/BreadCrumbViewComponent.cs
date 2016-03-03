using System.Collections.Generic;
using System.Linq;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure.Domain.IRepositories;
using HvCommerce.Web.ViewModels.Catalog;
using Microsoft.AspNet.Mvc;
using System.Text;

namespace HvCommerce.Web.Components
{
    public class BreadCrumbViewComponent : ViewComponent
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly IRepository<Product> productRepository;

        public BreadCrumbViewComponent(IRepository<Category> categoryRepository, IRepository<Product> productRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
        }

        public IViewComponentResult Invoke()
        {
            var breadCrumbModel = new BreadCrumbModel();

            if (ViewContext.RouteData.Values["controller"].ToString() == "Home" ||
                ViewContext.RouteData.Values["controller"].ToString() == "Account" ||
                ViewContext.RouteData.Values["controller"].ToString() == "Manage" ||
                ViewContext.RouteData.Values["controller"].ToString() == "Error")
            {
                breadCrumbModel = null;
            }
            else if (ViewContext.RouteData.Values["controller"].ToString() == "Product")
            {
                // Product
                if (ViewContext.RouteData.Values["seoTitle"]!= null)
                {
                    string seoTitle = ViewContext.RouteData.Values["seoTitle"]?.ToString();
                    var product = productRepository.Query().SingleOrDefault(x => x.SeoTitle == seoTitle && x.IsPublished);

                    var q = product?.Categories?.FirstOrDefault(x=>x.ProductId == product.Id);

                    breadCrumbModel.BreadCrumbCategory = new BreadCrumbCategory {
                        CategoryName = q?.Category.Name,
                        CategorySeoTitle = q?.Category.SeoTitle
                    };

                    breadCrumbModel.BreadCrumbDetail = new BreadCrumbDetail
                    {
                        Name = product?.Name,
                        SeoTitle = product?.SeoTitle
                    };
                }
                if (ViewContext.RouteData.Values["catSeoTitle"] != null)
                {
                    string cateSeoTitle = ViewContext.RouteData.Values["catSeoTitle"]?.ToString();

                    var category = categoryRepository.Query().FirstOrDefault(x => x.SeoTitle == cateSeoTitle);
                    breadCrumbModel.BreadCrumbCategory = new BreadCrumbCategory
                    {
                        CategoryName = category?.Name,
                        CategorySeoTitle = category?.SeoTitle
                    };
                }
            }

            return View(breadCrumbModel);
        }
    }
}
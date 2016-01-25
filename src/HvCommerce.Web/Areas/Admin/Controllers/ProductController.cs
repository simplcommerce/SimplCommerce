using System.Linq;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure.Domain.IRepositories;
using HvCommerce.Web.Areas.Admin.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace HvCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductController : Controller
    {
        private readonly IRepository<Product> productRepository;

        public ProductController(IRepository<Product> productRepository)
        {
            this.productRepository = productRepository;
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult ListAjax([DataSourceRequest] DataSourceRequest request)
        {
            var products = productRepository.Query().Where(x => !x.IsDeleted);
            var gridData = products.ToDataSourceResult(
                request,
                x => new ProductListItem
                    {
                        Id = x.Id,
                        Name = x.Name,
                        CreatedOn = x.CreatedOn,
                        IsPublished = x.IsPublished
                    });

            return Json(gridData);
        }
    }
}
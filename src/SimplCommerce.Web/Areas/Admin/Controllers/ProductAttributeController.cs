using System.Linq;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SimplCommerce.Web.Areas.Admin.ViewModels.Products;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductAttributeController : Controller
    {
        private readonly IRepository<ProductAttribute> productAttrRepository;

        public ProductAttributeController(IRepository<ProductAttribute> productAttrRepository)
        {
            this.productAttrRepository = productAttrRepository;
        }

        public IActionResult List()
        {
            var attributes = productAttrRepository
                .Query()
                .Select(x => new ProductAttributeVm
                {
                    Id = x.Id,
                    Name = x.Name,
                    GroupName = x.Group.Name
                });

            return Json(attributes);
        }
    }
}
using System.Linq;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Shopcuatoi.Web.Areas.Admin.ViewModels.Products;

namespace Shopcuatoi.Web.Areas.Admin.Controllers
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
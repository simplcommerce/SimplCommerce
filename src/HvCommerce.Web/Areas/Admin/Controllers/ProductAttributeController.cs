using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure.Domain.IRepositories;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace HvCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductAttributeController : Controller
    {
        private readonly IRepository<ProductAttribute> productAttRepository;

        public ProductAttributeController(IRepository<ProductAttribute> productAttRepository)
        {
            this.productAttRepository = productAttRepository;
        }

        public IActionResult List()
        {
            var attributes = productAttRepository.Query();
            return Json(attributes);
        }
    }
}
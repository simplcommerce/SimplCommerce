using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductOptionController : Controller
    {
        private readonly IRepository<ProductOption> productOptionRepository;

        public ProductOptionController(IRepository<ProductOption> productOptionRepository)
        {
            this.productOptionRepository = productOptionRepository;
        }

        public IActionResult List()
        {
            var options = productOptionRepository.Query();
            return Json(options);
        }
    }
}

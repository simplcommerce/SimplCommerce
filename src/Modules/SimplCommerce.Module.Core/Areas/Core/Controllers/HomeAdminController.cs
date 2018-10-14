using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SimplCommerce.Module.Core.Areas.Core.Controllers
{
    [Area("Core")]
    [Authorize(Roles = "admin, vendor")]
    public class HomeAdminController : Controller
    {
        [Route("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

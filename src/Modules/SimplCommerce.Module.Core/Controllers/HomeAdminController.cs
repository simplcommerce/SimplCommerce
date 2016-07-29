using Microsoft.AspNetCore.Mvc;

namespace SimplCommerce.Module.Core.Controllers
{
    public class HomeAdminController : Controller
    {
        [Route("admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

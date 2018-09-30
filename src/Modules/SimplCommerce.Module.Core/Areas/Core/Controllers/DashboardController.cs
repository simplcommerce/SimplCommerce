using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SimplCommerce.Module.Core.Controllers
{
    [Area("Core")]
    [Authorize(Roles = "admin, vendor")]
    public class DashboardController : Controller
    {
        [Route("admin/dashboard-tpl")]
        public IActionResult HomeTemplate()
        {
            return View();
        }
    }
}

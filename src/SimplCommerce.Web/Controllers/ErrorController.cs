using Microsoft.AspNetCore.Mvc;

namespace SimplCommerce.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult FindNotFound()
        {
            return View();
        }
    }
}

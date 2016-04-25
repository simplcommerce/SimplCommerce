using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using Shopcuatoi.Core.Domain.Models;

namespace Shopcuatoi.Web.Controllers
{
    [Authorize]
    public class Checkout : BaseController
    {
        public Checkout(UserManager<User> userManager) : base(userManager)
        {
        }

        public IActionResult Index()
        {
            return RedirectToAction("DeliveryInformation");
        }

        public IActionResult DeliveryInformation()
        {
            return View();
        }
    }
}
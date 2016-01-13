using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using HvCommerce.Core.Domain.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HvCommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> userManager;

        public HomeController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = new User { Email = "nlqthien@yahoo.com", UserName = "nlqthien" };
            var result = await userManager.CreateAsync(user, "dfsdfwerweG3123!");
            return View();
        }

        public string Error()
        {
            return "error";
        }
    }
}

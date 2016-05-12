using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

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

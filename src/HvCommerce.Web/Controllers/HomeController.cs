using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure.Domain.IRepositories;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HvCommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> userManager;
        private IRepository<Product> productRepository;

        public HomeController(UserManager<User> userManager, IRepository<Product> productRepository)
        {
            this.userManager = userManager;
            this.productRepository = productRepository;
        }

        public IActionResult Index()
        {
            productRepository.Add(new Product { Name = "Test" });
            productRepository.SaveChange();
            return View();
        }

        public string Error()
        {
            return "error";
        }
    }
}

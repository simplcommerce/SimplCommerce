using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shopcuatoi.Core.ApplicationServices;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;
using Shopcuatoi.Web.ViewModels;
using Shopcuatoi.Web.ViewModels.Catalog;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Shopcuatoi.Web.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> userManager;
        private IRepository<Product> productRepository;
        private IMediaService mediaService;

        public HomeController(UserManager<User> userManager, IRepository<Product> productRepository, IMediaService mediaService)
        {
            this.userManager = userManager;
            this.productRepository = productRepository;
            this.mediaService = mediaService;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();
            model.FeaturedProducts = productRepository.Query()
                .Where(x => x.IsPublished)
                .OrderByDescending(x => x.CreatedOn)
                .Take(4)
                .Select(x => new ProductListItem
                {
                    Id = x.Id,
                    Name = x.Name,
                    SeoTitle = x.SeoTitle,
                    Price = x.Price,
                    OldPrice = x.OldPrice,
                    ThumbnailImage = x.ThumbnailImage
                }).ToList();

            foreach (var product in model.FeaturedProducts)
            {
                product.ThumbnailUrl = mediaService.GetThumbnailUrl(product.ThumbnailImage);
            }

            return View(model);
        }

        public string Error()
        {
            return "error";
        }
    }
}

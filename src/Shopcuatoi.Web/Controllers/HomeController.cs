using System;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Localization;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Localization;
using Shopcuatoi.Core.ApplicationServices;
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
        private readonly IStringLocalizer<HomeController> localizer;

        public HomeController(UserManager<User> userManager, IRepository<Product> productRepository, IMediaService mediaService, IStringLocalizer<HomeController> localizer)
        {
            this.userManager = userManager;
            this.productRepository = productRepository;
            this.mediaService = mediaService;
            this.localizer = localizer;
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
                    ThumbnailImage = x.ThumbnailImage,
                    NumberVariation = x.Variations.Count
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

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTime.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}

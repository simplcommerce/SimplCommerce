using System;
using System.Linq;
using Microsoft.Extensions.Localization;
using SimplCommerce.Core.ApplicationServices;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.ViewModels;
using SimplCommerce.Web.ViewModels.Catalog;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using SimplCommerce.Cms.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace SimplCommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> _userManager;
        private IRepository<Product> _productRepository;
        private IMediaService _mediaService;
        private IRepository<WidgetInstance> _widgetInstanceRepository;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(UserManager<User> userManager, IRepository<Product> productRepository, IMediaService mediaService, IRepository<WidgetInstance> widgetInstanceRepository, IStringLocalizer<HomeController> localizer)
        {
            _userManager = userManager;
            _productRepository = productRepository;
            _mediaService = mediaService;
            _widgetInstanceRepository = widgetInstanceRepository;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();
            model.FeaturedProducts = _productRepository.Query()
                .Where(x => x.IsPublished && x.IsVisibleIndividually)
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
                    NumberVariation = x.ProductLinks.Count
                }).ToList();

            foreach (var product in model.FeaturedProducts)
            {
                product.ThumbnailUrl = _mediaService.GetThumbnailUrl(product.ThumbnailImage);
            }

            var widgetInstances = _widgetInstanceRepository.Query()
                .Include(x => x.Widget).Where(x => x.WidgetZone == WidgetZone.HomeFeatured || x.WidgetZone == WidgetZone.HomeContent);

            model.WidgetInstances = widgetInstances.Select(x => new WidgetInstanceVm
            {
                Id = x.Id,
                ViewComponentName = x.Widget.ViewComponentName,
                WidgetZone = x.WidgetZone
            }).ToList();

            return View(model);
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

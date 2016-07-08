using System;
using System.Linq;
using Microsoft.Extensions.Localization;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.ViewModels;
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
        private IRepository<WidgetInstance> _widgetInstanceRepository;
        private readonly IStringLocalizer<HomeController> _localizer;

        public HomeController(UserManager<User> userManager, IRepository<WidgetInstance> widgetInstanceRepository, IStringLocalizer<HomeController> localizer)
        {
            _userManager = userManager;
            _widgetInstanceRepository = widgetInstanceRepository;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();

            var widgetInstances = _widgetInstanceRepository.Query()
                .Include(x => x.Widget).Where(x => x.WidgetZoneId == WidgetZoneIds.HomeFeatured
                    || x.WidgetZoneId == WidgetZoneIds.HomeMainContent
                    || x.WidgetZoneId == WidgetZoneIds.HomeAfterMainContent);

            model.WidgetInstances = widgetInstances.Select(x => new WidgetInstanceVm
            {
                Id = x.Id,
                Name = x.Name,
                ViewComponentName = x.Widget.ViewComponentName,
                WidgetId = x.WidgetId,
                WidgetZoneId = x.WidgetZoneId,
                Data = x.Data,
                HtmlData = x.HtmlData
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

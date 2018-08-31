using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.ProductRecentlyViewed.ViewModels;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.ProductRecentlyViewed.Components
{
    public class RecentlyViewedWidgetViewComponent: ViewComponent
    {
        private IMediaService _mediaService;

        public RecentlyViewedWidgetViewComponent(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public IViewComponentResult Invoke(WidgetInstanceViewModel widgetInstance)
        {
            var model = new RecentlyViewedWidgetViewComponentVm
            {
                Id = widgetInstance.Id,
                ItemCount = JsonConvert.DeserializeObject<int>(widgetInstance.Data)
            };

            return View(this.GetViewPath(), model);
        }

    }
}

using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Cms.ViewModels;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Core.ViewModels;

namespace SimplCommerce.Module.Cms.Components
{
    public class CarouselWidgetViewComponent : ViewComponent
    {
        private IMediaService _mediaService;

        public CarouselWidgetViewComponent(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public IViewComponentResult Invoke(WidgetInstanceViewModel widgetInstance)
        {
            var model = new CarouselWidgetViewComponentVm
            {
                Id = widgetInstance.Id,
                Items = JsonConvert.DeserializeObject<IList<CarouselWidgetViewComponentItemVm>>(widgetInstance.Data)
            };

            foreach (var item in model.Items)
            {
                item.Image = _mediaService.GetMediaUrl(item.Image);
            }

            return View(this.GetViewPath(), model);
        }
    }
}

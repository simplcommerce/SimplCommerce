using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimplCommerce.Web.ViewModels;
using SimplCommerce.Core.ApplicationServices;

namespace SimplCommerce.Web.Components
{
    public class CarouselWidgetViewComponent : ViewComponent
    {
        private IMediaService _mediaService;

        public CarouselWidgetViewComponent(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        public IViewComponentResult Invoke(WidgetInstanceVm widgetInstance)
        {
            var model = new CarouselWidgetViewComponentVm
            {
                Id = widgetInstance.Id,
                Items = JsonConvert.DeserializeObject<IList<CarouselWidgetViewComponentItemVm>>(widgetInstance.WidgetData)
            };

            foreach(var item in model.Items)
            {
                item.Image = _mediaService.GetMediaUrl(item.Image);
            }

            return View(model);
        }
    }
}

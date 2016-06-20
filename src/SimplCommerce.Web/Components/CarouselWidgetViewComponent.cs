using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Cms.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.ViewModels;

namespace SimplCommerce.Web.Components
{
    public class CarouselWidgetViewComponent : ViewComponent
    {
        private IRepository<WidgetInstance> _widgetInstanceRepository;

        public CarouselWidgetViewComponent(IRepository<WidgetInstance> widgetInstanceRepository)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
        }

        public IViewComponentResult Invoke(long widgetInstanceId)
        {
            var widgetInstance = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == widgetInstanceId);

            var model = new CarouselWidgetViewComponentVm
            {
                Id = widgetInstance.Id,
                Items = widgetInstance.WidgetProperties.Where(x => x.PropertyName == "Content").Select(x => new CarouselWidgetViewComponentItemVm
                {
                    Content = x.PropertyValue
                }).ToList()
            };

            return View(model);
        }
    }
}

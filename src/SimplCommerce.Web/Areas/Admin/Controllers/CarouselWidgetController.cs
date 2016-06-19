using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Cms.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.Areas.Admin.ViewModels.Cms;


namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CarouselWidgetController : Controller
    {
        private readonly IRepository<WidgetInstance> _widgetInstanceRepository;
        private readonly IRepository<Widget> _widgetRespository;

        public CarouselWidgetController(IRepository<WidgetInstance> widgetInstanceRepository, IRepository<Widget> widgetRespository)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
            _widgetRespository = widgetRespository;
        }

        public IActionResult Get(long id)
        {
            var widget = _widgetInstanceRepository.Query().Include(x => x.WidgetProperties).FirstOrDefault(x => x.Id == id);
            var model = new CarouselWidgetForm
            {
                Id = widget.Id,
                Name = widget.Name,
                Zone = (int)widget.WidgetZone,
                Items = widget.WidgetProperties.Where(x => x.PropertyName == "Content").Select(x => new WidgetPropertyForm {
                    Id = x.Id,
                    Name = x.PropertyName,
                    Value = x.PropertyValue
                }).ToList()
            };

            return Json(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CarouselWidgetForm model)
        {
            if (ModelState.IsValid)
            {
                var widgetInstance = new WidgetInstance
                {
                    Name = model.Name,
                    WidgetId = 1,
                    WidgetZone = (WidgetZone)model.Zone
                };

                foreach(var item in model.Items)
                {
                    var property = new WidgetInstanceProperty
                    {
                        PropertyName = "Content",
                        PropertyValue = item.Value
                    };

                    widgetInstance.AddProperty(property);
                }

                _widgetInstanceRepository.Add(widgetInstance);
                _widgetInstanceRepository.SaveChange();

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost]
        public IActionResult Edit(long id, [FromBody] CarouselWidgetForm model)
        {
            if (ModelState.IsValid)
            {
                var widgetInstance = _widgetInstanceRepository.Query().Include(x => x.WidgetProperties).FirstOrDefault(x => x.Id == id);
                widgetInstance.Name = model.Name;
                widgetInstance.WidgetZone = (WidgetZone)model.Zone;

                foreach (var item in model.Items)
                {
                    var property = widgetInstance.WidgetProperties.Where(x => x.Id == item.Id).FirstOrDefault();
                    if(property == null)
                    {
                        property = new WidgetInstanceProperty
                        {
                            PropertyName = "Content",
                            PropertyValue = item.Value
                        };
                        widgetInstance.AddProperty(property);
                    }
                    property.PropertyValue = item.Value;
                }

                _widgetInstanceRepository.SaveChange();

                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }
    }
}

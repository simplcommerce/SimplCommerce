using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Cms.ViewModels;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Cms.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/html-widgets")]
    public class HtmlWidgetApiController : Controller
    {
        private readonly IRepository<WidgetInstance> _widgetInstanceRepository;
        private readonly IRepository<Widget> _widgetRespository;
        private readonly IMapper _mapper;

        public HtmlWidgetApiController(IRepository<WidgetInstance> widgetInstanceRepository, 
            IRepository<Widget> widgetRespository,
            IMapper mapper)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
            _widgetRespository = widgetRespository;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var widget = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);

            var model = _mapper.Map<WidgetInstance, HtmlWidgetForm>(widget);

            return Json(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] HtmlWidgetForm model)
        {
            if (ModelState.IsValid)
            {
                var widgetInstance = _mapper.Map<HtmlWidgetForm, WidgetInstance>(model);
                widgetInstance.WidgetId = 2;

                _widgetInstanceRepository.Add(widgetInstance);
                _widgetInstanceRepository.SaveChange();
                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] HtmlWidgetForm model)
        {
            if (ModelState.IsValid)
            {
                var widgetInstanceForModification = _widgetInstanceRepository.Query().FirstOrDefault(x => x.Id == id);
                
                _mapper.Map(model, widgetInstanceForModification, op => op.BeforeMap((fModel, tWidgetInstanceForModification) =>
                {
                    fModel.Id = tWidgetInstanceForModification.Id;
                }));

                _widgetInstanceRepository.SaveChange();
                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }
    }
}

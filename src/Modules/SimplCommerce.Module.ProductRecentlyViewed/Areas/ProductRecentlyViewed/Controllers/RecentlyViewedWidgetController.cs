using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.ProductRecentlyViewed.Areas.ProductRecentlyViewed.ViewModels;

namespace SimplCommerce.Module.ProductRecentlyViewed.Areas.ProductRecentlyViewed.Controllers
{
    [Area("ProductRecentlyViewed")]
    [Authorize(Roles = "admin")]
    [Route("api/recently-viewed-widgets")]
    public class RecentlyViewedWidgetApiController : Controller
    {
        private readonly IRepository<WidgetInstance> _widgetInstanceRepository;
        private readonly IMediaService _mediaService;

        public RecentlyViewedWidgetApiController(IRepository<WidgetInstance> widgetInstanceRepository, IMediaService mediaService)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
            _mediaService = mediaService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var widgetInstance = await _widgetInstanceRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            var model = new RecentlyViewedWidgetForm
            {
                Id = widgetInstance.Id,
                Name = widgetInstance.Name,
                WidgetZoneId = widgetInstance.WidgetZoneId,
                PublishStart = widgetInstance.PublishStart,
                PublishEnd = widgetInstance.PublishEnd,
                DisplayOrder = widgetInstance.DisplayOrder,
                ItemCount = JsonConvert.DeserializeObject<int>(widgetInstance.Data)
            };

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RecentlyViewedWidgetForm model)
        {
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var widgetInstance = new WidgetInstance
                {
                    Name = model.Name,
                    WidgetId = "RecentlyViewedWidget",
                    WidgetZoneId = model.WidgetZoneId,
                    Data = model.ItemCount.ToString(),
                    PublishStart = model.PublishStart,
                    PublishEnd = model.PublishEnd,
                    DisplayOrder = model.DisplayOrder,
                };

                _widgetInstanceRepository.Add(widgetInstance);
                await _widgetInstanceRepository.SaveChangesAsync();
                return CreatedAtAction(nameof(Get), new {id = widgetInstance.Id}, null);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] RecentlyViewedWidgetForm model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var widgetInstance = await _widgetInstanceRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if(widgetInstance == null)
            {
                return NotFound();
            }

            widgetInstance.Name = model.Name;
            widgetInstance.PublishStart = model.PublishStart;
            widgetInstance.PublishEnd = model.PublishEnd;
            widgetInstance.WidgetZoneId = model.WidgetZoneId;
            widgetInstance.DisplayOrder = model.DisplayOrder;
            widgetInstance.Data = model.ItemCount.ToString();

            await _widgetInstanceRepository.SaveChangesAsync();
            return Accepted();
        }
    }
}

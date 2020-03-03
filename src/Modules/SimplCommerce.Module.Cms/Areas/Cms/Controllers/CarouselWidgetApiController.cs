using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Cms.Areas.Cms.ViewModels;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Cms.Areas.Cms.Controllers
{
    [Area("Cms")]
    [Authorize(Roles = "admin")]
    [Route("api/carousel-widgets")]
    [ApiController]
    public class CarouselWidgetApiController : ControllerBase
    {
        private readonly IRepository<WidgetInstance> _widgetInstanceRepository;
        private readonly IMediaService _mediaService;

        public CarouselWidgetApiController(IRepository<WidgetInstance> widgetInstanceRepository, IMediaService mediaService)
        {
            _widgetInstanceRepository = widgetInstanceRepository;
            _mediaService = mediaService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarouselWidgetForm>> Get(long id)
        {
            var totalWidgets = _widgetInstanceRepository.Query().ToList().Count();
            var widgetInstance = await _widgetInstanceRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            var model = new CarouselWidgetForm
            {
                Id = widgetInstance.Id,
                Name = widgetInstance.Name,
                WidgetZoneId = widgetInstance.WidgetZoneId,
                PublishStart = widgetInstance.PublishStart,
                PublishEnd = widgetInstance.PublishEnd,
                DisplayOrder = widgetInstance.DisplayOrder,
                Items = JsonConvert.DeserializeObject<IList<CarouselWidgetItemForm>>(widgetInstance.Data)
            };

            foreach (var item in model.Items)
            {
                item.ImageUrl = _mediaService.GetMediaUrl(item.Image);
            }

            return model;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm]CarouselWidgetForm model)
        {
            ModelBindUploadFiles(model);

            if(model.Items.Any(x => x.UploadImage == null))
            {
                ModelState.AddModelError("Images", "Images is required");
                return BadRequest(ModelState);
            }

            foreach (var item in model.Items)
            {
                item.Image = await SaveFile(item.UploadImage);
            }

            var widgetInstance = new WidgetInstance
            {
                Name = model.Name,
                WidgetId = "CarouselWidget",
                WidgetZoneId = model.WidgetZoneId,
                PublishStart = model.PublishStart,
                PublishEnd = model.PublishEnd,
                DisplayOrder = model.DisplayOrder,
                Data = JsonConvert.SerializeObject(model.Items)
            };

            _widgetInstanceRepository.Add(widgetInstance);
            await _widgetInstanceRepository.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = widgetInstance.Id }, null);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromForm]CarouselWidgetForm model)
        {
            ModelBindUploadFiles(model);

            foreach (var item in model.Items)
            {
                if (item.UploadImage != null)
                {
                    if (!string.IsNullOrWhiteSpace(item.Image))
                    {
                        await _mediaService.DeleteMediaAsync(item.Image);
                    }
                    item.Image = await SaveFile(item.UploadImage);
                }
            }

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
            widgetInstance.Data = JsonConvert.SerializeObject(model.Items);

            await _widgetInstanceRepository.SaveChangesAsync();
            return Accepted();
        }

        private CarouselWidgetForm ModelBindUploadFiles(CarouselWidgetForm model)
        {
            for (var i = 0; i < model.Items.Count; i++)
            {
                model.Items[i].UploadImage = Request.Form.Files[$"items[{i}][uploadImage]"];
            }

            return model;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _mediaService.SaveMediaAsync(file.OpenReadStream(), fileName, file.ContentType);
            return fileName;
        }
    }
}

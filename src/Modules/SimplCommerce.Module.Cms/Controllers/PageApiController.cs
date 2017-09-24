using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Cms.Models;
using SimplCommerce.Module.Cms.Services;
using SimplCommerce.Module.Cms.ViewModels;

namespace SimplCommerce.Module.Cms.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/pages")]
    public class PageApiController : Controller
    {
        private readonly IRepository<Page> _pageRepository;
        private readonly IPageService _pageService;

        public PageApiController(IRepository<Page> pageRepository, IPageService pageService)
        {
            _pageRepository = pageRepository;
            _pageService = pageService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var pageList = _pageRepository.Query().Where(x => !x.IsDeleted).ToList();

            return Json(pageList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var page = _pageRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new PageForm
            {
                Id = page.Id,
                Name = page.Name,
                SeoTitle = page.SeoTitle,
                Body = page.Body,
                IsPublished = page.IsPublished
            };

            return Json(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PageForm model)
        {
            if (ModelState.IsValid)
            {
                var page = new Page
                {
                    Name = model.Name,
                    SeoTitle = model.SeoTitle,
                    Body = model.Body,
                    IsPublished = model.IsPublished
                };

                _pageService.Create(page);

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] PageForm model)
        {
            if (ModelState.IsValid)
            {
                var page = _pageRepository.Query().FirstOrDefault(x => x.Id == id);
                page.Name = model.Name;
                page.SeoTitle = model.SeoTitle;
                page.Body = model.Body;
                page.IsPublished = model.IsPublished;
                page.UpdatedOn = DateTimeOffset.Now;

                _pageService.Update(page);

                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var page = _pageRepository.Query().FirstOrDefault(x => x.Id == id);
            if (page == null)
            {
                return new NotFoundResult();
            }

            await _pageService.Delete(page);
            return Ok();
        }
    }
}

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Get()
        {
            var pageList = await _pageRepository.Query()
                .Where(x => !x.IsDeleted)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.SeoTitle,
                    x.CreatedOn,
                    x.IsPublished
                })
                .ToListAsync();

            return Json(pageList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var page = await _pageRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            var model = new PageForm
            {
                Id = page.Id,
                Name = page.Name,
                Slug = page.SeoTitle,
                Body = page.Body,
                IsPublished = page.IsPublished
            };

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PageForm model)
        {
            if (ModelState.IsValid)
            {
                var page = new Page
                {
                    Name = model.Name,
                    SeoTitle = model.Slug,
                    Body = model.Body,
                    IsPublished = model.IsPublished
                };

                await _pageService.Create(page);
                return CreatedAtAction(nameof(Get), new { id = page.Id }, null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] PageForm model)
        {
            if (ModelState.IsValid)
            {
                var page = await _pageRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
                if(page == null)
                {
                    return NotFound();
                }

                page.Name = model.Name;
                page.SeoTitle = model.Slug;
                page.Body = model.Body;
                page.IsPublished = model.IsPublished;
                page.UpdatedOn = DateTimeOffset.Now;

                await _pageService.Update(page);
                return Accepted();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var page = await _pageRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (page == null)
            {
                return NotFound();
            }

            await _pageService.Delete(page);
            return NoContent();
        }
    }
}

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
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.Module.Cms.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/pages")]
    public class PageApiController : Controller
    {
        private readonly IRepository<Page> _pageRepository;
        private readonly IPageService _pageService;
        private readonly IWorkContext _workContext;

        public PageApiController(IRepository<Page> pageRepository, IPageService pageService, IWorkContext workContext)
        {
            _pageRepository = pageRepository;
            _pageService = pageService;
            _workContext = workContext;
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
                    x.Slug,
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
                Slug = page.Slug,
                MetaTitle = page.MetaTitle,
                MetaKeywords = page.MetaKeywords,
                MetaDescription = page.MetaDescription,
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
                var currentUser = await _workContext.GetCurrentUser();
                var page = new Page
                {
                    Name = model.Name,
                    Slug = model.Slug,
                    MetaTitle = model.MetaTitle,
                    MetaKeywords = model.MetaKeywords,
                    MetaDescription = model.MetaDescription,
                    Body = model.Body,
                    IsPublished = model.IsPublished,
                    CreatedBy = currentUser
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

                var currentUser = await _workContext.GetCurrentUser();

                page.Name = model.Name;
                page.Slug = model.Slug;
                page.MetaTitle = model.MetaTitle;
                page.MetaKeywords = model.MetaKeywords;
                page.MetaDescription = model.MetaDescription;
                page.Body = model.Body;
                page.IsPublished = model.IsPublished;
                page.UpdatedOn = DateTimeOffset.Now;
                page.UpdatedBy = currentUser;

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

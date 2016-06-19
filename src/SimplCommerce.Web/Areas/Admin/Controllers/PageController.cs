using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SimplCommerce.Cms.Domain.Models;
using SimplCommerce.Cms.ApplicationServices;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.Areas.Admin.ViewModels.Pages;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class PageController : Controller
    {
        private readonly IRepository<Page> pageRepository;
        private readonly IPageService pageService;

        public PageController(IRepository<Page> pageRepository, IPageService pageService)
        {
            this.pageRepository = pageRepository;
            this.pageService = pageService;
        }

        public IActionResult List()
        {
            var pageList = pageRepository.Query().Where(x => !x.IsDeleted).ToList();

            return Json(pageList);
        }

        public IActionResult Get(long id)
        {
            var page = pageRepository.Query().FirstOrDefault(x => x.Id == id);
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
        public IActionResult Create([FromBody] PageForm model)
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

                pageService.Create(page);

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost]
        public IActionResult Edit(long id, [FromBody] PageForm model)
        {
            if (ModelState.IsValid)
            {
                var page = pageRepository.Query().FirstOrDefault(x => x.Id == id);
                page.Name = model.Name;
                page.SeoTitle = model.SeoTitle;
                page.Body = model.Body;
                page.IsPublished = model.IsPublished;
                page.UpdatedOn = DateTime.Now;

                pageService.Update(page);

                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            var page = pageRepository.Query().FirstOrDefault(x => x.Id == id);
            if (page == null)
            {
                return new NotFoundResult();
            }

            pageService.Delete(page);

            return Json(true);
        }
    }
}
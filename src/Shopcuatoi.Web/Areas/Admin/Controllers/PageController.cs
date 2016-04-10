using System;
using System.Linq;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Shopcuatoi.Core.ApplicationServices;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;
using Shopcuatoi.Web.Areas.Admin.ViewModels.Pages;
using Shopcuatoi.Web.Extensions;

namespace Shopcuatoi.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class PageController : Controller
    {
        private readonly IRepository<Page> pageRepository;
        private readonly IUrlSlugService urlSlugService;

        public PageController(IRepository<Page> pageRepository, IUrlSlugService urlSlugService)
        {
            this.pageRepository = pageRepository;
            this.urlSlugService = urlSlugService;
        }

        public IActionResult List()
        {
            var pageList = pageRepository.Query().Where(x => !x.IsDeleted).ToList();

            return Json(pageList);
        }

        public IActionResult Get(long id)
        {
            var page = pageRepository.Get(id);
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

                pageRepository.Add(page);
                pageRepository.SaveChange();

                urlSlugService.Add(page.SeoTitle, page.Id, "Page");
                pageRepository.SaveChange();

                return Ok();
            }
            return Json(ModelState.ToDictionary());
        }

        [HttpPost]
        public IActionResult Edit(long id, [FromBody] PageForm model)
        {
            if (ModelState.IsValid)
            {
                var page = pageRepository.Get(id);
                page.Name = model.Name;
                page.SeoTitle = model.SeoTitle;
                page.Body = model.Body;
                page.IsPublished = model.IsPublished;
                page.UpdatedOn = DateTime.Now;

                urlSlugService.Update(page.SeoTitle, page.Id, "Page");

                pageRepository.SaveChange();

                return Ok();
            }

            return Json(ModelState.ToDictionary());
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            var page = pageRepository.Get(id);
            if (page == null)
            {
                return new HttpStatusCodeResult(400);
            }

            pageRepository.Remove(page);
            urlSlugService.Remove(page.Id, "Page");
            pageRepository.SaveChange();

            return Json(true);
        }
    }
}
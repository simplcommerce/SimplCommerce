using System;
using System.Linq;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public PageApiController(IRepository<Page> pageRepository, IPageService pageService, IMapper mapper)
        {
            _pageRepository = pageRepository;
            _pageService = pageService;
            _mapper = mapper;
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

            var model = _mapper.Map<Page, PageForm>(page);
            
            return Json(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PageForm model)
        {
            if (ModelState.IsValid)
            {
                var page = _mapper.Map<PageForm, Page>(model);

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

                _mapper.Map(model, page, op => op.BeforeMap((fPageFrom, tPage) =>
                {
                    fPageFrom.Id = tPage.Id;
                    tPage.UpdatedOn = DateTimeOffset.Now;
                }));
                
                _pageService.Update(page);

                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var page = _pageRepository.Query().FirstOrDefault(x => x.Id == id);
            if (page == null)
            {
                return new NotFoundResult();
            }

            _pageService.Delete(page);

            return Ok();
        }
    }
}

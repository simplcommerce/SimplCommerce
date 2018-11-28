using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.News.Areas.News.ViewModels;
using SimplCommerce.Module.News.Models;
using SimplCommerce.Module.News.Services;

namespace SimplCommerce.Module.News.Areas.News.Controllers
{
    [Area("News")]
    [Authorize(Roles = "admin")]
    [Route("api/news-categories")]
    public class NewsCategoryApiController : Controller
    {
        private readonly IRepository<NewsCategory> _categoryRepository;
        private readonly INewsCategoryService _categoryService;

        public NewsCategoryApiController(IRepository<NewsCategory> categoryRepository, INewsCategoryService categoryService)
        {
            _categoryRepository = categoryRepository;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categoryList = await _categoryRepository.Query().Where(x => !x.IsDeleted).ToListAsync();

            return Json(categoryList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var category = await _categoryRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if(category == null)
            {
                return NotFound();
            }

            var model = new NewsCategoryForm
            {
                Id = category.Id,
                Name = category.Name,
                Slug = category.Slug,
                MetaTitle = category.MetaTitle,
                MetaKeywords = category.MetaKeywords,
                MetaDescription = category.MetaDescription,
                IsPublished = category.IsPublished
            };

            return Json(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] NewsCategoryForm model)
        {
            if (ModelState.IsValid)
            {
                var category = new NewsCategory
                {
                    Name = model.Name,
                    Slug = model.Slug,
                    MetaTitle = model.MetaTitle,
                    MetaKeywords = model.MetaKeywords,
                    MetaDescription = model.MetaDescription,
                    IsPublished = model.IsPublished
                };

                await _categoryService.Create(category);
                return CreatedAtAction(nameof(Get), new { id = category.Id }, null);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put(long id, [FromBody] NewsCategoryForm model)
        {
            if (ModelState.IsValid)
            {
                var category = _categoryRepository.Query().FirstOrDefault(x => x.Id == id);
                category.Name = model.Name;
                category.Slug = model.Slug;
                category.MetaTitle = model.MetaTitle;
                category.MetaKeywords = model.MetaKeywords;
                category.MetaDescription = model.MetaDescription;
                category.IsPublished = model.IsPublished;

                await _categoryService.Update(category);
                return Accepted();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(long id)
        {
            var category = await _categoryRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            await _categoryService.Delete(category);
            return NoContent();
        }
    }
}

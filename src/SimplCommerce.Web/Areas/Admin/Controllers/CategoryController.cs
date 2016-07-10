using System.Linq;
using SimplCommerce.Core.ApplicationServices;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.Areas.Admin.Helpers;
using SimplCommerce.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> categoryRepository;
        private readonly ICategoryService categoryService;

        public CategoryController(IRepository<Category> categoryRepository, ICategoryService categoryService)
        {
            this.categoryRepository = categoryRepository;
            this.categoryService = categoryService;
        }

        public IActionResult List()
        {
            var categories = categoryRepository.Query().Where(x => !x.IsDeleted).ToList();
            var categoriesList = CategoryMapper.ToCategoryListItem(categories);
            var gridData = categoriesList;

            return Json(gridData);
        }

        public IActionResult Get(long id)
        {
            var category = categoryRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new CategoryForm
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId,
                IsPublished = category.IsPublished
            };

            return Json(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryForm model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category
                {
                    Name = model.Name,
                    SeoTitle = StringHelper.ToUrlFriendly(model.Name),
                    ParentId = model.ParentId,
                    IsPublished = model.IsPublished
                };

                categoryService.Create(category);

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost]
        public IActionResult Edit(long id, [FromBody]CategoryForm model)
        {
            if (ModelState.IsValid)
            {
                var category = categoryRepository.Query().FirstOrDefault(x => x.Id == id);
                category.Name = model.Name;
                category.SeoTitle = StringHelper.ToUrlFriendly(model.Name);
                category.ParentId = model.ParentId;
                category.IsPublished = model.IsPublished;

                categoryService.Update(category);

                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            var category = categoryRepository.Query().Include(x => x.Child).FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return new NotFoundResult();
            }

            if(category.Child.Any(x => !x.IsDeleted))
            {
                return BadRequest(new { Error = "Please make sure this category contains no children" });
            }

            categoryService.Delete(category);

            return Ok();
        }
    }
}
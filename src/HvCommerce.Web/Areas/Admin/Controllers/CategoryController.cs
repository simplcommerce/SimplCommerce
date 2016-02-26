using System.Collections.Generic;
using System.Linq;
using HvCommerce.Core.ApplicationServices;
using HvCommerce.Core.Domain.Models;
using HvCommerce.Infrastructure;
using HvCommerce.Infrastructure.Domain.IRepositories;
using HvCommerce.Web.Areas.Admin.Helpers;
using HvCommerce.Web.Areas.Admin.ViewModels;
using HvCommerce.Web.Areas.Admin.ViewModels.SmartTable;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using HvCommerce.Web.Extensions;

namespace HvCommerce.Web.Areas.Admin.Controllers
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

                categoryRepository.Add(category);
                categoryRepository.SaveChange();

                return Ok();
            }
            return Json(ModelState.ToDictionary());
        }

        public IActionResult Edit(long id)
        {
            var category = categoryRepository.Get(id);
            var model = new CategoryForm
            {
                Id = category.Id,
                Name = category.Name,
                ParentId = category.ParentId,
                IsPublished = category.IsPublished
            };
            AddCategoryListToForm(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(long id, CategoryForm model)
        {
            if (ModelState.IsValid)
            {
                var category = categoryRepository.Get(id);
                category.Name = model.Name;
                category.SeoTitle = StringHelper.ToUrlFriendly(model.Name);
                category.ParentId = model.ParentId;
                category.IsPublished = model.IsPublished;

                categoryRepository.SaveChange();
                return RedirectToAction("List");
            }

            AddCategoryListToForm(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            var category = categoryRepository.Get(id);
            if (category == null)
            {
                return new HttpStatusCodeResult(400);
            }

            categoryService.Delete(category);
            categoryRepository.SaveChange();
            return Json(true);
        }

        private void AddCategoryListToForm(long excludedId)
        {
            var categories = categoryRepository.Query().Where(x => !x.IsDeleted).ToList();

            var categoryListItem = CategoryMapper.ToCategoryListItem(categories)
                    .Where(x => x.Id != excludedId)
                    .Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() })
                    .ToList();
            categoryListItem.Insert(0, new SelectListItem { Text = "Top", Value = string.Empty });
            ViewBag.Categories = categoryListItem;
        }
    }
}
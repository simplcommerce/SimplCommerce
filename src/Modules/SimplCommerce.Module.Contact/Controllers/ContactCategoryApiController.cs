using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Contact.Models;
using SimplCommerce.Module.Contact.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimplCommerce.Module.Contact.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/contact-categories")]
    public class ContactCategoryApiController : Controller
    {
        private readonly IRepository<ContactCategory> _contactRepository;

        public ContactCategoryApiController(IRepository<ContactCategory> categoryRepository)
        {
            _contactRepository = categoryRepository;
        }

        public IActionResult Get()
        {
            var categoryList = _contactRepository.Query().Where(x => !x.IsDeleted).ToList();

            return Json(categoryList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var category = _contactRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new ContactCategoryForm
            {
                Id = category.Id,
                Name = category.Name
            };

            return Json(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post([FromBody] ContactCategoryForm model)
        {
            if (ModelState.IsValid)
            {
                var category = new ContactCategory
                {
                    Name = model.Name
                };

                _contactRepository.Add(category);
                _contactRepository.SaveChange();

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Put(long id, [FromBody] ContactCategoryForm model)
        {
            if (ModelState.IsValid)
            {
                var category = _contactRepository.Query().FirstOrDefault(x => x.Id == id);
                category.Name = model.Name;

                _contactRepository.SaveChange();

                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(long id)
        {
            var category = _contactRepository.Query().FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return new NotFoundResult();
            }

            category.IsDeleted = true;
            _contactRepository.SaveChange();

            return Json(true);
        }
    }
}
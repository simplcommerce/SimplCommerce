using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Contacts.Areas.Contacts.ViewModels;
using SimplCommerce.Module.Contacts.Models;

namespace SimplCommerce.Module.Contacts.Areas.Contacts.Controllers
{
    [Area("Contacts")]
    [Authorize(Roles = "admin")]
    [Route("api/contact-area")]
    public class ContactAreaApiController : Controller
    {
        private readonly IRepository<ContactArea> _contactRepository;

        public ContactAreaApiController(IRepository<ContactArea> categoryRepository)
        {
            _contactRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var categoryList = _contactRepository.Query().Where(x => !x.IsDeleted).ToList();
            return Json(categoryList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var category = _contactRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new ContactAreaForm
            {
                Id = category.Id,
                Name = category.Name
            };

            return Json(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ContactAreaForm model)
        {
            if (ModelState.IsValid)
            {
                var category = new ContactArea
                {
                    Name = model.Name
                };

                _contactRepository.Add(category);
                _contactRepository.SaveChanges();

                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ContactAreaForm model)
        {
            if (ModelState.IsValid)
            {
                var category = _contactRepository.Query().FirstOrDefault(x => x.Id == id);
                category.Name = model.Name;

                _contactRepository.SaveChanges();

                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var category = _contactRepository.Query().FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            category.IsDeleted = true;
            _contactRepository.SaveChanges();

            return Json(true);
        }
    }
}

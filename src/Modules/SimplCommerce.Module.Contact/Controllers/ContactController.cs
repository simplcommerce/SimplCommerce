using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using SimplCommerce.Module.Contact.Models;
using SimplCommerce.Module.Contact.ViewModels;
using System.Linq;

namespace SimplCommerce.Module.Contact.Controllers
{    
    public class ContactController : Controller
    {
        private readonly IRepository<Models.Contact> _contactRepository;
        private readonly IRepository<ContactCategory> _contactCategoryRepository;

        public ContactController(IRepository<Models.Contact> contactRepository, IRepository<ContactCategory> contactCategoryRepository)
        {
            _contactRepository = contactRepository;
            _contactCategoryRepository = contactCategoryRepository;
        }

        [Route("contact")]
        public IActionResult Index()
        {
            var model = new ContactVm()
            {
                Categories = GetContactCategory()
            };

            return View(model);
        }

        [Route("contact")]
        [HttpPost]
        public IActionResult SubmitContact(ContactVm model)
        {
            if (ModelState.IsValid)
            {
                var contact = new Models.Contact()
                {
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    EmailAddress = model.EmailAddress,
                    Address = model.Address,
                    CategoryId = model.CategoryId,
                    Content = model.Content
                };

                _contactRepository.Add(contact);
                _contactRepository.SaveChange();

                return View("SubmitContactResult", model);
            }

            model.Categories = GetContactCategory();

            return View("Index", model);
        }

        private IList<ContactCategoryVm> GetContactCategory()
        {
            var categories = _contactCategoryRepository.Query()
                .Where(x => x.IsDeleted)
                .Select(x => new ContactCategoryVm()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            return categories;
        }
    }
}

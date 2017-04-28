using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Contacts.Models;
using SimplCommerce.Module.Contacts.ViewModels;

namespace SimplCommerce.Module.Contacts.Controllers
{
    public class ContactController : Controller
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly IRepository<ContactArea> _contactAreaRepository;

        public ContactController(IRepository<Contact> contactRepository, IRepository<ContactArea> contactAreaRepository)
        {
            _contactRepository = contactRepository;
            _contactAreaRepository = contactAreaRepository;
        }

        [Route("contact")]
        public IActionResult Index()
        {
            var model = new ContactVm()
            {
                ContactAreas = GetContactArea()
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
                    ContactAreaId = model.ContactAreaId,
                    Content = model.Content
                };

                _contactRepository.Add(contact);
                _contactRepository.SaveChange();

                return View("SubmitContactResult", model);
            }

            model.ContactAreas = GetContactArea();

            return View("Index", model);
        }

        private IList<ContactAreaVm> GetContactArea()
        {
            var categories = _contactAreaRepository.Query()
                .Where(x => !x.IsDeleted)
                .Select(x => new ContactAreaVm()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            return categories;
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Contacts.Areas.Contacts.ViewModels;
using SimplCommerce.Module.Contacts.Models;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;

namespace SimplCommerce.Module.Contacts.Areas.Contacts.Controllers
{
    [Area("Contacts")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ContactController : Controller
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly IRepository<ContactArea> _contactAreaRepository;
        private readonly IWorkContext _workContext;
        private readonly IContentLocalizationService _contentLocalizationService;

        public ContactController(IRepository<Contact> contactRepository, IRepository<ContactArea> contactAreaRepository, IWorkContext workContext, IContentLocalizationService contentLocalizationService)
        {
            _contactRepository = contactRepository;
            _contactAreaRepository = contactAreaRepository;
            _workContext = workContext;
            _contentLocalizationService = contentLocalizationService;
        }

        [HttpGet("contact")]
        public async Task<IActionResult> Index()
        {
            var model = new ContactVm()
            {
                ContactAreas = GetContactArea()
            };

            if(User.Identity.IsAuthenticated)
            {
                var currentUser = await _workContext.GetCurrentUser();
            
                model.FullName = currentUser.FullName;
                model.EmailAddress = currentUser.Email;
                model.PhoneNumber = currentUser.PhoneNumber;
            }

            return View(model);
        }

        [HttpPost("contact")]
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
                _contactRepository.SaveChanges();

                return View("SubmitContactResult", model);
            }

            model.ContactAreas = GetContactArea();

            return View("Index", model);
        }

        private IList<ContactAreaVm> GetContactArea()
        {
            var getContactAreaName = _contentLocalizationService.GetLocalizationFunction<ContactArea>();
            var categories = _contactAreaRepository.Query()
                .Where(x => !x.IsDeleted)
                .Select(x => new ContactAreaVm()
                {
                    Id = x.Id,
                    Name = getContactAreaName(x.Id, nameof(x.Name), x.Name)
                })
                .ToList();

            return categories;
        }
    }
}

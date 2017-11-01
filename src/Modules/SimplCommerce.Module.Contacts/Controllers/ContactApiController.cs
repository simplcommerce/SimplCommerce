using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Contacts.Models;
using SimplCommerce.Module.Core.Extensions;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Contacts.ViewModels;
using SimplCommerce.Infrastructure.Web.SmartTable;

namespace SimplCommerce.Module.Contacts.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/contacts")]
    public class ContactApiController : Controller
    {
        private readonly IRepository<Contact> _contactRepository;
        private readonly IMediaService _mediaService;
        private readonly IWorkContext _workContext;

        public ContactApiController(IRepository<Contact> contactRepository, IMediaService mediaService, IWorkContext workContext)
        {
            _contactRepository = contactRepository;
            _mediaService = mediaService;
            _workContext = workContext;
        }

        [HttpPost("grid")]
        public IActionResult Get([FromBody] SmartTableParam param)
        {
            var query = _contactRepository.Query()
                .Where(x => !x.IsDeleted);

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;

                if (search.FullName != null)
                {
                    string name = search.FullName;
                    query = query.Where(x => x.FullName.Contains(name));
                }

                if (search.ContactAreaId != null)
                {
                    long id = search.ContactAreaId;
                    query = query.Where(x => x.ContactArea.Id == id);
                }

                if (search.CreatedOn != null)
                {
                    if (search.CreatedOn.before != null)
                    {
                        DateTimeOffset before = search.CreatedOn.before;
                        query = query.Where(x => x.CreatedOn <= before);
                    }

                    if (search.CreatedOn.after != null)
                    {
                        DateTimeOffset after = search.CreatedOn.after;
                        query = query.Where(x => x.CreatedOn >= after);
                    }
                }
            }

            var contacts = query.ToSmartTableResult(
                param,
                x => new
                {
                    Id = x.Id,
                    FullName = x.FullName,
                    ContactArea = x.ContactArea.Name,
                    CreatedOn = x.CreatedOn,
                    Content = x.Content
                });
            return Json(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var contact = _contactRepository.Query()
               .Include(x => x.ContactArea)
               .FirstOrDefault(x => x.Id == id);

            var model = new ContactForm()
            {
                FullName = contact.FullName,
                PhoneNumber = contact.PhoneNumber,
                EmailAddress = contact.EmailAddress,
                Address = contact.Address,
                Content = contact.Content,
                CreatedOn = contact.CreatedOn,
                ContactArea = contact.ContactArea.Name
            };

            return Json(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var contact = _contactRepository.Query().FirstOrDefault(x => x.Id == id);

            if (contact == null)
            {
                return NotFound();
            }

            contact.IsDeleted = true;
            _contactRepository.SaveChanges();

            return Ok();
        }
    }
}

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Localization;
using SimplCommerce.Module.Contacts.Areas.Contacts.ViewModels;
using SimplCommerce.Module.Contacts.Models;

namespace SimplCommerce.Module.Contacts.Areas.Contacts.Controllers
{
    [Area("Contacts")]
    [Authorize(Roles = "admin")]
    [Route("api/contact-area-translations")]
    public class ContactAreaTranslationApiController : Controller
    {
        private readonly IRepository<ContactArea> _contactAreaRepository;
        private readonly IRepository<LocalizedContentProperty> _localizedContentPropertyRepository;

        public ContactAreaTranslationApiController(IRepository<ContactArea> contactAreaRepository, IRepository<LocalizedContentProperty> localizedContentPropertyRepository)
        {
            _contactAreaRepository = contactAreaRepository;
            _localizedContentPropertyRepository = localizedContentPropertyRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, string culture)
        {
            var contactArea = await _contactAreaRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (contactArea == null)
            {
                return NotFound();
            }

            var entityType = contactArea.GetType().Name;
            var localizeProperties = _localizedContentPropertyRepository.Query().Where(x => x.EntityId == contactArea.Id
                && x.EntityType == entityType && x.CultureId == culture);
            var model = new ContactAreaTranslationForm
            {
                DefaultCultureName = contactArea.Name,
                Name = localizeProperties.FirstOrDefault(x => x.ProperyName == nameof(contactArea.Name))?.Value ?? contactArea.Name,
            };

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, string culture, [FromBody] ContactAreaTranslationForm model)
        {
            if (ModelState.IsValid)
            {
                var contactArea = await _contactAreaRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
                if (contactArea == null)
                {
                    return NotFound();
                }

                var entityType = contactArea.GetType().Name;
                var localizeProperties = _localizedContentPropertyRepository.Query().Where(x => x.EntityId == contactArea.Id
                    && x.EntityType == entityType && x.CultureId == culture);
                var localizedName = CreateOrUpdateTranslation(localizeProperties, contactArea, nameof(contactArea.Name), culture);
                localizedName.Value = model.Name;

                await _localizedContentPropertyRepository.SaveChangesAsync();

                return Accepted();
            }

            return BadRequest(ModelState);
        }

        private LocalizedContentProperty CreateOrUpdateTranslation(IQueryable<LocalizedContentProperty> localizedContentProperties, ContactArea contactArea, string propertyName, string culture)
        {
            var localizedProperty = localizedContentProperties.FirstOrDefault(x => x.ProperyName == propertyName);
            if (localizedProperty == null)
            {
                localizedProperty = new LocalizedContentProperty
                {
                    CultureId = culture,
                    EntityId = contactArea.Id,
                    EntityType = contactArea.GetType().Name,
                    ProperyName = propertyName
                };

                _localizedContentPropertyRepository.Add(localizedProperty);
            }

            return localizedProperty;
        }
    }
}

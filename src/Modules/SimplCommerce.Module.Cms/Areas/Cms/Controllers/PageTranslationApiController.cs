using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Localization;
using SimplCommerce.Module.Cms.Areas.Cms.ViewModels;
using SimplCommerce.Module.Cms.Models;

namespace SimplCommerce.Module.Cms.Areas.Cms.Controllers
{
    [Area("Cms")]
    [Authorize(Roles = "admin")]
    [Route("api/page-translations")]
    public class PageTranslationApiController : Controller
    {
        private readonly IRepository<Page> _pageRepository;
        private readonly IRepository<LocalizedContentProperty> _localizedContentPropertyRepository;

        public PageTranslationApiController(IRepository<Page> pageRepository, IRepository<LocalizedContentProperty> localizedContentPropertyRepository)
        {
            _pageRepository = pageRepository;
            _localizedContentPropertyRepository = localizedContentPropertyRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, string culture)
        {
            var page = await _pageRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (page == null)
            {
                return NotFound();
            }

            var entityType = page.GetType().Name;

            var localizeProperties = _localizedContentPropertyRepository.Query().Where(x => x.EntityId == page.Id
                && x.EntityType == entityType && x.CultureId == culture);

            var model = new PageTranslationForm
            {
                DefaultCultureName = page.Name,
                Name = localizeProperties.FirstOrDefault(x => x.ProperyName == nameof(page.Name))?.Value,
                Body = localizeProperties.FirstOrDefault(x => x.ProperyName == nameof(page.Body))?.Value,
            };

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, string culture, [FromBody] PageTranslationForm model)
        {
            if (ModelState.IsValid)
            {
                var page = await _pageRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
                if (page == null)
                {
                    return NotFound();
                }

                var entityType = page.GetType().Name;

                var localizeProperties = _localizedContentPropertyRepository.Query().Where(x => x.EntityId == page.Id
                    && x.EntityType == entityType && x.CultureId == culture);

                var localizedName = CreateOrUpdateTranslation(localizeProperties, page, nameof(page.Name), culture);
                localizedName.Value = model.Name;

                var localizedDescription = CreateOrUpdateTranslation(localizeProperties, page, nameof(page.Body), culture);
                localizedDescription.Value = model.Body;

                await _localizedContentPropertyRepository.SaveChangesAsync();

                return Accepted();
            }

            return BadRequest(ModelState);
        }

        private LocalizedContentProperty CreateOrUpdateTranslation(IQueryable<LocalizedContentProperty> localizedContentProperties, Page page, string propertyName, string culture)
        {
            var localizedProperty = localizedContentProperties.FirstOrDefault(x => x.ProperyName == propertyName);
            if (localizedProperty == null)
            {
                localizedProperty = new LocalizedContentProperty
                {
                    CultureId = culture,
                    EntityId = page.Id,
                    EntityType = page.GetType().Name,
                    ProperyName = propertyName
                };

                _localizedContentPropertyRepository.Add(localizedProperty);
            }

            return localizedProperty;
        }
    }
}

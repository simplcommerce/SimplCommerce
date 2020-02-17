using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Localization;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    [Authorize(Roles = "admin")]
    [Route("api/category-translations")]
    public class CategoryTranslationApiController : Controller
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<LocalizedContentProperty> _localizedContentPropertyRepository;

        public CategoryTranslationApiController(IRepository<Category> categoryRepository, IRepository<LocalizedContentProperty> localizedContentPropertyRepository)
        {
            _categoryRepository = categoryRepository;
            _localizedContentPropertyRepository = localizedContentPropertyRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, string culture)
        {
            var category = await _categoryRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            var entityType = category.GetType().Name;

            var localizeProperties = _localizedContentPropertyRepository.Query().Where(x => x.EntityId == category.Id
                && x.EntityType == entityType && x.CultureId == culture);

            var model = new CategoryTranslationForm
            {
                DefaultCultureName = category.Name,
                Name = localizeProperties.FirstOrDefault(x => x.ProperyName == nameof(category.Name))?.Value,
                Description = localizeProperties.FirstOrDefault(x => x.ProperyName == nameof(category.Description))?.Value,
            };

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, string culture, [FromBody] CategoryTranslationForm model)
        {
            if (ModelState.IsValid)
            {
                var category = await _categoryRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
                if (category == null)
                {
                    return NotFound();
                }

                var entityType = category.GetType().Name;

                var localizeProperties = _localizedContentPropertyRepository.Query().Where(x => x.EntityId == category.Id
                    && x.EntityType == entityType && x.CultureId == culture);

                var localizedName = CreateOrUpdateTranslation(localizeProperties, category, nameof(category.Name), culture);
                localizedName.Value = model.Name;

                var localizedDescription = CreateOrUpdateTranslation(localizeProperties, category, nameof(category.Description), culture);
                localizedDescription.Value = model.Description;

                await _localizedContentPropertyRepository.SaveChangesAsync();

                return Accepted();
            }

            return BadRequest(ModelState);
        }

        private LocalizedContentProperty CreateOrUpdateTranslation(IQueryable<LocalizedContentProperty> localizedContentProperties, Category category, string propertyName, string culture)
        {
            var localizedProperty = localizedContentProperties.FirstOrDefault(x => x.ProperyName == propertyName);
            if (localizedProperty == null)
            {
                localizedProperty = new LocalizedContentProperty
                {
                    CultureId = culture,
                    EntityId = category.Id,
                    EntityType = category.GetType().Name,
                    ProperyName = propertyName
                };

                _localizedContentPropertyRepository.Add(localizedProperty);
            }

            return localizedProperty;
        }
    }
}

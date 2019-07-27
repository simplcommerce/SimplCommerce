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
    [Route("api/product-translations")]
    public class ProductTranslationApiController : Controller
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<LocalizedContentProperty> _localizedContentPropertyRepository;

        public ProductTranslationApiController(IRepository<Product> productRepository, IRepository<LocalizedContentProperty> localizedContentPropertyRepository)
        {
            _productRepository = productRepository;
            _localizedContentPropertyRepository = localizedContentPropertyRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, string culture)
        {
            var product = await _productRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            var entityType = product.GetType().Name;

            var localizeProperties = _localizedContentPropertyRepository.Query().Where(x => x.EntityId == product.Id
                && x.EntityType == entityType && x.CultureId == culture);

            var model = new ProductTranslationForm
            {
                DefaultCultureName = product.Name,
                Name = localizeProperties.FirstOrDefault(x => x.ProperyName == nameof(product.Name))?.Value,
                ShortDescription = localizeProperties.FirstOrDefault(x => x.ProperyName == nameof(product.ShortDescription))?.Value,
                Description = localizeProperties.FirstOrDefault(x => x.ProperyName == nameof(product.Description))?.Value,
                Specification = localizeProperties.FirstOrDefault(x => x.ProperyName == nameof(product.Specification))?.Value
            };

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, string culture, [FromBody] ProductTranslationForm model)
        {
            if (ModelState.IsValid)
            {
                var product = await _productRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
                if (product == null)
                {
                    return NotFound();
                }

                var entityType = product.GetType().Name;

                var localizeProperties = _localizedContentPropertyRepository.Query().Where(x => x.EntityId == product.Id
                    && x.EntityType == entityType && x.CultureId == culture);

                var localizedName = CreateOrUpdateTranslation(localizeProperties, product, nameof(product.Name), culture);
                localizedName.Value = model.Name;

                var localizedShortDescription = CreateOrUpdateTranslation(localizeProperties, product, nameof(product.ShortDescription), culture);
                localizedShortDescription.Value = model.ShortDescription;

                var localizedDescription = CreateOrUpdateTranslation(localizeProperties, product, nameof(product.Description), culture);
                localizedDescription.Value = model.Description;

                var localizedSpecification = CreateOrUpdateTranslation(localizeProperties, product, nameof(product.Specification), culture);
                localizedSpecification.Value = model.Specification;

                await _localizedContentPropertyRepository.SaveChangesAsync();

                return Accepted();
            }

            return BadRequest(ModelState);
        }

        private LocalizedContentProperty CreateOrUpdateTranslation(IQueryable<LocalizedContentProperty> localizedContentProperties, Product product, string propertyName, string culture)
        {
            var localizedProperty = localizedContentProperties.FirstOrDefault(x => x.ProperyName == propertyName);
            if (localizedProperty == null)
            {
                localizedProperty = new LocalizedContentProperty
                {
                    CultureId = culture,
                    EntityId = product.Id,
                    EntityType = product.GetType().Name,
                    ProperyName = propertyName
                };

                _localizedContentPropertyRepository.Add(localizedProperty);
            }

            return localizedProperty;
        }
    }
}

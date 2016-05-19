using System.Linq;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.Areas.Admin.ViewModels.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Core.Domain.IRepositories;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductTemplateController : Controller
    {
        private readonly IRepository<ProductTemplate> productTemplateRepository;
        private readonly IRepository<ProductAttribute> productAttributeRepository;
        private readonly IProductTemplateProductAttributeRepository productTemplateProductAttributeRepository;

        public ProductTemplateController(IRepository<ProductTemplate> productTemplateRepository, IRepository<ProductAttribute> productAttributeRepository, IProductTemplateProductAttributeRepository productTemplateProductAttributeRepository)
        {
            this.productTemplateRepository = productTemplateRepository;
            this.productAttributeRepository = productAttributeRepository;
            this.productTemplateProductAttributeRepository = productTemplateProductAttributeRepository;
        }

        public IActionResult List()
        {
            var productTemplates = productTemplateRepository
                .Query()
                .Select(x => new 
                {
                    x.Id,
                    x.Name
                });

            return Json(productTemplates);
        }

        public IActionResult Get(long id)
        {
            var productTemplate = productTemplateRepository
                .Query()
                .Include(x => x.ProductAttributes).ThenInclude(x => x.ProductAttribute).ThenInclude(x => x.Group)
                .FirstOrDefault(x => x.Id == id);
            var model = new ProductTemplateFrom
            {
                Id = productTemplate.Id,
                Name = productTemplate.Name,
                Attributes = productTemplate.ProductAttributes.Select(
                    x => new ProductAttributeVm()
                    {
                        Id = x.ProductAttributeId,
                        Name = x.ProductAttribute.Name,
                        GroupName = x.ProductAttribute.Group.Name
                    }).ToList()
            };

            return Json(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductTemplateFrom model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var productTemplate = new ProductTemplate
            {
                Name = model.Name
            };

            foreach (var attributeVm in model.Attributes)
            {
                productTemplate.AddAttribute(attributeVm.Id);
            }

            productTemplateRepository.Add(productTemplate);
            productAttributeRepository.SaveChange();

            return Ok();
        }

        [HttpPost]
        public IActionResult Edit(long id, [FromBody] ProductTemplateFrom model)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            var productTemplate = productTemplateRepository
                .Query()
                .Include(x => x.ProductAttributes)
                .FirstOrDefault(x => x.Id == id);

            productTemplate.Name = model.Name;

            foreach (var attribute in model.Attributes)
            {
                if (productTemplate.ProductAttributes.Any(x => x.ProductAttributeId == attribute.Id))
                {
                    continue;
                }

                productTemplate.AddAttribute(attribute.Id);
            }

            var deletedAttributes = productTemplate.ProductAttributes.Where(attr => !model.Attributes.Select(x => x.Id).Contains(attr.ProductAttributeId));

            foreach (var deletedAttribute in deletedAttributes)
            {
                deletedAttribute.ProductTemplate = null;
                productTemplateProductAttributeRepository.Remove(deletedAttribute);
            }

            productAttributeRepository.SaveChange();

            return Ok();
        }
    }
}

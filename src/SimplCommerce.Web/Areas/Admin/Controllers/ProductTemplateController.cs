using System.Linq;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.Areas.Admin.ViewModels.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductTemplateController : Controller
    {
        private readonly IRepository<ProductTemplate> productTemplateRepository;
        private readonly IRepository<ProductAttribute> productAttributeRepository;

        public ProductTemplateController(IRepository<ProductTemplate> productTemplateRepository, IRepository<ProductAttribute> productAttributeRepository)
        {
            this.productTemplateRepository = productTemplateRepository;
            this.productAttributeRepository = productAttributeRepository;
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
                .Include(x => x.ProductAttributes).ThenInclude(x => x.ProductAttribute)
                .FirstOrDefault(x => x.Id == id);
            var model = new ProductTemplateFrom
            {
                Id = productTemplate.Id,
                Name = productTemplate.Name,
                Attributes = productTemplate.ProductAttributes.Select(
                    x => new ProductAttributeVm()
                    {
                        Id = x.ProductAttributeId,
                        Name = x.ProductAttribute.Name
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

            productTemplate.ProductAttributes.Clear();
            foreach (var attributeVm in model.Attributes)
            {
                productTemplate.AddAttribute(attributeVm.Id);
            }

            productAttributeRepository.SaveChange();

            return Ok();
        }
    }
}

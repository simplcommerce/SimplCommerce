using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.ViewModels;

namespace SimplCommerce.Module.Catalog.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/product-attribute-groups")]
    public class ProductAttributeGroupApiController : Controller
    {
        private IRepository<ProductAttributeGroup> _productAttrGroupRepository;

        public ProductAttributeGroupApiController(IRepository<ProductAttributeGroup> productAttrGroupRepository)
        {
            _productAttrGroupRepository = productAttrGroupRepository;
        }

        public IActionResult Get()
        {
            var attributeGroups = _productAttrGroupRepository
                .Query()
                .Select(x => new ProductAttributeGroupFormVm
                {
                    Id = x.Id,
                    Name = x.Name
                });

            return Json(attributeGroups);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var productAttributeGroup = _productAttrGroupRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new ProductAttributeGroupFormVm
            {
                Id = productAttributeGroup.Id,
                Name = productAttributeGroup.Name
            };

            return Json(model);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ProductAttributeGroupFormVm model)
        {
            if (ModelState.IsValid)
            {
                var productAttributeGroup = new ProductAttributeGroup
                {
                    Name = model.Name
                };

                _productAttrGroupRepository.Add(productAttributeGroup);
                _productAttrGroupRepository.SaveChange();

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ProductAttributeGroupFormVm model)
        {
            if (ModelState.IsValid)
            {
                var productAttributeGroup = _productAttrGroupRepository.Query().FirstOrDefault(x => x.Id == id);
                productAttributeGroup.Name = model.Name;

                _productAttrGroupRepository.SaveChange();

                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var productAttributeGroup = _productAttrGroupRepository.Query().FirstOrDefault(x => x.Id == id);
            if (productAttributeGroup == null)
            {
                return new NotFoundResult();
            }

            _productAttrGroupRepository.Remove(productAttributeGroup);
            return Json(true);
        }
    }
}

using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.Areas.Admin.ViewModels.Products;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductAttributeGroupController : Controller
    {
        private IRepository<ProductAttributeGroup> _productAttrGroupRepository;

        public ProductAttributeGroupController(IRepository<ProductAttributeGroup> productAttrGroupRepository)
        {
            _productAttrGroupRepository = productAttrGroupRepository;
        }

        public IActionResult List()
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
        public IActionResult Create([FromBody] ProductAttributeGroupFormVm model)
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

        [HttpPost]
        public IActionResult Edit(long id, [FromBody] ProductOptionFormVm model)
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

        [HttpPost]
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

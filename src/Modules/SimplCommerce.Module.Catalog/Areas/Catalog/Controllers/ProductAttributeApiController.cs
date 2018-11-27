using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Models;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    [Authorize(Roles = "admin, vendor")]
    [Route("api/product-attributes")]
    public class ProductAttributeApiController : Controller
    {
        private readonly IRepository<ProductAttribute> _productAttrRepository;

        public ProductAttributeApiController(IRepository<ProductAttribute> productAttrRepository)
        {
            _productAttrRepository = productAttrRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            var attributes = _productAttrRepository
                .Query()
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    GroupName = x.Group.Name
                });

            return Json(attributes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var productAttribute = _productAttrRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new ProductAttributeFormVm
            {
                Id = productAttribute.Id,
                Name = productAttribute.Name,
                GroupId = productAttribute.GroupId
            };

            return Json(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post([FromBody] ProductAttributeFormVm model)
        {
            if (ModelState.IsValid)
            {
                var productAttribute = new ProductAttribute
                {
                    Name = model.Name,
                    GroupId = model.GroupId
                };

                _productAttrRepository.Add(productAttribute);
                _productAttrRepository.SaveChanges();

                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Put(long id, [FromBody] ProductAttributeFormVm model)
        {
            if (ModelState.IsValid)
            {
                var productAttribute = _productAttrRepository.Query().FirstOrDefault(x => x.Id == id);
                productAttribute.Name = model.Name;
                productAttribute.GroupId = model.GroupId;

                _productAttrRepository.SaveChanges();

                return Ok();
            }

            return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(long id)
        {
            var productAttribute = _productAttrRepository.Query().FirstOrDefault(x => x.Id == id);
            if (productAttribute == null)
            {
                return NotFound();
            }

            _productAttrRepository.Remove(productAttribute);
            return Json(true);
        }
    }
}

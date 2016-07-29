using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.ViewModels;

namespace SimplCommerce.Module.Catalog.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/product-attributes")]
    public class ProductAttributeApiController : Controller
    {
        private readonly IRepository<ProductAttribute> _productAttrRepository;

        public ProductAttributeApiController(IRepository<ProductAttribute> productAttrRepository)
        {
            _productAttrRepository = productAttrRepository;
        }

        public IActionResult List()
        {
            var attributes = _productAttrRepository
                .Query()
                .Include(x => x.Group)
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
                _productAttrRepository.SaveChange();

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] ProductAttributeFormVm model)
        {
            if (ModelState.IsValid)
            {
                var productAttribute = _productAttrRepository.Query().FirstOrDefault(x => x.Id == id);
                productAttribute.Name = model.Name;
                productAttribute.GroupId = model.GroupId;

                _productAttrRepository.SaveChange();

                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var productAttribute = _productAttrRepository.Query().FirstOrDefault(x => x.Id == id);
            if (productAttribute == null)
            {
                return new NotFoundResult();
            }

            _productAttrRepository.Remove(productAttribute);
            return Json(true);
        }
    }
}

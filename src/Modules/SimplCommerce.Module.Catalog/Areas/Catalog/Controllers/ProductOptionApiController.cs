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
    [Route("api/product-options")]
    public class ProductOptionApiController : Controller
    {
        private readonly IRepository<ProductOption> _productOptionRepository;

        public ProductOptionApiController(IRepository<ProductOption> productOptionRepository)
        {
            _productOptionRepository = productOptionRepository;
        }

        public IActionResult Get()
        {
            var options = _productOptionRepository.Query();
            return Json(options);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var productOption = _productOptionRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new ProductOptionFormVm
            {
                Id = productOption.Id,
                Name = productOption.Name
            };

            return Json(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post([FromBody] ProductOptionFormVm model)
        {
            if (ModelState.IsValid)
            {
                var productOption = new ProductOption
                {
                    Name = model.Name
                };

                _productOptionRepository.Add(productOption);
                _productOptionRepository.SaveChanges();

                return Ok();
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Put(long id, [FromBody] ProductOptionFormVm model)
        {
            if (ModelState.IsValid)
            {
                var productOption = _productOptionRepository.Query().FirstOrDefault(x => x.Id == id);
                productOption.Name = model.Name;

                _productOptionRepository.SaveChanges();

                return Ok();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(long id)
        {
            var productOption = _productOptionRepository.Query().FirstOrDefault(x => x.Id == id);
            if (productOption == null)
            {
                return NotFound();
            }

            _productOptionRepository.Remove(productOption);
            return Json(true);
        }
    }
}

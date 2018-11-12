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
    [Route("api/product-clone")]
    public class ProductCloneApiController : Controller
    {
        private readonly IRepository<Product> _productRepository;

        public ProductCloneApiController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var product = _productRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new ProductCloneFormVm
            {
                Id = product.Id,
                Name = product.Name
            };

            return Json(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post([FromBody] ProductCloneFormVm model)
        {
            if (ModelState.IsValid)
            {
                var producctId = model.Id;
                var productNmae = model.Name;

                //Save into database

                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}

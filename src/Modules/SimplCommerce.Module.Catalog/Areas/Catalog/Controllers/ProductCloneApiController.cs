using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Core.Extensions;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    [Authorize(Roles = "admin, vendor")]
    [Route("api/product-clone")]
    public class ProductCloneApiController : Controller
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IWorkContext _workContext;

        public ProductCloneApiController(IRepository<Product> productRepository, IWorkContext workContext)
        {
            _productRepository = productRepository;
            _workContext = workContext;
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
        public async Task<IActionResult> Post([FromBody] ProductCloneFormVm model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _workContext.GetCurrentUser();
                var producctId = model.Id;
                var productNmae = model.Name;
                var product = _productRepository.Query().FirstOrDefault(x => x.Id == producctId);
                if (product != null)
                {
                    var newProduct = product.Clone();
                    newProduct.Name = productNmae;
                    newProduct.CreatedById = currentUser.Id;
                    newProduct.LatestUpdatedById = currentUser.Id;
                    newProduct.CreatedOn = DateTimeOffset.Now;
                    newProduct.LatestUpdatedOn = DateTimeOffset.Now;
                    _productRepository.Add(newProduct);
                    _productRepository.SaveChanges();

                    return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, null);
                }
            }
            return BadRequest(ModelState);
        }
    }
}

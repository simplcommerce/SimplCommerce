using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.Areas.Admin.ViewModels.Products;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductAttributeController : Controller
    {
        private readonly IRepository<ProductAttribute> productAttrRepository;

        public ProductAttributeController(IRepository<ProductAttribute> productAttrRepository)
        {
            this.productAttrRepository = productAttrRepository;
        }

        public IActionResult List()
        {
            var attributes = productAttrRepository
                .Query()
                .Include(x => x.Group)
                .Select(x => new ProductAttributeVm
                {
                    Id = x.Id,
                    Name = x.Name,
                    GroupName = x.Group.Name
                });

            return Json(attributes);
        }

        public IActionResult Get(long id)
        {
            var productAttribute = productAttrRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new ProductAttributeFormVm
            {
                Id = productAttribute.Id,
                Name = productAttribute.Name,
                GroupId = productAttribute.GroupId
            };

            return Json(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductAttributeFormVm model)
        {
            if (ModelState.IsValid)
            {
                var productAttribute = new ProductAttribute
                {
                    Name = model.Name,
                    GroupId = model.GroupId
                };

                productAttrRepository.Add(productAttribute);
                productAttrRepository.SaveChange();

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost]
        public IActionResult Edit(long id, [FromBody] ProductAttributeFormVm model)
        {
            if (ModelState.IsValid)
            {
                var productAttribute = productAttrRepository.Query().FirstOrDefault(x => x.Id == id);
                productAttribute.Name = model.Name;
                productAttribute.GroupId = model.GroupId;

                productAttrRepository.SaveChange();

                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            var productAttribute = productAttrRepository.Query().FirstOrDefault(x => x.Id == id);
            if (productAttribute == null)
            {
                return new NotFoundResult();
            }

            productAttrRepository.Remove(productAttribute);
            return Json(true);
        }
    }
}
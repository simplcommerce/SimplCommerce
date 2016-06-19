using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.Areas.Admin.ViewModels.Products;
using System.Linq;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ProductOptionController : Controller
    {
        private readonly IRepository<ProductOption> productOptionRepository;

        public ProductOptionController(IRepository<ProductOption> productOptionRepository)
        {
            this.productOptionRepository = productOptionRepository;
        }

        public IActionResult List()
        {
            var options = productOptionRepository.Query();
            return Json(options);
        }

        public IActionResult Get(long id)
        {
            var productOption = productOptionRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new ProductOptionFormVm
            {
                Id = productOption.Id,
                Name = productOption.Name
            };

            return Json(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ProductOptionFormVm model)
        {
            if (ModelState.IsValid)
            {
                var productOption = new ProductOption
                {
                    Name = model.Name
                };

                productOptionRepository.Add(productOption);
                productOptionRepository.SaveChange();

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost]
        public IActionResult Edit(long id, [FromBody] ProductOptionFormVm model)
        {
            if (ModelState.IsValid)
            {
                var productOption = productOptionRepository.Query().FirstOrDefault(x => x.Id == id);
                productOption.Name = model.Name;

                productOptionRepository.SaveChange();

                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            var productOption = productOptionRepository.Query().FirstOrDefault(x => x.Id == id);
            if (productOption == null)
            {
                return new NotFoundResult();
            }

            productOptionRepository.Remove(productOption);
            return Json(true);
        }
    }
}

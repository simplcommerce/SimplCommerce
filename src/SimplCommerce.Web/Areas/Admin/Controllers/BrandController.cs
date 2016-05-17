using System.Linq;
using SimplCommerce.Core.ApplicationServices;
using SimplCommerce.Core.Domain.Models;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Domain.IRepositories;
using SimplCommerce.Web.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SimplCommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class BrandController : Controller
    {
        private readonly IRepository<Brand> brandRepository;
        private readonly IBrandService brandService;

        public BrandController(IRepository<Brand> brandRepository, IBrandService brandService)
        {
            this.brandRepository = brandRepository;
            this.brandService = brandService;
        }

        public IActionResult List()
        {
            var brandList = brandRepository.Query().Where(x => !x.IsDeleted).ToList();

            return Json(brandList);
        }

        public IActionResult Get(long id)
        {
            var brand = brandRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new BrandForm
            {
                Id = brand.Id,
                Name = brand.Name,
                IsPublished = brand.IsPublished
            };

            return Json(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] BrandForm model)
        {
            if (ModelState.IsValid)
            {
                var brand = new Brand
                {
                    Name = model.Name,
                    SeoTitle = StringHelper.ToUrlFriendly(model.Name),
                    IsPublished = model.IsPublished
                };

                brandService.Create(brand);

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost]
        public IActionResult Edit(long id, [FromBody] BrandForm model)
        {
            if (ModelState.IsValid)
            {
                var brand = brandRepository.Query().FirstOrDefault(x => x.Id == id);
                brand.Name = model.Name;
                brand.SeoTitle = StringHelper.ToUrlFriendly(model.Name);
                brand.IsPublished = model.IsPublished;

                brandService.Update(brand);

                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            var brand = brandRepository.Query().FirstOrDefault(x => x.Id == id);
            if (brand == null)
            {
                return new NotFoundResult();
            }

            brandService.Delete(brand);
            return Json(true);
        }
    }
}
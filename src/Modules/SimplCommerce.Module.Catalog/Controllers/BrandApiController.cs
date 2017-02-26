using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;
using SimplCommerce.Module.Catalog.ViewModels;

namespace SimplCommerce.Module.Catalog.Controllers
{
    [Authorize(Roles = "admin, vendor")]
    [Route("api/brands")]
    public class BrandApiController : Controller
    {
        private readonly IRepository<Brand> _brandRepository;
        private readonly IBrandService _brandService;

        public BrandApiController(IRepository<Brand> brandRepository, IBrandService brandService)
        {
            _brandRepository = brandRepository;
            _brandService = brandService;
        }

        public IActionResult Get()
        {
            var brandList = _brandRepository.Query().Where(x => !x.IsDeleted).ToList();

            return Json(brandList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var brand = _brandRepository.Query().FirstOrDefault(x => x.Id == id);
            var model = new BrandForm
            {
                Id = brand.Id,
                Name = brand.Name,
                IsPublished = brand.IsPublished
            };

            return Json(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Post([FromBody] BrandForm model)
        {
            if (ModelState.IsValid)
            {
                var brand = new Brand
                {
                    Name = model.Name,
                    SeoTitle = model.Name.ToUrlFriendly(),
                    IsPublished = model.IsPublished
                };

                _brandService.Create(brand);

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Put(long id, [FromBody] BrandForm model)
        {
            if (ModelState.IsValid)
            {
                var brand = _brandRepository.Query().FirstOrDefault(x => x.Id == id);
                brand.Name = model.Name;
                brand.SeoTitle = model.Name.ToUrlFriendly();
                brand.IsPublished = model.IsPublished;

                _brandService.Update(brand);

                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public IActionResult Delete(long id)
        {
            var brand = _brandRepository.Query().FirstOrDefault(x => x.Id == id);
            if (brand == null)
            {
                return new NotFoundResult();
            }

            _brandService.Delete(brand);
            return Json(true);
        }
    }
}

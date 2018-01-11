using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Get()
        {
            var brandList = await _brandRepository.Query().Where(x => !x.IsDeleted).ToListAsync();

            return Json(brandList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var brand = await _brandRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            var model = new BrandForm
            {
                Id = brand.Id,
                Name = brand.Name,
                Slug = brand.SeoTitle,
                IsPublished = brand.IsPublished
            };

            return Json(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] BrandForm model)
        {
            if (ModelState.IsValid)
            {
                var brand = new Brand
                {
                    Name = model.Name,
                    SeoTitle = model.Slug,
                    IsPublished = model.IsPublished
                };

                await _brandService.Create(brand);
                return CreatedAtAction(nameof(Get), new { id = brand.Id }, null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put(long id, [FromBody] BrandForm model)
        {
            if (ModelState.IsValid)
            {
                var brand = _brandRepository.Query().FirstOrDefault(x => x.Id == id);
                if(brand == null)
                {
                    return NotFound();
                }

                brand.Name = model.Name;
                brand.SeoTitle = model.Slug;
                brand.IsPublished = model.IsPublished;

                await _brandService.Update(brand);
                return Accepted();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(long id)
        {
            var brand = _brandRepository.Query().FirstOrDefault(x => x.Id == id);
            if (brand == null)
            {
                return NotFound();
            }

            await _brandService.Delete(brand);
            return NoContent();
        }
    }
}

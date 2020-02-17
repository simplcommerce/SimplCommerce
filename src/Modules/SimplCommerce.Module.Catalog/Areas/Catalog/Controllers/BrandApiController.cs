using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Catalog.Areas.Catalog.ViewModels;
using SimplCommerce.Module.Catalog.Models;
using SimplCommerce.Module.Catalog.Services;

namespace SimplCommerce.Module.Catalog.Areas.Catalog.Controllers
{
    [Area("Catalog")]
    [Authorize(Roles = "admin, vendor")]
    [Route("api/brands")]
    [ApiController]
    public class BrandApiController : ControllerBase
    {
        private readonly IRepository<Brand> _brandRepository;
        private readonly IBrandService _brandService;

        public BrandApiController(IRepository<Brand> brandRepository, IBrandService brandService)
        {
            _brandRepository = brandRepository;
            _brandService = brandService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<BrandVm>>> Get()
        {
            var brands = await _brandRepository.Query()
            .Where(x => !x.IsDeleted)
            .Select(x =>  new BrandVm
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                IsPublished = x.IsPublished
            }).ToListAsync();

            return brands;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrandVm>> Get(long id)
        {
            var brand = await _brandRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if(brand == null)
            {
                return NotFound();
            }

            var model = new BrandVm
            {
                Id = brand.Id,
                Name = brand.Name,
                Slug = brand.Slug,
                IsPublished = brand.IsPublished
            };

            return model;
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] BrandForm model)
        {
            var brand = new Brand
            {
                Name = model.Name,
                Slug = model.Slug,
                IsPublished = model.IsPublished
            };

            await _brandService.Create(brand);
            return CreatedAtAction(nameof(Get), new { id = brand.Id }, null);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Put(long id, [FromBody] BrandForm model)
        {
            var brand = _brandRepository.Query().FirstOrDefault(x => x.Id == id);
            if(brand == null)
            {
                return NotFound();
            }

            brand.Name = model.Name;
            brand.Slug = model.Slug;
            brand.IsPublished = model.IsPublished;

            await _brandService.Update(brand);
            return Accepted();
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

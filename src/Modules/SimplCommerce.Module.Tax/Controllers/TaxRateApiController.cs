using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Tax.Models;
using SimplCommerce.Module.Tax.ViewModels;

namespace SimplCommerce.Module.Tax.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/tax-rates")]
    public class TaxRateApiController : Controller
    {
        private readonly IRepository<TaxRate> _taxRateRepository;

        public TaxRateApiController(IRepository<TaxRate> taxRateRepository)
        {
            _taxRateRepository = taxRateRepository;
        }

        public async Task<IActionResult> Get()
        {
            var taxRates = await _taxRateRepository
                .Query()
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    TagClassName = x.TaxClass.Name,
                    CountryName = x.Country.Name,
                    StateOrProvinceName = x.StateOrProvince.Name,
                    Rate = x.Rate
                })
                .ToListAsync();
            return Json(taxRates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var taxRate = await _taxRateRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if(taxRate == null)
            {
                return NotFound();
            }

            var model = new TaxRateForm
            {
                Id = taxRate.Id,
                Name = taxRate.Name,
                TaxClassId = taxRate.TaxClassId,
                CountryId = taxRate.CountryId,
                StateOrProvinceId = taxRate.StateOrProvinceId,
                Rate = taxRate.Rate
            };

            return Json(model);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaxRateForm model)
        {
            if (ModelState.IsValid)
            {
                var tagRate = new TaxRate
                {
                    Name = model.Name,
                    TaxClassId = model.TaxClassId,
                    CountryId = model.CountryId,
                    StateOrProvinceId = model.StateOrProvinceId,
                    Rate = model.Rate
                };

                _taxRateRepository.Add(tagRate);
                await _taxRateRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = tagRate.Id }, null);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] TaxRateForm model)
        {
            if (ModelState.IsValid)
            {
                var taxRate = await _taxRateRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
                if (taxRate == null)
                {
                    return NotFound();
                }

                taxRate.Name = model.Name;
                taxRate.TaxClassId = model.TaxClassId;
                taxRate.CountryId = model.CountryId;
                taxRate.StateOrProvinceId = model.StateOrProvinceId;
                taxRate.Rate = model.Rate;

                await _taxRateRepository.SaveChangesAsync();
                return Accepted();
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var taxRate = await _taxRateRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (taxRate == null)
            {
                return NotFound();
            }

            try
            {
                _taxRateRepository.Remove(taxRate);
                await _taxRateRepository.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest(new { Error = $"The tax rate {taxRate.Name} can't not be deleted because it is referenced by other tables" });
            }

            return NoContent();
        }
    }
}

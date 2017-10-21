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
            var taxRates = await _taxRateRepository.Query().ToListAsync();
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
                    Name = model.Name
                };

                _taxRateRepository.Add(tagRate);
                await _taxRateRepository.SaveChangesAsync();

                return Ok();
            }
            return new BadRequestObjectResult(ModelState);
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
                await _taxRateRepository.SaveChangesAsync();
                return Ok();
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var taxRate = await _taxRateRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (taxRate == null)
            {
                return NotFound();
            }

            _taxRateRepository.Remove(taxRate);
            await _taxRateRepository.SaveChangesAsync();
            return Ok();
        }
    }
}

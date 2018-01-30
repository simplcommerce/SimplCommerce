using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Infrastructure.Web.SmartTable;
using SimplCommerce.Module.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace SimplCommerce.Module.Core.Controllers
{
    [Route("api/countries")]
    public class CountryApiController : Controller
    {
        private readonly IRepository<Country> _countryRepository;

        public CountryApiController(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IActionResult> Get([FromQuery]bool? shippingEnabled)
        {
            var query = _countryRepository.Query();
            if (shippingEnabled.HasValue)
            {
                query = query.Where(x => x.IsShippingEnabled == shippingEnabled.Value);
            }
            var countries = await query
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToListAsync();
            return Json(countries);
        }

        [HttpPost("grid")]
        public IActionResult List([FromBody] SmartTableParam param)
        {
            var query = _countryRepository.Query();

            if (param.Search.PredicateObject != null)
            {
                dynamic search = param.Search.PredicateObject;

                if (search.Name != null)
                {
                    string name = search.Name;
                    query = query.Where(x => x.Name.Contains(name));
                }
            }

            var countries = query.ToSmartTableResult(
                param,
                c => new
                {
                    c.Id,
                    c.Name,
                    c.IsShippingEnabled,
                    c.IsBillingEnabled
                });

            return Json(countries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var country = await _countryRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            var model = new CountryForm
            {
                Id = country.Id,
                Name = country.Name,
                Code2 = country.Code2,
                Code3 = country.Code3,
                IsBillingEnabled = country.IsBillingEnabled,
                IsShippingEnabled = country.IsShippingEnabled,
            };

            return Json(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] CountryForm model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var country = await _countryRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            country.Name = model.Name;
            country.Code2 = model.Code2;
            country.Code3 = model.Code3;
            country.IsShippingEnabled = model.IsShippingEnabled;
            country.IsBillingEnabled = model.IsBillingEnabled;

            await _countryRepository.SaveChangesAsync();

            return Accepted();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Post([FromBody] CountryForm model)
        {
            if (ModelState.IsValid)
            {
                var country = new Country
                {
                    Name = model.Name,
                    Code2 = model.Code2,
                    Code3 = model.Code3,
                    IsBillingEnabled = model.IsBillingEnabled,
                    IsShippingEnabled = model.IsShippingEnabled
                };

                _countryRepository.Add(country);
                await _countryRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { id = country.Id }, null);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(long id)
        {
            var country = await _countryRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            try
            {
                _countryRepository.Remove(country);
                await _countryRepository.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return BadRequest(new { Error = $"The country {country.Name} can't not be deleted because it is referenced by other tables" });
            }

            return NoContent();
        }
    }
}

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.ShippingTableRate.Models;
using SimplCommerce.Module.ShippingTableRate.ViewModels;

namespace SimplCommerce.Module.ShippingTableRate.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/shippings/table-rate/price-destinations")]
    public class PriceAndDestinationApiController : Controller
    {
        private readonly IRepository<PriceAndDestination> _priceAndDestinationRepository;

        public PriceAndDestinationApiController(IRepository<PriceAndDestination> priceAndDestinationRepository)
        {
            _priceAndDestinationRepository = priceAndDestinationRepository;
        }

        public async Task<IActionResult> Get()
        {
            var items = await _priceAndDestinationRepository.Query()
                .Select(x => new PriceAndDestinationForm
                {
                    Id = x.Id,
                    CountryId = x.CountryId,
                    CountryName = x.Country.Name,
                    StateOrProvinceId = x.StateOrProvinceId,
                    StateOrProvinceName = x.StateOrProvince.Name,
                    MinOrderSubtotal = x.MinOrderSubtotal,
                    ShippingPrice = x.ShippingPrice,
                    Note = x.Note
                }).ToListAsync();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            var returnModel = await _priceAndDestinationRepository.Query().Where(x => x.Id == id).Select(x => new PriceAndDestinationForm
            {
                Id = x.Id,
                CountryId = x.CountryId,
                CountryName = x.Country.Name,
                StateOrProvinceId = x.StateOrProvinceId,
                StateOrProvinceName = x.StateOrProvince.Name,
                MinOrderSubtotal = x.MinOrderSubtotal,
                ShippingPrice = x.ShippingPrice,
                Note = x.Note
            }).FirstOrDefaultAsync();
            return Ok(returnModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PriceAndDestinationForm model)
        {
            if (ModelState.IsValid)
            {
                var priceAndDestination = new PriceAndDestination
                {
                    CountryId = model.CountryId,
                    StateOrProvinceId = model.StateOrProvinceId,
                    MinOrderSubtotal = model.MinOrderSubtotal,
                    ShippingPrice = model.ShippingPrice,
                    Note = model.Note
                };

                _priceAndDestinationRepository.Add(priceAndDestination);
                await _priceAndDestinationRepository.SaveChangesAsync();
                return await Get(priceAndDestination.Id);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] PriceAndDestinationForm model)
        {
            if (ModelState.IsValid)
            {
                var priceAndDestination = await _priceAndDestinationRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
                if (priceAndDestination == null)
                {
                    return NotFound();
                }

                priceAndDestination.CountryId = model.CountryId;
                priceAndDestination.StateOrProvinceId = model.StateOrProvinceId;
                priceAndDestination.ShippingPrice = model.ShippingPrice;
                priceAndDestination.MinOrderSubtotal = model.MinOrderSubtotal;
                priceAndDestination.Note = model.Note;
                await _priceAndDestinationRepository.SaveChangesAsync();
                return await Get(priceAndDestination.Id);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var priceAndDestination = await _priceAndDestinationRepository.Query().FirstOrDefaultAsync(x => x.Id == id);
            if (priceAndDestination == null)
            {
                return NotFound();
            }

            _priceAndDestinationRepository.Remove(priceAndDestination);
            await _priceAndDestinationRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}

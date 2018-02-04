using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Controllers
{
    [Route("api/location")]
    public class LocationController : Controller
    {
        private readonly IRepository<District> districtRepository;

        public LocationController(IRepository<District> districtRepository)
        {
            this.districtRepository = districtRepository;
        }

        [Route("location/getdistricts/{stateOrProvinceId}")]
        public IActionResult GetDistricts(long stateOrProvinceId)
        {
            var districts = districtRepository
                .Query()
                .Where(x => x.StateOrProvinceId == stateOrProvinceId)
                .OrderBy(x => x.Name)
                .Select(x => new
                {
                    Text = x.Name,
                    Value = x.Id.ToString()
                }).ToList();

            return Json(districts);
        }

        [Route("districts")]
        public IActionResult Get(long? stateOrProvinceId)
        {
            var districts = districtRepository.Query();

            if (stateOrProvinceId.HasValue)
            {
                districts = districts.Where(d => d.StateOrProvinceId == stateOrProvinceId.GetValueOrDefault());
            }

            if (!districts.Any())
            {
                return NotFound();
            }

            districts = districts.OrderBy(x => x.Name);

            return Json(districts.Select(d=> new { d.Id, d.Name }).ToList());
        }
    }
}

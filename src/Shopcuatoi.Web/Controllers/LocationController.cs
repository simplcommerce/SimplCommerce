using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using Shopcuatoi.Core.ApplicationServices;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure.Domain.IRepositories;

namespace Shopcuatoi.Web.Controllers
{
    public class LocationController : Controller
    {
        private readonly IRepository<District> districtRepository;
        private readonly IRepository<TempWard> tempWardRepository;

        public LocationController(IRepository<District> districtRepository, IRepository<TempWard> tempWardRepository)
        {
            this.districtRepository = districtRepository;
            this.tempWardRepository = tempWardRepository;
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

        public IActionResult Import()
        {
            var filePath = Path.Combine(GlobalConfiguration.ApplicationPath, "SampleData", "wards.txt");
            var text = System.IO.File.ReadAllText(filePath);

            var model = JsonConvert.DeserializeObject<IList<Temp>>(text);

            foreach (var item in model)
            {
                foreach (var ward in item.Wards.Children)
                {
                    var tempWard = new TempWard
                    {
                        DistrictId = item.District.DistrictId,
                        DistrictName = item.District.DistrictName,
                        ProvinceName = item.District.Province,
                        WardId = ward.Id,
                        WardName = ward.Name
                    };

                    tempWardRepository.Add(tempWard);
                }
            }
            tempWardRepository.SaveChange();
            return Ok();
        }
    }

    public class Temp
    {
        public TempDistrict District { get; set; }

        public TempWards Wards { get; set; }
    }

    public class TempDistrict
    {
        public string Province { get; set; }

        public long DistrictId { get; set; }

        public string DistrictName { get; set; }
    }

    public class TempWards
    {
        public IList<TempChildren> Children { get; set; } = new List<TempChildren>();
    }

    public class TempChildren
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
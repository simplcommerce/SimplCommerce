using System.Linq;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Shopcuatoi.Core.ApplicationServices;
using Shopcuatoi.Core.Domain.Models;
using Shopcuatoi.Infrastructure;
using Shopcuatoi.Infrastructure.Domain.IRepositories;
using Shopcuatoi.Web.Areas.Admin.ViewModels;
using Shopcuatoi.Web.Extensions;

namespace Shopcuatoi.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class ManufacturerController : Controller
    {
        private readonly IRepository<Manufacturer> manufacturerRepository;
        private readonly IManufacturerService manufacturerService;
        private readonly IUrlSlugService urlSlugService;

        public ManufacturerController(IRepository<Manufacturer> manufacturerRepository,
            IManufacturerService manufacturerService, IUrlSlugService urlSlugService)
        {
            this.manufacturerRepository = manufacturerRepository;
            this.manufacturerService = manufacturerService;
            this.urlSlugService = urlSlugService;
        }

        public IActionResult List()
        {
            var manufacturerList = manufacturerRepository.Query().Where(x => !x.IsDeleted).ToList();

            return Json(manufacturerList);
        }

        public IActionResult Get(long id)
        {
            var manufacturer = manufacturerRepository.Get(id);
            var model = new ManufacturerForm
            {
                Id = manufacturer.Id,
                Name = manufacturer.Name,
                IsPublished = manufacturer.IsPublished
            };

            return Json(model);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ManufacturerForm model)
        {
            if (ModelState.IsValid)
            {
                var manufacturer = new Manufacturer
                {
                    Name = model.Name,
                    SeoTitle = StringHelper.ToUrlFriendly(model.Name),
                    IsPublished = model.IsPublished
                };

                manufacturerRepository.Add(manufacturer);
                manufacturerRepository.SaveChange();

                urlSlugService.Add(manufacturer.SeoTitle, manufacturer.Id, "Manufacturer");
                manufacturerRepository.SaveChange();

                return Ok();
            }
            return Json(ModelState.ToDictionary());
        }

        [HttpPost]
        public IActionResult Edit(long id, [FromBody] ManufacturerForm model)
        {
            if (ModelState.IsValid)
            {
                var manufacturer = manufacturerRepository.Get(id);
                manufacturer.Name = model.Name;
                manufacturer.SeoTitle = StringHelper.ToUrlFriendly(model.Name);
                manufacturer.IsPublished = model.IsPublished;

                urlSlugService.Update(manufacturer.SeoTitle, manufacturer.Id, "Manufacturer");

                manufacturerRepository.SaveChange();

                return Ok();
            }

            return Json(ModelState.ToDictionary());
        }

        [HttpPost]
        public IActionResult Delete(long id)
        {
            var manufacturer = manufacturerRepository.Get(id);
            if (manufacturer == null)
            {
                return new HttpStatusCodeResult(400);
            }

            manufacturerService.Delete(manufacturer);
            urlSlugService.Remove(manufacturer.Id, "Manufacturer");
            manufacturerRepository.SaveChange();

            return Json(true);
        }
    }
}
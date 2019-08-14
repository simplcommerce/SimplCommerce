using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Core.Areas.Core.ViewModels;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Inventory.Areas.Inventory.ViewModels;
using SimplCommerce.Module.Inventory.Models;

namespace SimplCommerce.Module.Cms.Areas.Inventory.Components
{
    public class WarehouseViewComponent : ViewComponent
    {
        private readonly IMediaService _mediaService;
        private readonly IRepository<Warehouse> _warehouseRepository;

        public WarehouseViewComponent(IMediaService mediaService,
            IRepository<Warehouse> warehouseRepository)
        {
            _mediaService = mediaService;
            _warehouseRepository = warehouseRepository;
        }

        public IViewComponentResult Invoke(long warehouseId)
        {
            var warehouse = _warehouseRepository.Query()
                .Include(x => x.Address)//.ThenInclude(x => x.Country)
                .Include(x => x.Media)
                .FirstOrDefault(x => x.Id == warehouseId);

            if (warehouse == null)
            {
                throw new System.Exception();
            }

            var model = new WarehouseViewComponentVm
            {
                Name = warehouse.Name,
                AddressLine1 = warehouse.Address.AddressLine1,
                AddressLine2 = warehouse.Address.AddressLine2,
                City = warehouse.Address.City,
                CountryCode = warehouse.Address.CountryId,
                PhoneNumber = warehouse.Address.Phone,
                EmailAddress = warehouse.Address.Email,
                ZipCode = warehouse.Address.ZipCode,
                Image = _mediaService.GetMediaUrl(warehouse.Media)
            };

            return View(this.GetViewPath(), model);
        }
    }
}

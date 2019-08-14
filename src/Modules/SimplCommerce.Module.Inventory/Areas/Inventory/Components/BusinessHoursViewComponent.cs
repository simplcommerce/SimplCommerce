using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Infrastructure.Models;
using SimplCommerce.Infrastructure.Web;
using SimplCommerce.Module.Core.Areas.Core.ViewModels;
using SimplCommerce.Module.Core.Services;
using SimplCommerce.Module.Inventory.Areas.Inventory.ViewModels;
using SimplCommerce.Module.Inventory.Models;

namespace SimplCommerce.Module.Cms.Areas.Inventory.Components
{
    public class BusinessHoursViewComponent : ViewComponent
    {
        private readonly IRepository<Warehouse> _warehouseRepository;

        public BusinessHoursViewComponent(IMediaService mediaService,
            IRepository<Warehouse> warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public IViewComponentResult Invoke(long warehouseId)
        {
            var warehouse = _warehouseRepository.Query().Include(x => x.Address)
                .FirstOrDefault(x => x.Id == warehouseId);

            if (warehouse == null)
            {
                throw new System.Exception();
            }


            var model = new BusinessHoursViewComponentVm
            {
                Name = warehouse.Name,
                EmailAddress = warehouse.Address.Email,
                PhoneNumber = warehouse.Address.Phone,
                BusinessHourItems = GetBusinessHours(warehouse).ToList()
            };

            return View(this.GetViewPath(), model);
        }

        private IEnumerable<BusinessHourItemViewComponentVm> GetBusinessHours(Warehouse warehouse)
        {
            var list = warehouse.GetData<List<BusinessHourItemViewComponentVm>>("BusinessHours");

            for (int i = 1; i < 8; i++)
            {
                DayOfWeek dayOfWeek = (DayOfWeek)(i % 7);
                var businessHour = list.FirstOrDefault(bh => bh.Day == dayOfWeek);

                if (businessHour == null)
                {
                    businessHour = new BusinessHourItemViewComponentVm { Day = dayOfWeek };
                }

                yield return businessHour;
            }

        }
    }
}

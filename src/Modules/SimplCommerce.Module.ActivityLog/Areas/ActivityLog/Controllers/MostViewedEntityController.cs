using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimplCommerce.Module.ActivityLog.Data;
using SimplCommerce.Module.ActivityLog.Models;

namespace SimplCommerce.Module.ActivityLog.Controllers
{
    [Area("ActivityLog")]
    [Authorize(Roles = "admin")]
    [Route("api/activitylog")]
    public class MostViewedEntityController : Controller
    {
        private readonly IActivityTypeRepository _activityTypeRepository;

        public MostViewedEntityController(IActivityTypeRepository activityTypeRepository)
        {
            _activityTypeRepository = activityTypeRepository;
        }

        [HttpGet("most-viewed-entities/{entityTypeId}")]
        public async Task<IList<MostViewEntityDto>> GetMostViewedEntities(string entityTypeId)
        {
            return await _activityTypeRepository.List().Where(x => x.EntityTypeId == entityTypeId).Take(10).ToListAsync();
        }
    }
}

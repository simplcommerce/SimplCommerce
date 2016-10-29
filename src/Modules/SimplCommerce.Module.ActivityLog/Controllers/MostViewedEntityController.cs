using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Module.ActivityLog.Data;
using SimplCommerce.Module.ActivityLog.Models;

namespace SimplCommerce.Module.ActivityLog.Controllers
{
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
        public IList<MostViewEntityDto> GetMostViewedEntities(long entityTypeId)
        {
            return _activityTypeRepository.List().Where(x => x.EntityTypeId == entityTypeId).Take(10).ToList();
        }
    }
}

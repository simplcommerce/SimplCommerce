using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SimplCommerce.Module.RecentlyViewedProducts.Data;
using SimplCommerce.Module.RecentlyViewedProducts.Models;

namespace SimplCommerce.Module.RecentlyViewedProducts.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/recentlyviewedproducts")]
    public class RecentlyViewedEntityController : Controller
    {
        private readonly IActivityTypeRepository _activityTypeRepository;

        public RecentlyViewedEntityController(IActivityTypeRepository activityTypeRepository)
        {
            _activityTypeRepository = activityTypeRepository;
        }

        [HttpGet("recently-viewed-entities/{entityTypeId}")]
        public IList<RecentViewEntityDto> GetRecentlyViewedEntities(long entityTypeId)
        {
            return _activityTypeRepository.List().Where(x => x.EntityTypeId == entityTypeId).Take(10).ToList();
        }
    }
}

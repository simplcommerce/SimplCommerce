using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Core.Models;

namespace SimplCommerce.Module.Core.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/entities")]
    public class EntityApiController : Controller
    {
        private IRepository<Entity> _entityRepository;

        public EntityApiController(IRepository<Entity> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public IActionResult Get(string entityTypeId, string name)
        {
            var query = _entityRepository.Query().Where(x => x.EntityType.IsMenuable);
            if (!string.IsNullOrWhiteSpace(entityTypeId))
            {
                query = query.Where(x => x.EntityTypeId == entityTypeId);
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                query = query.Where(x => x.Name.Contains(name));
            }

            var entities = query.Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                EntityTypeId = x.EntityTypeId,
                EntityTypeName = x.EntityType.Name
            });

            return Ok(entities);
        }
    }
}

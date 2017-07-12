using System.Linq;
using SimplCommerce.Module.Core.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.RecentlyViewedProducts.Models;

namespace SimplCommerce.Module.RecentlyViewedProducts.Data
{
    public class ActivityRepository : Repository<Activity>, IActivityTypeRepository
    {
        private const int RecentViewActivityTypeId = 1;

        public ActivityRepository(SimplDbContext context) : base(context)
        {
        }

        public IQueryable<RecentViewEntityDto> List()
        {
            return from a in DbSet
                join e in Context.Set<Entity>() on new { a.EntityId, a.EntityTypeId } equals new { e.EntityId, e.EntityTypeId }
                where a.ActivityTypeId == RecentViewActivityTypeId
                   group a by new { a.EntityId, a.EntityTypeId, e.Name, e.Slug }
                into g
                orderby g.Count() descending
                select new RecentViewEntityDto
                {
                    EntityTypeId = g.Key.EntityTypeId,
                    EntityId = g.Key.EntityId,
                    Name = g.Key.Name,
                    Slug = g.Key.Slug,
                    ViewedCount = g.Count()
                };
        }
    }
}

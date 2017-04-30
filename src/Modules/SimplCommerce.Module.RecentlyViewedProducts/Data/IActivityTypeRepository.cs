using System.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.RecentlyViewedProducts.Models;

namespace SimplCommerce.Module.RecentlyViewedProducts.Data
{
    public interface IActivityTypeRepository : IRepository<Activity>
    {
        IQueryable<RecentViewEntityDto> List();
    }
}

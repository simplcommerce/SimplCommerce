using System.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.ActivityLog.Models;

namespace SimplCommerce.Module.ActivityLog.Data
{
    public interface IActivityTypeRepository : IRepository<Activity>
    {
        IQueryable<MostViewEntityDto> List();
    }
}

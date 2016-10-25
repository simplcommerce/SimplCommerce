using System.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Reviews.Models;

namespace SimplCommerce.Module.Reviews.Data
{
    public interface IReviewRepository : IRepository<Review>
    {
        IQueryable<ReviewListItemDto> List();
    }
}
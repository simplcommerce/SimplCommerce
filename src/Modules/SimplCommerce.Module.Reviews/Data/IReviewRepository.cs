using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Reviews.Models;
using System.Linq;

namespace SimplCommerce.Module.Reviews.Data
{
    public interface IReviewRepository : IRepository<Review>
    {
        IQueryable<ReviewListItemDto> List();
    }
}
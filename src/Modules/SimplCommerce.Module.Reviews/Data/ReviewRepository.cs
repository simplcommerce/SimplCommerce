using System.Linq;
using SimplCommerce.Module.Core.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Reviews.Models;

namespace SimplCommerce.Module.Reviews.Data
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        public ReviewRepository(SimplDbContext context) : base(context)
        {
        }

        public IQueryable<ReviewListItemDto> List()
        {
            var items = DbSet.Join(Context.Set<UrlSlug>(),
                r => new {key1 = r.EntityId, key2 = r.EntityTypeId},
                u => new {key1 = u.EntityId, key2 = u.EntityTypeId},
                (r, u) => new ReviewListItemDto
                {
                    EntityTypeId = r.EntityTypeId,
                    Id = r.Id,
                    ReviewerName = r.ReviewerName,
                    Rating = r.Rating,
                    Title = r.Title,
                    Comment = r.Comment,
                    Status = r.Status,
                    CreatedOn = r.CreatedOn,
                    EntityName = u.Slug
                });

            return items;
        }
    }
}
using System.Linq;
using SimplCommerce.Module.Core.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Comments.Models;

namespace SimplCommerce.Module.Comments.Data
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(SimplDbContext context) : base(context)
        {
        }

        public IQueryable<CommentListItemDto> List()
        {
            var items = DbSet.Join(Context.Set<Entity>(),
                r => new { key1 = r.EntityId, key2 = r.EntityTypeId },
                u => new { key1 = u.EntityId, key2 = u.EntityTypeId },
                (r, u) => new CommentListItemDto
                {
                    EntityTypeId = r.EntityTypeId,
                    Id = r.Id,
                    CommenterName = r.CommenterName,
                    CommentText = r.CommentText,
                    Status = r.Status,
                    CreatedOn = r.CreatedOn,
                    ParentId = r.ParentId,
                    EntityName = u.Name,
                    EntitySlug = u.Slug
                });

            return items;
        }
    }
}
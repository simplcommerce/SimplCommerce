using SimplCommerce.Module.Core.Data;
using SimplCommerce.Module.Core.Models;
using SimplCommerce.Module.Comments.Models;
using System.Linq;

namespace SimplCommerce.Module.Comments.Data
{
    public class ReplyRepository : Repository<Reply>, IReplyRepository
    {
        public ReplyRepository(SimplDbContext context) : base(context)
        {
        }

        public IQueryable<ReplyListItemDto> List()
        {
            var items = from rv in Context.Set<Comment>()
                         join e in Context.Set<Entity>()
                         on new { key1 = rv.EntityId, key2 = rv.EntityTypeId } equals new { key1 = e.EntityId, key2 = e.EntityTypeId }
                         join rp in Context.Set<Reply>()
                         on rv.Id equals rp.CommentId
                         select new ReplyListItemDto
                         {
                             Id = rp.Id,
                             ReplierName = rp.ReplierName,
                             Comment = rp.CommentText,
                             Status = rp.Status,
                             CreatedOn = rp.CreatedOn,
                             EntityName = e.Name,
                             EntitySlug = e.Slug
                         };

            return items;
        }
    }
}

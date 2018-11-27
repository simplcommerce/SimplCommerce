using System.Linq;
using SimplCommerce.Infrastructure.Data;
using SimplCommerce.Module.Comments.Models;

namespace SimplCommerce.Module.Comments.Data
{
    public interface ICommentRepository : IRepository<Comment>
    {
        IQueryable<CommentListItemDto> List();
    }
}